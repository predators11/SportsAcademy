using System.ComponentModel.DataAnnotations;

namespace SportsAcademy.Infrastructure.Data
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string TrainingExpirience { get; set; } = null!;
    }
}
