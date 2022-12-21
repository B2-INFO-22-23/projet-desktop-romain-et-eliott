using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_desktop.Model
{
    internal class ConnectionDAO
    {

        public MySqlConnection? connection;

        // set these values correctly for your database server
        

        public MySqlConnection? Connect(string server, string userId, string password, string database)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = server,
                UserID = userId,
                Password = password,
                Database = database,
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            
            this.connection = connection;

            //tests
            /*using var command = this.connection.CreateCommand();
            command.CommandText = @"SELECT * FROM products";
            MySqlDataReader reader = command.ExecuteReader();
            List<Product> productsList = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product();

                //var id = reader.GetValue(0);
                product.ProductId = (int)reader.GetValue(0);
                product.ProductName = (string)reader.GetValue(1);
                product.Price = (float)reader.GetValue(2);
                product.Quantity = (int)reader.GetValue(3);
                product.Publishers = (string)reader.GetValue(4);
                product.CategoryId= (int)reader.GetValue(5);
                product.CreationDate= (string)reader.GetValue(6);
                product.Description= (string)reader.GetValue(7);
                
                productsList.Add(product);
            }
            Console.WriteLine(productsList.ToArray());*/
            
            return connection.Clone();
        }
    }


}
