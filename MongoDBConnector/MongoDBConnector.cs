using System;
using MongoDB.Bson;
using MongoDB.Driver;


namespace MongoDBConnector
{
    public class MongoDBConnector : IDBConnector
    {
        private readonly MongoClient _client;

        public MongoDBConnector(string connectionString)
        {
            _client = new MongoClient(connectionString);
        }

        public bool Ping() {
            try
            {
                var database = _client.GetDatabase("admin");
                var command = new BsonDocument("ping", 1);
                var result = database.RunCommand<BsonDocument>(command);
            if (result != null && result.Contains("ok"))
            {
                // Convert ok value safely to numeric
                var okValue = result["ok"];
                double okNumeric = okValue.IsDouble ? okValue.AsDouble :
                                   okValue.IsInt32 ? okValue.AsInt32 :
                                   okValue.IsInt64 ? okValue.AsInt64 : 0.0;
                return Math.Abs(okNumeric - 1.0) < 1e-6;
            }

            return false;


            }
            catch
            {
                return false;
            }
    }
}

    
}

