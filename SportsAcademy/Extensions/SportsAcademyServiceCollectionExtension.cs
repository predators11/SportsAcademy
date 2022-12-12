using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Contracts.Admin;
using SportsAcademy.Core.Exceptions;
using SportsAcademy.Core.Services;
using SportsAcademy.Core.Services.Admin;
using SportsAcademy.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SportsAcademyServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ISportMembershipService, SportMembershipService>();
            services.AddScoped<ISportingHallService, SportingHallService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IGuard, Guard>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITrainerService, TrainerService>();

            return services;
        }
    }
}
