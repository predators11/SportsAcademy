namespace SportsAcademy.Core.Models.SportMembership
{
    public class SportMembershipQueryModel
    {
        public int TotalSportMembershipsCount { get; set; }

        public IEnumerable<SportMembershipServiceModel> SportMemberships { get; set; } = new List<SportMembershipServiceModel>();
    }
}
