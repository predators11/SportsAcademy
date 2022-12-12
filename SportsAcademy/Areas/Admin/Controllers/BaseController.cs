using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SportsAcademy.Areas.Admin.Constants.AdminConstants;

namespace SportsAcademy.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRolleName)]

    public class BaseController : Controller
    {
    }
}
