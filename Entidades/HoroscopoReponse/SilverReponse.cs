using System.Text.Json.Serialization;
using HoroscopoPdc.Entidades.HoroscopoData;

namespace HoroscopoPdc.Entidades.HoroscopoResponse
{
    public class SilverReponse
    {
        [JsonPropertyName("data")]
        public SilverData Data { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}