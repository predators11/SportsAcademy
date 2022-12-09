using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Contracts.Users;
using SportsAcademy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAcademy.Core.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext data;

        public UsersService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public string UserFullName(string userId)
        {
            var user = data.Users.Find(userId);

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}
