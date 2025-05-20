using MySql.Data.MySqlClient;
using SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp.Database
{
    public static class UserRepo
    {
       


        public static List<User> GetUserID()
        {
            var users = new List<User>();
            var connection = DBConnection.GetConnection();
            string query = "SELECT userId, userName FROM user";
            using (var cmd = new MySqlCommand(query, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserID = reader.GetInt32("userId"),
                            UserName = reader.GetString("userName")
                        });
                    }
                }
            }
            return users;
        }
    }
}
