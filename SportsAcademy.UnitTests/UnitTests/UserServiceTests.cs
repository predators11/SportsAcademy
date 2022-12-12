using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts.Admin;
using SportsAcademy.Core.Services.Admin;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Tests.UnitTests
{
    public class UserServiceTests
    {
        private IRepository repo;
        private IUserService userService;
        private ApplicationDbContext applicationDbContext;
        private UserManager<ApplicationUser> userManager;

        [SetUp]
        public async Task SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("userServiceDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestAll()
        {
            var repo = new Repository(applicationDbContext);
            userService = new UserService(repo, userManager);

            await repo.AddRangeAsync(new List<Member>()
            {
                new Member() { Id = 1, UserId = "1", FirstName = "", LastName = "", PhoneNumber = "" },
                new Member() { Id = 3, UserId = "2", FirstName = "", LastName = "", PhoneNumber = "" },
                new Member() { Id = 5, UserId = "3", FirstName = "", LastName = "", PhoneNumber = "" },
            });

            await repo.SaveChangesAsync();
            var sportingHallCollection = await userService.All();

            Assert.That(2, Is.EqualTo(sportingHallCollection.Count()));
        }

        [Test]
        public async Task TestUserFullName()
        {
            var repo = new Repository(applicationDbContext);
            userService = new UserService(repo, userManager);

            await repo.AddRangeAsync(new List<Member>()
            {
                new Member() { Id = 1, UserId = "1", FirstName = "da1", LastName = "da2", PhoneNumber = "" },
                new Member() { Id = 3, UserId = "2", FirstName = "", LastName = "", PhoneNumber = "" },
                new Member() { Id = 5, UserId = "3", FirstName = "", LastName = "", PhoneNumber = "" },
            });

            await repo.SaveChangesAsync();
            await userService.UserFullName("1");
            var dbUser = await repo.All<Member>()
                .AnyAsync(a => a.FirstName == "da1" && a.LastName == "da2");

            Assert.IsTrue(dbUser);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
