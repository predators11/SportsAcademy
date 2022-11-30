using SportsAcademy.Core.Models.SportMembership;

namespace SportsAcademy.Core.Contracts
{
    public interface ISportMembershipService
    {
        Task<IEnumerable<SportMembershipCategoryModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(SportMembershipModel model, int agentId);

        Task<SportMembershipQueryModel> All(
            string? category = null,
            string? searchTerm = null,
            SportMembershipSorting sorting = SportMembershipSorting.Newest,
            int currentPage = 1,
            int sportMembershipsPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<SportMembershipServiceModel>> AllSportMembershipsByMemberId(int id);

        Task<IEnumerable<SportMembershipServiceModel>> AllSportMembershipsByUserId(string userId);

        Task<SportMembershipDetailsModel> SportMembershipDetailsById(int id);

        Task<bool> Exists(int id);

        Task Edit(int sportMembershipId, SportMembershipModel model);

        Task<bool> HasMemberWithId(int sportMembershipId, string currentUserId);

        Task<int> GetSportMembershipCategoryId(int sportMembershipId);

        Task Delete(int sportMembershipId);

        Task<bool> IsBought(int sportMembershipId);

        Task<bool> IsBoughtByUserWithId(int sportMembershipId, string currentUserId);

        Task Buy(int sportMembershipId, string currentUserId);

        Task Cancel(int sportMembershipId);
    }
}
