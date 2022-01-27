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

namespace Z2.Windows
{
    /// <summary>
    /// Логика взаимодействия для BooksWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window
    {
        libraryEntities context;
        public BooksWindow()
        {
            InitializeComponent();
            context = new libraryEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridBooks.ItemsSource = context.Books.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewBook = new Book();
            context.Books.Add(NewBook);
            var NewWind = new BookAddWindow(context, NewBook);
            NewWind.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentBook = DataGridBooks.SelectedItem as Book;
            if (currentBook == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Books.Remove(currentBook);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentBook = BtnEdit.DataContext as Book;
            var EditWindow = new Windows.BookAddWindow(context, currentBook);
            EditWindow.ShowDialog();
        }
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridBooks.ItemsSource = context.Books.Where(x => x.Name.Contains(TxtSearch.Text)).Select(x => x.Name).ToList();
            DataGridBooks.ItemsSource = context.Books.Where(x => x.Name.Contains(TxtSearch.Text)).ToList();
        }
    }
}
