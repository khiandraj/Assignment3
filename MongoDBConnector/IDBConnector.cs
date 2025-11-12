namespace IDBConnector;

///Create the interface called IDBConnector

public interface IDBConnector 
    {
        ///Declaring the ping method for the interface
        bool Ping();
    }

///Create a Postgres Connector class that implements the IDBConnector interface
public class PostgresConnector : IDBConnector
    {
        private readonly string _connectionString;
        
        public PostgresConnector (string connectionString)
        {
            _connectionString = connectionString; 
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

