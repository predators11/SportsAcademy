using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Services;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Tests.UnitTests
{
    public class MemberServiceTests
    {
        private IRepository repo;
        private ApplicationDbContext applicationDbContext;
        private IMemberService memberService;

        [SetUp]
        public async Task SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("memberDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestMemberCreate()
        {
            var repo = new Repository(applicationDbContext);
            memberService = new MemberService(repo);

            await repo.AddAsync(new Member()
            {
                FirstName = "da1",
                LastName = "da2",
                UserId = "da3",
                PhoneNumber = "da4"
            });

            await repo.SaveChangesAsync();

            await memberService.Create("da1", "da2", "da3", "da4");

            var dbMember = await repo.GetByIdAsync<Member>(1);

            Assert.That(dbMember.FirstName, Is.EqualTo("da1"));
        }

        [Test]
        public async Task TestExistsByIdAndGetByMemberId()
        {
            var repo = new Repository(applicationDbContext);
            memberService = new MemberService(repo);

            await repo.AddAsync(new Member()
            {
                FirstName = "da1",
                LastName = "da2",
                UserId = "da3",
                PhoneNumber = "da4"
            });

            await repo.SaveChangesAsync();
            await memberService.ExistsById("da3");
            await memberService.GetMemberId("da3");
            var dbMember = await repo.All<Member>()
                .AnyAsync(a => a.UserId == "da3");

            Assert.IsTrue(dbMember);
        }

        [Test]
        public async Task TestUserHasBuys()
        {
            var repo = new Repository(applicationDbContext);
            memberService = new MemberService(repo);

            await repo.AddAsync(new Member()
            {
                FirstName = "da1",
                LastName = "da2",
                UserId = "da3",
                PhoneNumber = "da4"
            });

            await repo.SaveChangesAsync();

            await memberService.UserHasBuys("da3");

            var dbMember = await repo.GetByIdAsync<Member>(1);

            Assert.That(dbMember.UserId, Is.EqualTo("da3"));
        }

        [Test]
        public async Task TestUserWithPhoneNumberExists()
        {
            var repo = new Repository(applicationDbContext);
            memberService = new MemberService(repo);

            await repo.AddAsync(new Member()
            {
                FirstName = "da1",
                LastName = "da2",
                UserId = "da3",
                PhoneNumber = "da4"
            });

            await repo.SaveChangesAsync();

            await memberService.UserWithPhoneNumberExists("da4");

            var dbMember = await repo.GetByIdAsync<Member>(1);

            Assert.That(dbMember.PhoneNumber, Is.EqualTo("da4"));
        }

        [Test]
        public async Task TestUserWithFirstNameExists()
        {
            var repo = new Repository(applicationDbContext);
            memberService = new MemberService(repo);

            await repo.AddAsync(new Member()
            {
                FirstName = "da1",
                LastName = "da2",
                UserId = "da3",
                PhoneNumber = "da4"
            });

            await repo.SaveChangesAsync();

            await memberService.UserWithFirstNameExists("da1");

            var dbMember = await repo.GetByIdAsync<Member>(1);

            Assert.That(dbMember.FirstName, Is.EqualTo("da1"));
        }

        [Test]
        public async Task TestUserWithLastNameExists()
        {
            var repo = new Repository(applicationDbContext);
            memberService = new MemberService(repo);

            await repo.AddAsync(new Member()
            {
                FirstName = "da1",
                LastName = "da2",
                UserId = "da3",
                PhoneNumber = "da4"
            });

            await repo.SaveChangesAsync();

            await memberService.UserWithLastNameExists("da2");

            var dbMember = await repo.GetByIdAsync<Member>(1);

            Assert.That(dbMember.LastName, Is.EqualTo("da2"));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }    
}
