using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProfileCardApp.Models;

namespace ProfileCardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Pass a blank form model to the view
            return View(new ContactFormViewModel());
        }

        [HttpPost]
        public IActionResult Index(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                // You can log, store or simulate sending the data here
                TempData["SuccessMessage"] = "Message sent successfully!";
                return RedirectToAction("Index");
            }

            // Return view with validation errors
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
