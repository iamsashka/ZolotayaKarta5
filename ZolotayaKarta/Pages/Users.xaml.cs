using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        UsersTableAdapter users = new UsersTableAdapter();
        public Users()
        {
            InitializeComponent();
            UsersGrid.ItemsSource = users.GetData();
        }
        private static string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                string sb = "";
                for (int i = 0; i < hash.Length; i++)
                {
                    sb += hash[i].ToString("x2");
                }
                return sb;
            }
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            UsersGrid.Columns[0].Header = "Код пользователя";
            UsersGrid.Columns[1].Header = "Логин";
            UsersGrid.Columns[2].Header = "Пароль";
            UsersGrid.Columns[3].Header = "Название роли";
        }

        private void RoleTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;

            bool containsDigits = input.Any(char.IsDigit);

            if (containsDigits)
            {
                MessageBox.Show("В поле должны быть введены тольео буквы!");
                textBox.Text = string.Empty;
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTbx.Text) || string.IsNullOrWhiteSpace(PasswordTbx.Password) || string.IsNullOrWhiteSpace(RoleTbx.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Не заполнены обязательные поля", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            users.InsertQuery(LoginTbx.Text, Hash(PasswordTbx.Password), RoleTbx.Text);
            UsersGrid.ItemsSource = users.GetData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView selectedRow = (DataRowView)UsersGrid.SelectedItem;
            int Original_user_id = (int)selectedRow.Row["user_id"];

            try
            {
                users.DeleteQuery(Original_user_id);
                UsersGrid.ItemsSource = users.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку для обновления.", "Ни одна строка не выбрана", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(LoginTbx.Text) || string.IsNullOrWhiteSpace(PasswordTbx.Password) || string.IsNullOrWhiteSpace(RoleTbx.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Не заполнены обязательные поля", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DataRowView selectedRow = (DataRowView)UsersGrid.SelectedItem;
            int Original_user_id = (int)selectedRow.Row["user_id"];
            string Original_Login = (string)selectedRow.Row["Login"];
            string Original_Password = (string)selectedRow.Row["Password"];
            string Original_Role = (string)selectedRow.Row["Role"];

            users.UpdateQuery(LoginTbx.Text, Hash(PasswordTbx.Password), RoleTbx.Text, Original_user_id, Original_Login, Original_Password, Original_Role);
            UsersGrid.ItemsSource = users.GetData();
        }
        private void UsersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)UsersGrid.SelectedItem;
                LoginTbx.Text = selectedRow["user_id"].ToString();
            }

        }

        private void LoginTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                var text = textBox.Text;
                if (text.Any(c => !char.IsLetter(c) && !char.IsDigit(c) && c != ' '))
                {
                    MessageBox.Show("Пожалуйста, вводите только текст или цифры в поле логина.", "Недопустимый символ", MessageBoxButton.OK, MessageBoxImage.Warning);
                    textBox.SelectAll();
                    textBox.Focus();
                }
            }
        }


        private void PasswordTbx_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var textBox = sender as PasswordBox;
            if (textBox != null && textBox.Password.Length > 8)
            {
                MessageBox.Show("Пожалуйста, введите пароль не более 8 символов.", "Длина пароля превышена", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBox.SelectAll();
                textBox.Focus();
            }
        }

        
    }
}
