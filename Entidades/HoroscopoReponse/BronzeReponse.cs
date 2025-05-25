using System.Text.Json.Serialization;
using HoroscopoPdc.Entidades.HoroscopoData;

namespace HoroscopoPdc.Entidades.HoroscopoResponse
{
    public class BronzeResponse
    {
        [JsonPropertyName("data")]
        public BronzeData Data { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }

}