using System.Drawing;

namespace DataAccessLayer.Models
{
    public class Player
    {
        //PlayerInfo
        public string Name { get; set; }
        public long ShirtNumber { get; set; }
        public Position Position { get; set; }
        public bool Captain { get; set; }
        public bool Favourite { get; set; }
        public Image Picture { get; set; }

        //RankedPlayerInfo
        public int Goals { get; set; }
        public int YellowCards { get; set; }     
    }
}
