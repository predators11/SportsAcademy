using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Exceptions;
using SportsAcademy.Core.Models.SportMembership;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Core.Services
{
    public class SportMembershipService : ISportMembershipService
    {
        private readonly IRepository repo;

        private readonly IGuard guard;

        private readonly ILogger logger;

        public SportMembershipService(IRepository _repo, IGuard _guard, ILogger<SportMembershipService> _logger)
        {
            repo = _repo;
            guard = _guard;
            logger = _logger;
        }

        /// <summary>
        /// Showing all the available memberships
        /// </summary>
        /// <param name="category"></param>
        /// <param name="searchTerm"></param>
        /// <param name="sorting"></param>
        /// <param name="currentPage"></param>
        /// <param name="sportMembershipsPerPage"></param>
        /// <returns></returns>
        public async Task<SportMembershipQueryModel> All(string? category = null, string? searchTerm = null, SportMembershipSorting sorting = SportMembershipSorting.Newest, int currentPage = 1, int sportMembershipsPerPage = 1)
        {
            var result = new SportMembershipQueryModel();
            var memberships = repo.AllReadonly<SportMembership>()
                .Where(m => m.IsActive);

            if (string.IsNullOrEmpty(category) == false)
            {
                memberships = memberships
                    .Where(h => h.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                memberships = memberships
                    .Where(m => EF.Functions.Like(m.Title.ToLower(), searchTerm) ||
                        EF.Functions.Like(m.Description.ToLower(), searchTerm));
            }

            memberships = sorting switch
            {
                SportMembershipSorting.Price => memberships
                    .OrderBy(m => m.PricePerMonth),
                SportMembershipSorting.NotBought => memberships
                    .OrderBy(m => m.BuyerId),
                _ => memberships.OrderByDescending(m => m.Id)
            };

            result.SportMemberships = await memberships
                .Skip((currentPage - 1) * sportMembershipsPerPage)
                .Take(sportMembershipsPerPage)
                .Select(m => new SportMembershipServiceModel() 
                {
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    IsBought = m.BuyerId != null,
                    PricePerMonth = m.PricePerMonth,
                    Title = m.Title
                })
                .ToListAsync();
            
            result.TotalSportMembershipsCount = await memberships.CountAsync();

            return result;
        }

        /// <summary>
        /// Showing All the availabe categories
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SportMembershipCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new SportMembershipCategoryModel() 
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// Showing the names of All the availabe categories
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// Taking the memberships with memberId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SportMembershipServiceModel>> AllSportMembershipsByMemberId(int id)
        {
            return await repo.AllReadonly<SportMembership>()
                .Where(c => c.IsActive)
                .Where(c => c.MemberId == id)
                .Select(c => new SportMembershipServiceModel() 
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    IsBought = c.BuyerId != null,
                    PricePerMonth = c.PricePerMonth,
                    Title = c.Title
                })
                .ToListAsync();
        }

        /// <summary>
        /// Taking the memberships with userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SportMembershipServiceModel>> AllSportMembershipsByUserId(string userId)
        {
            return await repo.AllReadonly<SportMembership>()
                .Where(c => c.BuyerId == userId)
                .Where(c => c.IsActive)
                .Select(c => new SportMembershipServiceModel()
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    IsBought = c.BuyerId != null,
                    PricePerMonth = c.PricePerMonth,
                    Title = c.Title
                })
                .ToListAsync();
        }

        /// <summary>
        /// Checking if the category exists with the current categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        /// <summary>
        /// Add membership to the repo
        /// </summary>
        /// <param name="model"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<int> Create(SportMembershipModel model, int memberId)
        {
            var membership = new SportMembership()
            {
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                Title = model.Title,
                MemberId = memberId
            };

            try
            {
                await repo.AddAsync(membership);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return membership.Id;
        }

        /// <summary>
        /// Deleting the membership
        /// </summary>
        /// <param name="membershipId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task Delete(int membershipId)
        {
            var membership = await repo.GetByIdAsync<SportMembership>(membershipId);
            membership.IsActive = false;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Failed to delete", ex);
            }
        }

        /// <summary>
        /// Editing the membership
        /// </summary>
        /// <param name="membershipId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Edit(int membershipId, SportMembershipModel model)
        {
            var membership = await repo.GetByIdAsync<SportMembership>(membershipId);

            membership.Description = model.Description;
            membership.ImageUrl = model.ImageUrl;
            membership.PricePerMonth = model.PricePerMonth;
            membership.Title = model.Title;
            membership.CategoryId = model.CategoryId;

            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Checking if the membership exists with the current id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<SportMembership>()
                .AnyAsync(m => m.Id == id && m.IsActive);
        }

        /// <summary>
        /// Taking the membership category with the current membershipId
        /// </summary>
        /// <param name="membershipId"></param>
        /// <returns></returns>
        public async Task<int> GetSportMembershipCategoryId(int membershipId)
        {
            return (await repo.GetByIdAsync<SportMembership>(membershipId)).CategoryId;
        }

        /// <summary>
        /// Checking if there is a member with the current membershipId and currentUserId
        /// </summary>
        /// <param name="membershipId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<bool> HasMemberWithId(int membershipId, string currentUserId)
        {
            bool result = false;
            var membership = await repo.AllReadonly<SportMembership>()
                .Where(h => h.IsActive)
                .Where(h => h.Id == membershipId)
                .Include(h => h.Member)
                .FirstOrDefaultAsync();

            if (membership?.Member != null && membership.Member.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }
        /// <summary>
        /// Showing the membership details with the current id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SportMembershipDetailsModel> SportMembershipDetailsById(int id)
        {
            return await repo.AllReadonly<SportMembership>()
                .Where(m => m.IsActive)
                .Where(m => m.Id == id)
                .Select(m => new SportMembershipDetailsModel() 
                {
                    Category = m.Category.Name,
                    Description = m.Description,
                    Id = id,
                    ImageUrl = m.ImageUrl,
                    IsBought = m.BuyerId != null,
                    PricePerMonth = m.PricePerMonth,
                    Title = m.Title,
                    Member = new Models.Member.MemberServiceModel() 
                    {
                        FirstName = m.Member.FirstName,
                        LastName = m.Member.LastName,
                        Email = m.Member.User.Email,
                        PhoneNumber = m.Member.PhoneNumber
                    }
                    
                })
                .FirstAsync();
        }

        /// <summary>
        /// Checking if the membership is bought with the current membershipId
        /// </summary>
        /// <param name="membershipId"></param>
        /// <returns></returns>
        public async Task<bool> IsBought(int membershipId)
        {
            return (await repo.GetByIdAsync<SportMembership>(membershipId)).BuyerId != null; 
        }

        /// <summary>
        /// Checking if the membership is bought with the current membershipId and the current currentUserId
        /// </summary>
        /// <param name="membershipId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<bool> IsBoughtByUserWithId(int membershipId, string currentUserId)
        {
            bool result = false;
            var membership = await repo.AllReadonly<SportMembership>()
                .Where(h => h.IsActive)
                .Where(h => h.Id == membershipId)
                .FirstOrDefaultAsync();

            if (membership != null && membership.BuyerId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Canceling the already bought membership
        /// </summary>
        /// <param name="membershipId"></param>
        /// <returns></returns>
        public async Task Cancel(int membershipId)
        {
            var membership = await repo.GetByIdAsync<SportMembership>(membershipId);
            guard.AgainstNull(membership, "Membership can not be found");
            membership.BuyerId = null;

            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Buying the membership
        /// </summary>
        /// <param name="membershipId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task Buy(int membershipId, string currentUserId)
        {
            var membership = await repo.GetByIdAsync<SportMembership>(membershipId);

            if (membership != null && membership.BuyerId != null)
            {
                throw new ArgumentException("Membership is already bought");
            }

            guard.AgainstNull(membership, "Membership can not be found");

            membership.BuyerId = currentUserId;

            await repo.SaveChangesAsync();
        }
    }
}
