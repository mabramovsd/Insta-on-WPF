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

namespace InstaMilligram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Content = new GuestPage();
            SQLClass.OpenConnection();
            StaticVars.MainWnd = frame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ProfilePage();
        }
        private void OpenTape(object sender, RoutedEventArgs e)
        {
            frame.Content = new TapePage();
        }

        private void NewPost(object sender, RoutedEventArgs e)
        {
            frame.Content = new AddPost();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SQLClass.CloseConnection();
        }
    }
}
