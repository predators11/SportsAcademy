using System.ComponentModel.DataAnnotations;

namespace SportsAcademy.Infrastructure.Data
{
    public class Category
    {
        public Category()
        {
            SportMemberships = new List<SportMembership>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public List<SportMembership> SportMemberships { get; set; }
    }
}
