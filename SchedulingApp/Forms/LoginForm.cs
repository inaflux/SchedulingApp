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
        public LoginForm()
        {
            InitializeComponent();
            SetLanguageBasedOnCulture();
        }
        public static class GlobalState
        {
            public static int CurrentUserID { get; set; }
            public static string CurrentUsername { get; set; }
        }
        private void SetLanguageBasedOnCulture()
        {
            string cultureCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            if (cultureCode == "es") // Spanish
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
            }
            else // Default to English
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }

            // Update UI text based on the selected culture
            UpdateUIText();
        }

        private void UpdateUIText()
        {
            loginBtn.Text = GetLocalizedMessage("LoginButton");
            label1.Text = GetLocalizedMessage("UsernameLabel");
           label2.Text = GetLocalizedMessage("PasswordLabel");
        }

        private string GetLocalizedMessage(string key)
        {
            // English messages
            var englishMessages = new Dictionary<string, string>
                {
                    { "LoginButton", "Login" },
                    { "UsernameLabel", "Username:" },
                    { "PasswordLabel", "Password:" },
                    { "InvalidCredentials", "Invalid username or password." },
                    { "LoginSuccess", "Login successful!" },
                    { "ErrorTitle", "Error" },
                    { "SuccessTitle", "Success" }
                };

            // Spanish messages
            var spanishMessages = new Dictionary<string, string>
                {
                    { "LoginButton", "Iniciar sesión" },
                    { "UsernameLabel", "Nombre de usuario:" },
                    { "PasswordLabel", "Contraseña:" },
                    { "InvalidCredentials", "Nombre de usuario o contraseña inválidos." },
                    { "LoginSuccess", "¡Inicio de sesión exitoso!" },
                    { "ErrorTitle", "Error" },
                    { "SuccessTitle", "Éxito" }
                };

            string cultureCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            if (cultureCode == "es" && spanishMessages.ContainsKey(key))
            {
                return spanishMessages[key];
            }

            // Default to English
            return englishMessages.ContainsKey(key) ? englishMessages[key] : key;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = pwTextBox.Text.Trim();

            if (username == "test" && password == "test")
            {
                LogLogin(username); // Replace 'username' with your actual variable
                GlobalState.CurrentUserID = 1; // Example: Set the logged-in user's ID
                GlobalState.CurrentUsername = username;

                MessageBox.Show("Login successful!");
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
        public static void LogLogin(string username)
        {
            string logPath = "Login_History.txt";
            string logEntry = $"{DateTime.UtcNow:u} - {username}";
            try
            {
                System.IO.File.AppendAllText(logPath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to write login history: " + ex.Message);
            }
        }

        

    }
    
}
