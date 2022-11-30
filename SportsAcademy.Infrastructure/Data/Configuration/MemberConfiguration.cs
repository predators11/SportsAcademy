using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsAcademy.Infrastructure.Data.Configuration
{
    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasData(new Member()
            {
                Id = 1,
                FirstName = "Petko",
                LastName = "Petkov",
                PhoneNumber = "+359123456789",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            });
        }
    }
}
