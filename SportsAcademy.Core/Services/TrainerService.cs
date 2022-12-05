using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Models.Trainer;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Core.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;
        private readonly ILogger logger;

        public TrainerService(ApplicationDbContext _context, IRepository _repo, ILogger<TrainerService> _logger)
        {
            context = _context;
            repo = _repo;
            logger = _logger;
        }

        public async Task AddTrainerAsync(AddTrainerViewModel model)
        {
            var entity = new Trainer()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                TrainingExpirience = model.TrainingExpirience,
                CategoryId = model.CategoryId
            };

            await context.Trainers.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrainerViewModel>> GetAllAsync()
        {
            var entities = await context.Trainers
                .Include(t => t.Category)
                .ToListAsync();

            return entities
                .Select(t => new TrainerViewModel()
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Category = t?.Category?.Name,
                    Id = t.Id,                   
                    TrainingExpirience = t.TrainingExpirience
                });
        }
    }
}
