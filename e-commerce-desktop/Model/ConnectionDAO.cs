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
        // set these values correctly for your database server
        public async Task ConnectAsync()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "",
                Database = "e-commerce",
            };

            using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();
            
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM products;";

            using var reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                var id = reader.GetInt32("ProductId");
                //var date = reader.GetDateTime("order_date");
                Console.WriteLine(id);
                // ...
            }



        }
    }
    
}
