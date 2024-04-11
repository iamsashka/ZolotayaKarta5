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
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        EmployeesTableAdapter employees = new EmployeesTableAdapter();
        public Employees()
        {
            InitializeComponent();
            EmployeesGrid.ItemsSource = employees.GetData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmployeesFirstNameTbx.Text) || string.IsNullOrWhiteSpace(EmployeesLastNameTbx.Text) || string.IsNullOrWhiteSpace(PositionTbx.Text) || string.IsNullOrWhiteSpace(SalaryTbx.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Не заполнены обязательные поля", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int salary;
            if (!int.TryParse(SalaryTbx.Text, out salary))
            {
                MessageBox.Show("Пожалуйста, введите корректную зарплату.", "Неверная зарплата", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            employees.InsertQuery(EmployeesFirstNameTbx.Text, EmployeesLastNameTbx.Text, PositionTbx.Text, salary, 1);
            EmployeesGrid.ItemsSource = employees.GetData();

            EmployeesFirstNameTbx.Clear();
            EmployeesLastNameTbx.Clear();
            PositionTbx.Clear();
            SalaryTbx.Clear();

            EmployeesFirstNameTbx.Focus();
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EmployeesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)EmployeesGrid.SelectedItem;
                EmployeesFirstNameTbx.Text = selectedRow["FirstName"].ToString();
                EmployeesLastNameTbx.Text = selectedRow["LastName"].ToString();
                PositionTbx.Text = selectedRow["Position"].ToString();
                SalaryTbx.Text = selectedRow["Salary"].ToString();
            }

        }

        private void EmployeesFirstNameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EmployeesLastNameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PositionTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SalaryTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


