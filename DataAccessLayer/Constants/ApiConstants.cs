using System.IO;

namespace DataAccessLayer.Constants
{
    public static class ApiConstants
    {
        //File
        public static string FemaleGroupResultsLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/women_group_results.json");
        public static string FemaleMatchesLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/women_matches.json");
        public static string FemaleResultsLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/women_results.json");
        public static string FemaleTeamsLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/women_teams.json");

        public static string MaleGroupResultsLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/men_group_results.json");
        public static string MaleMatchesLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/men_matches.json");
        public static string MaleResultsLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/men_results.json");
        public static string MaleTeamsLocation = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/men_teams.json");


        //Web
        public const string FemaleTeamsWebLocation = "https://worldcup.sfg.io/teams/results";
        public const string FemaleMatchesWebLocation = "https://worldcup.sfg.io/matches";
        public const string FemaleDetailedMatchesWebLocation = "https://worldcup.sfg.io/matches/country?fifa_code=ENG";

        public const string MaleTeamsWebLocation = "https://world-cup-json-2018.herokuapp.com/teams/results";
        public const string MaleMatchesWebLocation = "https://world-cup-json-2018.herokuapp.com/matches";
        public const string MaleDetailedMatchesWebLocation = "https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=ENG";

    }
}
