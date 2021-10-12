using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TelegramAutoPosting.Interfaces;
using TelegramAutoPosting.Models;

namespace TelegramAutoPosting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITelegramService _telegramService;

        public HomeController(ILogger<HomeController> logger, ITelegramService telegramService)
        {
            _telegramService = telegramService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(string text)
        {
            _telegramService.SendMessageToChannel(text);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
