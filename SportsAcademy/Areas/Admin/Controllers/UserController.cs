﻿using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Core.Constants;
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

        [HttpPost]
        public async Task<IActionResult> Forget(string userId)
        {
            bool result = await userService.Forget(userId);

            if (result)
            {
                TempData[MessageConstant.SuccessMessage] = "User is now forgotten";
            }
            else
            {
                TempData[MessageConstant.ErrorMessage] = "User is unforgetable";
            }

            return RedirectToAction(nameof(All));
        }
    }
}
