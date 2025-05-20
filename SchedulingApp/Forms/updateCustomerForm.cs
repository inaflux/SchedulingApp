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
using static SchedulingApp.LoginForm;

namespace SchedulingApp
{
    public partial class updateCustomerForm : Form
    {
        private int _customerId;

        public updateCustomerForm(int customerId, string customerName, string address, string phone, string city, string country)
        {
            InitializeComponent();

           
            _customerId = customerId;
            
            custIDTextBox.Text = customerId.ToString();
            custIDTextBox.ReadOnly = true;
    
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

                int countryId = CountryRepo.GetOrAddCountry(countryTextBox.Text);
                int cityId = CityRepo.GetOrAddCity(cityTextBox.Text, countryId);
                int addressId = AddressRepo.GetOrAddAddress(addressTextBox.Text, cityId, phoneNumTextBox.Text);

                var updatedCustomer = new Customer(
                    customerID: _customerId,
                    customerName: nameTextBox.Text,
                    addressID: addressId,
                    active: true, 
                    createDate: DateTime.Now, 
                    createdBy: GlobalState.CurrentUsername, 
                    lastUpdate: DateTime.Now,
                    lastUpdatedBy: GlobalState.CurrentUsername 
                );

                CustomerRepo.UpdateCustomer(updatedCustomer);

                MessageBox.Show("Customer updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
