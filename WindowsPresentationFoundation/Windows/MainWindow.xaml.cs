using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
            FillData();
            FillPlayerData();
        }

        private async void FillData()
        {
            lblInfo.Content = "Waiting to fetch data!";

            try
            {
                HashSet<Teams> teams = await Repository.LoadJsonCountries();

                foreach (var orderedTeam in teams)
                {
                    ddlGroupResults.Items.Add(orderedTeam);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblInfo.Content = ex.Message;
            }
        }

        private void ddlGroupResults_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SettingsFile.country = ddlGroupResults.SelectedItem.ToString().Substring(0, ddlGroupResults.SelectedItem.ToString().IndexOf("(")).Trim();
            Repository.SaveSettings();
        }

        private async void FillPlayerData()
        {
            lblInfo.Content = "Fetching data...";
                        
            try
            {
                HashSet<Matches> teams = await Repository.LoadJsonPlayers();
                

                StartingEleven player = new StartingEleven();
                TeamEvent rankedPlayer = new TeamEvent();
                Matches stadium = new Matches();

                TeamEvent teamEvent = new TeamEvent();

                HashSet<StartingEleven> playerList = new HashSet<StartingEleven>();
                HashSet<TeamEvent> rankedPlayerList = new HashSet<TeamEvent>();
                HashSet<Matches> rankedStadiumList = new HashSet<Matches>();

                foreach (var players in teams)
                {
                    if (players.HomeTeamStatistics.Country == SettingsFile.country)
                    {
                        rankedStadiumList.Add(players);
                        foreach (var playerItem in players.HomeTeamStatistics.StartingEleven)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.HomeTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                        foreach (var playerItem in players.HomeTeamStatistics.Substitutes)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.HomeTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                    }
                    if (players.AwayTeamStatistics.Country == SettingsFile.country)
                    {
                        rankedStadiumList.Add(players);
                        foreach (var playerItem in players.AwayTeamStatistics.StartingEleven)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.AwayTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                        foreach (var playerItem in players.AwayTeamStatistics.Substitutes)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.AwayTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                    }
                }

                lblInfo.Content = SettingsFile.country;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblInfo.Content = ex.Message;
            }            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
            FillPlayerData();
        }
    }
}
