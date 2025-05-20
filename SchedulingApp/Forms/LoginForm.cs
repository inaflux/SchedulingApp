using SchedulingApp.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
    public partial class LoginForm : Form
    {

        private static string username;
        private static string password;
        public LoginForm()
        {
            InitializeComponent();
            GetCultureCode();
        }
        public static class GlobalState
        {
            public static int CurrentUserID { get; set; }
            public static string CurrentUsername { get; set; }
            public static string CurrentUserTimeZoneId { get; set; }
        }
        private void GetCultureCode()
        {
            string cultureCode = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            if (cultureCode == "es") // Spanish Translation 
            {
                label7.Text = "Iniciar sesión";
                label1.Text = "Nombre de usuario:";
                label2.Text = "Contraseña:";
                loginBtn.Text = "Iniciar sesión";
                exitBtn.Text = "Salir";
            }
            else 
            {
                label7.Text = "Login";
                label1.Text = "Username:";
                label2.Text = "Password:";
                loginBtn.Text = "Login";
                exitBtn.Text = "Exit";
            }
        }

        

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            username = usernameTextBox.Text.Trim();
            password = pwTextBox.Text.Trim();
            if (username == "test" && password == "test")
            {
                LogLogin(username, true);
                GlobalState.CurrentUserID = 1;
                GlobalState.CurrentUsername = username;

                UpcomingAppointmentAlert(GlobalState.CurrentUserID);

                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                LogLogin(username, false);
                MessageBox.Show("Invalid username or password.");
            }
        }
        public static void LogLogin(string username, bool isSuccess)
        {
            string logPath = "Login_History.txt";
            string logEntry = $"{DateTime.UtcNow:u} - {username} - Login {(isSuccess ? "Successful" : "Failed")}.";
            System.IO.File.AppendAllText(logPath, logEntry + Environment.NewLine);
        }
        public static void UpcomingAppointmentAlert(int userId)
        {
            var userAppointments = AppointmentRepo.GetAppointmentsByUserId(userId);
            var nowUtc = DateTime.UtcNow;
            var fifteenMinFromNow = nowUtc.AddMinutes(15);

            var upcoming = userAppointments
                .FirstOrDefault(appt =>
                    DateTime.SpecifyKind(appt.Start, DateTimeKind.Utc) >= nowUtc &&
                    DateTime.SpecifyKind(appt.Start, DateTimeKind.Utc) <= fifteenMinFromNow);

            if (upcoming != null)
            {
                var localStart = DateTime.SpecifyKind(upcoming.Start, DateTimeKind.Utc).ToLocalTime();
                MessageBox.Show(
                    $"You have an appointment in 15 minutes!\n" +
                    $"Appointment ID: {upcoming.AppointmentID}\n" +
                    $"Start Time (Local): {localStart:f}",
                    "Upcoming Appointment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

    }
    
}
