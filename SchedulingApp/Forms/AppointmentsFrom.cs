using SchedulingApp.Database;
using SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using static SchedulingApp.LoginForm;

namespace SchedulingApp
{
    public partial class AppointmentsFrom : Form
    {
        public AppointmentsFrom(int customerId)
        {
            InitializeComponent();

            _customerId = customerId; // Set this first!
            LoadCustomers();
            LoadUsers();
            LoadAppointmentTypes();
            LoadAppointmentsData();   // Now it will use the correct _customerId
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
                // ... validation code ...

                var newAppointment = new Appointment
                {
                    CustomerID = customerId,
                    UserID = userId,
                    Title = "Untitled",
                    Description = "No description",
                    Location = "No location",
                    Contact = "No contact",
                    Type = type,
                    URL = "No URL",
                    Start = start,
                    End = end,
                    CreateDate = DateTime.Now,
                    CreatedBy = GlobalState.CurrentUsername,
                    LastUpdate = DateTime.Now,
                    LastUpdatedBy = GlobalState.CurrentUsername
                };

                AppointmentRepo.AddAppointment(newAppointment);
                MessageBox.Show("Appointment added successfully!");
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
                    LastUpdatedBy = GlobalState.CurrentUsername // Replace with the logged-in user's username
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

                // Validate user selection
                if (userIDComboBox.SelectedValue == null || !int.TryParse(userIDComboBox.SelectedValue.ToString(), out int userId))
                {
                    MessageBox.Show("Please select a valid user.");
                    return;
                }

                // Validate appointment type selection
                if (apptComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Please select a valid appointment type.");
                    return;
                }
                string type = apptComboBox.SelectedValue.ToString();

                // Get the start and end times
                DateTime start = startTimePick.Value;
                DateTime end = endTimePick.Value;

                // Validate that the end time is after the start time
                if (end <= start)
                {
                    MessageBox.Show("The end time must be after the start time.");
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
        private void LoadUsers()
        {
            try
            {
                var users = UserRepo.GetUserID();
                if (users.Count == 0)
                {
                    MessageBox.Show("No users found.");
                    return;
                }
                userIDComboBox.DataSource = users;
                userIDComboBox.DisplayMember = "UserName"; // Show the username
                userIDComboBox.ValueMember = "UserID";     // Use the user ID as value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading users: {ex.Message}");
            }
        }



        private void LoadAppointmentTypes()
        {
            try
            {
                // Retrieve the list of appointment types from the database
                var appointmentTypes = AppointmentRepo.GetAllTypes();
                if (appointmentTypes.Count == 0)
                {
                    MessageBox.Show("No appointment types found.");
                    return;
                }
                // Bind the appointment types to the ComboBox
                apptComboBox.DataSource = appointmentTypes;
                apptComboBox.DisplayMember = "Type"; // Display appointment type
                apptComboBox.ValueMember = "Type"; // Use appointment type as the value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading appointment types: {ex.Message}");
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
                apptComboBox.SelectedValue = type;
                startTimePick.Value = start;
                endTimePick.Value = end;

                // Update the appointment when the user clicks "Save"
                saveBtn.Click -= saveBtn_Click; // Unsubscribe from the Add functionality
                saveBtn.Click += (s, args) =>
                {
                    UpdateAppointment(appointmentId, customerId, type, startTimePick.Value, endTimePick.Value, userId);
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
                    int userId = (int)userIDComboBox.SelectedValue;
                    string type = apptComboBox.SelectedValue.ToString();
                    int customerId = (int)custComboBox.SelectedValue;
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
