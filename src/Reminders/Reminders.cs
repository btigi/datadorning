using Microsoft.Extensions.Configuration;
using PluginBase;
using Reminders.Model.AppSettings;

namespace Reminders
{
    public class Reminders : ICommand
    {
        public string Name { get => "Reminders"; }

        public string Description => "Prints reminders";

        public async Task Execute(IDatadorningPrinter printer, string configFile)
        {
            var builder = new ConfigurationBuilder()
                            .AddJsonFile(configFile, true, true);
            var configuration = builder.Build();
            var settings = new AppSettings();
            configuration.Bind(settings);
            var printedIntro = false;

            // Print a reminder for weekly (e.g. bin day)
            var weekEvents = settings.ReminderInfo.Where(w => w.EventType == "weekly");
            var relevantWeekEvents = weekEvents.Where(w => (DateOnly.FromDateTime(DateTime.Today.AddDays(7)).DayNumber - w.Date.DayNumber) % 7 == 0);
            foreach (var weekEvent in relevantWeekEvents)
            {
                if (weekEvent.Date == DateOnly.FromDateTime(DateTime.Today))
                {
                    if (!printedIntro)
                    {
                        printer.Append($"Reminders");
                        printedIntro = true;
                    }
                    printer.Append($"  {weekEvent.Name}");
                }
            }

            // Print one or more reminders for annual events (e.g. birthdays)
            var annualEvents = settings.ReminderInfo.Where(w => w.EventType == "annual");
            foreach (var annualEvent in annualEvents)
            {
                foreach (var offset in annualEvent.NotificationOffsets.Select(s => s.Offset))
                {
                    if (DateOnly.FromDateTime(new DateTime(DateTime.Today.Year, annualEvent.Date.Month, annualEvent.Date.Day, 0, 0, 0, DateTimeKind.Utc).AddDays(offset)) == annualEvent.Date)
                    {
                        if (!printedIntro)
                        {
                            printer.Append($"Reminders");
                            printedIntro = true;
                        }
                        printer.Append($"  {annualEvent} in {offset} days");
                    }
                }
            }

            await Task.CompletedTask;
        }
    }
}