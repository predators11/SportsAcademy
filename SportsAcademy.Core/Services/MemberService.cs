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

        /// <summary>
        /// Add member to repository
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userId"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checking if the member exists with that id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<Member>()
                .AnyAsync(a => a.UserId == userId);
        }

        /// <summary>
        /// Getting the member with the current userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetMemberId(string userId)
        {
            return (await repo.AllReadonly<Member>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        /// <summary>
        /// Checking if the member has buys with the current userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> UserHasBuys(string userId)
        {
            return await repo.All<SportMembership>()
                .AnyAsync(h => h.BuyerId == userId);
        }

        /// <summary>
        /// Checking if the member exists with that phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<Member>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// Checking if the user exists with that first name
        /// </summary>
        /// <param name="firsName"></param>
        /// <returns></returns>
        public async Task<bool> UserWithFirstNameExists(string firsName)
        {
            return await repo.All<Member>()
                .AnyAsync(a => a.FirstName == firsName);
        }

        /// <summary>
        /// Checking if the user exists with that last name
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public async Task<bool> UserWithLastNameExists(string lastName)
        {
            return await repo.All<Member>()
                .AnyAsync(a => a.LastName == lastName);
        }
    }
}
