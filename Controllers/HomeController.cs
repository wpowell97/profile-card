using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileCardApp.Models;
using ProfileCardApp.Data;
using ProfileCardApp.Services;

namespace ProfileCardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly HubSpotService _hubSpotService;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext dbContext,
            HubSpotService hubSpotService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _hubSpotService = hubSpotService;
        }

        /// <summary>
        /// Displays the homepage with the contact form.
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactFormViewModel());
        }

        /// <summary>
        /// Handles POST submissions of the contact form.
        /// Saves the message to the database and submits it to HubSpot.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel model)
        {
            // Validate form input before any processing
            if (!ModelState.IsValid)
            {
                // Form is invalid, return with validation messages
                return View(model);
            }

            // Map form input to DB entity
            var message = new ContactMessage
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message
            };

            try
            {
                // Save to local SQL database
                _dbContext.ContactMessages.Add(message);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Failed to save contact message to database.");
                TempData["ErrorMessage"] = "Sorry, we couldn't save your message. Please try again later.";
                return View(model);
            }

            try
            {
                // Send to HubSpot via custom API service
                await _hubSpotService.SubmitFormAsync(model);
                TempData["SuccessMessage"] = "✅ Message saved and submitted to HubSpot!";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "⚠️ HubSpot submission failed.");
                TempData["WarningMessage"] = "Message saved, but we couldn’t notify HubSpot.";
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Standard Privacy policy page
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Displays the most recent contact messages from the database.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Messages()
        {
            try
            {
                var messages = await _dbContext.ContactMessages
                    .OrderByDescending(m => m.SubmittedAt)
                    .Take(5) // Adjust as needed
                    .ToListAsync();

                return View(messages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Failed to load contact messages.");
                TempData["ErrorMessage"] = "Unable to load contact submissions at this time.";
                return View(new List<ContactMessage>());
            }
        }


        /// <summary>
        /// Error page shown when unhandled exceptions occur.
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
