using DataAccessLayer.Models;
using System.Windows;

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

            //HashSet<StartingEleven> startingEleven = new HashSet<StartingEleven>();
            //HashSet<TeamEvent> teamEvent = new HashSet<TeamEvent>();
            //TeamEvent scores = new TeamEvent();
            //foreach (var playerItem in startingEleven)
            //{

            //    foreach (var rankedItem in teamEvent)
            //    {
            //        if (playerItem.Name == rankedItem.Player)
            //        {

            //            switch (rankedItem.TypeOfEvent)
            //            {
            //                case "goal":
            //                    scores.Goals++;
            //                    break;
            //                case "yellow-card":
            //                    scores.YellowCards++;
            //                    break;
            //            }
            //        }
            //    }
            //}

        }
    }
}
