using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Write a New Department Name");

            var newDepartmentName = Console.ReadLine();

            repo.InsertDepartment(newDepartmentName);

            var departement = repo.GetAllDepartments();

            foreach (var dept in departement)
            {
                Console.WriteLine(dept.Name);
            }

            var productRepo = new DapperProductRepository(conn);

            var products = productRepo.GetAllProducts();

            foreach(var product in products)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine("Let's Make a new product!");
            Console.WriteLine("What's your product's name?" );
            string newProduct = Console.ReadLine();

            Console.WriteLine("What's the products category?");
            int newCategoryID = int.Parse(Console.ReadLine());

            Console.WriteLine("And how much is it? ");

            double newPrice = double.Parse(Console.ReadLine());

            productRepo.CreateProduct(newProduct, newPrice, newCategoryID);

            Console.WriteLine("Let's update a price!");

            Console.WriteLine("What is the product id that needs to be updated?");

            int productToBeUpdated = int.Parse(Console.ReadLine());

            Console.WriteLine("What's the new name of this product?");

            string productNameToBeUpdated = Console.ReadLine();

            Console.WriteLine("And What is the new price?");

            double updatedPriceProd = double.Parse(Console.ReadLine());


        }
    }
}
