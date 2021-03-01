using System;
namespace Section_05_08
{
    public class LogEntry
    {
        [Column("Log Date", Format = "{0:yyyy-MM-dd hh:mm}")]
        public DateTime CreatedAt { get; set; }

        [Column("Severity")]
        public string Type { get; set; }

        [Column("Location")]
        public string Where { get; set; }

        [Column("Message")]
        public string Description { get; set; }
    }
}
