// Move all config files into 'config' folder

using Datadorning;
using Datadorning.Model.AppSettings;
using Datadorning.PluginHandler;
using ESC_POS_USB_NET.Printer;
using Microsoft.Extensions.Configuration;
using PluginBase;
using System.Text;

var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
var configuration = builder.Build();
var settings = new AppSettings();
configuration.Bind(settings);

var encodingProvider = CodePagesEncodingProvider.Instance;
Encoding.RegisterProvider(encodingProvider);
var printer = new Printer(settings.PrinterName);

var wrapper = new PrinterWrapper(printer);
wrapper.AlignRight();
wrapper.Append($"{DateTime.Now:G}");
wrapper.AlignLeft();

var commands = new List<(IEnumerable<ICommand> commands, string config, bool preSeparator, bool postSeparator)>();
foreach (var plugin in settings.Plugins)
{
    var pluginAssembly = PluginLoader.LoadPlugin(plugin.Assembly);
    var assembly = PluginLoader.CreateCommands(pluginAssembly);
    commands.Add((assembly, plugin.Config, plugin.PreSeparator, plugin.PostSeparator));
}

foreach (var assembly in commands)
{
    foreach (var command in assembly.commands)
    {
        if (assembly.preSeparator)
        {
            wrapper.Separator();
        }
        await command.Execute(wrapper, assembly.config);
        if (assembly.postSeparator)
        {
            wrapper.Separator();
        }
    }
}

wrapper.FullPaperCut();
wrapper.PrintDocument();