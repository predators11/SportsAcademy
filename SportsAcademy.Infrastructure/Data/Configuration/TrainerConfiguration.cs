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
                    TrainingExpirience = "5 years",
                    CategoryId = 1
                },

                new Trainer()
                {
                    Id = 2,
                    FirstName = "Stoqn",
                    LastName = "Manev",
                    TrainingExpirience = "7 years",
                    CategoryId = 2
                },

                new Trainer()
                {
                    Id = 3,
                    FirstName = "Tenko",
                    LastName = "Cakov",
                    TrainingExpirience = "10 years",
                    CategoryId = 3
                }
             };

            return trainers;
        }
    }
}
