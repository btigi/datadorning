using Microsoft.Extensions.Configuration;
using PluginBase;
using RandomLine.Model.AppSettings;

namespace RandomLine
{
    public class RandomLine : ICommand
    {
        public string Name { get => "RandomLine"; }

        public string Description => "Prints a random line from a text file";

        public async Task Execute(IDatadorningPrinter printer, string configFile)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(configFile, true, true);
            var configuration = builder.Build();
            var settings = new AppSettings();
            configuration.Bind(settings);

            var lines = await File.ReadAllLinesAsync(settings.Filename);
            var lineNumber = Random.Shared.Next(lines.Length);
            var line = lines[lineNumber];

            printer.AlignLeft();
            printer.Append($"{settings.Intro} {line}");
        }
    }
}