using System.Text.Json.Serialization;

namespace BankHoliday.Model.BankHoliday
{
    public class BankHolidayResponse
    {
        [JsonPropertyName("england-and-wales")]
        public EnglandAndWales EnglandAndWales { get; set; }
        public Scotland Scotland { get; set; }
        [JsonPropertyName("northern-ireland")]
        public NorthernIreland NorthernIreland { get; set; }
    }

    public class EnglandAndWales
    {
        public string Division { get; set; }
        public Event[] Events { get; set; }
    }

    public class NorthernIreland
    {
        public string Division { get; set; }
        public Event[] Events { get; set; }
    }

    public class Scotland
    {
        public string Division { get; set; }
        public Event[] Events { get; set; }
    }

    public class Event
    {
        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public string Notes { get; set; }
        public bool Bunting { get; set; }
    }
}