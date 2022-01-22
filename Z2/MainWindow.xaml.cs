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

namespace Z2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        libraryEntities context;
        public MainWindow()
        {
            InitializeComponent();
            var Login = new Windows.LoginPage();
            Login.ShowDialog();
            context = new libraryEntities();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridInstRelease.ItemsSource = context.Instance_Release.ToList();
        }

        private void BtnSelectBook_Click(object sender, RoutedEventArgs e)
        {
            var BooksList = new Windows.BooksWindow();
            BooksList.ShowDialog();
        }

        private void BtnSelectReaders_Click(object sender, RoutedEventArgs e)
        {
            var ReadersList = new Windows.ReadersWindow();
            ReadersList.ShowDialog();
        }

        private void BtnSelectAuthors_Click(object sender, RoutedEventArgs e)
        {
            var AuthorsList = new Windows.AuthorsWindow();
            AuthorsList.ShowDialog();
        }
        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
