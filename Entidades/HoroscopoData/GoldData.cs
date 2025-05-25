using System.Text.Json.Serialization;

namespace HoroscopoPdc.Entidades.HoroscopoData
{
    public class GoldData
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("horoscope_data")]
        public string HoroscopeDataa { get; set; }
    }
}