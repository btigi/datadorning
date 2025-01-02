using BankHoliday.Model.BankHoliday;
using PluginBase;
using System.Text.Json;

namespace BankHoliday
{
    public class WeatherApi : ICommand
    {
        public string Name { get => "BankHoliday"; }

        public string Description => "Prints the next Bank Holiday in England and Wales";

        public async Task Execute(IDatadorningPrinter printer, string configFile)
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.gov.uk/");
            var endpoint = "bank-holidays.json";
            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            var bankHolidayResponse = JsonSerializer.Deserialize<BankHolidayResponse>(responseBody, options);

            if (bankHolidayResponse != null)
            {
                var nextBankHoliday = bankHolidayResponse.EnglandAndWales.Events.FirstOrDefault(f => f.Date >= DateOnly.FromDateTime(DateTime.Today));
                if (nextBankHoliday != null)
                {
                    var days = nextBankHoliday.Date.DayNumber - DateOnly.FromDateTime(DateTime.Today).DayNumber;
                    var text = "";
                    text = days switch
                    {
                        0 => "today",
                        1 => $"in 1 day",
                        _ => $"in {days} days",
                    };
                    printer.Append($"Bank Holiday");
                    printer.Append($"  {nextBankHoliday.Title} {text}");
                }
            }
        }
    }
}