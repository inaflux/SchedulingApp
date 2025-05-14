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
    public partial class AppointmentsFrom : Form
    {
        private string userName; // Store the username of the logged-in user
        public AppointmentsFrom(int customerId)
        {
            InitializeComponent();

            LoadAppointmentsData();
            LoadCustomers();
            _customerId = customerId; // Set the customer ID
           // int userId = GlobalState.CurrentUserID;
           LayoutAppointmentsDGV();
          





        }

        private void LayoutAppointmentsDGV()
        {
            // Set the headers for the required columns
            appointmentsDGV.Columns["Type"].HeaderText = "Type";
            appointmentsDGV.Columns["CustomerID"].HeaderText = "Customer";
            appointmentsDGV.Columns["Start"].HeaderText = "Start Time";
            appointmentsDGV.Columns["End"].HeaderText = "End Time";
            appointmentsDGV.Columns["UserID"].HeaderText = "UserID";

            // Hide all other columns
            foreach (DataGridViewColumn column in appointmentsDGV.Columns)
            {
                if (column.Name != "Type" && column.Name != "CustomerID" && column.Name != "Start" && column.Name != "End" && column.Name != "UserID")
                {
                    column.Visible = false;
                }
            }

            // Adjust column widths
            appointmentsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private int _customerId; // Store the customer ID



        private void LoadAppointmentsData()
        {
            try
            {
                // Use the stored customer ID to fetch appointments
                List<Appointment> appointments = AppointmentRepo.GetAppointmentsByCustomerId(_customerId);

                // Bind the data to the DataGridView
                appointmentsDGV.DataSource = appointments;

                // Layout the DataGridView to show only the required columns
                LayoutAppointmentsDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading appointments: {ex.Message}");
            }
        }
        private bool IsWithinBusinessHours(DateTime start, DateTime end)
        {
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEST = TimeZoneInfo.ConvertTimeFromUtc(start.ToUniversalTime(), est);
            DateTime endEST = TimeZoneInfo.ConvertTimeFromUtc(end.ToUniversalTime(), est);

            // Check if the appointment is within business hours (9 AM to 5 PM, Monday to Friday)
            if (startEST.Hour < 9 || endEST.Hour > 17 || startEST.DayOfWeek == DayOfWeek.Saturday || startEST.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            return true;
        }
        private bool IsOverlappingAppointment(int customerId, DateTime start, DateTime end)
        {
            var appointments = AppointmentRepo.GetAppointmentsByCustomerId(customerId);

            foreach (var appointment in appointments)
            {
                if (start < appointment.End && end > appointment.Start)
                {
                    return true; // Overlapping appointment found
                }
            }
            return false;
        }
        public void AddAppointment(int customerId, string type, DateTime start, DateTime end, int userId)
        {
            try
            {
                // Validate business hours
                if (!IsWithinBusinessHours(start, end))
                {
                    MessageBox.Show("Appointments must be scheduled during business hours (9 AM to 5 PM EST, Monday to Friday).");
                    return;
                }

                // Validate overlapping appointments
                if (IsOverlappingAppointment(customerId, start, end))
                {
                    MessageBox.Show("This appointment overlaps with an existing appointment.");
                    return;
                }

                // Add the appointment to the database
                var newAppointment = new Appointment
                {
                    CustomerID = customerId,
                    UserID = userId,
                    Title = "Untitled", // Provide a default value for the title
                    Type = type,
                    Start = start,
                    End = end,
                    CreateDate = DateTime.Now,
                    CreatedBy = userName,
                    LastUpdate = DateTime.Now,
                    LastUpdatedBy = userName
                };

                AppointmentRepo.AddAppointment(newAppointment);
                MessageBox.Show("Appointment added successfully!");

                // Refresh the DataGridView
                LoadAppointmentsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the appointment: {ex.Message}");
            }
        }
        public void UpdateAppointment(int appointmentId, int customerId, string type, DateTime start, DateTime end, int userId)
        {
            try
            {
                // Validate business hours
                if (!IsWithinBusinessHours(start, end))
                {
                    MessageBox.Show("Appointments must be scheduled during business hours (9 AM to 5 PM EST, Monday to Friday).");
                    return;
                }

                // Validate overlapping appointments
                if (IsOverlappingAppointment(customerId, start, end))
                {
                    MessageBox.Show("This appointment overlaps with an existing appointment.");
                    return;
                }

                // Update the appointment in the database
                var updatedAppointment = new Appointment
                {
                    AppointmentID = appointmentId,
                    CustomerID = customerId,
                    UserID = userId,
                    Type = type,
                    Start = start,
                    End = end,
                    LastUpdate = DateTime.Now,
                    LastUpdatedBy = userName // Replace with the logged-in user's username
                };

                AppointmentRepo.UpdateAppointment(updatedAppointment);
                MessageBox.Show("Appointment updated successfully!");

                // Refresh the DataGridView
                LoadAppointmentsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the appointment: {ex.Message}");
            }
        }
        public void DeleteAppointment(int appointmentId)
        {
            try
            {
                // Delete the appointment from the database
                AppointmentRepo.DeleteAppointment(appointmentId);
                MessageBox.Show("Appointment deleted successfully!");

                // Refresh the DataGridView
                LoadAppointmentsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the appointment: {ex.Message}");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate customer selection
                if (custComboBox.SelectedValue == null || !int.TryParse(custComboBox.SelectedValue.ToString(), out int customerId))
                {
                    MessageBox.Show("Please select a valid customer.");
                    return;
                }

                // Validate type input
                if (string.IsNullOrWhiteSpace(apptTextBox.Text))
                {
                    MessageBox.Show("Please enter the appointment type.");
                    return;
                }

                // Get the appointment type
                string type = apptTextBox.Text;

                // Get the start and end times
                DateTime start = startTimePick.Value;
                DateTime end = endTimePick.Value;

                // Validate that the end time is after the start time
                if (end <= start)
                {
                    MessageBox.Show("The end time must be after the start time.");
                    return;
                }

                // Validate user ID
                if (string.IsNullOrWhiteSpace(userIDTextBox.Text) || !int.TryParse(userIDTextBox.Text, out int userId))
                {
                    MessageBox.Show("Please enter a valid user ID.");
                    return;
                }

                // Add the appointment
                AddAppointment(customerId, type, start, end, userId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the appointment: {ex.Message}");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
        private void LoadCustomers()
        {
            try
            {
                // Retrieve the list of customers from the database
                var customers = CustomerRepo.GetCustomerName();

                if (customers.Count == 0)
                {
                    MessageBox.Show("No customers found.");
                    return;
                }

                // Bind the customers to the ComboBox
                custComboBox.DataSource = customers;
                custComboBox.DisplayMember = "CustomerName"; // Display customer name
                custComboBox.ValueMember = "CustomerID"; // Use customer ID as the value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading customers: {ex.Message}");
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (appointmentsDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an appointment to edit.");
                    return;
                }

                var selectedRow = appointmentsDGV.SelectedRows[0];

                // Validate AppointmentID
                if (selectedRow.Cells["AppointmentID"].Value == null || !int.TryParse(selectedRow.Cells["AppointmentID"].Value.ToString(), out int appointmentId))
                {
                    MessageBox.Show("Invalid Appointment ID.");
                    return;
                }

                // Validate CustomerID
                if (selectedRow.Cells["CustomerID"].Value == null || !int.TryParse(selectedRow.Cells["CustomerID"].Value.ToString(), out int customerId))
                {
                    MessageBox.Show("Invalid Customer ID.");
                    return;
                }

                // Validate UserID
                if (selectedRow.Cells["UserID"].Value == null || !int.TryParse(selectedRow.Cells["UserID"].Value.ToString(), out int userId))
                {
                    MessageBox.Show("Invalid User ID.");
                    return;
                }

                // Get other details
                string type = selectedRow.Cells["Type"].Value.ToString();
                DateTime start = Convert.ToDateTime(selectedRow.Cells["Start"].Value);
                DateTime end = Convert.ToDateTime(selectedRow.Cells["End"].Value);

                // Populate the form's input fields
                custComboBox.SelectedValue = customerId;
                apptTextBox.Text = type;
                startTimePick.Value = start;
                endTimePick.Value = end;

                // Update the appointment when the user clicks "Save"
                saveBtn.Click -= saveBtn_Click; // Unsubscribe from the Add functionality
                saveBtn.Click += (s, args) =>
                {
                    UpdateAppointment(appointmentId, customerId, apptTextBox.Text, startTimePick.Value, endTimePick.Value, userId);
                };

                MessageBox.Show("Edit the appointment details and click 'Save' to update.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while editing the appointment: {ex.Message}");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (appointmentsDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an appointment to delete.");
                    return;
                }

                // Get the selected appointment's ID
                var selectedRow = appointmentsDGV.SelectedRows[0];
                int appointmentId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this appointment?", "Delete Appointment", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Delete the appointment
                    DeleteAppointment(appointmentId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the appointment: {ex.Message}");
            }
        }
    }
}
