using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MvvmToolkitExmple.Entities;

namespace MvvmToolkitExmple.Services
{
    public class WeatherService : IweatherWebService
    {
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            string apiUrl = $"https://api.weatherapi.com/v1/current.json?key=f6941c2d31b74d5ba3392039242111&q={city}&aqi=no";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize and return the WeatherResponse object
                    return JsonSerializer.Deserialize<WeatherResponse>(jsonResponse);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message}");
            }
        }
    }
}
