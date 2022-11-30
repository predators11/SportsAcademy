using System.ComponentModel.DataAnnotations;

namespace SportsAcademy.Core.Models.SportMembership
{
    public class SportMembershipServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = "Price per month")]
        public decimal PricePerMonth { get; init; }

        [Display(Name = "Is Bought")]
        public bool IsBought { get; init; }
    }
}
