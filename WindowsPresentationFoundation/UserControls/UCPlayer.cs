using DataAccessLayer.Models;
using System.Windows.Controls;

namespace WindowsPresentationFoundation.UserControls
{
    /// <summary>
    /// Interaction logic for UCPlayer.xaml
    /// </summary>
    public partial class UCPlayer : UserControl
    {
        public UCPlayer(StartingEleven startingEleven)
        {
            InitializeComponent();
            DataContext = this;
            lblPlayer.Content = startingEleven.Name;
            lblShirtNumber.Content = startingEleven.ShirtNumber;
        }
        public string PlayerName { get; set; }
        public int ShirtNumber { get; set; }
    }
}
