using SportsAcademy.Core.Models.Member;

namespace SportsAcademy.Core.Models.SportMembership
{
    public class SportMembershipDetailsModel : SportMembershipServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public MemberServiceModel Member { get; set; }
    }
}
