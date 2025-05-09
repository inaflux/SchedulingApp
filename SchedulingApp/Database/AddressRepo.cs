public static class AddressRepo
{
    public static int AddAddress(Address address)
    {
        var connection = DBConnection.GetConnection();
        string query = "INSERT INTO address (address, address2, cityID, postalCode, phone, createDate, createdBy, lastUpdateBy) " +
                       "VALUES (@address, @address2, @cityID, @postalCode, @phone, @createDate, @createdBy, @lastUpdateBy)";
        using (var cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@address", address.Address);
            cmd.Parameters.AddWithValue("@address2", address.AddressTwo);
            cmd.Parameters.AddWithValue("@cityID", address.CityID);
            cmd.Parameters.AddWithValue("@postalCode", address.PostalCode);
            cmd.Parameters.AddWithValue("@phone", address.Phone);
            cmd.Parameters.AddWithValue("@createDate", address.CreateDate);
            cmd.Parameters.AddWithValue("@createdBy", address.CreatedBy);
            cmd.Parameters.AddWithValue("@lastUpdateBy", address.LastUpdatedBy);
            cmd.ExecuteNonQuery();
        }
        return (int)cmd.LastInsertedId;
    }
}

