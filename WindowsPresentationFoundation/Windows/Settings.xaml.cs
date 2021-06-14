using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Threading;
using System.Windows;

namespace WindowsPresentationFoundation
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            SettingsFile.gender = (bool)rbtnFemale.IsChecked;
            SettingsFile.country = String.Empty;
            Repository.SaveSettings();
            new MainWindow().Show();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }

        private void BtnLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentCulture.Name == Repository.HR)
            {
                Repository.SetCulture(Repository.EN);
                SettingsFile.language = "Croatian";
            }
            else
            {
                Repository.SetCulture(Repository.HR);
                SettingsFile.language = "Engleski";
            }
        }

        private void LoadGender()
        {
            if (SettingsFile.gender)
            {
                rbtnFemale.IsChecked = true;
            }
            else
            {
                rbtnMale.IsChecked = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
            LoadGender();
        }

        private void Btn480p_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn720p_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn1080p_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}