using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using WindowsPresentationFoundation.UserControls;
using WindowsPresentationFoundation.Windows;

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HashSet<Matches> matches = new HashSet<Matches>();
        HashSet<Results> results = new HashSet<Results>();
        HashSet<StartingEleven> startingEleven = new HashSet<StartingEleven>();

        Results country = new Results();
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadResolution();
            Repository.LoadSettings();
            Repository.LoadLanguage();
            FillData();
            ddlCountries.SelectedIndex = SettingsFile.countryIndex;
            ddlVersusCountries.SelectedIndex = SettingsFile.versusCountryIndex;
        }
        private void LoadResolution()
        {
            switch (SettingsFile.resolution)
            {
                case "480p":
                    Width = 800;
                    Height = 500;
                    break;
                case "720p":
                    Width = 1280;
                    Height = 720;
                    break;
                case "1080p":
                    Width = 1920;
                    Height = 1080;
                    break;
                case "FullScreen":
                    WindowState = WindowState.Maximized;
                    break;
            }
        }

        private async void FillData()
        {
            try
            {
                results = await Repository.LoadJsonResults();

                foreach (var resultItem in results)
                {
                    ddlCountries.Items.Add(resultItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DdlCountries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                SettingsFile.country = ddlCountries.SelectedItem.ToString().Substring(0, ddlCountries.SelectedItem.ToString().IndexOf("(")).Trim();
                SettingsFile.countryIndex = ddlCountries.SelectedIndex;
                Repository.SaveSettings();
                FillPlayerData();
                hGoalie.Children.Clear();
                hDefender.Children.Clear();
                hForward.Children.Clear();
                hMidField.Children.Clear();
                AddHomePlayers();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void AddHomePlayers()
        {
            foreach (var matchesItem in matches)
            {
                if (matchesItem.HomeTeamStatistics.Country == SettingsFile.country)
                {
                    startingEleven = new HashSet<StartingEleven>();
                    foreach (var startingElevenItem in matchesItem.HomeTeamStatistics.StartingEleven)
                    {
                        startingEleven.Add(startingElevenItem);                        
                    }                    
                }
            }
            foreach (var startingElevenItem in startingEleven)
            {
                switch (startingElevenItem.Position)
                {
                    case Position.Defender:
                        hDefender.Children.Add(new UCPlayer(startingElevenItem));
                        break;
                    case Position.Forward:
                        hForward.Children.Add(new UCPlayer(startingElevenItem));
                        break;
                    case Position.Goalie:
                        hGoalie.Children.Add(new UCPlayer(startingElevenItem));
                        break;
                    case Position.Midfield:
                        hMidField.Children.Add(new UCPlayer(startingElevenItem));
                        break;
                    default:
                        break;
                }
            }
        }

        private void DdlVersusCountries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                SettingsFile.versusCountry = ddlVersusCountries.SelectedItem.ToString();
                SettingsFile.versusCountryIndex = ddlVersusCountries.SelectedIndex;
                Repository.SaveSettings();
                GetResult();
                aGoalie.Children.Clear();
                aDefender.Children.Clear();
                aForward.Children.Clear();
                aMidField.Children.Clear();
                AddAwayPlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddAwayPlayers()
        {
            foreach (var matchesItem in matches)
            {
                if (matchesItem.AwayTeamStatistics.Country == SettingsFile.versusCountry)
                {
                    startingEleven = new HashSet<StartingEleven>();
                    foreach (var startingElevenItem in matchesItem.AwayTeamStatistics.StartingEleven)
                    {
                        startingEleven.Add(startingElevenItem);                        
                    }                    
                }
            }
            foreach (var startingElevenItem in startingEleven)
            {
                switch (startingElevenItem.Position)
                {
                    case Position.Defender:
                        aDefender.Children.Add(new UCPlayer(startingElevenItem));
                        break;
                    case Position.Forward:
                        aForward.Children.Add(new UCPlayer(startingElevenItem));
                        break;
                    case Position.Goalie:
                        aGoalie.Children.Add(new UCPlayer(startingElevenItem));
                        break;
                    case Position.Midfield:
                        aMidField.Children.Add(new UCPlayer(startingElevenItem));
                        break;
                    default:
                        break;
                }
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
                matches = await Repository.LoadJsonMatches();
                //ddlVersusCountries.Items.Clear();
                ddlVersusCountries.Items.Clear();
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
        private void Gif_MediaEnded(object sender, RoutedEventArgs e)
        {
            //gif.Position = new TimeSpan(0, 0, 1);
            //gif.Play();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnInfoCountry_Click(object sender, RoutedEventArgs e)
        {
            country = new Results();
            foreach (var item in results)
            {
                if (item.Country == SettingsFile.country)
                {
                    country = item;
                }
            }
            new InformationWindow(country).Show();
        }

        private void BtnInfoVersusCountry_Click(object sender, RoutedEventArgs e)
        {
            country = new Results();
            foreach (var item in results)
            {
                if (item.Country == SettingsFile.versusCountry)
                {
                    country = item;
                }
            }
            new InformationWindow(country).Show();
        }
    }
}
