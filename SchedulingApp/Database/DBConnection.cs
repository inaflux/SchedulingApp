using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;

namespace SchedulingApp.Database
{
    public static class DBConnection
    {
        private static MySqlConnection _connection;

        public static string ConnectionString => ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

        public static void StartConnection()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = new MySqlConnection(ConnectionString);
                    _connection.Open();
                }
                else if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            catch (MySqlException ex)
            {
             
                throw new Exception("Failed to open database connection.", ex);
            
            }
        }

        public static void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection = null;
            }
        }

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
