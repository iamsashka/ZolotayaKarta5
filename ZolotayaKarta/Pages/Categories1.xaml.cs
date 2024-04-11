using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
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
using ZolotayaKarta.Practica5DataSetTableAdapters;

namespace ZolotayaKarta
{
    /// <summary>
    /// Логика взаимодействия для Categories1.xaml
    /// </summary>
    public partial class Categories1 : Page
    {
        CategoriesTableAdapter categories = new CategoriesTableAdapter();
        public Categories1()
        {
            InitializeComponent();
            CategoriesGrid.ItemsSource = categories.GetData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryNameTbx.Text))
            {
                MessageBox.Show("Пожалуйста, введите название категории.", "Не заполнено обязательное поле", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            categories.InsertQuery(CategoryNameTbx.Text);
            CategoriesGrid.ItemsSource = categories.GetData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.", "Ни одна строка не выбрана", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView selectedRow = (DataRowView)CategoriesGrid.SelectedItem;
            int Original_CategoryID = (int)selectedRow.Row["CategoryID"];
            string Original_CategoryName = (string)selectedRow.Row["CategoryName"];

            try
            {
                categories.DeleteQuery(Original_CategoryID, Original_CategoryName);
                CategoriesGrid.ItemsSource = categories.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)CategoriesGrid.SelectedItem;
                int Original_CategoryID;
                string Original_CategoryName;

                if (!int.TryParse(selectedRow.Row["CategoryID"].ToString(), out Original_CategoryID))
                {
                    MessageBox.Show("Ошибка: Некорректный формат CategoryID", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Original_CategoryName = selectedRow.Row["CategoryName"].ToString();

                if (string.IsNullOrWhiteSpace(CategoryNameTbx.Text))
                {
                    MessageBox.Show("Ошибка: Поле CategoryName не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                categories.UpdateQuery(CategoryNameTbx.Text, Original_CategoryID, Original_CategoryName);
                CategoriesGrid.ItemsSource = categories.GetData();
            }
        }
        private void CategoriesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)CategoriesGrid.SelectedItem;
                CategoryNameTbx.Text = selectedRow["CategoryName"].ToString();
            }
        }

        private void btnJson_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            CommonFileDialogResult result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                string jsonText = File.ReadAllText(dialog.FileName);
                List<Categorie> categorieList = JsonConvert.DeserializeObject<List<Categorie>>(jsonText);

                CategoriesTableAdapter categories = new CategoriesTableAdapter();

                foreach (Categorie categorie in categorieList)
                {
                    categories.InsertQuery(categorie.CategoryName);
                }

                CategoriesGrid.ItemsSource = categories.GetData();
                CategoriesGrid.Columns[1].Header = "Название категории";
                

                MessageBox.Show("Данные успешно импортированы в таблицу");
            }
        }
    }
    
}


