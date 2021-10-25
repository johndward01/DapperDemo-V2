using System;
using System.Collections.Generic;
using System.Text;

namespace DapperDemo_V2
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string name, double price, int categoryID);
    }
}
