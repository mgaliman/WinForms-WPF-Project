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
            DataContext = this;
            lblPlayer.Content = startingEleven.Name;
            lblShirtNumber.Content = startingEleven.ShirtNumber;
        }
        public string PlayerName { get; set; }
        public int ShirtNumber { get; set; }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            player = new StartingEleven();
            
            new PlayerInfoWindow(player).Show();
        }
    }
}
