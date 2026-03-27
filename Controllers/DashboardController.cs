using Microsoft.AspNetCore.Mvc;
using SuruYonetimAPI.Data;
using SuruYonetimAPI.DTOs;
using System.Linq;

namespace SuruYonetimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public IActionResult GetSummary()
        {
            var summary = new DashboardSummaryDto
            {
                ToplamHayvan = _context.Animals.Count(),
                GebeSayisi = _context.Animals.Count(a => a.PregnancyStatus == "Gebe"),
                BosSayisi = _context.Animals.Count(a => a.PregnancyStatus == "Boş"),
                SaglikliSayisi = _context.Animals.Count(a => a.HealthStatus == "Sağlıklı"),
                SagmalSayisi = _context.Animals.Count(a => a.MilkStatus == "Sağmal")
            };

            return Ok(summary);
        }
    }
}