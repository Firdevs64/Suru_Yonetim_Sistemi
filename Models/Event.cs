using System;

namespace SuruYonetimAPI.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public int AnimalId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime EventDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResultStatus { get; set; }
        public string PerformedBy { get; set; }
        public int CreatedByUserId { get; set; }
    }
}