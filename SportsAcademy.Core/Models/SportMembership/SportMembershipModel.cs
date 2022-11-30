using System.ComponentModel.DataAnnotations;

namespace SportsAcademy.Core.Models.SportMembership
{
    public class SportMembershipModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Price per month")]
        [Range(0.00, 2000.00, ErrorMessage = "Price per month must be a positive number and less than {2} leva")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SportMembershipCategoryModel> SportMembershipCategories { get; set; } = new List<SportMembershipCategoryModel>();
    }
}
