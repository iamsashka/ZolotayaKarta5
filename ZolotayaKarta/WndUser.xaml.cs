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
    /// Логика взаимодействия для WndUser.xaml
    /// </summary>
    public partial class WndUser : Window
    {
        public WndUser()
        {
            InitializeComponent();
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Categories1();
        }

        private void BrandsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Brands1();
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Products1();
        }

        private void FeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Feedback();
        }

        private void StockButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Stock();
        }
        private void SuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Suppliers();
        }
    }
}
