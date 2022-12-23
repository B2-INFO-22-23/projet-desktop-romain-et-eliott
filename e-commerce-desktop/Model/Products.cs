using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace e_commerce_desktop.Model
{
    internal class Products
    {

        public List<Product> GetProducts(MySqlConnection connection)
        {
            MySqlConnection newConnection = connection.Clone();
            newConnection.Open();
            List<Product> products = new List<Product>();
            using var command = newConnection.CreateCommand();
            command.CommandText = @"SELECT * FROM products";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new();
                product.ProductId = (int)reader.GetValue(0);
                product.ProductName = (string)reader.GetValue(1);
                product.Price = (float)reader.GetValue(2);
                product.Quantity = (int)reader.GetValue(3);
                product.Publishers = (string)reader.GetValue(4);
                product.CategoryId = (int)reader.GetValue(5);
                product.CreationDate = (string)reader.GetValue(6);
                product.Description = (string)reader.GetValue(7);

                products.Add(product);
            }
            return products;
        }

        public Product GetProductById(int id, MySqlConnection connection)
        {
            MySqlConnection newConnection = connection.Clone();
            newConnection.Open();
            Product product = new Product();
            using var command = newConnection.CreateCommand();
            command.CommandText = @"SELECT * FROM products WHERE ProductId=" + id + ";";
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                product.ProductId = (int)reader.GetValue(0);
                product.ProductName = (string)reader.GetValue(1);
                product.Price = (float)reader.GetValue(2);
                product.Quantity = (int)reader.GetValue(3);
                product.Publishers = (string)reader.GetValue(4);
                product.CategoryId = (int)reader.GetValue(5);
                product.CreationDate = (string)reader.GetValue(6);
                product.Description = (string)reader.GetValue(7);
            };
            return product;
        }

        public void AddProduct(MySqlConnection connection, string ProductName, float Price, int Quantity, string Publishers,int CategoryId, string Description)
        {
            MySqlConnection newConnection = connection.Clone();
            newConnection.Open();
            using var command = newConnection.CreateCommand();

            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            command.CommandText = "INSERT INTO products (ProductName, Price, Quantity, Publishers, CategoryId, CreationDate, Description) VALUE (@ProductName, @Price, @Quantity, @Publishers,@CategoryId, @CreationDate, @Description)";
            command.Parameters.AddWithValue("@ProductName", ProductName);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@Publishers", Publishers);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@CategoryId", CategoryId);
            command.Parameters.AddWithValue("@CreationDate", date);
            command.ExecuteNonQuery();
        }

        public void UpdateProduct(MySqlConnection connection, int id, string ProductName, float Price, int Quantity, string Publishers, int CategoryId, string Description)
        {
            MySqlConnection newConnection = connection.Clone();
            newConnection.Open();
            using var command = newConnection.CreateCommand();


            command.CommandText = @"UPDATE products SET ProductName=@ProductName, Price=@Price, Quantity=@Quantity, Publishers=@Publishers, CategoryId=@CategoryId, Description=@Description WHERE ProductId=@id;";

            command.Parameters.AddWithValue("@ProductName", ProductName);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Quantity", Quantity);
            command.Parameters.AddWithValue("@Publishers", Publishers);
            command.Parameters.AddWithValue("@CategoryId", CategoryId);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@id", id);
            Console.WriteLine(command.ToString());
            command.ExecuteNonQuery();
        }


        public void DeleteProduct(MySqlConnection connection, int id)
        {
            MySqlConnection newConnection = connection.Clone();
            newConnection.Open();
            using var command = newConnection.CreateCommand();
            command.CommandText = @"SET FOREIGN_KEY_CHECKS=0;
DELETE FROM products WHERE ProductId=" + id + ";" +
"SET FOREIGN_KEY_CHECKS=1;";

            command.ExecuteNonQuery();
        }

    }
}