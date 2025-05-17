using SchedulingApp.Database;
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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            LoadUsers();
            monthPicker.ValueChanged += monthPicker_ValueChanged;
            userComboBox.SelectedIndexChanged += userComboBox_SelectedIndexChanged;
            numOfCitiesBtn.Click += numOfCitiesBtn_Click;
        }

        // 1. Load users into ComboBox
        private void LoadUsers()
        {
            var users = UserRepo.GetUserID(); // Assumes this returns List<User>
            userComboBox.DataSource = users;
            userComboBox.DisplayMember = "UserName";
            userComboBox.ValueMember = "UserID";
        }

        // 1. When user selected, show their appointments
        private void userComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userComboBox.SelectedValue is int userId)
            {
                var appts = AppointmentRepo.GetAppointmentsByUserId(userId);
                currentApptDVG.DataSource = appts;
            }
        }

        // 2. When month selected, show appointment types for that month
        private void monthPicker_ValueChanged(object sender, EventArgs e)
        {
            var selectedMonth = monthPicker.Value.Month;
            var selectedYear = monthPicker.Value.Year;
            var appts = AppointmentRepo.GetAllAppointments();
            var typesByMonth = appts
                .Where(a => a.Start.Month == selectedMonth && a.Start.Year == selectedYear)  //This lambda expression returns only appointments whose Start date matches the selected month and year.


                .GroupBy(a => a.Type)//This groups the appointments so you can count how many of each type there are.

                .Select(g => $"{g.Key}: {g.Count()}") 
                //This lambda expression creates a string for each group, where g.Key is the type and g.Count() is the number of appointments of that type.

                .ToList();

            numOfApptList.Items.Clear();

            if (typesByMonth.Count == 0)
            {
                numOfApptList.Items.Add(new ListViewItem("No appointments this month"));
            }
            else
            {
                foreach (var item in typesByMonth)
                {
                    numOfApptList.Items.Add(new ListViewItem(item));
                }
            }
        }

        // 3. On button click, show how many cities are in the database


        private void numOfCitiesBtn_Click(object sender, EventArgs e)
        {
            var cities = CityRepo.GetAllCities();
            var cityCount = cities.Select(c => c.CityName).Distinct().Count();

            citiList.Items.Clear();
            citiList.Items.Add(new ListViewItem($"Total Cities: {cityCount}"));
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
