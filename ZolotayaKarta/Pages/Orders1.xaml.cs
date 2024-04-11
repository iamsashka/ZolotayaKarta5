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
using ZolotayaKarta.Practica5DataSetTableAdapters;

namespace ZolotayaKarta
{
    /// <summary>
    /// Логика взаимодействия для Orders1.xaml
    /// </summary>
    public partial class Orders1 : Page
    {
        OrdersTableAdapter orders = new OrdersTableAdapter();
        UsersTableAdapter users = new UsersTableAdapter();
        CustomersTableAdapter customers = new CustomersTableAdapter();
        public Orders1()
        {
            InitializeComponent();
            OrdersGrid.ItemsSource = orders.GetData();
            OrdersGrid.ItemsSource= null ;

            CustomersGrid.ItemsSource = customers.GetData();
            CustomersGrid.Items.Clear();
            UsersGrid.ItemsSource = users.GetData();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(UsersGrid.SelectedValue.ToString(), out int user_id) &&
                int.TryParse(CustomersGrid.SelectedValue.ToString(), out int customerID) &&
                DateTime.TryParse(OrderDateTbx.Text, out DateTime orderDate) &&
                decimal.TryParse(PriceTbx.Text, out decimal price) &&
                decimal.TryParse(TotalAmountTbx.Text, out decimal totalAmount))
            {
                orders.InsertQuery(customerID, user_id, orderDate.ToString(), price, totalAmount);
                OrdersGrid.ItemsSource = orders.GetData();
            }
            else
            {
                MessageBox.Show("Invalid input values.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OrdersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CustomersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UsersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
