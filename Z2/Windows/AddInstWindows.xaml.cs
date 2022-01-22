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
    /// Логика взаимодействия для AddInstWindows.xaml
    /// </summary>
    public partial class AddInstWindows : Window
    {
        libraryEntities context;
        public AddInstWindows(libraryEntities context, Instance_Release instance_Release)
        {
            InitializeComponent();
            this.context = context;
            CmbReaders.ItemsSource = context.Readers.ToList();
            CmbBooks.ItemsSource = context.Books.ToList();
            this.DataContext = instance_Release;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
