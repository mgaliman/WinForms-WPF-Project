using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        HashSet<RankedPlayerInfo> userRankedPlayerControls = new HashSet<RankedPlayerInfo>();
        HashSet<RankedStadiumInfo> userRankedStadiumControls = new HashSet<RankedStadiumInfo>();

        List<TeamEvent> userRankedPlayerControlsList = new List<TeamEvent>();
        List<Matches> userRankedStadiumControlsList = new List<Matches>();

        public MainForm()
        {            
            InitializeComponent();            
            Init();
        }

        private void Init()
        {            
            Repository.LoadSettings();
            Repository.LoadLanguage();            
            FillData();
            FillPlayerData();
            InitDnD();            
        }

        private void InitDnD()
        {
            //Other players
            pnlPlayersContainer.DragEnter += PnlContainers_DragEnter;
            pnlPlayersContainer.DragDrop += PnlPlayersContainer_DragDrop;            

            //Favourite players
            pnlFavouritePlayersContainer.DragEnter += PnlContainers_DragEnter;
            pnlFavouritePlayersContainer.DragDrop += PnlFavouritePlayersContainer_DragDrop;
        }

        private void PnlContainers_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;

        private void PnlPlayersContainer_DragDrop(object sender, DragEventArgs e)
        {
            var playerInfo = (PlayerInfo)e.Data.GetData(typeof(PlayerInfo));
            
            if (playerInfo.Parent == pnlFavouritePlayersContainer)
            {
                playerInfo.selected = false;
                pnlPlayersContainer.Controls.Add(playerInfo);
            }
        }

        private void PnlFavouritePlayersContainer_DragDrop(object sender, DragEventArgs e)
        {
            var playerInfo = (PlayerInfo)e.Data.GetData(typeof(PlayerInfo));

            if (playerInfo.Parent == pnlPlayersContainer)
            {
                playerInfo.selected = true;
                pnlFavouritePlayersContainer.Controls.Add(playerInfo); 
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Repository.SaveSettings();
            new Settings().Show();
        }

        private async void FillData()
        {
            lblInfo.Text = "Waiting to fetch data!";

            try
            {
                HashSet<Teams> teams = await Repository.LoadJsonCountries();

                foreach (var orderedTeam in teams)
                {
                    ddlGroupResults.Items.Add(orderedTeam);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblInfo.Text = ex.Message;
            }
        }

        private void DdlGroupResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsFile.country = ddlGroupResults.SelectedItem.ToString().Substring(0, ddlGroupResults.SelectedItem.ToString().IndexOf("(")).Trim();
            Repository.SaveSettings();
            FillPlayerData();
        }

        private async void FillPlayerData()
        {
            lblInfo.Text = "Fetching data...";

            pnlPlayersContainer.Controls.Clear();
            pnlRankedPlayerContainer.Controls.Clear();
            pnlRankedStadiumContainer.Controls.Clear();
            
            try
            {
                Player player = new Player();
                Player rankedPlayer = new Player();
                Stadium stadium = new Stadium();

                HashSet<Matches> teams = await Repository.LoadJsonPlayers();

                HashSet<StartingEleven> playerList = new HashSet<StartingEleven>();
                HashSet<TeamEvent> rankedPlayerList = new HashSet<TeamEvent>();                
                HashSet<Matches> rankedStadiumList = new HashSet<Matches>();

                userRankedPlayerControls = new HashSet<RankedPlayerInfo>();
                userRankedStadiumControls = new HashSet<RankedStadiumInfo>();

                userRankedPlayerControlsList = new List<TeamEvent>();
                userRankedStadiumControlsList = new List<Matches>();

                lblTest.Text = SettingsFile.country;

                foreach (var players in teams)
                {                    
                    if (players.HomeTeamStatistics.Country == SettingsFile.country)
                    {                        
                        rankedStadiumList.Add(players);
                        foreach (var playerItem in players.HomeTeamStatistics.StartingEleven)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.HomeTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);     
                            }
                        }
                        foreach (var playerItem in players.HomeTeamStatistics.Substitutes)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.HomeTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);                                                               
                            }                            
                        }                        
                    }
                    if (players.AwayTeamStatistics.Country == SettingsFile.country)
                    {
                        rankedStadiumList.Add(players);
                        foreach (var playerItem in players.AwayTeamStatistics.StartingEleven)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.AwayTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                        foreach (var playerItem in players.AwayTeamStatistics.Substitutes)
                        {
                            playerList.Add(playerItem);

                            foreach (var rankedItem in players.AwayTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                    }
                }                                


                //Players
                foreach (var playerItem in playerList)
                {
                    player.Name = playerItem.Name;                    
                    player.ShirtNumber = playerItem.ShirtNumber;
                    player.Position = playerItem.Position;
                    player.Captain = playerItem.Captain;
                    foreach (var rankedItem in rankedPlayerList)
                    {
                        if (player.Name == rankedItem.Player)
                        {
                            rankedPlayer.Name = rankedItem.Player;
                            switch (rankedItem.TypeOfEvent)
                            {
                                case "goal":
                                    rankedPlayer.Goals++;
                                    break;
                                case "yellow-card":
                                    rankedPlayer.YellowCards++;
                                    break;
                            }
                        }                        
                    }
                    if (!(rankedPlayer.Goals == 0 && rankedPlayer.YellowCards == 0))
                    {                        
                        pnlRankedPlayerContainer.Controls.Add(new RankedPlayerInfo(rankedPlayer));                        
                    }
                    rankedPlayer.Goals = 0;
                    rankedPlayer.YellowCards = 0;
                    pnlPlayersContainer.Controls.Add(new PlayerInfo(player));                    
                }

                foreach (var rankedPlayerItem in userRankedPlayerControlsList)
                {
                    //Lista teamEvent-a
                }

                //Stadium
                IEnumerable<Matches> sortedStadium = rankedStadiumList.OrderBy(item => -item.Attendance);

                foreach (var stadiumItem in sortedStadium)
                {
                    stadium.Location = stadiumItem.Location;
                    stadium.Attendance = stadiumItem.Attendance;
                    stadium.HomeTeam = stadiumItem.HomeTeamCountry;
                    stadium.AwayTeam = stadiumItem.AwayTeamCountry;

                    userRankedStadiumControls.Add(new RankedStadiumInfo(stadium));
                    userRankedStadiumControlsList.Add(stadiumItem);
                }

                foreach (var rankedStadiumItem in userRankedStadiumControls)
                {
                    pnlRankedStadiumContainer.Controls.Add(rankedStadiumItem);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lblInfo.Text = ex.Message;
            }
            lblInfo.Text = $"Players: {pnlPlayersContainer.Controls.Count}";
        }

        private void MiChoosePrintType_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();
        }

        private void MiPreviewPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void MiPrint_Click(object sender, EventArgs e)
        {
            printDocument.Print();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            int x = 230;
            int y = 50;

            e.Graphics.DrawString("RANKED PLAYERS", Font, Brushes.Black, x, y);
            //foreach (var rankedPlayerItem in userRankedPlayerControls)
            //{
            //    e.Graphics.DrawString("Player: " + rankedPlayerItem.Player.Name + " - - -" +
            //        " Goals: " + rankedPlayerItem.Player.Goals + " - - -" +
            //        " Yellow cards: " + rankedPlayerItem.Player.YellowCards,
            //        Font, Brushes.Black, x, y += 20);
            //}

            //for (int i = 0; i < userRankedPlayerControlsList.Count; i++)
            //{
            //    e.Graphics.DrawString("Player: " + userRankedPlayerControlsList[i].Player + " - - -" +
            //        " Goals: " + userRankedPlayerControlsList[i].Goals + " - - -" +
            //        " Yellow cards: " + userRankedPlayerControlsList[i].YellowCards,
            //        Font, Brushes.Black, x, y += 20);
            //}

            e.Graphics.DrawString("RANKED STADIUMS", Font, Brushes.Black, x, y+=40);
            //foreach (var rankedStadiumItem in userRankedStadiumControls)
            //{
            //    e.Graphics.DrawString("Location: " + rankedStadiumItem.Stadium.Location + " - - -" +
            //        " Attendance: " + rankedStadiumItem.Stadium.Attendance,
            //        Font, Brushes.Black, x, y += 20);
            //}
            for (int i = 0; i < userRankedStadiumControlsList.Count; i++)
            {
                e.Graphics.DrawString("Location: " + userRankedStadiumControlsList[i].Location + " - - -" +
                    " Attendance: " + userRankedStadiumControlsList[i].Attendance,
                    Font, Brushes.Black, x, y += 20);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();
    }
}