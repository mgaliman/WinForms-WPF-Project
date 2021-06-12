using DataAccessLayer.Constants;
using DataAccessLayer.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository
    {
        public const string HR = "hr", EN = "en";        
        public static string SETTINGS_PATH = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Settings/settings.txt");
        public static string FAVOURITES_PATH = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Settings/favourites.txt");
        public const string DEFAULT_SETTINGS = "Croatian|True|";
        private const char DEL = '|';

        public static void SaveSettings()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder
                .Append(SettingsFile.language)
                    .Append(DEL)
                    .Append(SettingsFile.gender)
                    .Append(DEL)
                    .Append(SettingsFile.country);
            File.WriteAllText(SETTINGS_PATH, stringBuilder.ToString());
        }

        public static List<string> LoadSettings()
        {
            string[] lines = File.ReadAllLines(SETTINGS_PATH);
            List<string> myList = new List<string>();
            foreach (string item in lines)
            {
                string[] data = item.Split(DEL);
                myList.Add(data[0]);
                myList.Add(data[1]);
                myList.Add(data[2]);

                SettingsFile.language = data[0];
                SettingsFile.gender = Convert.ToBoolean(data[1]);
                SettingsFile.country = data[2];
            }
            return myList;
        }
        public static void SaveFavourites(HashSet<string> favourites)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in favourites)
            {
                stringBuilder.AppendLine(item);
            }
            File.WriteAllText(FAVOURITES_PATH, stringBuilder.ToString());
        }

        public static HashSet<string> LoadFavourites()
        {
            string[] lines = File.ReadAllLines(FAVOURITES_PATH);
            HashSet<string> myList = new HashSet<string>();
            foreach (string item in lines)
            {
                myList.Add(item);
            }
            SettingsFile.favourites = myList;
            return myList;
        }

        public static void SetCulture(string language)
        {
            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
        public static void LoadLanguage()
        {
            if (SettingsFile.language == "Croatian")
            {
                SetCulture(EN);
            }
            else
            {
                SetCulture(HR);
            }
        }

        public static Task<HashSet<Teams>> LoadJsonCountries()
        {
            if (File.Exists(ApiConstants.FemaleTeamsLocation) && File.Exists(ApiConstants.MaleTeamsLocation))
            {
                //File load
                if (SettingsFile.gender)
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ApiConstants.FemaleTeamsLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Teams>>(json);
                        }
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ApiConstants.MaleTeamsLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Teams>>(json);
                        }
                    });
                }
            }
            else
            {
                //Web load
                if (SettingsFile.gender)
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ApiConstants.FemaleTeamsWebLocation);
                        var response = apiClient.Execute<HashSet<Teams>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Teams>>(response.Content);
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ApiConstants.MaleTeamsWebLocation);
                        var response = apiClient.Execute<HashSet<Teams>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Teams>>(response.Content);
                    });
                }
            }
        }

        public static Task<HashSet<Matches>> LoadJsonPlayers()
        {
            if (File.Exists(ApiConstants.FemaleMatchesLocation) || File.Exists(ApiConstants.MaleMatchesLocation))
            {
                //File load
                if (SettingsFile.gender)
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ApiConstants.FemaleMatchesLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Matches>>(json);
                        }
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ApiConstants.MaleMatchesLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Matches>>(json);
                        }
                    });
                }
            }
            else
            {
                //Web load
                if (SettingsFile.gender)
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ApiConstants.FemaleDetailedMatchesWebLocation);
                        var response = apiClient.Execute<HashSet<Matches>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Matches>>(response.Content);
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ApiConstants.MaleDetailedMatchesWebLocation);
                        var response = apiClient.Execute<HashSet<Matches>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Matches>>(response.Content);
                    });
                }
            }
        }
        public static Image GetPicture()
        {
            return MyResources.defaultUser;
        }
    }
}
