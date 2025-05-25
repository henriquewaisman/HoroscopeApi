using System.Text.Json.Serialization;

namespace HoroscopoPdc.Entidades.HoroscopoData
{
    public class BronzeData
    {
        [JsonPropertyName("month")]
        public string Month { get; set; }

        [JsonPropertyName("horoscope_data")]
        public string HoroscopeDataa { get; set; }
    }
}