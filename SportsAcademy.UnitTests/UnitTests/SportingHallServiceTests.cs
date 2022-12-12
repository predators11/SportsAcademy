using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Services;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Tests.UnitTests
{
    public class SportingHallServiceTests
    {
        private IRepository repo;
        private ISportingHallService sportingHallService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public async Task SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("SportingHallDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestBestSportingHallsInMemory()
        {
            var repo = new Repository(applicationDbContext);
            sportingHallService = new SportingHallService(repo);

            await repo.AddRangeAsync(new List<SportingHall>()
            {
                new SportingHall() { Id = 1, Address = "", ImageUrl = "", Title = "", Description = "" },
                new SportingHall() { Id = 3, Address = "", ImageUrl = "", Title = "", Description = "" },
                new SportingHall() { Id = 5, Address = "", ImageUrl = "", Title = "", Description = "" },
                new SportingHall() { Id = 2, Address = "", ImageUrl = "", Title = "", Description = "" }
            });

            await repo.SaveChangesAsync();
            var sportingHallCollection = await sportingHallService.BestSportingHalls();

            Assert.That(3, Is.EqualTo(sportingHallCollection.Count()));
            Assert.That(sportingHallCollection.Any(h => h.Id == 1), Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}