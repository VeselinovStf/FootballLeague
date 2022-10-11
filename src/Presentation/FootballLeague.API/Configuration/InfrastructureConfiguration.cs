using FootballLeague.Core.Interfaces;
using FootballLeague.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague.API.Configuration
{
    public static class InfrastructureConfiguration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(AppLoggerAdapter<>));
        }
    }
}
