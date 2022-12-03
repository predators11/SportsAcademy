using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Core.Contracts.Admin;

namespace SportsAcademy.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public async Task<IActionResult> All()
        {
            var model = await userService.All();

            return View(model);
        }
    }
}
