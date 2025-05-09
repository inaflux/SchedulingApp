using MySql.Data.MySqlClient;
using SchedulingApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchedulingApp.CustomerRecords
{
    public  class CustomerDetails
    {
        public  int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public  string Address { get; set; }
        public string Phone { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    
        
        public static List<CustomerDetails> GetCustomerDetails() //gets specific customer details from the database
        {
            var connection = DBConnection.GetConnection();
            var customerRecords = new List<CustomerDetails>();
            string query = @"SELECT customer.customerID, customer.customerName, address.address, address.phone, city.city, country.country" +
                "FROM customer" +
                "JOIN address ON customer.addressID = address.addressID" +
                "JOIN city ON address.cityID = city.cityID" +
                "JOIN country ON city.countryID = country.countryID";

            using (var cmd = new MySqlCommand(query, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        customerRecords.Add(new CustomerDetails
                        {
                            CustomerID = reader.GetInt32("customerID"),
                            CustomerName = reader.GetString("customerName"),
                            Address = reader.GetString("address"),
                            Phone = reader.GetString("phone"),
                            City = reader.GetString("city"),
                            Country = reader.GetString("country")
                        });
                    }
                }

            }
            return customerRecords;




        }
    }
}

