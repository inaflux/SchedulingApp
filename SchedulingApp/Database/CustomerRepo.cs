using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;
using SchedulingApp.Models;


namespace SchedulingApp.Database
{
    public static class CustomerRepo
    {
        




        public static void AddCustomer(Customer customer)
        {
            var connection = DBConnection.GetConnection();
          
                string query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy) " +
                               "VALUES (@customerName, @addressId, @active, @createDate, @createdBy, @lastUpdateBy)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@customerName", customer.CustomerName);
                    cmd.Parameters.AddWithValue("@addressId", customer.AddressID);
                    cmd.Parameters.AddWithValue("@active", customer.Active);
                    cmd.Parameters.AddWithValue("@createDate", customer.CreateDate);
                    cmd.Parameters.AddWithValue("@createdBy", customer.CreatedBy);
                    cmd.Parameters.AddWithValue("@lastUpdateBy", customer.LastUpdatedBy);

                    cmd.ExecuteNonQuery();
                }
            
        }

   
        public static void UpdateCustomer(Customer customer)
        {
            var connection = DBConnection.GetConnection();
            string query = "UPDATE customer SET customerName = @customerName, addressID = @addressID, active = @active, " +
                           "lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy WHERE customerID = @customerID";

            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@customerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@customerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@addressID", customer.AddressID);
                cmd.Parameters.AddWithValue("@active", customer.Active);
                cmd.Parameters.AddWithValue("@lastUpdate", customer.LastUpdate);
                cmd.Parameters.AddWithValue("@lastUpdateBy", customer.LastUpdatedBy);

                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteCustomer(int customerId)
        {
            var connection = DBConnection.GetConnection();
            
                string query = "DELETE FROM customer WHERE customerId = @customerId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.ExecuteNonQuery();
                }
            
        }

        public static List<Customer> GetCustomerName()
        {
            var customers = new List<Customer>();
            var connection = DBConnection.GetConnection();

            string query = "SELECT customerID, customerName FROM customer";
            using (var cmd = new MySqlCommand(query, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerID = reader.GetInt32("customerID"),
                            CustomerName = reader.GetString("customerName")
                        });
                    }
                }
            }

            return customers;
        }



    }
}
