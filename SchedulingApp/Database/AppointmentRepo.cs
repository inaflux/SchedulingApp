using MySql.Data.MySqlClient;
using SchedulingApp.Database;
using SchedulingApp.Models;
using System;
using System.Collections.Generic;

public static class AppointmentRepo
{
    public static void AddAppointment(Appointment appointment)
    {
        var connection = DBConnection.GetConnection();
        string query = "INSERT INTO appointment (customerID, userID, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) " +
                       "VALUES (@customerID, @userID, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdateBy)";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@customerID", appointment.CustomerID);
            cmd.Parameters.AddWithValue("@userID", appointment.UserID);
            cmd.Parameters.AddWithValue("@title", appointment.Title);
            cmd.Parameters.AddWithValue("@description", appointment.Description);
            cmd.Parameters.AddWithValue("@location", appointment.Location);
            cmd.Parameters.AddWithValue("@contact", appointment.Contact);
            cmd.Parameters.AddWithValue("@type", appointment.Type);
            cmd.Parameters.AddWithValue("@url", appointment.URL);
            cmd.Parameters.AddWithValue("@start", appointment.Start);
            cmd.Parameters.AddWithValue("@end", appointment.End);
            cmd.Parameters.AddWithValue("@createDate", appointment.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", appointment.CreatedBy);
            cmd.Parameters.AddWithValue("@lastUpdateBy", appointment.LastUpdatedBy);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Executing query: " + query);

    }

    public static List<Appointment> GetAppointmentsByCustomerId(int customerId)
    {
        var connection = DBConnection.GetConnection();
        var appointments = new List<Appointment>();
        string query = "SELECT * FROM appointment WHERE customerID = @customerID";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@customerID", customerId);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    appointments.Add(new Appointment(
                        reader.GetInt32("appointmentID"),
                        reader.GetInt32("customerID"),
                        reader.GetInt32("userID"),
                        reader.GetString("title"),
                        reader.GetString("description"),
                        reader.GetString("location"),
                        reader.GetString("contact"),
                        reader.GetString("type"),
                        reader.GetString("url"),
                        reader.GetDateTime("start"),
                        reader.GetDateTime("end"),
                        reader.GetDateTime("createDate"),
                        reader.GetString("createdBy"),
                        reader.GetDateTime("lastUpdate"),
                        reader.GetString("lastUpdateBy")
                    ));
                }
            }
        }
        Console.WriteLine("Executing query: " + query);

        return appointments;
    }

    public static void DeleteAppointment(int appointmentId)
    {
        var connection = DBConnection.GetConnection();
        string query = "DELETE FROM appointment WHERE appointmentID = @appointmentID";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@appointmentID", appointmentId);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Executing query: " + query);

    }

    //update appointment
    public static void UpdateAppointment(Appointment appointment)
    {
        var connection = DBConnection.GetConnection();
        string query = "UPDATE appointment SET customerID = @customerID, userID = @userID, title = @title, description = @description, " +
                       "location = @location, contact = @contact, type = @type, url = @url, start = @start, end = @end, " +
                       "lastUpdateBy = @lastUpdateBy WHERE appointmentID = @appointmentID";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@customerID", appointment.CustomerID);
            cmd.Parameters.AddWithValue("@userID", appointment.UserID);
            cmd.Parameters.AddWithValue("@title", appointment.Title);
            cmd.Parameters.AddWithValue("@description", appointment.Description);
            cmd.Parameters.AddWithValue("@location", appointment.Location);
            cmd.Parameters.AddWithValue("@contact", appointment.Contact);
            cmd.Parameters.AddWithValue("@type", appointment.Type);
            cmd.Parameters.AddWithValue("@url", appointment.URL);
            cmd.Parameters.AddWithValue("@start", appointment.Start);
            cmd.Parameters.AddWithValue("@end", appointment.End);
            cmd.Parameters.AddWithValue("@lastUpdateBy", appointment.LastUpdatedBy);
            cmd.Parameters.AddWithValue("@appointmentID", appointment.AppointmentID);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Executing query: " + query);
    }

    public static List<Appointment> GetAllTypes()
    {
        var connection = DBConnection.GetConnection();
        var types = new List<Appointment>();
        string query = "SELECT DISTINCT type FROM appointment";
        using (var cmd = new MySqlCommand(query, connection))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    types.Add(new Appointment
                    {
                        Type = reader.GetString("type")
                    });
                }
            }
        }
        
        return types;

    }


    public static List<Appointment> GetAllAppointments()
    {
        var appointments = new List<Appointment>();
        var connection = DBConnection.GetConnection();
      
            
            string query = "SELECT * FROM appointment";
            using (var cmd = new MySqlCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    appointments.Add(new Appointment
                    {
                        AppointmentID = reader.GetInt32("appointmentId"),
                        CustomerID = reader.GetInt32("customerId"),
                        UserID = reader.GetInt32("userId"),
                        Type = reader.GetString("type"),
                        Start = reader.GetDateTime("start"),
                        End = reader.GetDateTime("end"),
                        // Add other fields as needed
                    });
                }
            }
        return appointments;
    }
    public static List<Appointment> GetAppointmentsByUserId(int userId)
    {
        var connection = DBConnection.GetConnection();
        var appointments = new List<Appointment>();
        string query = "SELECT * FROM appointment WHERE userID = @userID";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@userID", userId);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    appointments.Add(new Appointment(
                        reader.GetInt32("appointmentID"),
                        reader.GetInt32("customerID"),
                        reader.GetInt32("userID"),
                        reader.GetString("title"),
                        reader.GetString("description"),
                        reader.GetString("location"),
                        reader.GetString("contact"),
                        reader.GetString("type"),
                        reader.GetString("url"),
                        reader.GetDateTime("start"),
                        reader.GetDateTime("end"),
                        reader.GetDateTime("createDate"),
                        reader.GetString("createdBy"),
                        reader.GetDateTime("lastUpdate"),
                        reader.GetString("lastUpdateBy")
                    ));
                }
            }
        }
        Console.WriteLine("Executing query: " + query);
        return appointments;
    }
}
