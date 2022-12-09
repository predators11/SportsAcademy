using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAcademy.Core.Contracts.Users
{
    public interface IUsersService
    {
        string UserFullName(string userId);
    }
}
