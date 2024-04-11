using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using ZolotayaKarta.Practica5DataSetTableAdapters;

namespace ZolotayaKarta
{
    /// <summary>
    /// Логика взаимодействия для Brands1.xaml
    /// </summary>
    public partial class Brands1 : Page
    {
        BrandsTableAdapter brands = new BrandsTableAdapter();
        public Brands1()
        {
            InitializeComponent();
            BrandsGrid.ItemsSource = brands.GetData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BrandsGrid.Columns[0].Header = "Код бренда";
            BrandsGrid.Columns[1].Header = "Название бренда";
           
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BrandNameTbx.Text))
            {
                MessageBox.Show("Пожалуйста, введите название бренда.", "Не заполнено обязательное поле", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            brands.InsertQuery(BrandNameTbx.Text);
            BrandsGrid.ItemsSource = brands.GetData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (BrandsGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.", "Ни одна строка не выбрана", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView selectedRow = (DataRowView)BrandsGrid.SelectedItem;
            int Original_CategoryID = (int)selectedRow.Row["BrandID"];
            string Original_CategoryName = (string)selectedRow.Row["BrandName"];

            try
            {
                brands.DeleteQuery(Original_CategoryID, Original_CategoryName);
                BrandsGrid.ItemsSource = brands.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (BrandsGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку для обновления.", "Ни одна строка не выбрана", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(BrandNameTbx.Text))
            {
                MessageBox.Show("Пожалуйста, введите название бренда.", "Не заполнено обязательное поле", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView selectedRow = (DataRowView)BrandsGrid.SelectedItem;
            int Original_BrandID = (int)selectedRow.Row["BrandID"];
            string Original_BrandName = (string)selectedRow.Row["BrandName"];

            brands.UpdateQuery(BrandNameTbx.Text, Original_BrandID, Original_BrandName);
            BrandsGrid.ItemsSource = brands.GetData();
        
    }
        private void BrandsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrandsGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)BrandsGrid.SelectedItem;
                BrandNameTbx.Text = selectedRow["BrandName"].ToString();
            }

        }

        private void btnJson_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            CommonFileDialogResult result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                string jsonText = File.ReadAllText(dialog.FileName);
                List<Brands> brandList = JsonConvert.DeserializeObject<List<Brands>>(jsonText);

                BrandsTableAdapter directorsTableAdapter = new BrandsTableAdapter();

                foreach (Brands brand in brandList)
                {
                    brands.InsertQuery(brand.BrandName);
                }

                BrandsGrid.ItemsSource = brands.GetData();
                BrandsGrid.Columns[1].Header = "Название бренда: ";
                

                MessageBox.Show("Данные успешно импортированы в таблицу");
            }

        }
    }
}
