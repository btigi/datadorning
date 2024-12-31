namespace Reminders.Model.AppSettings
{
    public class AppSettings
    {
        public Reminder[] ReminderInfo { get; set; }
    }

    public class Reminder
    {
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public string EventType { get; set; }
        public NotificationOffset[] NotificationOffsets { get; set; }
    }

    public class NotificationOffset
    {
        public double Offset { get; set; }
    }
}