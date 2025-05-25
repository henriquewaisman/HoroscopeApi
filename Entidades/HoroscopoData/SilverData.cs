using System.Text.Json.Serialization;

namespace HoroscopoPdc.Entidades.HoroscopoData
{
    public class SilverData
    {
        [JsonPropertyName("week")]
        public string Week { get; set; }

        [JsonPropertyName("horoscope_data")]
        public string HoroscopeDataa { get; set; }
    }
}