using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Models.SportingHall;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Core.Services
{
    public class SportingHallService : ISportingHallService
    {
        private readonly IRepository repo;

        public SportingHallService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<SportingHallModel>> BestSportingHalls()
        {
            return await repo.AllReadonly<SportingHall>()
                .OrderByDescending(s => s.Id)
                .Select(s => new SportingHallModel()
                {
                    Id = s.Id,
                    ImageUrl = s.ImageUrl,
                    Title = s.Title
                })
                .Take(3)
                .ToListAsync();
        }
    }
}
