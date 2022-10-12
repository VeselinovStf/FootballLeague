using FootballLeague.Infrastructure.Data;
using FootballLeague.Infrastructure.Identity;
using FootballLeague.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.IO;

namespace FootballLeague.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logsPath = Path.Combine(Environment.CurrentDirectory, "Logs");

            NLog.GlobalDiagnosticsContext.Set("AppDirectory", logsPath);
            NLog.Common.InternalLogger.LogFile = Path.Combine(logsPath, "nlog-internal.log");

            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

            try
            {
                logger.Debug("init main");
                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;

                    var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var identityContext = serviceProvider.GetRequiredService<AppIdentityDbContext>();
                    var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
                    var config = serviceProvider.GetRequiredService<IConfiguration>();

                    var adminSeedPassword = string.Empty;
                    if (environment.IsDevelopment())
                    {
                        adminSeedPassword = config.GetSection("Development_AdminPassword").Value;
                    }
                    else
                    {
                        //TODO: Add administration pass from secured source
                        adminSeedPassword = config.GetSection("Production_DevAdminPassword").Value;
                    }

                    AppIdentityDbContextSeed.SeedAsync(
                        identityContext, 
                        userManager, 
                        roleManager,
                        adminSeedPassword)
                        .GetAwaiter()
                        .GetResult();

                }

                host.Run();
            }
            catch (Exception ex)
            {

                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                    logging.ClearProviders();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseNLog();
    }
}
