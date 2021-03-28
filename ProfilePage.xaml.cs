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
using Microsoft.Win32;

namespace InstaMilligram
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            if (StaticVars.UserId != "")
            {
                List<string> userData = SQLClass.Select(
                    "SELECT \"Login\", \"Info\" FROM \"Users\" WHERE \"Id\" = '" + StaticVars.UserId + "'");

                if (userData.Count >= 2)
                {
                    RegisterBtn.Content = "Обновить профиль";
                    LoginTB.Text = userData[0];
                    AboutMeTB.Text = userData[1];

                    try
                    {
                        BitmapImage image = SQLClass.SelectImage(
                            "SELECT \"Photo\" FROM \"Users\" WHERE \"Id\" = '" + StaticVars.UserId + "'");
                        if (image != null)
                            Photo.Source = image;
                    }
                    catch (Exception) { }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StaticVars.UserId != "")
            {
                SQLClass.Insert("UPDATE \"Users\"" +
                    " SET \"Login\" = '" + LoginTB.Text + "', " +
                    "\"Password\" = '" + PassTB.Text + "', " +
                    "\"Info\" = '" + AboutMeTB.Text + "'" +
                    " WHERE \"Id\" = " + StaticVars.UserId);
            }
            else
            {
                SQLClass.Insert("INSERT INTO \"Users\"(\"Login\", \"Password\", \"Info\")" +
                    " VALUES('" + LoginTB.Text + "'," +
                    "'" + PassTB.Text + "'," +
                    "'" + AboutMeTB.Text + "')");
            }

            if (picAddress != "")
                SQLClass.UpdateImg("UPDATE \"Users\" SET \"Photo\" = @Image WHERE \"Login\" = '" + LoginTB.Text + "'", picAddress);


            if (StaticVars.UserId == "")
            {
                MessageBox.Show("Вы успешно зарегистрированы");

                StaticVars.Login = LoginTB.Text;
                StaticVars.UserId = SQLClass.Select("SELECT MAX(\"Id\") FROM \"Users\" WHERE \"Login\" = '" + LoginTB.Text + "'")[0];
            }
            else
            {
                MessageBox.Show("Профиль успешно обновлен");
            }
        }


        string picAddress = "";
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if ((bool)openFile.ShowDialog())
            {
                picAddress = openFile.FileName;
                Photo.Source =
                    new BitmapImage(new Uri(openFile.FileName, UriKind.Absolute)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache }; ;
            }
        }
    }
}
