using SportsAcademy.Core.Models.Statistics;

namespace SportsAcademy.Core.Contracts
{
    public interface IStatisticsService
    {
        Task<StatisticsServiceModel> Total();
    }
}
