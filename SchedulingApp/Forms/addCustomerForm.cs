using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchedulingApp.CustomerRecords;
using SchedulingApp.Database;
using SchedulingApp.Models;


namespace SchedulingApp
{
    public partial class addCustomerForm : Form
    {
        public addCustomerForm()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    MessageBox.Show("Please enter a customer name.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(addressTextBox.Text))
                {
                    MessageBox.Show("Please enter an address.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(phoneNumTextBox.Text))
                {
                    MessageBox.Show("Please enter a phone number.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(cityTextBox.Text))
                {
                    MessageBox.Show("Please enter a city.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(countryTextBox.Text))
                {
                    MessageBox.Show("Please enter a country.");
                    return;
                }

                // Save the country
                int countryID = CountryRepo.GetOrAddCountry(countryTextBox.Text);

                // Save the city
                int cityID = CityRepo.GetOrAddCity(cityTextBox.Text, countryID);

                // Save the address
                var newAddress = new Address


                {
                    AddressID = 0,
                    AddressName = addressTextBox.Text,
                    AddressTwo = "", // Optional second address line
                    CityID = cityID,
                    PostalCode = postalCodeTextBox.Text, // Optional
                    Phone = phoneNumTextBox.Text,
                    CreateDate = DateTime.Now,
                    CreatedBy = "admin", // Replace with the logged-in user's username
                    LastUpdate = DateTime.Now,
                    LastUpdatedBy = "admin"// Replace with the logged-in user's username);
                };

                int addressID = AddressRepo.AddAddress(newAddress); // Save the address and get the AddressID

                // Create and save the customer
                var newCustomer = new Customer(
                    customerID: 0, // Assuming the database auto-generates this
                    customerName: nameTextBox.Text,
                    addressID: addressID,
                    active: true, // Assuming the customer is active by default
                    createDate: DateTime.Now,
                    createdBy: "admin", // Replace with the logged-in user's username
                    lastUpdate: DateTime.Now,
                    lastUpdatedBy: "admin" // Replace with the logged-in user's username
                );

                CustomerRepo.AddCustomer(newCustomer); // Save the customer to the database

                // Close the form
                this.Close();

                // Optionally, show a success message
                MessageBox.Show("Customer added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
