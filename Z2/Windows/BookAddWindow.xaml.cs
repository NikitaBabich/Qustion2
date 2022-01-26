using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Z2.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookAddWindow.xaml
    /// </summary>
    public partial class BookAddWindow : Window
    {
        libraryEntities context1;
        public BookAddWindow(libraryEntities context, Book book)
        {
            InitializeComponent();
            this.context1 = context;
            CmbAuthor.ItemsSource = context1.Authors.ToList();
            CmbGenre.ItemsSource = context1.Genres.ToList();
            CmbPublishingHouse.ItemsSource = context1.Publishing_Houses.ToList();
            CmbType.ItemsSource = context1.Book_Type.ToList();
            this.DataContext = book;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            SaveImage();
            context1.SaveChanges();
            this.Close();
        }
        private void SaveImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png| *.jpg;*.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string namefile = openFile.FileName;
                byte[] image = File.ReadAllBytes(namefile);
                var book = (Book)this.DataContext;
                book.Photo = image;
                Img.Source = new BitmapImage(new Uri(namefile));
            }
        }
    }
}
