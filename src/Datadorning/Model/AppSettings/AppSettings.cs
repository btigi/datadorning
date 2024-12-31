namespace Datadorning.Model.AppSettings
{
    public class AppSettings
    {
        public string PrinterName { get; set; }
        public Plugin[] Plugins { get; set; }
    }

    public class Plugin
    {
        public string Assembly { get; set; }
        public string Config { get; set; }
        public bool PreSeparator { get; set; }
        public bool PostSeparator { get; set; }
    }
}