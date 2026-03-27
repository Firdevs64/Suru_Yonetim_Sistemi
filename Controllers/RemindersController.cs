using Microsoft.AspNetCore.Mvc;
using SuruYonetimAPI.Data;
using System.Linq;

namespace SuruYonetimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemindersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RemindersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllReminders()
        {
            var reminders = _context.Reminders
                .OrderBy(r => r.ReminderDate)
                .ToList();

            return Ok(reminders);
        }

        [HttpGet("active")]
        public IActionResult GetActiveReminders()
        {
            var reminders = _context.Reminders
                .Where(r => !r.IsCompleted)
                .OrderBy(r => r.ReminderDate)
                .ToList();

            return Ok(reminders);
        }
    }
}