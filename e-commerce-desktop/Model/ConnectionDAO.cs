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
            
            this.connection = connection.Clone();
            
            return connection.Clone();
        }
    }


}
