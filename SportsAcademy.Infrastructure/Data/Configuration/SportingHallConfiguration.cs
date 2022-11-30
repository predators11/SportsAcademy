using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SportsAcademy.Infrastructure.Data.Configuration
{
    internal class SportingHallConfiguration : IEntityTypeConfiguration<SportingHall>
    {
        public void Configure(EntityTypeBuilder<SportingHall> builder)
        {
            builder.HasData(CreateHalls());
        }

        private List<SportingHall> CreateHalls()
        {
            var halls = new List<SportingHall>()
            {
                new SportingHall()
                {
                      Id = 1,
                      Title = "Small Predator Arena",
                      Address = "San Stefano, Burgas",
                      Description = "I samll hall for futsal to play , average distance to run around and nice terain for good trainers with with friends",
                      ImageUrl = "https://www.greatmats.com/images/sport-courts/table-tennis-flooring-carpet-500.jpg.webp"
                },
                
                new SportingHall()
                {
                      Id = 2,
                      Title = "Big Predator Arena",
                      Address = "Bratq Miladinovi 20, Burgas",
                      Description = "I big hall with new expensive tables to play , a lot of distance to run around the tables and good trainers for you to get you into the best form to play",
                      ImageUrl = "https://i.pinimg.com/736x/bf/61/bd/bf61bd125649fbdb1d0aeaaac6b23c93.jpg"
                },

                new SportingHall()
                {
                      Id = 3,
                      Title = "Big Game Hunter Arena",
                      Address = "Car Simeon 52, Burgas",
                      Description = "I big hall for archey training",
                      ImageUrl = "http://4.bp.blogspot.com/-NwYPpc2TR7A/VO9HvfPu03I/AAAAAAAAfiU/OzVQgjiouLM/s1600/Indoor%2BArchery%2BRange%2C%2BOlympic.jpg"
                }
            };

            return halls;
        }
    }
}
