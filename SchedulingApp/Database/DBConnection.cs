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
    public class DBConnection
    {
        public static MySqlConnection conn { get; set; }

        public static void StartConnection()
        {
           string connStr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

            try
            {
                //intialize connection
                conn = new MySqlConnection(connStr);
                //open connection
                conn.Open();

                MessageBox.Show("Connection is open");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public static void CloseConnection()
        {
            conn.Close();

        }
    }
}
