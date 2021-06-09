using Newtonsoft.Json;

namespace DataAccessLayer.Models
{
    public partial class Teams
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        public override string ToString() => Country + " (" + FifaCode + ")";
    }
}
