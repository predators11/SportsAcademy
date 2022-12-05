using System.ComponentModel.DataAnnotations;

namespace SportsAcademy.Core.Models.Trainer
{
    public class AddTrainerViewModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string TrainingExpirience { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
    }
}
