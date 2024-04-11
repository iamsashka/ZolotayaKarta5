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
    /// Логика взаимодействия для Suppliers.xaml
    /// </summary>
    public partial class Suppliers : Page
    {
        SuppliersTableAdapter suppliers = new SuppliersTableAdapter();
        public Suppliers()
        {
            InitializeComponent();
            SuppliersGrid.ItemsSource = suppliers.GetData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SuppliersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SupplierNameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ContactInfo_MailTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
