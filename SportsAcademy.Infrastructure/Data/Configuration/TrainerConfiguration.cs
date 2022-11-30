using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsAcademy.Infrastructure.Data.Configuration
{
    internal class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasData(CreateTrainers());
        }

        private List<Trainer> CreateTrainers()
        {
            List<Trainer> trainers = new List<Trainer>()
            {
                new Trainer()
                {
                    Id = 1,
                    FirstName = "Ivailo",
                    LastName = "Dobrev",
                    TrainingExpirience = "2 years"
                },

                new Trainer()
                {
                    Id = 2,
                    FirstName = "Stoqn",
                    LastName = "Manev",
                    TrainingExpirience = "5 years"
                },

                new Trainer()
                {
                    Id = 3,
                    FirstName = "Tenko",
                    LastName = "Cakov",
                    TrainingExpirience = "10 years"
                }
             };

            return trainers;
        }
    }
}
