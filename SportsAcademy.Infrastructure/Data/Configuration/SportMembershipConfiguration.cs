using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsAcademy.Infrastructure.Data.Configuration
{
    internal class SportMembershipConfiguration : IEntityTypeConfiguration<SportMembership>
    {
        public void Configure(EntityTypeBuilder<SportMembership> builder)
        {
            builder.HasData(CreateMemberships());
        }

        private List<SportMembership> CreateMemberships()
        {
            List<SportMembership> memberships = new List<SportMembership>()
            {
                new SportMembership()
                {
                    Id = 1,
                    Title = "Table Tennis Membership",
                    Description = "Playing for 1 month with suitable trainer with maximum 2 hours a day",
                    ImageUrl = "https://uploads-ssl.webflow.com/5e71b829d37a8158f8643ac3/5e7e3d6fdf522d8b72159b02_rackets-merged.png",
                    PricePerMonth = 50M,                    
                    MemberId = 1,
                    CategoryId = 1,
                    BuyerId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                },

                new SportMembership()
                {
                    Id = 2,
                    Title = "Futsal Membership",
                    Description = "Playing for 1 month with suitable trainer you with maximum 2 hours a day",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5fb46909e6fc155f519f8ee1/c0d2fe31-f621-470b-ad71-2a2813ef3e0d/DSCF0321.jpg",
                    PricePerMonth = 60M,
                    MemberId = 1,
                    CategoryId = 2
                },

                new SportMembership()
                {
                    Id = 3,
                    Title = "Archery Membership",
                    Description = "Shooting for 1 month with suitable trainer you with maximum 2 hours a day",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZGUej8azFt2SwL96yk2qblXY70diU3zEbOA&usqp=CAU",
                    PricePerMonth = 70M,
                    MemberId = 1,
                    CategoryId = 3
                }

             };

            return memberships;
        }
    }
}
