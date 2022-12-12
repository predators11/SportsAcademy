using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Core.Models.SportingHall;

namespace SportsAcademy.Controllers
{
    [Authorize]
    public class SportingHallController : Controller
    {
        /// <summary>
        /// Showing the halls where members can train their skills
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = new SportingHallDetailsModel();

            return View(model);
        }
    }
}
