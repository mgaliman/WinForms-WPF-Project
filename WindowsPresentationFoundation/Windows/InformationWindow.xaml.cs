using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Windows;

namespace WindowsPresentationFoundation.Windows
{
    /// <summary>
    /// Interaction logic for InformationWindow.xaml
    /// </summary>
    public partial class InformationWindow : Window
    {
        Teams team = new Teams();
        public InformationWindow(Teams team)
        {
            InitializeComponent();
            this.team = team;
            Init();
        }
        private void Init()
        {
            lblCountryData.Content = team.Country;
            lblCodeData.Content = team.FifaCode;
            lblGamesPlayedData.Content = team.GamesPlayed;
            lblWinsData.Content = team.Wins;
            lblLossesData.Content = team.Losses;
            lblDrawsData.Content = team.Draws;
            lblGoalsForData.Content = team.GoalDifferential;
            lblGoalsAgainstsData.Content = team.GoalsAgainst;
            lblGoalDifferentialData.Content = team.GoalDifferential;
        }
    }
}
