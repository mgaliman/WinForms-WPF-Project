using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        //Print variables
        List<TeamEvent> userRankedPlayerControlsList = new List<TeamEvent>();
        List<Matches> userRankedStadiumControlsList = new List<Matches>();

        //Favourite List
        HashSet<string> userFavourites = new HashSet<string>();

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Repository.LoadSettings();
            Repository.LoadLanguage();
            userFavourites = Repository.LoadFavourites();
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

                userFavourites.Remove(playerInfo.FavouriteName);
            }
        }

        private void PnlFavouritePlayersContainer_DragDrop(object sender, DragEventArgs e)
        {
            var playerInfo = (PlayerInfo)e.Data.GetData(typeof(PlayerInfo));

            if (playerInfo.Parent == pnlPlayersContainer && (pnlFavouritePlayersContainer.Controls.Count) < 3)
            {
                playerInfo.selected = true;
                pnlFavouritePlayersContainer.Controls.Add(playerInfo);

                userFavourites.Add(playerInfo.FavouriteName);
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Repository.SaveSettings();
            Repository.SaveFavourites(userFavourites);
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
            pnlFavouritePlayersContainer.Controls.Clear();

            try
            {
                HashSet<Matches> matches = await Repository.LoadJsonPlayers();
                lblTest.Text = SettingsFile.country;

                StartingEleven player = new StartingEleven();
                TeamEvent rankedPlayer = new TeamEvent();
                Matches stadium = new Matches();

                TeamEvent teamEvent = new TeamEvent();
                
                HashSet<StartingEleven> playerList = new HashSet<StartingEleven>();
                HashSet<TeamEvent> rankedPlayerList = new HashSet<TeamEvent>();
                HashSet<Matches> rankedStadiumList = new HashSet<Matches>();

                HashSet<PlayerInfo> userPlayerControls = new HashSet<PlayerInfo>();
                HashSet<RankedPlayerInfo> userRankedPlayerControls = new HashSet<RankedPlayerInfo>();
                HashSet<RankedStadiumInfo> userRankedStadiumControls = new HashSet<RankedStadiumInfo>();

                userRankedPlayerControlsList = new List<TeamEvent>();
                userRankedStadiumControlsList = new List<Matches>();

                


                foreach (var players in matches)
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
                IEnumerable<StartingEleven> sortedPlayers = playerList.OrderBy(item => item.ShirtNumber);

                foreach (var playerItem in sortedPlayers)
                {
                    foreach (var rankedItem in rankedPlayerList)
                    {
                        if (playerItem.Name == rankedItem.Player)
                        {
                            rankedPlayer.Player = rankedItem.Player;
                            switch (rankedItem.TypeOfEvent)
                            {
                                case "goal":
                                    rankedPlayer.Goals++;
                                    teamEvent.Goals++;
                                    break;
                                case "yellow-card":
                                    rankedPlayer.YellowCards++;
                                    teamEvent.YellowCards++;
                                    break;
                            }
                            //Loads only name!!!
                            teamEvent = rankedItem;
                        }
                    };

                    if (!(rankedPlayer.Goals == 0 && rankedPlayer.YellowCards == 0))
                    {
                        userRankedPlayerControls.Add(new RankedPlayerInfo(rankedPlayer));
                        userRankedPlayerControlsList.Add(teamEvent);
                    }
                    rankedPlayer.Goals = 0;
                    rankedPlayer.YellowCards = 0;
                    userPlayerControls.Add(new PlayerInfo(playerItem));
                }

                //Unranked players
                foreach (var unrankedplayerItem in userPlayerControls)
                {
                    pnlPlayersContainer.Controls.Add(unrankedplayerItem);
                    //Favourites
                    foreach (var favouriteItem in userFavourites)
                    {
                        if (unrankedplayerItem.Player.Name == favouriteItem)
                        {
                            unrankedplayerItem.selected = true;
                            pnlFavouritePlayersContainer.Controls.Add(unrankedplayerItem);
                        }
                    }
                }

                //Ranked players
                //IEnumerable<RankedPlayerInfo> sortedRankedPlayer = userRankedPlayerControls.OrderBy(Item => -Item.Player.Goals);
                foreach (var rankedPlayerItem in userRankedPlayerControls)
                {
                    pnlRankedPlayerContainer.Controls.Add(rankedPlayerItem);
                }

                //Stadium
                IEnumerable<Matches> sortedStadium = rankedStadiumList.OrderBy(item => -item.Attendance);

                foreach (var stadiumItem in sortedStadium)
                {
                    userRankedStadiumControls.Add(new RankedStadiumInfo(stadiumItem));
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
            lblInfo.Text = "Data is fatched!";
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

            //Players
            e.Graphics.DrawString("RANKED PLAYERS", Font, Brushes.Black, x, y);
            for (int i = 0; i < userRankedPlayerControlsList.Count; i++)
            {
                e.Graphics.DrawString("Player: " + userRankedPlayerControlsList[i].Player + " - - -" +
                    " Goals: " + userRankedPlayerControlsList[i].Goals + " - - -" +
                    " Yellow cards: " + userRankedPlayerControlsList[i].YellowCards,
                    Font, Brushes.Black, x, y += 20);
            }

            //Stadiums
            e.Graphics.DrawString("RANKED STADIUMS", Font, Brushes.Black, x, y += 40);
            for (int i = 0; i < userRankedStadiumControlsList.Count; i++)
            {
                e.Graphics.DrawString("Location: " + userRankedStadiumControlsList[i].Location + " - - -" +
                    " Attendance: " + userRankedStadiumControlsList[i].Attendance,
                    Font, Brushes.Black, x, y += 20);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Repository.SaveFavourites(userFavourites);
                Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Dispose();
                    Application.Exit();                    
                }
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}