using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}
