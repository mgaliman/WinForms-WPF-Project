using DataAccessLayer.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WindowsPresentationFoundation.Windows
{
    /// <summary>
    /// Interaction logic for PlayerInfoWindow.xaml
    /// </summary>
    public partial class PlayerInfoWindow : Window
    {
        StartingEleven player = new StartingEleven();
        public PlayerInfoWindow(StartingEleven player)
        {
            InitializeComponent();
            this.player = player;
            Init();
        }

        private void Init()
        {
            string name = player.Name;
            name = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(name.ToLower());
            lblNameData.Content = name;
            lblShirtNumberData.Content = player.ShirtNumber;
            lblPositionData.Content = player.Position;
            lblCaptainData.Content = player.Captain;
            lblScoredGoalsData.Content = "null";
            lblYellowCardsData.Content = "null";

            var uriSource = new Uri(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"DataAccessLayer/pictures/defaultUser.png"));
            PlayerImage.Source = new BitmapImage(uriSource);
            string[] filePaths = Directory.GetFiles(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"Pictures/Saved/"));
            for (int i = 0; i < filePaths.Length; i++)
            {
                string exactFile = ($"{filePaths[i].Substring(filePaths[i].IndexOf("d/") + 2)}");
                string parsedFile = exactFile.Remove(exactFile.IndexOf('.'));
                if (name == parsedFile)
                {
                    uriSource = new Uri(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"Pictures/Saved/{name}.jfif"));
                    PlayerImage.Source = new BitmapImage(uriSource);
                }
            }
        }
    }
}
