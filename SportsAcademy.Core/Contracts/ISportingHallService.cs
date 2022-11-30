using SportsAcademy.Core.Models.SportingHall;

namespace SportsAcademy.Core.Contracts
{
    public interface ISportingHallService
    {
        Task<IEnumerable<SportingHallModel>> BestSportingHalls();
    }
}
