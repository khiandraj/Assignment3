using Testcontainers.MongoDb;


namespace MongoDBConnector.Tests;

public class MongoDBConnectorTests : IAsyncLifetime
{
    private readonly MongoDbContainer _mongoContainer;

    public MongoDBConnectorTests()
    {
        _mongoContainer = new MongoDbBuilder()
            .WithImage("mongo:7.0")
            .WithCleanUp(true)
            .Build();
    }

    public async Task InitializeAsync()
    {
        await _mongoContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _mongoContainer.DisposeAsync();
    }

    [Fact]
    public async Task should_ping_db_successfully()
    {
        // Given
        IDBConnector connector = new DBConnector.MongoConnector(_mongoContainer.GetConnectionString());

        // When
        bool ping_result = await connector.ping();

        // Then
        Assert.True(ping_result);
    }
    

    [Fact]
    public async Task should_fail_missing_db()
    {
    // Given
        var connector = new DBConnector.MongoConnector("");

        // When
        bool ping_result = await connector.ping();

        // Then
        Assert.False(ping_result);

    }
}



