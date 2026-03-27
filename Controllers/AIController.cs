using Microsoft.AspNetCore.Mvc;
using SuruYonetimAPI.Data;
using SuruYonetimAPI.Models;
using System;
using System.Linq;

namespace SuruYonetimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AIController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("analyze")]
        public IActionResult Analyze([FromBody] string input)
        {
            string predictedEvent = "Bilinmiyor";
            float confidence = 0.5f;

            // BASİT AI MANTIĞI (rule-based ama AI gibi davranıyor)
            if (input.ToLower().Contains("iştahsız") || input.ToLower().Contains("hasta"))
            {
                predictedEvent = "Hastalık";
                confidence = 0.9f;
            }
            else if (input.ToLower().Contains("kızgınlık"))
            {
                predictedEvent = "Kızgınlık Görüldü";
                confidence = 0.85f;
            }
            else if (input.ToLower().Contains("tohumlama"))
            {
                predictedEvent = "Tohumlama";
                confidence = 0.95f;
            }

            // LOG DB’ye kaydet
            var log = new AIAnalysisLog
            {
                UserId = 1,
                InputText = input,
                PredictedEventType = predictedEvent,
                ConfidenceScore = confidence,
                CreatedAt = DateTime.Now
            };

            _context.AIAnalysisLogs.Add(log);
            _context.SaveChanges();

            return Ok(new
            {
                input,
                predictedEvent,
                confidence
            });
        }
        [HttpPost("chat")]
        public IActionResult Chat([FromBody] string question)
        {
            string answer = "Anlaşılamadı.";

            var q = question.ToLower();

            if (q.Contains("gebe"))
                answer = "Gebe hayvanlar düzenli kontrol edilmelidir.";
            else if (q.Contains("aşı"))
                answer = "Aşı takvimine uygun ilerlemeniz önerilir.";
            else if (q.Contains("süt"))
                answer = "Süt verimi için beslenme ve sağlık kontrolü önemlidir.";
            else if (q.Contains("hasta"))
                answer = "Hayvan hastaysa veteriner kontrolü önerilir.";
            else if (q.Contains("doğum"))
                answer = "Doğuma yaklaşan hayvanlar sık gözlemlenmeli ve doğum ortamı hazırlanmalıdır.";
            else if (q.Contains("tohumlama"))
                answer = "Tohumlama sonrası kontrol ve takip önemlidir.";
            else if (q.Contains("kızgınlık"))
                answer = "Kızgınlık belirtileri dikkatle gözlemlenmeli ve zamanında işlem yapılmalıdır.";
            else if (q.Contains("sağmal"))
                answer = "Sağmal hayvanlarda süt verimi ve beslenme düzeni birlikte takip edilmelidir.";

            var chat = new AIChatHistory
            {
                UserId = 1,
                Question = question,
                Answer = answer,
                CreatedAt = DateTime.Now
            };

            _context.AIChatHistories.Add(chat);
            _context.SaveChanges();

            return Ok(new
            {
                question,
                answer
            });
        }
    }
}