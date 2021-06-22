using DataAccessLayer.Models;
using System.Windows.Controls;
using WindowsPresentationFoundation.Windows;

namespace WindowsPresentationFoundation.UserControls
{
    /// <summary>
    /// Interaction logic for UCPlayer.xaml
    /// </summary>
    public partial class UCPlayer : UserControl
    {
        StartingEleven player = new StartingEleven();
        public UCPlayer(StartingEleven startingEleven)
        {
            InitializeComponent();
            player = startingEleven;

            string name = startingEleven.Name;
            name = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(name.ToLower());
            lblPlayer.Content = name;
            lblShirtNumber.Content = startingEleven.ShirtNumber;
        }
        public string PlayerName { get; set; }
        public int ShirtNumber { get; set; }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new PlayerInfoWindow(player).Show();
        }
    }
}
