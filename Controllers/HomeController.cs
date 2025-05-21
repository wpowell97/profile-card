using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProfileCardApp.Models;
using ProfileCardApp.Data;

namespace ProfileCardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactFormViewModel());
        }

        [HttpPost]
        public IActionResult Index(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = new ContactMessage
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message
                };

                _dbContext.ContactMessages.Add(message);
                _dbContext.SaveChanges();

                TempData["SuccessMessage"] = "Message saved successfully!";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
