
namespace PluginBase
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        Task Execute(IDatadorningPrinter printer, string configFile);
    }
}