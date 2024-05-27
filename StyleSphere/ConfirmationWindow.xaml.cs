using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;
using StyleLibrary;

namespace StyleSphere
{
    /// <summary>
    /// Логика взаимодействия для ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        public ConfirmationWindow()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Deregistration();   
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Deregistration()
        {
            Registration? deregReg = JsonSerializer.Deserialize<Registration>(File.ReadAllText("User.json"));
            deregReg.RegEvent += Message;
            deregReg.Print();
        }

        public void Message(string login, string password)
        {
            string Login = txtLogin.Text;
            string Password = txtPassword.Password;
            if (login == Login && password == Password)
            {
                string del = "";
                File.WriteAllText("User.json", del);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
