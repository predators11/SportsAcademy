using Microsoft.AspNetCore.Diagnostics;
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

        private readonly ILogger logger;

        public HomeController(ISportingHallService _sportingHallservice, ILogger<HomeController> _logger)
        {
            sportingHallservice = _sportingHallservice;
            logger = _logger;
        }

        /// <summary>
        /// Showing the main page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRolleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            var model = await sportingHallservice.BestSportingHalls();

            return View(model);
        }
        
        /// <summary>
        /// Cheking for errors
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();

            logger.LogError(feature.Error, "TraceIdentifier: {0}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}