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
        HashSet<StartingEleven> printRankedPlayerList = new HashSet<StartingEleven>();
        HashSet<Matches> printRankedStadiumList = new HashSet<Matches>();
        HashSet<RankedPlayerInfo> userControls = new HashSet<RankedPlayerInfo>();

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

                printRankedPlayerList = new HashSet<StartingEleven>();
                printRankedStadiumList = new HashSet<Matches>();
                userControls = new HashSet<RankedPlayerInfo>();
                

                lblTest.Text = SettingsFile.country;

                foreach (var players in teams)
                {                    
                    if (players.HomeTeamStatistics.Country == SettingsFile.country)
                    {                        
                        rankedStadiumList.Add(players);
                        foreach (var item in players.HomeTeamStatistics.StartingEleven)
                        {
                            playerList.Add(item);

                            foreach (var rankedItem in players.HomeTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);     
                            }
                        }
                        foreach (var item in players.HomeTeamStatistics.Substitutes)
                        {
                            playerList.Add(item);

                            foreach (var rankedItem in players.HomeTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);                                                               
                            }                            
                        }                        
                    }
                    if (players.AwayTeamStatistics.Country == SettingsFile.country)
                    {
                        rankedStadiumList.Add(players);
                        foreach (var item in players.AwayTeamStatistics.StartingEleven)
                        {
                            playerList.Add(item);

                            foreach (var rankedItem in players.AwayTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                        foreach (var item in players.AwayTeamStatistics.Substitutes)
                        {
                            playerList.Add(item);

                            foreach (var rankedItem in players.AwayTeamEvents)
                            {
                                rankedPlayerList.Add(rankedItem);
                            }
                        }
                    }
                }
                
                IEnumerable<Matches> sortedStadium = rankedStadiumList.OrderBy(item => -item.Attendance);                

                foreach (var item in playerList)
                {
                    player.Name = item.Name;
                    rankedPlayer.Name = item.Name;
                    player.ShirtNumber = item.ShirtNumber;
                    player.Position = item.Position;
                    player.Captain = item.Captain;
                    foreach (var rankedItem in rankedPlayerList)
                    {
                        if (player.Name == rankedItem.Player)
                        {
                            switch (rankedItem.TypeOfEvent)
                            {
                                case "goal":
                                    rankedPlayer.Goals++;
                                    //rankedItem.Goals++;
                                    break;
                                case "yellow-card":
                                    rankedPlayer.YellowCards++;
                                    //rankedItem.YellowCards++;
                                    break;
                            }
                        }
                    }
                    if (!(rankedPlayer.Goals == 0 && rankedPlayer.YellowCards == 0))
                    {
                        //pnlRankedPlayerContainer.Controls.Add(new RankedPlayerInfo(rankedPlayer));
                        userControls.Add(new RankedPlayerInfo(rankedPlayer));
                        //printRankedPlayerList.Add(item);
                    }
                    rankedPlayer.Goals = 0;
                    rankedPlayer.YellowCards = 0;
                    pnlPlayersContainer.Controls.Add(new PlayerInfo(player));                    
                }

                //IEnumerable<RankedPlayerInfo> sortedRankedPlayers = userControls.OrderBy(item => item.Player.Goals);

                foreach (var rankedPlayerItem in userControls)
                {
                    pnlRankedPlayerContainer.Controls.Add(rankedPlayerItem);
                }

                foreach (var stadiumItem in sortedStadium)
                {
                    stadium.Location = stadiumItem.Location;
                    stadium.Attendance = stadiumItem.Attendance;
                    stadium.HomeTeam = stadiumItem.HomeTeamCountry;
                    stadium.AwayTeam = stadiumItem.AwayTeamCountry;

                    pnlRankedStadiumContainer.Controls.Add(new RankedStadiumInfo(stadium));
                    printRankedStadiumList.Add(stadiumItem);
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
            //List<StartingEleven> listPrintRankedPlayerList = new List<StartingEleven>(printRankedPlayerList);
            //List<RankedPlayerInfo> userControlsList = new List<RankedPlayerInfo>(userControls);
            List<Matches> listPrintRankedStadiumList = new List<Matches>(printRankedStadiumList);

            e.Graphics.DrawString("RANKED PLAYERS", Font, Brushes.Black, x, y);
            foreach (var rankedPlayerItem in userControls)
            {
                e.Graphics.DrawString("Player: " + rankedPlayerItem.Player.Name + " - - -" + " Goals: " + rankedPlayerItem.Player.Goals + " - - -" + " Yellow cards: " + rankedPlayerItem.Player.YellowCards, Font, Brushes.Black, x, y += 20);
            }
            //for (int i = 0; i < userControlsList.Count(); i++)
            //{
            //    string name = userControlsList[i].Player.Name;
            //    int goals = userControlsList[i].Player.Goals;
            //    int yellowCards = userControlsList[i].Player.YellowCards;
            //    e.Graphics.DrawString("Player: " + name + " - - -" + " Goals: " + goals + " - - -" + " Yellow cards: " + yellowCards, Font, Brushes.Black, x, y+=20);
            //}

            e.Graphics.DrawString("RANKED STADIUMS", Font, Brushes.Black, x, y+=40);
            for (int i = 0; i < listPrintRankedStadiumList.Count(); i++)
            {
                string location = listPrintRankedStadiumList[i].Location;
                string attendance = listPrintRankedStadiumList[i].Attendance.ToString();
                e.Graphics.DrawString("Location: " + location + " - - -" + " Attendance: " + attendance, Font, Brushes.Black, x, y += 20);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();
    }
}