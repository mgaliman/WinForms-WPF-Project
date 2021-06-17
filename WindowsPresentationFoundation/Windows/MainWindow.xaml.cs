using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Windows;
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
            Repository.LoadSettings();
            Repository.LoadLanguage();
            FillData();
            ddlCountries.SelectedItem = SettingsFile.country;
            ddlVersusCountries.SelectedItem = SettingsFile.versusCountry;
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
            SettingsFile.country = ddlCountries.SelectedItem.ToString().Substring(0, ddlCountries.SelectedItem.ToString().IndexOf("(")).Trim();
            Repository.SaveSettings();
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
