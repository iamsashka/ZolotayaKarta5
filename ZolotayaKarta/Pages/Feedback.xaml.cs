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
    /// Логика взаимодействия для Feedback.xaml
    /// </summary>
    public partial class Feedback : Page
    {
        FeedbackTableAdapter feedback = new FeedbackTableAdapter();
        public Feedback()
        {
            InitializeComponent();
            FeedbackGrid.ItemsSource = feedback.GetData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CustomerIDTbx.Text, out int customerID) &&
                int.TryParse(ProductIDTbx.Text, out int productID) &&
                int.TryParse(RatingTbx.Text, out int rating) &&
                !string.IsNullOrEmpty(CommentTbx.Text))
            {
                feedback.InsertQuery(customerID, productID, rating, CommentTbx.Text);
                FeedbackGrid.ItemsSource = feedback.GetData();
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
        private void FeedbackGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FeedbackGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)FeedbackGrid.SelectedItem;
                CustomerIDTbx.Text = selectedRow["CustomerID"].ToString();
                ProductIDTbx.Text = selectedRow["ProductID"].ToString();
                RatingTbx.Text = selectedRow["Rating"].ToString();
                CommentTbx.Text = selectedRow["Comment"].ToString();
            }
        }

        private void CustomerIDTbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProductIDTbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

