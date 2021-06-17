using System.Windows.Controls;

namespace WindowsPresentationFoundation.UserControls
{
    /// <summary>
    /// Interaction logic for UCPlayer.xaml
    /// </summary>
    public partial class UCPlayer : UserControl
    {


        public UCPlayer()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string PlayerName { get; set; }
        public int ShirtNumber { get; set; }
    }
}
