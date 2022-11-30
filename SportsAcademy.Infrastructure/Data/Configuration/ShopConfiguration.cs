using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsAcademy.Infrastructure.Data.Configuration
{
    internal class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasData(new Shop()
            {
                Id = 1,
                RacketsPrice = 50.00M,
                BallsPrice = 5.00M,
                RobotsPrice = 300.00M,
                ClothingPrice = 100.00M
            });
        }
    }
}
