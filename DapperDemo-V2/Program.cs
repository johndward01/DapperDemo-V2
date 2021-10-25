using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace DapperDemo_V2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperProductRepo(conn);


            repo.CreateProduct("Test Computer", 1000.99, 1);
            var products = repo.GetAllProducts();

            foreach (var p in products)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Price);
                Console.WriteLine(p.CategoryID);
                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
