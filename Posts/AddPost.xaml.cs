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
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InstaMilligram
{
    /// <summary>
    /// Логика взаимодействия для AddPost.xaml
    /// </summary>
    public partial class AddPost : Page
    {
        string photoAddress = "";
        public AddPost()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (photoAddress != "")
            {
                SQLClass.UpdateImg("INSERT INTO Posts(UserId, Photo, DT, Text) VALUES(" +
                    "'" + StaticVars.UserId + "', @Image, now()::date, '" + PostTB.Text + "')", photoAddress);
                MessageBox.Show("Сохранено");
            }
        }

        private void AddPhoto(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == true)
            {
                photoAddress = opf.FileName;
                Photo.Source =
                    new BitmapImage(new Uri(photoAddress, UriKind.Absolute)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache }; ;
            }
        }
    }
}
