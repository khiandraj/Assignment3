using Xunit; 



namespace PostgresConnector.Tests;


public class PostgresConnectorTest
{

    [Fact]
    public void Ping_ShouldReturnTrue_WhenMongoIsRunning()
    {
        var connector = new PostgresConnector();
        Assert.True(connector.Ping()); 
    }

    [Fact]
    public void Ping_ShouldReturnFalse_WhenMongoIsNotAvailable()
    {
        var connector = new PostgresConnector();
        Assert.False(connector.Ping())
    }

}