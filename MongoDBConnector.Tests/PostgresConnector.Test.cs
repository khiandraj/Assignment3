using Testcontainers.PostgreSql;
using Xunit;

namespace PostgresConnector.Test;

public class PostgresConnectorTest : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresDbContainer;

    public PostgresConnectorTest()
    {
        _postgresDbContainer = new PostgreSqlBuilder()
            .WithDatabase("testdb")
            .WithCleanUp(true)
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _postgresDbContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _postgresDbContainer.DisposeAsync();
    }

    [Fact]
    public async Task Should_Ping_Db_Successfully()
    {
        // Given
        IDBConnector connector = new MongoDBConnector.PostgresConnector(_postgresDbContainer.GetConnectionString());

        // When
        bool pingResult = await connector.Ping();

        // Then
        Assert.True(pingResult);
    }

    [Fact]
    public async Task Should_Fail_With_Missing_Connection_String()
    {
        // Given
        var connector = new MongoConnector.PostgresConnector("");

        // When
        bool pingResult = await connector.Ping();

        // Then
        Assert.False(pingResult);
    }
}
