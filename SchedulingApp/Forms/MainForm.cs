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
    }
}
