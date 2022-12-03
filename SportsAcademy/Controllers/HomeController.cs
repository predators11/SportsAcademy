using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Models;
using System.Diagnostics;
using static SportsAcademy.Areas.Admin.Constants.AdminConstants;

namespace SportsAcademy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISportingHallService sportingHallservice;

        public HomeController(ISportingHallService _sportingHallservice)
        {
            sportingHallservice = _sportingHallservice;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRolleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            var model = await sportingHallservice.BestSportingHalls();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}