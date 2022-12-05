using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Models.SportMembership;
using SportsAcademy.Extensions;
using static SportsAcademy.Areas.Admin.Constants.AdminConstants;

namespace SportsAcademy.Controllers
{
    [Authorize]
    public class SportMembershipController : Controller
    {
        private readonly ISportMembershipService sportMembershipService;

        private readonly IMemberService memberService;

        private readonly ILogger logger;

        public SportMembershipController(ISportMembershipService _sportMembershipService, IMemberService _memberService, ILogger<SportMembershipController> _logger)
        {
            sportMembershipService = _sportMembershipService;
            memberService = _memberService;
            logger = _logger;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllSportMembershipQueryModel query)
        {
            var result = await sportMembershipService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllSportMembershipQueryModel.SportMembershipsPerPage);

            query.TotalSportMembershipsCount = result.TotalSportMembershipsCount;
            query.Categories = await sportMembershipService.AllCategoriesNames();
            query.SportMemberships = result.SportMemberships;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            if (User.IsInRole(AdminRolleName))
            {
                return RedirectToAction("Mine", "SportMembership", new { area = AreaName });
            }

            IEnumerable<SportMembershipServiceModel> myMemberships;
            var userId = User.Id();

            if (await memberService.ExistsById(userId))
            {
                int memberId = await memberService.GetMemberId(userId);
                myMemberships = await sportMembershipService.AllSportMembershipsByMemberId(memberId);
            }
            else
            {
                myMemberships = await sportMembershipService.AllSportMembershipsByUserId(userId);
            }

            return View(myMemberships);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((await sportMembershipService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await sportMembershipService.SportMembershipDetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add() 
        {
            if ((await memberService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(MemberController.Become), "Member");
            }

            var model = new SportMembershipModel()
            {
                SportMembershipCategories = await sportMembershipService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SportMembershipModel model)
        {
            if ((await memberService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(MemberController.Become), "member");
            }

            if ((await sportMembershipService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.SportMembershipCategories = await sportMembershipService.AllCategories();

                return View(model);
            }

            int memberId = await memberService.GetMemberId(User.Id());

            int id = await sportMembershipService.Create(model, memberId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await sportMembershipService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!User.IsInRole(AdminRolleName) && (await sportMembershipService.HasMemberWithId(id, User.Id())) == false)
            {
                logger.LogInformation("User with id {0} attempted to open other member membership", User.Id());

                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (await sportMembershipService.IsBought(id) == true)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var house = await sportMembershipService.SportMembershipDetailsById(id);
            var categoryId = await sportMembershipService.GetSportMembershipCategoryId(id);

            var model = new SportMembershipModel()
            {
                Id = id,
                CategoryId = categoryId,    
                Description = house.Description,
                ImageUrl = house.ImageUrl,
                PricePerMonth = house.PricePerMonth,
                Title = house.Title,
                SportMembershipCategories = await sportMembershipService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SportMembershipModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await sportMembershipService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Membership does not exist");
                model.SportMembershipCategories = await sportMembershipService.AllCategories();

                return View(model);
            }

            if (!User.IsInRole(AdminRolleName) && (await sportMembershipService.HasMemberWithId(model.Id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (await sportMembershipService.IsBought(id) == true)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await sportMembershipService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.SportMembershipCategories = await sportMembershipService.AllCategories();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.SportMembershipCategories = await sportMembershipService.AllCategories();

                return View(model);
            }

            await sportMembershipService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await sportMembershipService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!User.IsInRole(AdminRolleName))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var membership = await sportMembershipService.SportMembershipDetailsById(id);
            var model = new SportMembershipDetailsViewModel()
            {
                Description = membership.Description,
                ImageUrl = membership.ImageUrl,
                Title = membership.Title
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id, SportMembershipDetailsViewModel model)
        {
            if ((await sportMembershipService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!User.IsInRole(AdminRolleName))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await sportMembershipService.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {
            if ((await sportMembershipService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (await sportMembershipService.IsBought(id))
            {
                return RedirectToAction(nameof(Mine));
            }

            await sportMembershipService.Buy(id, User.Id());

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            if ((await sportMembershipService.Exists(id)) == false ||
                (await sportMembershipService.IsBought(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!User.IsInRole(AdminRolleName))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await sportMembershipService.Cancel(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
