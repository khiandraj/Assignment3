using Xunit;
using Testcontainers.MongoDb;
using ConnectorLib = MongoDBConnector.MongoDBConnector;

namespace MongoDBConnector.Tests;

    public class MongoDBConnectorTest : IAsyncLifetime
    {
        private readonly MongoDbContainer _mongoDbContainer;

        public MongoDBConnectorTest()
        {
            _mongoDbContainer = new MongoDbBuilder().Build();
        }

        public async Task InitializeAsync() => await _mongoDbContainer.StartAsync();
        public async Task DisposeAsync() => await _mongoDbContainer.DisposeAsync();

        [Fact]
        public void Ping_ShouldReturnTrue_WhenMongoDBIsRunning()
        {
            var connector = new ConnectorLib(_mongoDbContainer.GetConnectionString());
            Assert.True(connector.Ping());
        }

        [Fact]
        public void Ping_ShouldReturnFalse_WhenMongoDBIsNotRunning()
        {
            var connector = new ConnectorLib("mongodb://invalid:27017");
            Assert.False(connector.Ping());
        }
    }




