using DataAccessLayer.Models;
using System;
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
            lblNameData.Content = "null";
            lblShirtNumberData.Content = "null";
            lblPositionData.Content = "null";
            lblCaptainData.Content = "null";
            lblScoredGoalsData.Content = "null";
            lblYellowCardsData.Content = "null";
        }
    }
}
