using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsAcademy.Infrastructure.Data.Configuration
{
    internal class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasData(CreateTournaments());
        }

        private List<Tournament> CreateTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>()
            {
                new Tournament()
                {
                    Id = 1,
                    Description = "Amateurs format - 32 players with direct eliminations. Entry tax - 10 лв.",
                    Rewards = "First place -> gold medal + 60% from the taxes, Second place -> silver medal + 20%, Third place + bronze medal + 10%.",
                    PlayerStats = "Tournaments won + Overral win/loss player statistic",
                    Ranking = "top 100 players"
                },

                new Tournament()
                {
                    Id = 2,
                    Description = "Professional format - 64 players with direct eliminations. Entry tax - 20 лв.",
                    Rewards = "First place -> gold medal + 60% from the taxes, Second place -> silver medal + 20%, Third place + bronze medal + 10%.",
                    PlayerStats = "Tournaments won + Overral win/loss player statistic",
                    Ranking = "top 100 players"
                }
             };

            return tournaments;
        }
    }
}
