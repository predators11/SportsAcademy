using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Models.Trainer;
using SportsAcademy.Core.Services;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Tests.UnitTests
{
    public class TrainerServiceTests
    {
        private IRepository repo;
        private ApplicationDbContext applicationDbContext;
        private ITrainerService trainerService;

        [SetUp]
        public async Task SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("trainerDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestAddTrainer()
        {
            var repo = new Repository(applicationDbContext);
            trainerService = new TrainerService(repo);

            await repo.AddAsync(new Member()
            {
                FirstName = "da1",
                LastName = "da2",
                UserId = "da3",
                PhoneNumber = "da4"
            });

            await repo.SaveChangesAsync();

            await trainerService.AddTrainerAsync(new AddTrainerViewModel
            {
                FirstName = "ka1",
                LastName = "k2",
                TrainingExpirience = "",
                CategoryId = 1
            });

            var dbTrainer = await repo.GetByIdAsync<Trainer>(1);

            Assert.That(dbTrainer.FirstName, Is.EqualTo("ka1"));
        }

        [Test]
        public async Task TestGetAll()
        {
            var repo = new Repository(applicationDbContext);
            trainerService = new TrainerService(repo);

            await repo.AddRangeAsync(new List<Trainer>()
            {
                new Trainer() { Id = 1, FirstName = "da1", LastName = "ka1", TrainingExpirience = "" },
                new Trainer() { Id = 3, FirstName = "da2", LastName = "ka2", TrainingExpirience = "" },
                new Trainer() { Id = 5, FirstName = "da3", LastName = "ka3", TrainingExpirience = "" },
                new Trainer() { Id = 2, FirstName = "da4", LastName = "ka4", TrainingExpirience = "" }
            });

            await repo.SaveChangesAsync();
            var trainerCollection = await trainerService.GetAllAsync();

            Assert.That(4, Is.EqualTo(trainerCollection.Count()));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
