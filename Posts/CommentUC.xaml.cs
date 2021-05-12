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
    /// Логика взаимодействия для CommentUC.xaml
    /// </summary>
    public partial class CommentUC : UserControl
    {
        private readonly string id;
        private readonly string userId;
        private readonly string userName;
        private readonly string dt;
        private readonly string text;
        private readonly string myLks;
        public CommentUC(string _id, string _userId, string _userName, string _dt, string _text, string _myLks)
        {
            id = _id;
            userId = _userId;
            userName = _userName;
            text = _text;
            dt = _dt;
            myLks = _myLks;
            InitializeComponent();

            img.ToolTip = "Профиль пользователя " + userName;

            BitmapImage image = SQLClass.SelectImage(
                "SELECT Photo FROM Users WHERE Id = '" + userId + "'");
            if (image != null)
                img.Source = image;

            CommentText.Text = text;

            if (myLks != "0")
            {
                heart.Source = new BitmapImage(new Uri("../Resources/heart2.png", UriKind.Relative));
                heart.Tag = "DisLike";
            }
            else
            {
                heart.Source = new BitmapImage(new Uri("../Resources/heart.png", UriKind.Relative));
                heart.Tag = "Like";
            }
        }
        private void OpenProfile(object sender, RoutedEventArgs e)
        {
            TapePage tape = new TapePage(userId, userName);
            StaticVars.MainWnd.Content = tape;
        }
        private void LikeComment(object sender, RoutedEventArgs e)
        {
            if (StaticVars.UserId != "")
            {
                if (heart.Tag.ToString() == "Like")
                {
                    SQLClass.Insert("DELETE FROM CommentLikes WHERE UserId = " + StaticVars.UserId +
                        " AND CommentId = " + id);
                    SQLClass.Insert("INSERT INTO CommentLikes(UserId, CommentId)" +
                        " VALUES (" + StaticVars.UserId + "," + id + ")");
                    
                    heart.Source = new BitmapImage(new Uri("../Resources/heart2.png", UriKind.Relative));
                    heart.Tag = "DisLike";
                }
                else
                {
                    SQLClass.Insert("DELETE FROM CommentLikes WHERE UserId = " + StaticVars.UserId +
                        " AND CommentId = " + id);
                    heart.Source = new BitmapImage(new Uri("../Resources/heart.png", UriKind.Relative));
                    heart.Tag = "Like";
                }
            }
        }
    }
}
