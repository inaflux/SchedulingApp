using SchedulingApp.Database;
using SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
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

            _customerId = customerId;
            LoadCustomers();
            LoadUsers();
            LoadAppointmentTypes();
            custComboBox.SelectedIndexChanged += custComboBox_SelectedIndexChanged;
            LoadAppointmentsData();
            LayoutAppointmentsDGV();
        }

        private void LayoutAppointmentsDGV()
        {
            appointmentsDGV.Columns["Type"].HeaderText = "Type";
            appointmentsDGV.Columns["CustomerID"].HeaderText = "Customer";
            appointmentsDGV.Columns["Start"].HeaderText = "Start Time";
            appointmentsDGV.Columns["End"].HeaderText = "End Time";
            appointmentsDGV.Columns["UserID"].HeaderText = "UserID";

            foreach (DataGridViewColumn column in appointmentsDGV.Columns)
            {
                if (column.Name != "Type" && column.Name != "CustomerID" && column.Name != "Start" && column.Name != "End" && column.Name != "UserID")
                {
                    column.Visible = false;
                }
            }

            appointmentsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private int _customerId; 
      private void LoadAppointmentsData()
        {
            try
            {
                List<Appointment> appointments = AppointmentRepo.GetAppointmentsByCustomerId(_customerId);

                //Convert from UTC to local time for display in DGV
                foreach (var appt in appointments)
                    {
                        appt.Start = appt.Start.ToLocalTime();
                        appt.End = appt.End.ToLocalTime();
                    }

                appointmentsDGV.DataSource = null;
                appointmentsDGV.DataSource = appointments;
                LayoutAppointmentsDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading appointments: {ex.Message}");
            }
        }
        private bool BusinessHours(DateTime startUtc, DateTime endUtc)
        {
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEST = TimeZoneInfo.ConvertTimeFromUtc(startUtc, est);
            DateTime endEST = TimeZoneInfo.ConvertTimeFromUtc(endUtc, est);

            // Business hours: 8 AM to 5 PM, Monday–Friday
            if (startEST.Hour < 8 || endEST.Hour > 17 ||
                startEST.DayOfWeek == DayOfWeek.Saturday ||
                startEST.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            return true;
        }
        private bool AppointmentOverlap(int customerId, DateTime start, DateTime end)
        {
            var appointments = AppointmentRepo.GetAppointmentsByCustomerId(customerId);

            foreach (var appointment in appointments)
            {
                if (start < appointment.End && end > appointment.Start)
                {
                    return true; 
                }
            }
            return false;
        }
        public void AddAppointment(int customerId, string type, DateTime start, DateTime end, int userId)
        {
            try
            {
                
                if (AppointmentOverlap(customerId, start, end))
                {
                    MessageBox.Show("This appointment overlaps with an existing appointment.", "Overlap Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                if (!BusinessHours(start, end))
                {
                    MessageBox.Show("Appointments must be scheduled during business hours (9 AM to 5 PM , Monday to Friday).");
                    return;
                }

                if (AppointmentOverlap(customerId, start, end))
                {
                    MessageBox.Show("This appointment overlaps with an existing appointment.");
                    return;
                }

                
                var updatedAppointment = new Appointment
                {
                    AppointmentID = appointmentId,
                    CustomerID = customerId,
                    UserID = userId,
                    Type = type,
                    Title = "Untitled", 
                    Description = "No description", 
                    Location = "No location", 
                    Contact = "No contact", 
                    URL = "No URL",
                    Start = start,
                    End = end,
                    CreateDate = DateTime.Now,
                    CreatedBy = GlobalState.CurrentUsername,
                    LastUpdate = DateTime.Now,
                    LastUpdatedBy = GlobalState.CurrentUsername
                };

                AppointmentRepo.UpdateAppointment(updatedAppointment);
                MessageBox.Show("Appointment updated successfully!");

       
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
               
                AppointmentRepo.DeleteAppointment(appointmentId);
                MessageBox.Show("Appointment deleted successfully!");

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
                
                if (custComboBox.SelectedValue == null || !int.TryParse(custComboBox.SelectedValue.ToString(), out int customerId))
                {
                    MessageBox.Show("Please select a valid customer.");
                    return;
                }

                if (userIDComboBox.SelectedValue == null || !int.TryParse(userIDComboBox.SelectedValue.ToString(), out int userId))
                {
                    MessageBox.Show("Please select a valid user.");
                    return;
                }

                if (apptComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Please select a valid appointment type.");
                    return;
                }
                string type = apptComboBox.SelectedValue.ToString();

                DateTime start = startTimePick.Value.ToUniversalTime();
                DateTime end = endTimePick.Value.ToUniversalTime();

                if (end <= start)
                {
                    MessageBox.Show("The end time must be after the start time.");
                    return;
                }

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

                // Binds the customers to the ComboBox
                custComboBox.DataSource = customers;
                custComboBox.DisplayMember = "CustomerName"; 
                custComboBox.ValueMember = "CustomerID"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading customers: {ex.Message}");
            }
        }

        //load users into the userIDComboBox
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
                userIDComboBox.DisplayMember = "UserName"; 
                userIDComboBox.ValueMember = "UserID";     
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
               
                var dbTypes = AppointmentRepo.GetAllTypes()
                    ?.Select(t => t.Type)
                    .ToList() ?? new List<string>();

                // Adds custom types to the combo box along with the DB Types
                var customTypes = new[] { "Lunch", "Touchbase", "Conference" };
                foreach (var type in customTypes)
                {
                    if (!dbTypes.Contains(type, StringComparer.OrdinalIgnoreCase))
                    {
                        dbTypes.Add(type);
                    }
                }

                
                apptComboBox.DataSource = null; 
                apptComboBox.DataSource = dbTypes;
                apptComboBox.DisplayMember = null; 
                apptComboBox.ValueMember = null;   
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
                if (appointmentsDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an appointment to edit.");
                    return;
                }

                var selectedRow = appointmentsDGV.SelectedRows[0];

                // Get values directly from the selected row
                int appointmentId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);
                int customerId = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);
                int userId = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
                string type = selectedRow.Cells["Type"].Value.ToString();
                DateTime start = Convert.ToDateTime(selectedRow.Cells["Start"].Value);
                DateTime end = Convert.ToDateTime(selectedRow.Cells["End"].Value);

                
                custComboBox.SelectedValue = customerId;
                userIDComboBox.SelectedValue = userId;
                apptComboBox.SelectedItem = type; 
                startTimePick.Value = start;
                endTimePick.Value = end;

                
                saveBtn.Click -= saveBtn_Click;
                saveBtn.Click += (s, args) =>
                {
                    UpdateAppointment(appointmentId,
                                      (int)custComboBox.SelectedValue,
                                      apptComboBox.SelectedItem.ToString(), 
                                      startTimePick.Value.ToUniversalTime(),
                                      endTimePick.Value.ToUniversalTime(),
                                      (int)userIDComboBox.SelectedValue);
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
                if (appointmentsDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an appointment to delete.");
                    return;
                }

                var selectedRow = appointmentsDGV.SelectedRows[0];
                int appointmentId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this appointment?", "Delete Appointment", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
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

        private void custComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (custComboBox.SelectedValue != null && int.TryParse(custComboBox.SelectedValue.ToString(), out int customerId))
            {
                _customerId = customerId;
                LoadAppointmentsData();
            }
        }
    }
}
