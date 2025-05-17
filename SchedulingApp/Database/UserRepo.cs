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
        //Add user to database

        public static void AddUser(User user)
        {
            var connection = DBConnection.GetConnection();
            string query = "INSERT INTO USER (userName, password, createDate, createdBy, lastUpdateBy) " +
                           "VALUES (@userName, @password, @createDate, @createdBy, @lastUpdateBy)";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@userName", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@createDate", user.CreateDate);
                cmd.Parameters.AddWithValue("@createdBy", user.CreatedBy);
                cmd.Parameters.AddWithValue("@lastUpdateBy", user.LastUpdatedBy);
                cmd.ExecuteNonQuery();
                

            }
            Console.WriteLine("Executing query: " + query);


        }

        //Get all users from database
        public static void UpdateUser(User user)
        {
            var connection = DBConnection.GetConnection();
            string query = "UPDATE USER SET userName = @userName, password = @password, lastUpdateBy = @lastUpdateBy WHERE userId = @userId";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@userId", user.UserID);
                cmd.Parameters.AddWithValue("@userName", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@lastUpdateBy", user.LastUpdatedBy);
                cmd.ExecuteNonQuery();

            }
            Console.WriteLine("Executing query: " + query);

        }

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
