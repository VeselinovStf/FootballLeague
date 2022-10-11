using FootballLeague.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague.Data.Extensions
{
    public static class ConfigureServiceExtension
    {
        public static void ConfigureDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FootballLeagueDbContext>(c =>
                c.UseSqlServer(connectionString));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
        }
    }
}
