using System;

namespace SuruYonetimAPI.DTOs
{
    public class CreateAnimalDto
    {
        public int UserId { get; set; }
        public string TagNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        public string AnimalGroup { get; set; }
        public string PregnancyStatus { get; set; }
        public string HealthStatus { get; set; }
        public string MilkStatus { get; set; }
        public bool IsActive { get; set; }
    }
}