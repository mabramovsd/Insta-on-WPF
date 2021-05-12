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
        private readonly string author = "";
        private readonly string authorId = "";
        private string text = "";
        private readonly BitmapImage sourceImg = new BitmapImage();
        private readonly BitmapImage sourceAuthorImg = new BitmapImage();

        public PostUC()
        {
            InitializeComponent();
            AuthorImg.Width = 0;
            PostAuthor.Text = "";
            LikesPanel.Children.Clear();
        }
        public PostUC(BitmapImage _sourceImg, string _authorId, string _author, BitmapImage _sourceAuthorImg, string _dt, string _text)
        {
            InitializeComponent();
            text = _text;
            author = _author;
            authorId = _authorId;
            sourceImg = _sourceImg;
            PostImage.Source = sourceImg;
            PostAuthor.Text = author;
            sourceAuthorImg = _sourceAuthorImg;

            AuthorImg.Source = sourceAuthorImg;
            AuthorImg.ToolTip = "Профиль пользователя " + author;
            PostAuthor.ToolTip = "Профиль пользователя " + author;

            dtField.Text = _dt;
        }

        private void OpenTape(object sender, RoutedEventArgs e)
        {
            StaticVars.MainWnd.Content = new TapePage(authorId, author);
        }
    }
}
