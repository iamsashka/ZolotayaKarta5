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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZolotayaKarta.Properties;
using ZolotayaKarta.Practica5DataSetTableAdapters;
using System.Net;
using System.Security.Cryptography;

namespace ZolotayaKarta
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UsersTableAdapter adapter = new UsersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }
        private static string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                string sb = "";
                for (int i = 0; i < hash.Length; i++)
                {
                    sb += hash[i].ToString("x2");
                }
                return sb;
            }
        }
       

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var allLogin = adapter.GetData().Rows;
            bool isAuthenticated = false;

            for (int i = 0; i < allLogin.Count; i++)
            {
                if (allLogin[i][1].ToString() == LoginTbx.Text && allLogin[i][2].ToString() == Hash(PasswordTbx.Password))
                {
                    string Role = allLogin[i][3].ToString();

                    switch (Role)
                    {
                        case "admin": // admin
                            WndAdmin wndAdmin = new WndAdmin();
                            wndAdmin.Show();
                            Window.GetWindow(this).Close();
                            isAuthenticated = true;
                            break;
                        case "user": // user
                            WndUser wndUser = new WndUser();
                            wndUser.Show();
                            Window.GetWindow(this).Close();
                            isAuthenticated = true;
                            return;
                        case "casir": // user
                            WndCasir wndCasir = new WndCasir();
                            wndCasir.Show();
                            Window.GetWindow(this).Close();
                            isAuthenticated = true;
                            return;
                        default:
                            MessageBox.Show("Неверно введен логин или пароль");
                            break;

                    }

                }
            }
            if (!isAuthenticated)
            {
                MessageBox.Show("Неверно введен логин или пароль");
            }




        }
    }
}

