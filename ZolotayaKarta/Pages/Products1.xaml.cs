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
    /// Логика взаимодействия для Products1.xaml
    /// </summary>
    public partial class Products1 : Page
    {
        ProductsTableAdapter products = new ProductsTableAdapter();
        CategoriesTableAdapter categories = new CategoriesTableAdapter();
        BrandsTableAdapter brands = new BrandsTableAdapter();
        public Products1()
        {
            InitializeComponent();
            ProductsGrid.ItemsSource = products.GetData();
            CategoriesGrid.Items.Clear();
            CategoriesGrid.ItemsSource = categories.GetData();
            BrandsGrid.Items.Clear();
            BrandsGrid.ItemsSource = brands.GetData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Check if any of the fields are empty
            if (string.IsNullOrWhiteSpace(ProductsNameTbx.Text) || BrandsGrid.SelectedValue == null ||
                string.IsNullOrWhiteSpace(PriceTbx.Text) || CategoriesGrid.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (int.TryParse(BrandsGrid.SelectedValue.ToString(), out int brandID) &&
                int.TryParse(CategoriesGrid.SelectedValue.ToString(), out int categoryID) &&
                decimal.TryParse(PriceTbx.Text, out decimal price))
            {
                products.InsertQuery(ProductsNameTbx.Text, brandID, price, categoryID);
                ProductsGrid.ItemsSource = products.GetData();
            }
            else
            {
                MessageBox.Show("Invalid input values.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedItem != null && ProductsGrid.SelectedValue is int productID)
            {
                // Get the original values of the selected product
                var selectedProduct = products.GetData().FirstOrDefault(p => p.ProductID == productID);
                if (selectedProduct != null)
                {
                    var original_ProductsName = selectedProduct.ProductsName;
                    var original_BrandID = selectedProduct.BrandID;
                    var original_Price = selectedProduct.Price;
                    var original_CategoryID = selectedProduct.CategoryID;

                    // Check if the price is equal to 1,000,000
                    if (original_Price != 1000000)
                    {
                        MessageBox.Show("Вы можете удалить только товар стоимостью 1 000 000 долларов.");
                        return;
                    }

                    // Call the DeleteQuery method with the original values
                    products.DeleteQuery(productID, original_ProductsName, original_BrandID, original_Price, original_CategoryID);
                    ProductsGrid.ItemsSource = products.GetData();
                }
            }
            else
            {
                MessageBox.Show("Нельзя удалить запись, на которую есть ссылка!");
            }
        

    }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedItem != null && ProductsGrid.SelectedValue is int productID)
            {
                // Get the original values of the selected product
                var selectedProduct = products.GetData().FirstOrDefault(p => p.ProductID == productID);
                if (selectedProduct != null)
                {
                    var original_ProductsName = selectedProduct.ProductsName;
                    var original_BrandID = selectedProduct.BrandID;
                    var original_Price = selectedProduct.Price;
                    var original_CategoryID = selectedProduct.CategoryID;

                    // Check if any of the new values are empty or the price is too high
                    if (string.IsNullOrWhiteSpace(ProductsNameTbx.Text) || BrandsGrid.SelectedValue == null ||
                        !decimal.TryParse(PriceTbx.Text, out decimal new_Price) || new_Price >= 1000000 || CategoriesGrid.SelectedValue == null)
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля и убедитесь, что цена меньше 1 000 000 рублей.");
                        return;
                    }

                    // Get the new values for the product
                    var new_ProductsName = ProductsNameTbx.Text;
                    var new_BrandID = (int)BrandsGrid.SelectedValue;
                    var new_CategoryID = (int)CategoriesGrid.SelectedValue;

                    // Call the UpdateQuery method with the original and new values
                    products.UpdateQuery(new_ProductsName, new_BrandID, new_Price, new_CategoryID, productID, original_ProductsName, original_BrandID, original_Price, original_CategoryID);
                    ProductsGrid.ItemsSource = products.GetData();
                }
            }
            else
            {
                MessageBox.Show("No product selected.");
            }
        }
        private void ProductsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)ProductsGrid.SelectedItem;
                ProductsNameTbx.Text = selectedRow["ProductsName"].ToString();

                // Вывод значения BrandID в ComboBox
                BrandsGrid.SelectedValue = selectedRow["BrandID"];

                // Вывод значения Price в ComboBox
                // Здесь предполагается, что у Вас есть ComboBox для Price
                PriceTbx.Text = selectedRow["Price"].ToString();

                // Вывод значения CategoryID в ComboBox
                CategoriesGrid.SelectedValue = selectedRow["CategoryID"];
            }
        }
        private void CategoriesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesGrid.SelectedItem != null)
            {
                int selectedCategoryID = (int)CategoriesGrid.SelectedValue;
                MessageBox.Show(selectedCategoryID.ToString());
            }
        }

        private void BrandsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrandsGrid.SelectedItem != null && BrandsGrid.SelectedValue != null)
            {
                if (int.TryParse(BrandsGrid.SelectedValue.ToString(), out int selectedBrandID))
                {
                    MessageBox.Show(selectedBrandID.ToString());
                }
            }
        }

    }
}

