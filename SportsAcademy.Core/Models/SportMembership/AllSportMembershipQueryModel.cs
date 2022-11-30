namespace SportsAcademy.Core.Models.SportMembership
{
    public class AllSportMembershipQueryModel
    {
        public const int SportMembershipsPerPage = 3;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public SportMembershipSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalSportMembershipsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<SportMembershipServiceModel> SportMemberships { get; set; } = Enumerable.Empty<SportMembershipServiceModel>();
    }
}
