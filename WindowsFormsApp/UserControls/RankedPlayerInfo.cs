using DataAccessLayer;
using DataAccessLayer.Models;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class RankedPlayerInfo : UserControl
    {
        public TeamEvent Player { get; private set; }

        public RankedPlayerInfo(TeamEvent player)
        {
            InitializeComponent();
            Player = player;
            SetData(player);
        }

        private void SetData(TeamEvent player)
        {
            lblName.Text = player.Player;
            lblGoals.Text = "Goals: " + player.Goals.ToString();
            lblYellowCards.Text = "Yellow cards:" + player.YellowCards.ToString();
            pbRankedPlayer.Image = Repository.GetPicture();
            player.RankedPicture = pbRankedPlayer.Image;
        }
    }
}
