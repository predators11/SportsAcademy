using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts.Admin;
using SportsAcademy.Core.Models.Admin;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace SportsAcademy.Core.Services.Admin
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<Member>()
                .Select(a => new UserServiceModel() 
                {
                    UserId = a.UserId,
                    Email = a.User.Email,
                    FullName = $"{ a.User.FirstName } { a.User.LastName }",
                    PhoneNumber = a.PhoneNumber
                })
                .ToListAsync();

            string[] memberIds = result.Select(a => a.UserId).ToArray();

            result.AddRange(await repo.AllReadonly<ApplicationUser>()
                .Where(u => memberIds.Contains(u.Id) == false)
                .Select(u => new UserServiceModel() 
                {
                    UserId = u.Id,
                    Email = u.Email,
                    FullName = $"{ u.FirstName } { u.LastName }"
                }).ToListAsync());

            return result;
        }

        public async Task<string> UserFullName(string userId)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);

            return $"{user?.FirstName} {user?.LastName}".Trim();
        }
    }
}
