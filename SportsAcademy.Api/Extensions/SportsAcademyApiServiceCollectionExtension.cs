using Microsoft.EntityFrameworkCore;
using SportsAcademy.Core.Contracts;
using SportsAcademy.Core.Exceptions;
using SportsAcademy.Core.Services;
using SportsAcademy.Infrastructure.Data;
using SportsAcademy.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SportsAcademyApiServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IGuard, Guard>();

            return services;
        }

        public static IServiceCollection AddSportsAcademyDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
