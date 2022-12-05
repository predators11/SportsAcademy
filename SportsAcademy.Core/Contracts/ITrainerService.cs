using SportsAcademy.Core.Models.Trainer;

namespace SportsAcademy.Core.Contracts
{
    public interface ITrainerService
    {
        Task AddTrainerAsync(AddTrainerViewModel model);

        Task<IEnumerable<TrainerViewModel>> GetAllAsync();
    }
}
