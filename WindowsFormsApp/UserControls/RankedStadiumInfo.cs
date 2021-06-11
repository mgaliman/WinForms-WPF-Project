using DataAccessLayer.Models;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class RankedStadiumInfo : UserControl
    {
        public Matches Stadium { get; private set; }

        public RankedStadiumInfo(Matches stadium)
        {
            InitializeComponent();
            Stadium = stadium;
            SetData(Stadium);
        }

        private void SetData(Matches stadium)
        {
            lblLocation.Text = stadium.Location;
            lblVisitors.Text = stadium.Attendance.ToString();
            lblHomeTeam.Text = stadium.HomeTeamCountry;
            lblAwayTeam.Text = stadium.AwayTeamCountry;
        }
    }
}
