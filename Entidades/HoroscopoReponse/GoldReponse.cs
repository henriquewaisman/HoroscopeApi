using System.Text.Json.Serialization;
using HoroscopoPdc.Entidades.HoroscopoData;

namespace HoroscopoPdc.Entidades.HoroscopoReponse
{
    public class GoldReponse
    {
        [JsonPropertyName("data")]
        public GoldData Data { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}