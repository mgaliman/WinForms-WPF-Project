using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class RankedStadiumInfo : UserControl
    {
        public Stadium Stadium { get; private set; }

        public RankedStadiumInfo(Stadium stadium)
        {
            InitializeComponent();
            Stadium = stadium;
            SetData(Stadium);
        }

        private void SetData(Stadium stadium)
        {
            lblLocation.Text = stadium.Location;
            lblVisitors.Text = stadium.Attendance.ToString();
            lblHomeTeam.Text = stadium.HomeTeam;
            lblAwayTeam.Text = stadium.AwayTeam;
        }
    }
}
