using System;

namespace SuruYonetimAPI.Models
{
    public class Reminder
    {
        public int ReminderId { get; set; }
        public int AnimalId { get; set; }
        public int? EventId { get; set; }
        public string ReminderTitle { get; set; }
        public DateTime ReminderDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}