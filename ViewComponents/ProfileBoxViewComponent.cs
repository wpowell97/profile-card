using Microsoft.AspNetCore.Mvc;
using ProfileCardApp.Models;

namespace ProfileCardApp.ViewComponents
{
    public class ProfileBoxViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new ProfileModel
            {
                Name = "Will Powell",
                Role = "Frontend Developer",
                ImageUrl = "/images/profile.jpg",
                Followers = 1200,
                Likes = 350,
                Photos = 75
            };

            return View(model);
        }
    }
}
