using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StyleLibrary;

namespace StyleSphere
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Registration();
        }

        public void Registration()
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;
            if (login == "" || password == "")
            {
                MessageBox.Show("Пустые поля недопустимы!");
            }
            else
            {
                Registration registration = new Registration(login, password);
                var option = new JsonSerializerOptions { WriteIndented = true };
                string reg = JsonSerializer.Serialize<Registration>(registration, option);
                File.WriteAllText("User.json", reg);
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
