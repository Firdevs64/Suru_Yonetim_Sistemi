using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuruYonetimAPI.Models
{
    [Table("AIAnalysisLogs")]
    public class AIAnalysisLog
    {
        [Key]
        public int AnalysisId { get; set; }

        public int? AnimalId { get; set; }
        public int? UserId { get; set; }
        public string InputText { get; set; }
        public string PredictedEventType { get; set; }
        public float? ConfidenceScore { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}