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
        private List<CustomerDetails> allCustomers;
        

        public MainForm()
        {
            InitializeComponent();
            LoadCustomerData();
            allViewRadioBtn.CheckedChanged += CalendarViewChanged;
            weekViewRadioBtn.CheckedChanged += CalendarViewChanged;
            monthViewRadioBtn.CheckedChanged += CalendarViewChanged;
            allViewRadioBtn.Checked = true;
            CalendarViewChanged(null, null);
        }

        private void LoadCustomerData()
        {
            try
            {
                allCustomers = CustomerDetails.GetCustomerDetails();
                customersDGV.DataSource = allCustomers;
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

            LoadCustomerData();
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
         
            if (customersDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            var selectedRow = customersDGV.SelectedRows[0];
            int customerId = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);
            string customerName = selectedRow.Cells["CustomerName"].Value.ToString();
            string address = selectedRow.Cells["Address"].Value.ToString();
            string phone = selectedRow.Cells["Phone"].Value.ToString();
            string city = selectedRow.Cells["City"].Value.ToString();
            string country = selectedRow.Cells["Country"].Value.ToString();

            var updateForm = new updateCustomerForm(customerId, customerName, address, phone, city, country);
            updateForm.ShowDialog();

           
            LoadCustomerData();
        }


        

private void scheduleBtn_Click(object sender, EventArgs e)
        {
            
            if (customersDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to schedule an appointment.");
                return;
            }

            int customerId = Convert.ToInt32(customersDGV.SelectedRows[0].Cells["CustomerID"].Value);

            AppointmentsFrom scheduleForm = new AppointmentsFrom(customerId);
            scheduleForm.ShowDialog();
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }
  

    
private void CalendarViewChanged(object sender, EventArgs e)
        {
            List<Appointment> allAppointments = AppointmentRepo.GetAllAppointments();
            List<Appointment> filteredAppointments = new List<Appointment>();

            if (allViewRadioBtn.Checked)
            {
                filteredAppointments = allAppointments;
            }
            else if (weekViewRadioBtn.Checked)
            {
                filteredAppointments = GetAppointmentsForCurrentWeek(allAppointments);
            }
            else if (monthViewRadioBtn.Checked)
            {
                filteredAppointments = GetAppointmentsForCurrentMonth(allAppointments);
            }

            calendarDGV.DataSource = filteredAppointments;
            LayoutCalendarDGV(); // Hide unwanted columns and set headers
        }

        private List<Appointment> GetAppointmentsForCurrentWeek(List<Appointment> appointments)
        {
            List<Appointment> weekAppointments = new List<Appointment>();
            DateTime utcNow = DateTime.UtcNow;
            int diff = (int)utcNow.DayOfWeek;
            DateTime weekStart = utcNow.Date.AddDays(-diff); // Sunday
            DateTime weekEnd = weekStart.AddDays(7);         // Next Sunday

            foreach (Appointment appt in appointments)
            {
                DateTime apptUtc = appt.Start.ToUniversalTime();
                if (apptUtc >= weekStart && apptUtc < weekEnd)
                {
                    weekAppointments.Add(appt);
                }
            }
            return weekAppointments;
        }

        private List<Appointment> GetAppointmentsForCurrentMonth(List<Appointment> appointments)
        {
            List<Appointment> monthAppointments = new List<Appointment>();
            DateTime utcNow = DateTime.UtcNow;
            int year = utcNow.Year;
            int month = utcNow.Month;

            foreach (Appointment appt in appointments)
            {
                DateTime apptUtc = appt.Start.ToUniversalTime();
                if (apptUtc.Year == year && apptUtc.Month == month)
                {
                    monthAppointments.Add(appt);
                }
            }
            return monthAppointments;
        }
        private void LayoutCalendarDGV()
        {
           
            if (calendarDGV.Columns.Contains("AppointmentID"))
                calendarDGV.Columns["AppointmentID"].HeaderText = "ID";
            if (calendarDGV.Columns.Contains("Type"))
                calendarDGV.Columns["Type"].HeaderText = "Type";
            if (calendarDGV.Columns.Contains("CustomerID"))
                calendarDGV.Columns["CustomerID"].HeaderText = "Customer";
            if (calendarDGV.Columns.Contains("Start"))
                calendarDGV.Columns["Start"].HeaderText = "Start Time";
            if (calendarDGV.Columns.Contains("End"))
                calendarDGV.Columns["End"].HeaderText = "End Time";
            if (calendarDGV.Columns.Contains("UserID"))
                calendarDGV.Columns["UserID"].HeaderText = "User";

            foreach (DataGridViewColumn column in calendarDGV.Columns)
            {
                if (column.Name != "AppointmentID" &&
                    column.Name != "Type" &&
                    column.Name != "CustomerID" &&
                    column.Name != "Start" &&
                    column.Name != "End" &&
                    column.Name != "UserID")
                {
                    column.Visible = false;
                }
                else
                {
                    column.Visible = true;
                }
            }

            calendarDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
    
}
