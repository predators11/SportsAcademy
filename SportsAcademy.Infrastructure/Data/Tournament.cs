using System.ComponentModel.DataAnnotations;

namespace SportsAcademy.Infrastructure.Data
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Ranking { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string PlayerStats { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(300)]
        public string Rewards { get; set; } = null!;
    }
}
