using FootballLeague.Core.Interfaces;
using FootballLeague.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague.API.Configuration
{
    public static class CoreConfiguration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IMatchService, MatchService>();
        }
    }
}
