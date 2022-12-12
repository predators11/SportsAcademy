using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Models.Trainer;
using static SportsAcademy.Areas.Admin.Constants.AdminConstants;

namespace SportsAcademy.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService trainerService;

        public TrainerController(ITrainerService _trainerService)
        {
            trainerService = _trainerService;
        }

        /// <summary>
        /// Add trainer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Add trainer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddTrainerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!User.IsInRole(AdminRolleName))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });                
            }

            await trainerService.AddTrainerAsync(model);

            return RedirectToAction("Trainer", "All");
        }

        /// <summary>
        /// Showing all the trainers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await trainerService.GetAllAsync();

            return View(model);
        }
    }
}
