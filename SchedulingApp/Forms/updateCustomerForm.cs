using SchedulingApp.Database;
using SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
    public partial class updateCustomerForm : Form
    {
        private int _customerId;

        public updateCustomerForm(int customerId, string customerName, string address, string phone, string city, string country)
        {
            InitializeComponent();

            // Store the customer ID for updating
            _customerId = customerId;
            //customerID box disabled readonly
            custIDTextBox.Text = customerId.ToString();
            custIDTextBox.ReadOnly = true;
           

            // Populate the textboxes with the selected customer's data
            nameTextBox.Text = customerName;
            addressTextBox.Text = address;
            phoneNumTextBox.Text = phone;
            cityTextBox.Text = city;
            countryTextBox.Text = country;
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

                // Update the customer record in the database
                int countryId = CountryRepo.GetOrAddCountry(countryTextBox.Text);
                int cityId = CityRepo.GetOrAddCity(cityTextBox.Text, countryId);
                int addressId = AddressRepo.GetOrAddAddress(addressTextBox.Text, cityId, phoneNumTextBox.Text);

                var updatedCustomer = new Customer(
                    customerID: _customerId,
                    customerName: nameTextBox.Text,
                    addressID: addressId,
                    active: true, // Assuming the customer is active
                    createDate: DateTime.Now, // This can be the original creation date
                    createdBy: "admin", // Replace with the logged-in user's username
                    lastUpdate: DateTime.Now,
                    lastUpdatedBy: "admin" // Replace with the logged-in user's username
                );

                CustomerRepo.UpdateCustomer(updatedCustomer);

                // Close the form
                MessageBox.Show("Customer updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
