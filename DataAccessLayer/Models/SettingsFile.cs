using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class SettingsFile
    {
        public static string language;
        public static bool gender;
        public static string country;
        public static HashSet<string> favourites;
    }
}
