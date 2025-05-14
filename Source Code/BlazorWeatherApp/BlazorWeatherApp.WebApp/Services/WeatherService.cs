using BlazorWeatherApp.WebApp.Models;

namespace BlazorWeatherApp.WebApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WeatherAPI");
        }

        public async Task<WeatherForecast[]> GetWeatherAsync()
        {
            return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
