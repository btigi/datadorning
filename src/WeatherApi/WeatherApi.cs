using Microsoft.Extensions.Configuration;
using PluginBase;
using System.Text.Json;
using WeatherApi.Model.AppSettings;
using WeatherApi.Model.Weather;

namespace WeatherApi
{
    public class WeatherApi : ICommand
    {
        public string Name { get => "WeatherApi"; }

        public string Description => "Prints information from weatherapi.com";

        public async Task Execute(IDatadorningPrinter printer, string configFile)
        {
            var builder = new ConfigurationBuilder()
                            .AddJsonFile(configFile, true, true);
            var configuration = builder.Build();
            var settings = new AppSettings();
            configuration.Bind(settings);

            using var client = new HttpClient();
            client.BaseAddress = new Uri(settings.BaseAddress);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var endpoint = $"forecast.json?q={settings.Location}&days={settings.Days}&key={settings.ApiKey}";
            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(responseBody, options);

            var maxtempc = weatherResponse.Forecast.Forecastday[0].Day.Maxtemp_c;
            var mintempc = weatherResponse.Forecast.Forecastday[0].Day.Mintemp_c;
            var chanceofRain = weatherResponse.Forecast.Forecastday[0].Day.Daily_Chance_Of_Rain; // percent
            var maxwind = weatherResponse.Forecast.Forecastday[0].Day.Maxwind_mph;
            var condition = weatherResponse.Forecast.Forecastday[0].Day.Condition.Text;
            var sunrise = weatherResponse.Forecast.Forecastday[0].Astro.Sunrise;
            var sunset = weatherResponse.Forecast.Forecastday[0].Astro.Sunset;

            printer.AlignLeft();
            printer.Append($"Sunrise: {sunrise}");
            printer.Append($"Sunset: {sunset}");
            printer.Append($"Temp: {mintempc}°c - {maxtempc}°c");
            printer.Append($"Rain: {chanceofRain}% chance");
            printer.Append($"Wind: {maxwind}mph");
            printer.Append($"Condition: {condition}");
        }
    }
}