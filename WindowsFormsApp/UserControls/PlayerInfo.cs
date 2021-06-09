using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class PlayerInfo : UserControl    
    {
        public Player Player { get; private set; }
        

        public PlayerInfo(Player player)
        {
            InitializeComponent();
            Player = player;
            SetData(player);
            AllowDrop = true;            
        }
        private void SetData(Player player)
        {
            lblName.Text = player.Name;
            lblShirtNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position.ToString();
            lblCaptain.Text = player.Captain ? "Captain" : " ";
            lblFavourite.Text = player.Favourite ? "Favourite" : "No Favourite";
            pbPlayer.Image = Repository.GetPicture();
            player.Picture = pbPlayer.Image;
        }

        private void PlayersInfo_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerInfo playerInfo = sender as PlayerInfo;
            if (e.Button == MouseButtons.Left)
            {
                playerInfo.DoDragDrop(playerInfo, DragDropEffects.Copy); 
            }
        }

        private void EditToolStripMenuItem_Click(object sender, System.EventArgs e)
        {            
            PictureBox pictureBox = pbPlayer;
            FrmChangePicture frm = new FrmChangePicture(pictureBox);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = frm.GetUpdatedPicture().Image;
            }
            frm.Refresh();
        }

        private void AddToFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
