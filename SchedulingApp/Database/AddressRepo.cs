using MySql.Data.MySqlClient;
using SchedulingApp.Database;
using SchedulingApp.Models;
using System;

public static class AddressRepo
{
    public static int AddAddress(Address address)
    {
        var connection = DBConnection.GetConnection();
        string query = "INSERT INTO address (address, address2, cityID, postalCode, phone, createDate, createdBy, lastUpdateBy) " +
                       "VALUES (@address, @address2, @cityID, @postalCode, @phone, @createDate, @createdBy, @lastUpdateBy)";
        int lastInsertedId;
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@address", address.AddressName);
            cmd.Parameters.AddWithValue("@address2", address.AddressTwo);
            cmd.Parameters.AddWithValue("@cityID", address.CityID);
            cmd.Parameters.AddWithValue("@postalCode", address.PostalCode);
            cmd.Parameters.AddWithValue("@phone", address.Phone);
            cmd.Parameters.AddWithValue("@createDate", address.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", address.CreatedBy);
            cmd.Parameters.AddWithValue("@lastUpdateBy", address.LastUpdatedBy);
            cmd.ExecuteNonQuery();

            
            lastInsertedId = (int)cmd.LastInsertedId;
        }

        return lastInsertedId;
    }

    public static int GetOrAddAddress(string address, int cityId, string phone)
    {
        int lastInsertedId = 0;
        var connection = DBConnection.GetConnection();
        string query = "SELECT addressID FROM address WHERE address = @address AND cityID = @cityID AND phone = @phone";

        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@address2", DBNull.Value); //not using addresstwo
            cmd.Parameters.AddWithValue("@cityID", cityId);
            cmd.Parameters.AddWithValue("@phone", phone);

            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result); 
            }
        }

        //if the adress doesn't exist then you can insert it
        query = "INSERT INTO address (address, cityID, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@address, @cityID, @phone, NOW(), 'admin', NOW(), 'admin')";

        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@cityID", cityId);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.ExecuteNonQuery();

            lastInsertedId = (int)cmd.LastInsertedId;
        }

        return lastInsertedId;
    }
}

