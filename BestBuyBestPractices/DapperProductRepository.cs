using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void CreateProduct(string newProductName, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, price, categoryID) VALUES (@name, @price, @categoryID);",
            new { name = newProductName, price = price, categoryID = categoryID});
        }

        public void UpdateProduct(string updatedName, double updatedPrice, int productID)
        {
            _connection.Execute("UPDATE Products SET Price = (@price), Name = (@name) WHERE ProductID = (@productID);",
            new { name = updatedName, price = updatedPrice, productID = productID});
        }
    }
}
