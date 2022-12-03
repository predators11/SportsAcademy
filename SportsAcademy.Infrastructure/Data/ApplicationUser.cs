using Microsoft.AspNetCore.Identity;

namespace SportsAcademy.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
