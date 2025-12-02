using System;
using DatabaseConnectors;
using MongoDBConnector;
using PostgresConnectorLib;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Database Connector REPL ===");

        while (true)
        {
            Console.WriteLine("\nChoose a DB Type:");
            Console.WriteLine("1. MongoDB");
            Console.WriteLine("2. PostgreSQL");
            Console.WriteLine("3. Exit");
            Console.Write("> ");

            var choice = Console.ReadLine();

            if (choice == "3") break;

            Console.Write("Enter connection string: ");
            var connectionString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("Connection string cannot be empty. Try again.");
                continue;
            }

            IDBConnector? connector = choice switch
            {
                "1" => new MongoDBConnector.MongoDBConnector(connectionString),
                "2" => new PostgresConnectorLib.PostgresConnector(connectionString),
                _ => null
            };



            if (connector == null)
            {
                Console.WriteLine("Invalid selection.");
                continue;
            }

            Console.WriteLine("\nPinging database...");
            bool result = connector.Ping();

            Console.WriteLine(result
                ? "✔ SUCCESS — Database responded!"
                : "✘ FAILED — Database unreachable.");
        }
    }
}