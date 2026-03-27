using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuruYonetimAPI.Models
{
    [Table("AIChatHistory")]
    public class AIChatHistory
    {
        [Key]
        public int ChatId { get; set; }

        public int? UserId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}