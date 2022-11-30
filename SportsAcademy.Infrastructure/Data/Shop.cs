using System.ComponentModel.DataAnnotations;

namespace SportsAcademy.Infrastructure.Data
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        public decimal RacketsPrice { get; set; }

        public decimal BallsPrice { get; set; }

        public decimal RobotsPrice { get; set; }

        public decimal ClothingPrice { get; set; }
    }
}
