using MySql.Data.MySqlClient;
using SchedulingApp.Database;
using SchedulingApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;

public static class CityRepo
{
    public static int AddCity(City city)
    {
        var connection = DBConnection.GetConnection();
        string query = "INSERT INTO city (city, countryID, createDate, createdBy, lastUpdateBy) " +
                       "VALUES (@city, @countryID, @createDate, @createdBy, @lastUpdateBy)";
        int lastInsertedId;
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@city", city.CityName);
            cmd.Parameters.AddWithValue("@countryID", city.CountryID);
            cmd.Parameters.AddWithValue("@createDate", city.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", city.CreatedBy);
            cmd.Parameters.AddWithValue("@lastUpdateBy", city.LastUpdatedBy);
            cmd.ExecuteNonQuery();

            lastInsertedId = (int)cmd.LastInsertedId;
        }
 
        return lastInsertedId;
    }

    public static int GetOrAddCity(string cityName, int countryID)
    {
        var connection = DBConnection.GetConnection();
        string query = "SELECT cityID FROM city WHERE city = @cityName AND countryID = @countryID";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@cityName", cityName);
            cmd.Parameters.AddWithValue("@countryID", countryID);
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result); 
            }
        }

       
        var newCity = new City(0, cityName, countryID, DateTime.Now, "admin", DateTime.Now, "admin");
      
        DBConnection.CloseConnection();
        return AddCity(newCity);

    }

    public static List<City> GetAllCities()
    {
        var cities = new List<City>();
        using (var conn = DBConnection.GetConnection())
        {
            string query = "SELECT city FROM city";
            using (var cmd = new MySqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cities.Add(new City { CityName = reader.GetString("city") });
                }
            }
        }
        return cities;
    }


}
