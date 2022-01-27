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
    /// Логика взаимодействия для ReadersWindow.xaml
    /// </summary>
    public partial class ReadersWindow : Window
    {
        libraryEntities context;
        public ReadersWindow()
        {
            InitializeComponent();
            context = new libraryEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridReaders.ItemsSource=context.Readers.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewReader = new Reader();
            context.Readers.Add(NewReader);
            var NewWind = new Windows.ReaderAddWindow(context, NewReader);
            NewWind.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentReader = DataGridReaders.SelectedItem as Reader;
            if (currentReader == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Readers.Remove(currentReader);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentReader = BtnEdit.DataContext as Reader;
            var EditWindow = new Windows.ReaderAddWindow(context, currentReader);
            EditWindow.ShowDialog();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridReaders.ItemsSource = context.Readers.Where(x => x.Surname.Contains(TxtSearch.Text)).ToList();
        }
    }
}
