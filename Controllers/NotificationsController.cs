using Microsoft.AspNetCore.Mvc;
using SuruYonetimAPI.Data;
using System.Linq;

namespace SuruYonetimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotificationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            var notifications = _context.Notifications
                .OrderByDescending(n => n.CreatedAt)
                .ToList();

            return Ok(notifications);
        }

        [HttpGet("unread")]
        public IActionResult GetUnreadNotifications()
        {
            var notifications = _context.Notifications
                .Where(n => !n.IsRead)
                .OrderByDescending(n => n.CreatedAt)
                .ToList();

            return Ok(notifications);
        }

        [HttpPut("{id}/read")]
        public IActionResult MarkAsRead(int id)
        {
            var notification = _context.Notifications
                .FirstOrDefault(n => n.NotificationId == id);

            if (notification == null)
            {
                return NotFound("Bildirim bulunamadı.");
            }

            notification.IsRead = true;
            _context.SaveChanges();

            return Ok(notification);
        }
    }
}