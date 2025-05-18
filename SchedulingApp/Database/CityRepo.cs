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
        Console.WriteLine("Executing query: " + query);

        // Return the LastInsertedId after the using block
        return lastInsertedId;
    }

    public static City GetCityById(int cityId)
    {
        var connection = DBConnection.GetConnection();
        string query = "SELECT * FROM city WHERE cityID = @cityID";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@cityID", cityId);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new City(
                        reader.GetInt32("cityID"),
                        reader.GetString("city"),
                        reader.GetInt32("countryID"),
                        reader.GetDateTime("createDate"),
                        reader.GetString("createdBy"),
                        reader.GetDateTime("lastUpdate"),
                        reader.GetString("lastUpdateBy")
                    );
                }
            }
        }
        Console.WriteLine("Executing query: " + query);

        return null;
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
                return Convert.ToInt32(result); // City exists, return its ID
            }
        }

        // City does not exist, insert it
        var newCity = new City(0, cityName, countryID, DateTime.Now, "admin", DateTime.Now, "admin");
        Console.WriteLine("Executing query: " + query);

        DBConnection.CloseConnection();
        return AddCity(newCity);

    }

    public static List<City> GetAllCities()
    {
        var cities = new List<City>();
        var connection = DBConnection.GetConnection();

        string query = "SELECT * FROM city";
        using (var cmd = new MySqlCommand(query, connection))
            
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cities.Add(new City
                    {
                        CityID = reader.GetInt32("cityId"),
                        CityName = reader.GetString("city"),
                        // Add other fields as needed
                    });
                }
            }
        
        return cities;
    }


}
