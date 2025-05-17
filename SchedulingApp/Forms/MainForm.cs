using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SchedulingApp.CustomerRecords;
using SchedulingApp.Database;
using SchedulingApp.Models;


namespace SchedulingApp
{
    public partial class MainForm : Form
    {
        

        public MainForm()
        {
            InitializeComponent();
            LoadCustomerData();
            

        }

        private void LoadCustomerData()
        {
            try
            {
                List<CustomerDetails>  customerDetails = CustomerDetails.GetCustomerDetails();
                //CustomerDetails customerDetails = new CustomerDetails.GetCustomerDetails();
                customersDGV.DataSource = customerDetails;
                LayoutCustomerDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LayoutCustomerDGV()
        {
            customersDGV.Columns["CustomerName"].HeaderText = "Name";
            customersDGV.Columns["Address"].HeaderText = "Address";
            customersDGV.Columns["Phone"].HeaderText = "Phone Number";
            customersDGV.Columns["City"].HeaderText = "City";
            customersDGV.Columns["Country"].HeaderText = "Country";

            customersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addCustomerForm addCustomerForm = new addCustomerForm();
            addCustomerForm.ShowDialog();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(customersDGV.SelectedRows.Count > 0)
            {
                int customerId = (int)customersDGV.SelectedRows[0].Cells["CustomerID"].Value;
                string customerName = customersDGV.SelectedRows[0].Cells["CustomerName"].Value.ToString();
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {customerName}?", "Delete Customer", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    CustomerRepo.DeleteCustomer(customerId);
                    LoadCustomerData();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
          
            // Ensure a row is selected
            if (customersDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            // Get the selected customer data
            var selectedRow = customersDGV.SelectedRows[0];
            int customerId = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);
            string customerName = selectedRow.Cells["CustomerName"].Value.ToString();
            string address = selectedRow.Cells["Address"].Value.ToString();
            string phone = selectedRow.Cells["Phone"].Value.ToString();
            string city = selectedRow.Cells["City"].Value.ToString();
            string country = selectedRow.Cells["Country"].Value.ToString();

            // Open the updateCustomerForm and pass the selected customer data
            var updateForm = new updateCustomerForm(customerId, customerName, address, phone, city, country);
            updateForm.ShowDialog();

            // Refresh the DataGridView after updating
            LoadCustomerData();
        }


        

private void scheduleBtn_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (customersDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to schedule an appointment.");
                return;
            }

            // Get the selected customer's ID
            int customerId = Convert.ToInt32(customersDGV.SelectedRows[0].Cells["CustomerID"].Value);

            // Open the AppointmentsFrom form and pass the customer ID
            AppointmentsFrom scheduleForm = new AppointmentsFrom(customerId);
            scheduleForm.ShowDialog();
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }
    }
    
}
