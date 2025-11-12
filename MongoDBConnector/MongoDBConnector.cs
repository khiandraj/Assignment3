using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDBConnector;

///Implementing the interface on the MongoConnector 
public class MongoDBConnector : IDBConnector
{
    private readonly MongoClient _client; 

    public MongoDBConnector (string connectionString)
    {
        _client = new MongoClient(connectionString); 
    }

    public bool Ping()
    {
        try
        {
            var database = _client.GetDatabase("admin");
            var command = new BsonDocument("ping", 1);
            database.RunCommand<BsonDocument>(command);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
