using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Models.Statistics;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository repo;

        public StatisticsService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<StatisticsServiceModel> Total()
        {
            int totalMemberships = await repo.AllReadonly<SportMembership>()
                .CountAsync(h => h.IsActive);
            int boughtMemberships = await repo.AllReadonly<SportMembership>()
                .CountAsync(h => h.IsActive && h.BuyerId != null);

            return new StatisticsServiceModel()
            {
                TotalMemberships = totalMemberships,
                TotalBuys = boughtMemberships
            };
        }
    }
}
