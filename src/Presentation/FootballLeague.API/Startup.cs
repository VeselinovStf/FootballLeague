using FootballLeague.API.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FootballLeague.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            this.Configuration = configuration;
            this.Env = hostEnvironment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Env { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCoreServices();
            services.AddDataServices(Configuration, Env);
            services.AddInfrastructureServices();
            services.AddAPIServices();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
