using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class SettingsFile
    {
        public static string language;
        public static bool gender;
        public static string country;
        public static string versusCountry;
        public static string resolution;
        public static HashSet<string> favourites;
        public static int countryIndex;
        public static int versusCountryIndex;
    }
}
