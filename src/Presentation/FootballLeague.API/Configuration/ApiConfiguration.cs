using FootballLeague.Data;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FootballLeague.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddSwaggerGen();


            var assemblies = new Assembly[]
            {
                typeof(Startup).Assembly,
                typeof(FootballLeagueDbContext).Assembly,
            };

            services.AddMediatR(assemblies);
        }
    }
}
