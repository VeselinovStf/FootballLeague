using FootballLeague.Core.Interfaces;
using FootballLeague.Infrastructure.Data;
using FootballLeague.Infrastructure.Identity.Entities;
using FootballLeague.Infrastructure.Identity.Interfaces;
using FootballLeague.Infrastructure.Identity.JWT;
using FootballLeague.Infrastructure.Identity.Models;
using FootballLeague.Infrastructure.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;

namespace FootballLeague.API.Configuration
{
    public static class InfrastructureConfiguration
    {
        public static void AddInfrastructureServices(
            this IServiceCollection services, 
            IConfiguration configuration,
            IWebHostEnvironment hostEnvironment)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(AppLoggerAdapter<>));

            var identityConnectionStringName = string.Empty;
            JwtTokenConfig jwtTokenConfig;
            if (hostEnvironment.IsDevelopment())
            {
                identityConnectionStringName = "Development_IdentityDBConnectionString";
                jwtTokenConfig = configuration.GetSection("Development_jwtTokenConfig").Get<JwtTokenConfig>();
            }
            else
            {
                // TODO: Use more secured storage of connection strings and secrets for PRODUCTION
                identityConnectionStringName = "Production_IdentityDBConnectionString";
                jwtTokenConfig = configuration.GetSection("Development_jwtTokenConfig").Get<JwtTokenConfig>();
            }

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(identityConnectionStringName)));

            services.AddIdentity<AppUser, IdentityRole>()
                       .AddEntityFrameworkStores<AppIdentityDbContext>()
                                       .AddDefaultTokenProviders();
            //JwtAuth
            services.AddSingleton(jwtTokenConfig);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1),
                    NameClaimType = ClaimTypes.NameIdentifier,

                };
            });

            services.AddScoped<IJwtAuthManager, JwtAuthManager>();
            services.AddScoped<IJwtAuthService, JwtAuthService>();
        }
    }
}
