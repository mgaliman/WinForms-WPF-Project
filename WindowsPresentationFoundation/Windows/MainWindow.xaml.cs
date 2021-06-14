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
        HashSet<Matches> matches = new HashSet<Matches>();
        HashSet<Teams> teams = new HashSet<Teams>();
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
            try
            {
                teams = await Repository.LoadJsonCountries();

                foreach (var teamItem in teams)
                {
                    ddlCountries.Items.Add(teamItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void DdlCountries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SettingsFile.country = ddlCountries.SelectedItem.ToString().Substring(0, ddlCountries.SelectedItem.ToString().IndexOf("(")).Trim();
            Repository.SaveSettings();
            ddlVersusCountries.Items.Clear();
            FillPlayerData();
        }

        private void DdlVersusCountries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {                
                SettingsFile.versusCountry = ddlVersusCountries.SelectedItem.ToString();
                Repository.SaveSettings();
                GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetResult()
        {            
            foreach (var resultItems in matches)
            {
                if (SettingsFile.country == resultItems.HomeTeamStatistics.Country)
                {
                    lblResult.Content = $"{resultItems.HomeTeam.Goals} : {resultItems.AwayTeam.Goals}";
                }
            }            
        }

        private async void FillPlayerData()
        {
            try
            {                
                matches = await Repository.LoadJsonPlayers();

                foreach (var matchesItem in matches)
                {
                    if (matchesItem.HomeTeamStatistics.Country == SettingsFile.country)
                    {                        
                        ddlVersusCountries.Items.Add(matchesItem.AwayTeamCountry);                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }        
    }
}
