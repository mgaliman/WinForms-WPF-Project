using DataAccessLayer;
using DataAccessLayer.Models;
using System;
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
            Init();
            InitializeComponent();
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
            SettingsFile.language = (bool)rbtnEnglish.IsChecked ? "Croatian" : "Engleski";
            SettingsFile.country = String.Empty;
            Repository.SaveSettings();
            new MainWindow().Show();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
            LoadGender();
            LoadLanguage();
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

        private void LoadLanguage()
        {
            if (SettingsFile.language == "Croatian")
            {
                rbtnEnglish.IsChecked = true;
            }
            else
            {
                rbtnCroatian.IsChecked = true;
            }
        }

        //private void LoadResolution()
        //{
        //    if (false)
        //    {
        //        rbtn480p.IsChecked = true;
        //    }
        //    else if (false)
        //    {
        //        rbtn720p.IsChecked = true;
        //    }
        //    else
        //    {
        //        rbtn1080p.IsChecked = true;
        //    }
        //}
    }
}