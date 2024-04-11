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

namespace ZolotayaKarta
{
    /// <summary>
    /// Логика взаимодействия для WndAdmin.xaml
    /// </summary>
    public partial class WndAdmin : Window
    {
        public WndAdmin()
        {
            InitializeComponent();
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Users();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Employees();
        }

       


    }
}
