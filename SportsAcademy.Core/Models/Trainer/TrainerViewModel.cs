using System.ComponentModel.DataAnnotations;

namespace SportsAcademy.Core.Models.Trainer
{
    public class TrainerViewModel
    {
        public int Id { get; init; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string TrainingExpirience { get; set; } = null!;

        public string? Category { get; set; } = null!;
    }
}
