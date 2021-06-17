using DataAccessLayer.Models;
using System.Windows;

namespace WindowsPresentationFoundation.Windows
{
    /// <summary>
    /// Interaction logic for InformationWindow.xaml
    /// </summary>
    public partial class InformationWindow : Window
    {
        Results result = new Results();
        public InformationWindow(Results result)
        {
            InitializeComponent();
            this.result = result;
            Init();
        }
        private void Init()
        {
            lblCountryData.Content = result.Country;
            lblCodeData.Content = result.FifaCode;
            lblGamesPlayedData.Content = result.GamesPlayed;
            lblWinsData.Content = result.Wins;
            lblLossesData.Content = result.Losses;
            lblDrawsData.Content = result.Draws;
            lblGoalsForData.Content = result.GoalsFor;
            lblGoalsAgainstsData.Content = result.GoalsAgainst;
            lblGoalDifferentialData.Content = result.GoalDifferential;
        }
    }
}
