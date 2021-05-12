using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace InstaMilligram
{
    /// <summary>
    /// Логика взаимодействия для PostUC.xaml
    /// </summary>
    public partial class PostUC : UserControl
    {
        private readonly string id = "";
        private string lks = "";
        private string text = "";
        private string myLks = "";
        private readonly string author = "";
        private readonly string authorId = "";
        private readonly BitmapImage sourceImg = new BitmapImage();
        private readonly BitmapImage sourceAuthorImg = new BitmapImage();

        public PostUC()
        {
            InitializeComponent();
            AuthorImg.Width = 0;
            PostAuthor.Text = "";
            LikesPanel.Children.Clear();
        }
        public PostUC(BitmapImage _sourceImg, string _authorId, string _author, BitmapImage _sourceAuthorImg, string _dt, string _text, string _lks, string _myLks, string _id)
        {
            InitializeComponent();
            author = _author;
            authorId = _authorId;
            sourceImg = _sourceImg;
            PostImage.Source = sourceImg;
            PostAuthor.Text = author;
            sourceAuthorImg = _sourceAuthorImg;
            text = _text;
            lks = _lks;
            myLks = _myLks;
            id = _id;

            AuthorImg.Source = sourceAuthorImg;
            AuthorImg.ToolTip = "Профиль пользователя " + author;
            PostAuthor.ToolTip = "Профиль пользователя " + author;

            dtField.Text = _dt;
            likes.Text = lks;

            if (_myLks != "0")
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

        private void OpenTape(object sender, RoutedEventArgs e)
        {
            StaticVars.MainWnd.Content = new TapePage(authorId, author);
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
                    lks = (Convert.ToInt32(lks) + 1).ToString();
                    myLks = (Convert.ToInt32(myLks) + 1).ToString();
                    likes.Text = lks;
                }
                else
                {
                    SQLClass.Insert("DELETE FROM Likes WHERE UserId = " + StaticVars.UserId +
                        " AND PostId = " + id);
                    heart.Source = new BitmapImage(new Uri("../Resources/heart.png", UriKind.Relative));
                    heart.Tag = "Like";
                    lks = (Convert.ToInt32(lks) - 1).ToString();
                    myLks = (Convert.ToInt32(myLks) - 1).ToString();
                    likes.Text = lks;
                }
            }
        }
    }
}
