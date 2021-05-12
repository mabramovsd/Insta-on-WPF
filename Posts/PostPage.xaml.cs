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
    /// Логика взаимодействия для PostPage.xaml
    /// </summary>
    public partial class PostPage : Page
    {
        string id = "";
        private readonly string authorId;
        private readonly string authorName;
        public PostPage(BitmapImage sourceImg, string _userId, string _userName, BitmapImage sourceAuthorImg, string _dt, string _text, string lks, string _myLKS, string _id)
        {
            InitializeComponent();
            id = _id;
            authorId = _userId;
            authorName = _userName;
            img.Source = sourceImg;

            dt.Text = _dt;
            likes.Text = lks;
            PostAuthor.Text = authorName;
            PostAuthor.ToolTip = "Профиль пользователя " + authorName;
            AuthorImg.ToolTip = "Профиль пользователя " + authorName;
            AuthorImg.Source = sourceAuthorImg;
            PostText.Text = _text;

            if (_myLKS != "0")
            {
                heart.Source = new BitmapImage(new Uri("../Resources/heart2.png", UriKind.Relative));
                heart.Tag = "DisLike";
            }
            else
            {
                heart.Source = new BitmapImage(new Uri("../Resources/heart.png", UriKind.Relative));
                heart.Tag = "Like";
            }
            RefreshComments();
        }

        private void RefreshComments()
        {
            Com.Children.Clear();
            List<string> comments = SQLClass.Select(
               "SELECT comments.Id, comments.UserId, users.Login, DT, Text, COUNT(clk2.*) " +
               " FROM comments" +
               " JOIN users ON comments.UserId = users.Id" +
               " LEFT JOIN commentlikes clk2 ON comments.Id = clk2.CommentId AND clk2.UserId = 0" + StaticVars.UserId +
               " WHERE PostId = " + id +
               " GROUP BY comments.Id, comments.UserId, users.Login, DT, Text");

            for (int i = 0; i < comments.Count; i += 6)
            {
                CommentUC newComment = new CommentUC(comments[i], comments[i + 1], comments[i + 2], comments[i + 3], comments[i + 4], comments[i + 5]);
                Com.Children.Add(newComment);
            }
        }

        private void OpenProfile(object sender, RoutedEventArgs e)
        {
            TapePage tape = new TapePage(authorId, authorName);
            StaticVars.MainWnd.Content = tape;
        }

        private void LikePost(object sender, RoutedEventArgs e)
        {
            if (StaticVars.UserId != "")
            {
                if (heart.Tag.ToString() == "Like")
                {
                    SQLClass.Insert("DELETE FROM Likes WHERE UserId = " + StaticVars.UserId +
                        " AND PostId = " + id);
                    SQLClass.Insert("INSERT INTO Likes(UserId, PostId)" +
                        " VALUES (" + StaticVars.UserId + "," + id + ")");

                    heart.Source = new BitmapImage(new Uri("../Resources/heart2.png", UriKind.Relative));
                    heart.Tag = "DisLike";
                    likes.Text = (Convert.ToInt32(likes.Text) + 1).ToString();
                }
                else
                {
                    SQLClass.Insert("DELETE FROM Likes WHERE UserId = " + StaticVars.UserId +
                        " AND PostId = " + id);
                    heart.Source = new BitmapImage(new Uri("../Resources/heart.png", UriKind.Relative));
                    heart.Tag = "Like";
                    likes.Text = (Convert.ToInt32(likes.Text) - 1).ToString();
                }
            }
        }

        private void AddComment(object sender, RoutedEventArgs e)
        {
            if (StaticVars.UserId != "" && NewComment.Text != "")
            {
                SQLClass.Insert("INSERT INTO Comments(UserId, PostId, DT, Text)" +
                    " VALUES (" + StaticVars.UserId + "," + id + ", now()::date, '" + NewComment.Text + "')");
                RefreshComments();
                NewComment.Text = "";
            }
        }
    }
}
