using FootballLeague.Infrastructure.Data;
using FootballLeague.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FootballLeague.Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(
            AppIdentityDbContext identityDbContext,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            string adminDefaultPassword)
        {
            if (identityDbContext.Database.IsSqlServer())
            {
                identityDbContext.Database.Migrate();
            }

            if (!await identityDbContext.Users.AnyAsync())
            {
                // await roleManager.CreateAsync(new IdentityRole(AppRoles.ADMINISTRATOR.ToString()));

                string adminUserName = "admin@footballleague.com";
                var adminUser = new AppUser { UserName = adminUserName, Email = adminUserName };
                await userManager.CreateAsync(adminUser, adminDefaultPassword);
                adminUser = await userManager.FindByNameAsync(adminUserName);
                await userManager.AddToRoleAsync(adminUser, AppRoles.ADMINISTRATOR.ToString());
            }

        }
    }
}
