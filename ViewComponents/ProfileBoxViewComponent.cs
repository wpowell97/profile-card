using Microsoft.AspNetCore.Mvc;
using ProfileCardApp.Models;

namespace ProfileCardApp.ViewComponents
{
    /// <summary>
    /// Renders the profile card component with static data.
    /// Add error handling and fallback in case something fails.
    /// </summary>
    public class ProfileBoxViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            try
            {
                // Simulate fetching profile data (static in this case)
                var model = new ProfileModel
                {
                    Name = "Will Powell",
                    Role = "Frontend Developer",
                    ImageUrl = "/images/profile.jpg",
                    Followers = 1200,
                    Likes = 350,
                    Photos = 75
                };

                // Return the component view with the model
                return View(model);
            }
            catch (Exception ex)
            {
                // Log error if logger is available (or fallback silently for now)
                Console.WriteLine($"ProfileBoxViewComponent error: {ex.Message}");

                // Return an empty/default model to avoid crashing the page
                var fallbackModel = new ProfileModel
                {
                    Name = "Unknown",
                    Role = "Unavailable",
                    ImageUrl = "/images/profile.jpg"
                };

                return View(fallbackModel);
            }
        }
    }
}
