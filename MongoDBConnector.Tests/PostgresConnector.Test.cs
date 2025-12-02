using Xunit;
using Testcontainers.PostgreSql;
using ConnectorLib = MongoDBConnector.PostgresConnector;

namespace PostgresConnector.Tests
{
    public class PostgresConnectorTest : IAsyncLifetime
    {
        private readonly PostgreSqlContainer _postgresContainer;

        public PostgresConnectorTest()
        {
            _postgresContainer = new PostgreSqlBuilder().Build();
        }

        public async Task InitializeAsync() => await _postgresContainer.StartAsync();
        public async Task DisposeAsync() => await _postgresContainer.DisposeAsync();

        [Fact]
        public void Ping_ShouldReturnTrue_WhenPostgresIsRunning()
        {
            var connector = new ConnectorLib(_postgresContainer.GetConnectionString());
            Assert.True(connector.Ping());
        }

        [Fact]
        public void Ping_ShouldReturnFalse_WhenPostgresIsNotRunning()
        {
            var connector = new ConnectorLib("Host=invalid;Username=postgres;Password=postgres;Database=test");
            Assert.False(connector.Ping());
        }
    }
}