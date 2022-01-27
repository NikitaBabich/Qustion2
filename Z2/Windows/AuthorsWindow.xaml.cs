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
    /// Логика взаимодействия для AuthorsWindow.xaml
    /// </summary>
    public partial class AuthorsWindow : Window
    {
        libraryEntities context;
        public AuthorsWindow()
        {
            InitializeComponent();
            context = new libraryEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridAuthors.ItemsSource = context.Authors.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewAuthor = new Author();
            context.Authors.Add(NewAuthor);
            var NewWind = new Windows.AddAuthorWindow(context, NewAuthor);
            NewWind.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentAuthor = DataGridAuthors.SelectedItem as Author;
            if (currentAuthor == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Authors.Remove(currentAuthor);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentAuthor = BtnEdit.DataContext as Author;
            var EditWindow = new Windows.AddAuthorWindow(context, currentAuthor);
            EditWindow.ShowDialog();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridAuthors.ItemsSource = context.Authors.Where(x => x.Surname.Contains(TxtSearch.Text)).ToList();
        }
    }
}
