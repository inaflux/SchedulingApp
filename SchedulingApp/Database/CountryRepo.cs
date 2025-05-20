using MySql.Data.MySqlClient;
using SchedulingApp.Database;
using SchedulingApp.Models;
using System;

public static class CountryRepo
{
    public static int AddCountry(Country country)
    {
        var connection = DBConnection.GetConnection();
        string query = "INSERT INTO country (country, createDate, createdBy, lastUpdateBy) " +
                       "VALUES (@country, @createDate, @createdBy, @lastUpdateBy)";
        int lastInsertedId;
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@country", country.CountryName);
            cmd.Parameters.AddWithValue("@createDate", country.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", country.CreatedBy);
            cmd.Parameters.AddWithValue("@lastUpdateBy", country.LastUpdatedBy);
            cmd.ExecuteNonQuery();
            lastInsertedId = (int)cmd.LastInsertedId;
        }
       
        
        return lastInsertedId;
    }

  
    public static int GetOrAddCountry(string countryName)
    {
        var connection = DBConnection.GetConnection();
        string query = "SELECT countryID FROM country WHERE country = @countryName";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@countryName", countryName);
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result); 
            }
        }

        // if country does not exist, add it
        var newCountry = new Country(0, countryName, DateTime.Now, "admin", DateTime.Now, "admin");
        Console.WriteLine("Executing query: " + query);

        return AddCountry(newCountry);
    }
}
