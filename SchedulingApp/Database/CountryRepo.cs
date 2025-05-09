public static class CountryRepo
{
    public static int AddCountry(Country country)
    {
        var connection = DBConnection.GetConnection();
        string query = "INSERT INTO country (country, createDate, createdBy, lastUpdateBy) " +
                       "VALUES (@country, @createDate, @createdBy, @lastUpdateBy)";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@country", country.CountryName);
            cmd.Parameters.AddWithValue("@createDate", country.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", country.CreatedBy);
            cmd.Parameters.AddWithValue("@lastUpdateBy", country.LastUpdatedBy);
            cmd.ExecuteNonQuery();
        }
        return (int)cmd.LastInsertedId;
    }

    public static Country GetCountryById(int countryId)
    {
        var connection = DBConnection.GetConnection();
        string query = "SELECT * FROM country WHERE countryID = @countryID";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@countryID", countryId);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Country(
                        reader.GetInt32("countryID"),
                        reader.GetString("country"),
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
                return Convert.ToInt32(result); // Country exists, return its ID
            }
        }

        // Country does not exist, insert it
        var newCountry = new Country(0, countryName, DateTime.Now, "admin", DateTime.Now, "admin");
        return AddCountry(newCountry);
    }
}
