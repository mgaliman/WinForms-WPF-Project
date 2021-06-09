using DataAccessLayer;
using DataAccessLayer.Models;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class RankedPlayerInfo : UserControl
    {
        public Player Player { get; private set; }

        public RankedPlayerInfo(Player player)
        {
            InitializeComponent();
            Player = player;
            SetData(player);
        }
        private void SetData(Player player)
        {
            lblName.Text = player.Name;
            lblGoals.Text = "Goals: " + player.Goals.ToString();
            lblYellowCards.Text = "Yellow cards:" + player.YellowCards.ToString();
            picture.Image = Repository.GetPicture();
            //picture.Image = player.Picture;
        }
    }
}
