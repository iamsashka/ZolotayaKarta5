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
    /// Логика взаимодействия для Transactions.xaml
    /// </summary>
    public partial class Transactions : Page
    {
        TransactionsTableAdapter transactions = new TransactionsTableAdapter();
        public Transactions()
        {
            InitializeComponent();
            TransactionsGrid.ItemsSource = transactions.GetData();
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
        private void TransactionsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
