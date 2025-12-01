namespace MongoDBConnector;

public interface IDBConnector
{
    public Task<bool> ping();
}

