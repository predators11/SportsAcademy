using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Areas.Admin.Models;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Extensions;

namespace SportsAcademy.Areas.Admin.Controllers
{
    public class SportMembershipController : BaseController
    {
        private readonly ISportMembershipService sportMembershipService;

        private readonly IMemberService memberService;

        public SportMembershipController(
            ISportMembershipService _sportMembershipService,
            IMemberService _memberService)
        {
            sportMembershipService = _sportMembershipService;
            memberService = _memberService;
        }

        public async Task<IActionResult> Mine()
        {
            var myMemberships = new MySportMembershipViewModel();
            var adminId = User.Id();
            myMemberships.BoughtMemberships = await sportMembershipService.AllSportMembershipsByUserId(adminId);
            var memberId = await memberService.GetMemberId(adminId);
            myMemberships.AddedMemberships = await sportMembershipService.AllSportMembershipsByMemberId(memberId);

            return View(myMemberships);
        }
    }
}
