using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Models.Trainer;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Core.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly IRepository repo;

        public TrainerService(IRepository _repo)
        {
            repo = _repo;
        }

        /// <summary>
        /// Add the trainer to the repository
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddTrainerAsync(AddTrainerViewModel model)
        {
            var trainer = new Trainer()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                TrainingExpirience = model.TrainingExpirience,
                CategoryId = model.CategoryId
            };

            await repo.AddAsync(trainer);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Showing all the availabe trainers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TrainerViewModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Trainer>()
                .OrderBy(c => c.Id)
                .Select(t => new TrainerViewModel()
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Id = t.Id,
                    TrainingExpirience = t.TrainingExpirience
                })
                .ToListAsync();
        }
    }
}
