using Microsoft.Extensions.DependencyInjection;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Services;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;
using SportsAcademy.Tests.DbContext;

namespace SportsAcademy.Tests.UnitTests
{
    public class MemberServiceTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task SetUp()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IMemberService, MemberService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void CreateMemberIsValid()
        {
            var firstName = "Cako";
            var lastName = "Cakov";
            var userId = "userId";
            var phoneNumber = "0893555555";

            var member = new Member()
            {
                FirstName = firstName,
                LastName = lastName,
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            var service = serviceProvider.GetService<IMemberService>();

            Assert.DoesNotThrowAsync(async () => await service.Create(firstName, lastName, userId, phoneNumber));
        }

        [Test]
        public void ExistsByIdWorks()
        {
            //var userId = "userId";
            //var service = serviceProvider.GetService<IMemberService>();
            //var result = service.ExistsById(Member.UserId);           

            //Assert.IsTrue(result);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IRepository repo)
        {
            var firstName = "Cako";
            var lastName = "Cakov";
            var userId = "userId";
            var phoneNumber = "0893555555";

            var member = new Member()
            {
                FirstName = firstName,
                LastName = lastName,
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await repo.AddAsync(member);
            await repo.SaveChangesAsync();
        }
    }
}