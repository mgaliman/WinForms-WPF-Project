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
                AddHomePlayers();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void AddHomePlayers()
        {
            List<StartingEleven> listDefender = new List<StartingEleven>();
            List<StartingEleven> listForward = new List<StartingEleven>();
            List<StartingEleven> listMidfield = new List<StartingEleven>();
            foreach (var matchesItem in matches)
            {
                if (matchesItem.HomeTeamStatistics.Country == SettingsFile.country)
                {
                    foreach (var StartingElevenItem in matchesItem.HomeTeamStatistics.StartingEleven)
                    {
                        switch (StartingElevenItem.Position)
                        {
                            case Position.Defender:
                                listDefender.Add(StartingElevenItem);
                                break;
                            case Position.Forward:
                                listForward.Add(StartingElevenItem);
                                break;
                            case Position.Goalie:
                                hGoalie.Content = new UCPlayer(StartingElevenItem);
                                break;
                            case Position.Midfield:
                                listMidfield.Add(StartingElevenItem);
                                break;
                            default:
                                break;
                        }
                    }
                    foreach (var StartingElevenItem in matchesItem.AwayTeamStatistics.StartingEleven)
                    {
                        switch (StartingElevenItem.Position)
                        {
                            case Position.Defender:
                                hDefender1.Content = new UCPlayer(listDefender[0]);
                                hDefender2.Content = new UCPlayer(listDefender[1]);
                                hDefender3.Content = new UCPlayer(listDefender[2]);
                                hDefender4.Content = new UCPlayer(listDefender[3]);
                                break;
                            case Position.Forward:
                                hForward1.Content = new UCPlayer(listForward[0]);
                                hForward2.Content = new UCPlayer(listForward[1]);
                                hForward3.Content = new UCPlayer(listForward[2]);
                                hForward4.Content = new UCPlayer(listForward[3]);
                                break;
                            case Position.Goalie:
                                //aGoalie.Content = new UCPlayer(StartingElevenItem);
                                break;
                            case Position.Midfield:
                                hMidField1.Content = new UCPlayer(listMidfield[0]);
                                hMidField2.Content = new UCPlayer(listMidfield[1]);
                                break;
                            default:
                                break;
                        }
                    }
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
                AddAwayPlayers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddAwayPlayers()
        {
            List<StartingEleven> listDefender = new List<StartingEleven>();
            List<StartingEleven> listForward = new List<StartingEleven>();
            List<StartingEleven> listMidfield = new List<StartingEleven>();
            foreach (var matchesItem in matches)
            {
                if (matchesItem.AwayTeamStatistics.Country == SettingsFile.versusCountry)
                {
                    foreach (var StartingElevenItem in matchesItem.AwayTeamStatistics.StartingEleven)
                    {                        
                        switch (StartingElevenItem.Position)
                        {
                            case Position.Defender:
                                listDefender.Add(StartingElevenItem);
                                break;
                            case Position.Forward:
                                listForward.Add(StartingElevenItem);
                                break;
                            case Position.Goalie:
                                aGoalie.Content = new UCPlayer(StartingElevenItem);
                                break;
                            case Position.Midfield:
                                listMidfield.Add(StartingElevenItem);
                                break;
                            default:
                                break;
                        }
                    }
                    foreach (var StartingElevenItem in matchesItem.AwayTeamStatistics.StartingEleven)
                    {                        
                        switch (StartingElevenItem.Position)
                        {
                            case Position.Defender:
                                aDefender1.Content = new UCPlayer(listDefender[0]);
                                aDefender2.Content = new UCPlayer(listDefender[1]);
                                aDefender3.Content = new UCPlayer(listDefender[2]);
                                aDefender4.Content = new UCPlayer(listDefender[3]);
                                break;
                            case Position.Forward:
                                aForward1.Content = new UCPlayer(listForward[0]);
                                aForward2.Content = new UCPlayer(listForward[1]);
                                aForward3.Content = new UCPlayer(listForward[2]);
                                aForward4.Content = new UCPlayer(listForward[3]);
                                break;
                            case Position.Goalie:
                                //aGoalie.Content = new UCPlayer(StartingElevenItem);
                                break;
                            case Position.Midfield:
                                aMidField1.Content = new UCPlayer(listMidfield[0]);
                                aMidField2.Content = new UCPlayer(listMidfield[1]);
                                break;
                            default:
                                break;
                        }
                    }
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
