using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class PlayerInfo : UserControl
    {
        public StartingEleven Player { get; private set; }
        public bool selected = false;

        //Save property
        public string FavouriteName { get; set; }

        public PlayerInfo(StartingEleven player)
        {
            InitializeComponent();
            Player = player;
            SetData(player);
        }
        private void SetData(StartingEleven player)
        {
            FavouriteName = player.Name;
            lblName.Text = player.Name;
            lblShirtNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position.ToString();
            lblCaptain.Text = player.Captain ? "Captain" : " ";
            lblFavourite.Text = selected ? "Favourite" : "Not Favourite ";
            pbPlayer.Image = Repository.GetPicture();
           
            string[] filePaths = Directory.GetFiles(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"Pictures/Saved/"));
            for (int i = 0; i < filePaths.Length; i++)
            {                
                string exactFile = ($"{filePaths[i].Substring(filePaths[i].IndexOf("d/") + 2)}");
                string parsedFile = exactFile.Remove(exactFile.IndexOf('.'));
                if (player.Name == parsedFile)
                {
                    pbPlayer.Image = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"Pictures/Saved/{Player.Name}.jfif"));
                }
                
            }
            player.Picture = pbPlayer.Image;
        }

        private void PlayersInfo_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerInfo playerInfo = sender as PlayerInfo;
            if (e.Button == MouseButtons.Left)
            {
                playerInfo.DoDragDrop(playerInfo, DragDropEffects.Move);
                if (selected)
                {
                    lblFavourite.Text = "Favourite";
                }
                else
                {
                    lblFavourite.Text = "Not Favourite";
                }
            }
        }

        private void EditToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            PictureBox pictureBox = pbPlayer;
            FrmChangePicture frm = new FrmChangePicture(pictureBox);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = frm.GetUpdatedPicture().Image;
                Image image = frm.GetUpdatedPicture().Image;
                image.Save(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"Pictures/Saved/{Player.Name}.jfif"));
            }
            frm.Refresh();
        }

        private void AddToFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
