﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportsAcademy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "Administrator")]

    public class BaseController : Controller
    {
    }
}