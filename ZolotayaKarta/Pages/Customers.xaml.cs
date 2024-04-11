using System;
using System.Collections.Generic;
using System.Data;
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
using ZolotayaKarta.Practica5DataSetTableAdapters;

namespace ZolotayaKarta
{
    /// <summary>
    /// Логика взаимодействия для Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        CustomersTableAdapter customers = new CustomersTableAdapter();
        UsersTableAdapter users = new UsersTableAdapter();
        public Customers()
        {
            InitializeComponent();
            CustomersGrid.ItemsSource = customers.GetData();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string firstName = CustomersFirstNameTbx.Text;
            string lastName = CustomersLastNameTbx.Text;
            string email = CustomersEmailTbx.Text;
            string phone = CustomersPhoneTbx.Text;

            int userId;
            if (!int.TryParse(UsersGrid.Text, out userId))
            {
                MessageBox.Show("Ошибка: Некорректный формат User ID", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            customers.InsertQuery(firstName, lastName, userId, email, phone);
            CustomersGrid.ItemsSource = customers.GetData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CustomersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UsersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)UsersGrid.SelectedItem;
                CustomersFirstNameTbx.Text = selectedRow["FirstName"].ToString();

               
            }
        }

        private void CustomersFirstNameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CustomersLastNameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CustomersEmailTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CustomersPhoneTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}



