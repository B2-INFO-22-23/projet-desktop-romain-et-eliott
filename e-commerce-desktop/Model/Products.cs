using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace e_commerce_desktop.Model
{
    internal class Products
    {
        public List<Product> products;


        public List<Product> GetProducts(MySqlConnection connection)
        {
            List<Product> productsList = new List<Product>();
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM products";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader.GetValue(0);
                product.ProductName = (string)reader.GetValue(1);
                product.Price = (float)reader.GetValue(2);
                product.Quantity = (int)reader.GetValue(3);
                product.Publishers = (string)reader.GetValue(4);
                product.CategoryId = (int)reader.GetValue(5);
                product.CreationDate = (string)reader.GetValue(6);
                product.Description = (string)reader.GetValue(7);

                productsList.Add(product);
            }
            this.products = productsList;
            return productsList;
        }
    }
}
