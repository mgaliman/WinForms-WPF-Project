using DataAccessLayer;
using DataAccessLayer.Models;
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
            if ((bool)rbtn480p.IsChecked)
            {
                SettingsFile.resolution = "480p";
            }
            else if ((bool)rbtn720p.IsChecked)
            {
                SettingsFile.resolution = "720p";
            }
            else if ((bool)rbtn1080p.IsChecked)
            {
                SettingsFile.resolution = "1080p";
            }
            else
            {
                SettingsFile.resolution = "FullScreen";
            }
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
            LoadResolution();
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

        private void LoadResolution()
        {
            switch (SettingsFile.resolution)
            {
                case "480p":
                    rbtn480p.IsChecked = true;
                    break;
                case "720p":
                    rbtn720p.IsChecked = true;
                    break;
                case "1080p":
                    rbtn1080p.IsChecked = true;
                    break;
                case "FullScreen":
                    rbtnFullScreen.IsChecked = true;
                    break;
            }
        }
    }
}