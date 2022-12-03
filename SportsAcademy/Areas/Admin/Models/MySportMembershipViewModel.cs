using SportsAcademy.Core.Models.SportMembership;

namespace SportsAcademy.Areas.Admin.Models
{
    public class MySportMembershipViewModel
    {
        public IEnumerable<SportMembershipServiceModel> AddedMemberships { get; set; }
            = new List<SportMembershipServiceModel>();

        public IEnumerable<SportMembershipServiceModel> BoughtMemberships { get; set; }
            = new List<SportMembershipServiceModel>();
    }
}
