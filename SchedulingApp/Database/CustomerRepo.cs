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
        


        // Retrieve all customers
        public static Dictionary<int, Customer> GetAllCustomers()
        {
            var customers = new Dictionary<int, Customer>();
            var connection =  DBConnection.GetConnection();
          
                string query = "SELECT * FROM customer";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           var customer = new Customer(
                                reader.GetInt32("customerId"),
                                reader.GetString("customerName"),
                                reader.GetInt32("addressId"),
                                reader.GetBoolean(reader.GetInt32("active")),
                                reader.GetDateTime("createDate"),
                                reader.GetString("createdBy"),
                                reader.GetDateTime("lastUpdate"),
                                reader.GetString("lastUpdateBy")
                            );

                        customers.Add(customer.CustomerID, customer);
                    }
                    }
                }
            

            return customers;
        }

        // Add a new customer
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

        // Update an existing customer
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

        // Delete a customer
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

        // Retrieve a customer by ID
        public static  Customer GetCustomerById(int customerId)
        {
            var connection = DBConnection.GetConnection();
            
                string query = "SELECT * FROM customer WHERE customerId = @customerId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer(
                                reader.GetInt32("customerId"),
                                reader.GetString("customerName"),
                                reader.GetInt32("addressId"),
                                reader.GetBoolean("active"),
                                reader.GetDateTime("createDate"),
                                reader.GetString("createdBy"),
                                reader.GetDateTime("lastUpdate"),
                                reader.GetString("lastUpdateBy")
                            );
                        }
                    }
                }
            

            return null;

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
