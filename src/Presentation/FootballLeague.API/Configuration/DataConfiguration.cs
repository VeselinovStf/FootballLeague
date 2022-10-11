using FootballLeague.Data.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FootballLeague.API.Configuration
{
    public static class DataConfiguration
    {
        public static void AddDataServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment hostEnvironment)
        {
            var connectionStringName = string.Empty;
            if (hostEnvironment.IsDevelopment())
            {
                connectionStringName = "DevelopmentDBConnectionString";
            }
            else
            {
                connectionStringName = "ProductionDBConnectionString";
            }

            services.ConfigureDataServices(configuration.GetConnectionString(connectionStringName));
        }
    }
}
