using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Core.Models.SportingHall;

namespace SportsAcademy.Controllers
{
    [Authorize]
    public class SportingHallController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = new SportingHallDetailsModel();

            return View(model);
        }
    }
}
