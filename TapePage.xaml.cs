using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace InstaMilligram
{
    /// <summary>
    /// Логика взаимодействия для TapePage.xaml
    /// </summary>
    public partial class TapePage : Page
    {
        public TapePage(string UserId = "", string UserName = "")
        {
            InitializeComponent();

            Fr.Children.Clear();
            string commandText =
                "SELECT DT, Text, Posts.Id, Users.Id, Users.Login" +
                " FROM Posts JOIN Users ON Posts.UserId = Users.Id";
            if (UserId != "")
                commandText += " WHERE Users.Id = " + UserId;
            commandText +=    " ORDER BY DT DESC";
            List<string> posts = SQLClass.Select(commandText);

            for (int i = 0; i < posts.Count; i += 5)
            {
                BitmapImage image = SQLClass.SelectImage(
                    "SELECT Photo FROM Posts WHERE Id = " + posts[i + 2]);
                BitmapImage authorImg = SQLClass.SelectImage(
                    "SELECT Photo FROM Users WHERE Id = " + posts[i + 3]);
                if (image == null)
                    image = new BitmapImage(new Uri("../Resources/Nothing.png", UriKind.Relative));
                if (authorImg == null)
                    authorImg = new BitmapImage(new Uri("../Resources/Nothing.png", UriKind.Relative));

                PostUC postUC = new PostUC(image, posts[i+3], posts[i + 4], authorImg, posts[i], posts[i + 1]);
                Fr.Children.Add(postUC);
            }

            if (posts.Count < 10)
                Fr.Children.Add(new PostUC());
            if (posts.Count < 15)
                Fr.Children.Add(new PostUC());

            if (UserId != "" && UserName != "")
            {
                TapeText.Text = "Лента пользователя " + UserName;
                try
                {
                    BitmapImage image = SQLClass.SelectImage(
                         "SELECT Photo FROM Users WHERE Id = " + UserId);
                    if (image.Width > 0)
                    {
                        Image img = new Image();
                        img.Height = 30;
                        img.Source = image;
                        TapeData.Children.Clear();
                        TapeData.Children.Add(img);
                        TapeData.Children.Add(TapeText);
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
