using System;
using Npgsql;


namespace MongoDBConnector
{
    public class PostgresConnector : IDBConnector
    {
        private readonly string _connectionString;

        public PostgresConnector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Ping()
        {
            try
            {
                using var connection = new NpgsqlConnection(_connectionString);
                connection.Open();

                using var cmd = new NpgsqlCommand("SELECT 1", connection);
                var result = cmd.ExecuteScalar();

                return result != null && Convert.ToInt32(result) == 1;
            }
            catch
            {
                return false;
            }
        }
    }
}