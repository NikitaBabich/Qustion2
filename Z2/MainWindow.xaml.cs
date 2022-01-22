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
            //var Login = new Windows.LoginPage();
            //Login.ShowDialog();
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
            var NewZap = new Instance_Release();
            context.Instance_Release.Add(NewZap);
            var NewWind = new Windows.AddInstWindows(context, NewZap);
            NewWind.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentZap = DataGridInstRelease.SelectedItem as Instance_Release;
            if (currentZap == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Instance_Release.Remove(currentZap);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentZap = BtnEdit.DataContext as Instance_Release;
            var EditWindow = new Windows.AddInstWindows(context, currentZap);
            EditWindow.ShowDialog();
        }
    }
}
