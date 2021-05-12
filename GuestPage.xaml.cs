using System;
using System.Collections.Generic;
using System.Text;
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
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        public GuestPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StaticVars.Login = LoginTB.Text;
            string existUser = SQLClass.Select("SELECT COUNT(*) FROM Users WHERE Login = '" + LoginTB.Text + "'")[0];

            if (existUser != "0")
            {
                StaticVars.UserId = SQLClass.Select("SELECT MAX(Id) FROM Users WHERE Login = '" + LoginTB.Text + "'")[0];
                StaticVars.MainWnd.Content = new ProfilePage();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            StaticVars.Login = "";
            StaticVars.UserId = "";
            StaticVars.MainWnd.Content = new ProfilePage();
        }
    }
}
