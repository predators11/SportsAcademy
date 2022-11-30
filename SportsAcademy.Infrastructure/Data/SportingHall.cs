using System.ComponentModel.DataAnnotations;

namespace SportsAcademy.Infrastructure.Data
{
    public class SportingHall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = null!;
    }
}
