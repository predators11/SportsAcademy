using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Exceptions;
using SportsAcademy.Core.Models.SportMembership;
using SportsAcademy.Core.Services;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Tests.UnitTests
{
    public class SportMembershipTests
    {
        private IRepository repo;
        private ILogger<SportMembershipService> logger;
        private IGuard guard;
        private ISportMembershipService sportMembershipService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public async Task SetUp()
        {
            guard = new Guard();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("sportMembershipDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestSportMembershipEdit()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddAsync(new SportMembership()
            {
                Id = 1,
                ImageUrl = "",
                Title = "",
                Description = ""
            });

            await repo.SaveChangesAsync();

            await sportMembershipService.Edit(1, new SportMembershipModel()
            {
                Id = 1,
                ImageUrl = "",
                Title = "",
                Description = "This membership is edited",
            });

            var dbSportMembership = await repo.GetByIdAsync<SportMembership>(1);

            Assert.That(dbSportMembership.Description, Is.EqualTo("This membership is edited"));
        }

        [Test]
        public async Task TestSportMembershipDelete()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddAsync(new SportMembership()
            {
                Id = 1,
                ImageUrl = "",
                Title = "",
                Description = ""
            });

            await repo.SaveChangesAsync();

            await sportMembershipService.Delete(1);


            var dbSportMembership = await repo.GetByIdAsync<SportMembership>(1);

            Assert.That(dbSportMembership.Description, Is.EqualTo(""));
        }

        [Test]
        public async Task TestAllCategories()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<Category>()
            {
                new Category() { Id = 1, Name = "d1" },
                new Category() { Id = 3, Name = "d2" },
                new Category() { Id = 5, Name = "d3" },
                new Category() { Id = 2, Name = "d4" }
            });

            await repo.SaveChangesAsync();
            var categoryCollection = await sportMembershipService.AllCategories();

            Assert.That(4, Is.EqualTo(categoryCollection.Count()));
        }

        [Test]
        public async Task TestAllCategoriesNames()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<Category>()
            {
                new Category() { Id = 1, Name = "d1" },
                new Category() { Id = 3, Name = "d2" },
                new Category() { Id = 5, Name = "d3" },
                new Category() { Id = 2, Name = "d4" }
            });

            await repo.SaveChangesAsync();
            var categoryCollection = await sportMembershipService.AllCategoriesNames();

            Assert.That(categoryCollection.FirstOrDefault(), Is.EqualTo("d1"));
        }

        [Test]
        public async Task TestSportMembershipCreate()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddAsync(new SportMembership()
            {
                CategoryId = 1,
                Description = "da1",
                ImageUrl = "da2",
                PricePerMonth = 10,
                Title = "da3",
                MemberId = 2
            });
           
            await repo.SaveChangesAsync();

            await sportMembershipService.Create(new SportMembershipModel()
            {
                CategoryId = 1,
                Description = "da1",
                ImageUrl = "da2",
                PricePerMonth = 10,
                Title = "da3",                
            }, 2);


            var dbSportMembership = await repo.GetByIdAsync<SportMembership>(1);

            Assert.That(dbSportMembership.Description, Is.EqualTo("da1"));            
        }

        [Test]
        public async Task TestAllSportMembershipsByMemberId()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "" },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "" },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "" },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "" }
            });

            await repo.SaveChangesAsync();
            var sportMembershipCollection = await sportMembershipService.AllSportMembershipsByMemberId(0);

            Assert.That(4, Is.EqualTo(sportMembershipCollection.Count()));
        }

        [Test]
        public async Task TestAllSportMembershipsByUserId()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "", BuyerId = "4" },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "", BuyerId = "4" },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "", BuyerId = "4" },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "", BuyerId = "4" }
            });

            await repo.SaveChangesAsync();
            var sportMembershipCollection = await sportMembershipService.AllSportMembershipsByUserId("4");

            Assert.That(4, Is.EqualTo(sportMembershipCollection.Count()));
        }

        [Test]
        public async Task TestCategoryExists()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 2 },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 3 },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 5 },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 7 }
            });

            await repo.SaveChangesAsync();
            await sportMembershipService.CategoryExists(5);
            var dbSportMembership = await repo.All<SportMembership>()
                .AnyAsync(a => a.CategoryId == 5);

            Assert.IsTrue(dbSportMembership);
        }

        [Test]
        public async Task TestExists()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 2 },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 3 },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 5 },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 7 }
            });

            await repo.SaveChangesAsync();
            await sportMembershipService.Exists(5);
            var dbSportMembership = await repo.All<SportMembership>()
                .AnyAsync(a => a.Id == 5);

            Assert.IsTrue(dbSportMembership);
        }

        [Test]
        public async Task TestHasMemberWithId()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            var currentUser = "toto";

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 2 },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 3 },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 5 },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 7 }
            });

            await repo.AddAsync(new Member()
            {
                Id = 1,
                FirstName = "da1",
                LastName = "da2",
                UserId = "da3",
                PhoneNumber = "da4"
            });
           
            await repo.SaveChangesAsync();
            await sportMembershipService.HasMemberWithId(1, "toto");
            var dbSportMembership = await repo.All<SportMembership>()
                .AnyAsync(a => a.Id == 5 && currentUser == "toto");

            Assert.IsTrue(dbSportMembership);
        }

        [Test]
        public async Task TestGetSportMembershipCategoryId()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 2 },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 3 },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 5 },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 7 }
            });

            await repo.SaveChangesAsync();
            await sportMembershipService.GetSportMembershipCategoryId(2);
            var dbSportMembershipCategoryId = await repo.All<SportMembership>()
                .AnyAsync(a => a.CategoryId == 2);

            Assert.IsTrue(dbSportMembershipCategoryId);
        }

        [Test]
        public async Task TestSportMembershipDetailsById()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 2 },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 3 },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 5 },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 7 }
            });

            await repo.SaveChangesAsync();

            await sportMembershipService.SportMembershipDetailsById(1);

            var dbSportMembership = await repo.GetByIdAsync<SportMembership>(1);

            Assert.That(dbSportMembership.Description, Is.EqualTo(""));
        }

        [Test]
        public async Task TestIsBought()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 2 },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 3 },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 5 },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 7 }
            });

            await repo.SaveChangesAsync();
            await sportMembershipService.IsBought(2);
            var dbSportMembershipBuyerId = await repo.All<SportMembership>()
                .AnyAsync(a => a.BuyerId == "4");

            Assert.IsTrue(dbSportMembershipBuyerId);
        }

        [Test]
        public async Task TestIsBoughtByUserWithId()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            var currentUser = "toto2";

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 2 },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 3 },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 5 },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "", BuyerId = "4", CategoryId = 7 }
            });

            await repo.SaveChangesAsync();
            await sportMembershipService.IsBoughtByUserWithId(1, "toto2");
            var dbSportMembership = await repo.All<SportMembership>()
                .AnyAsync(a => a.BuyerId == "4" && currentUser == "toto2");

            Assert.IsTrue(dbSportMembership);
        }

        [Test]
        public async Task TestCancel()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddAsync(new SportMembership()
            {
                Id = 1,
                ImageUrl = "",
                Title = "",
                Description = "",
                BuyerId = ""
            });

            await repo.SaveChangesAsync();

            await sportMembershipService.Cancel(1);


            var dbSportMembership = await repo.GetByIdAsync<SportMembership>(1);

            Assert.That(dbSportMembership.BuyerId, Is.EqualTo(null));
        }

        [Test]
        public async Task TestAll()
        {
            var loggerMock = new Mock<ILogger<SportMembershipService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            sportMembershipService = new SportMembershipService(repo, guard, logger);

            await repo.AddRangeAsync(new List<SportMembership>()
            {
                new SportMembership() { Id = 1, ImageUrl = "", Title = "", Description = "", BuyerId = "4" },
                new SportMembership() { Id = 3, ImageUrl = "", Title = "", Description = "", BuyerId = "4" },
                new SportMembership() { Id = 5, ImageUrl = "", Title = "", Description = "", BuyerId = "4" },
                new SportMembership() { Id = 2, ImageUrl = "", Title = "", Description = "", BuyerId = "4" }
            });

            await repo.SaveChangesAsync();

            var allCollection = await sportMembershipService.All();

            Assert.That(allCollection.TotalSportMembershipsCount, Is.EqualTo(4));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}