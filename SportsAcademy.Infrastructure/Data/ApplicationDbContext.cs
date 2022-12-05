using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SportsAcademy.Infrastructure.Data.Configuration;

namespace SportsAcademy.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new MemberConfiguration());
            builder.ApplyConfiguration(new SportMembershipConfiguration());
            builder.ApplyConfiguration(new TrainerConfiguration());
            builder.ApplyConfiguration(new TournamentConfiguration());
            builder.ApplyConfiguration(new SportingHallConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(builder);

            var keysProperties = builder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }

            base.OnModelCreating(builder);
        }

        public DbSet<SportMembership> SportMemberships { get; set; } = null!;

        public DbSet<Member> Members { get; set; } = null!;

        public DbSet<SportingHall> SportingHalls { get; set; } = null!;

        public DbSet<Trainer> Trainers { get; set; } = null!;

        public DbSet<Tournament> Tournaments { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;
    }
}