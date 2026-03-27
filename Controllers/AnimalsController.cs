using Microsoft.AspNetCore.Mvc;
using SuruYonetimAPI.Data;
using System.Linq;
using SuruYonetimAPI.DTOs;
using SuruYonetimAPI.Models;

namespace SuruYonetimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnimalsController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 TÜM HAYVANLAR
        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            var animals = _context.Animals.ToList();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.AnimalId == id);

            if (animal == null)
            {
                return NotFound("Hayvan bulunamadı.");
            }

            return Ok(animal);
        }

        [HttpPost]
        public IActionResult CreateAnimal([FromBody] CreateAnimalDto dto)
        {
            var animal = new Animal
            {
                UserId = dto.UserId,
                TagNumber = dto.TagNumber,
                Name = dto.Name,
                Gender = dto.Gender,
                Breed = dto.Breed,
                BirthDate = dto.BirthDate,
                AnimalGroup = dto.AnimalGroup,
                PregnancyStatus = dto.PregnancyStatus,
                HealthStatus = dto.HealthStatus,
                MilkStatus = dto.MilkStatus,
                IsActive = dto.IsActive
            };

            _context.Animals.Add(animal);
            _context.SaveChanges();

            return Ok(animal);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.AnimalId == id);

            if (animal == null)
            {
                return NotFound("Hayvan bulunamadı.");
            }

            _context.Animals.Remove(animal);
            _context.SaveChanges();

            return Ok("Hayvan silindi.");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.AnimalId == id);

            if (animal == null)
            {
                return NotFound("Hayvan bulunamadı.");
            }

            // Güncelleme
            animal.Name = updatedAnimal.Name;
            animal.TagNumber = updatedAnimal.TagNumber;
            animal.Gender = updatedAnimal.Gender;
            animal.Breed = updatedAnimal.Breed;
            animal.PregnancyStatus = updatedAnimal.PregnancyStatus;
            animal.HealthStatus = updatedAnimal.HealthStatus;
            animal.MilkStatus = updatedAnimal.MilkStatus;
            animal.AnimalGroup = updatedAnimal.AnimalGroup;

            _context.SaveChanges();

            return Ok(animal);
        }

        //Sadece gebe hayvanlar
        [HttpGet("pregnant")]
        public IActionResult GetPregnantAnimals()
        {
            var animals = _context.Animals
                .Where(a => a.PregnancyStatus == "Gebe")
                .ToList();

            return Ok(animals);
        }

        //Sadece aktif hayvanlar
        [HttpGet("active")]
        public IActionResult GetActiveAnimals()
        {
            var animals = _context.Animals
                .Where(a => a.IsActive)
                .ToList();

            return Ok(animals);
        }

        //İsme göre arama
        [HttpGet("search")]
        public IActionResult SearchAnimals(string keyword)
        {
            var animals = _context.Animals
                .Where(a => a.Name.Contains(keyword) || a.TagNumber.Contains(keyword))
                .ToList();

            return Ok(animals);
        }

        //Tek hayvanın event geçmişi
        [HttpGet("{id}/events")]
        public IActionResult GetAnimalEvents(int id)
        {
            var events = _context.Events
                .Where(e => e.AnimalId == id)
                .OrderByDescending(e => e.EventDate)
                .ToList();

            return Ok(events);
        }
    }
}