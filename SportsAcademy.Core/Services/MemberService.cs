using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Core.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository repo;

        public MemberService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(string firstName, string lastName, string userId, string phoneNumber)
        {
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

        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<Member>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> GetMemberId(string userId)
        {
            return (await repo.AllReadonly<Member>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserHasBuys(string userId)
        {
            return await repo.All<SportMembership>()
                .AnyAsync(h => h.BuyerId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<Member>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }

        public async Task<bool> UserWithFirstNameExists(string firsName)
        {
            return await repo.All<Member>()
                .AnyAsync(a => a.FirstName == firsName);
        }

        public async Task<bool> UserWithLastNameExists(string lastName)
        {
            return await repo.All<Member>()
                .AnyAsync(a => a.LastName == lastName);
        }
    }
}
