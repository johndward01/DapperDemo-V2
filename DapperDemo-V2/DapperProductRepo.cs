using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperDemo_V2
{
    public class DapperProductRepo : IProductRepo
    {
        private readonly IDbConnection _conn;

        public DapperProductRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);", 
                new {name = name, price = price, categoryID = categoryID });
        }
    }
}
