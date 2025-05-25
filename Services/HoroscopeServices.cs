using HoroscopoPdc.Entidades.HoroscopoData;
using HoroscopoPdc.Entidades.HoroscopoReponse;
using HoroscopoPdc.Entidades.HoroscopoResponse;

namespace HoroscopoPdc.Services
{
    public class HoroscopeService
    {
        private readonly HttpClient _httpClient;

        public HoroscopeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BronzeData> GetBronzeHoroscopeAsync(string sign)
        {
            string url = $"https://horoscope-app-api.vercel.app/api/v1/get-horoscope/monthly?sign={sign}";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<BronzeResponse>(url);
                return response?.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching horoscope: {ex.Message}");
                return null;
            }
        }

        public async Task<SilverData> GetSilverHoroscopeAsync(string sign)
        {
            string url = $"https://horoscope-app-api.vercel.app/api/v1/get-horoscope/weekly?sign={sign}";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<SilverReponse>(url);
                return response?.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching horoscope: {ex.Message}");
                return null;
            }
        }

        public async Task<GoldData> GetGoldHoroscopeAsync(string sign)
        {
            string url = $"https://horoscope-app-api.vercel.app/api/v1/get-horoscope/daily?sign={sign}";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<GoldReponse>(url);
                return response?.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching horoscope: {ex.Message}");
                return null;
            }
        }
    }
}