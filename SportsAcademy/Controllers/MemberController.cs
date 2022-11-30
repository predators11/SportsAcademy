using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Core.Constants;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Models.Member;
using SportsAcademy.Extensions;

namespace SportsAcademy.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService _memberService)
        {
            memberService = _memberService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await memberService.ExistsById(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "Вие вече членувате";

                return RedirectToAction("Index", "Home");
            }

            var model = new BecomeMemberModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeMemberModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await memberService.ExistsById(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "Вие вече членувате";

                return RedirectToAction("Index", "Home");
            }

            if (await memberService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "Телефона вече съществува";

                return RedirectToAction("Index", "Home");
            }

            if (await memberService.UserHasBuys(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "Не трябва да имате купувания за да станете член";

                return RedirectToAction("Index", "Home");
            }

            await memberService.Create(model.FirstName, model.LastName, userId, model.PhoneNumber);

            return RedirectToAction("All", "SportMembership");
        }
    }
}
