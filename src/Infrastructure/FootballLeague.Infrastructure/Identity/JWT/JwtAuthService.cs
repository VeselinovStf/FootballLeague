using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FootballLeague.Core.Validations;
using FootballLeague.Infrastructure.Identity.Entities;
using FootballLeague.Infrastructure.Identity.Interfaces;
using FootballLeague.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace FootballLeague.Infrastructure.Identity.JWT
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly UserManager<AppUser> _userManager;

        public JwtAuthService(
             IJwtAuthManager jwtAuthManager,
             UserManager<AppUser> userManager)
        {
            this._jwtAuthManager = jwtAuthManager;
            this._userManager = userManager;
        }

        public async Task<JwtAuthResult> GenerateLogin(string userName)
        {
            Guard.StringIsNullEmptyOrWhiteSpace(userName);

            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                var roles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }


                return _jwtAuthManager.GenerateTokens(userName, claims, DateTime.Now);
            }
            catch (Exception ex)
            {
                return new JwtAuthResult(false, ex.Message);
            }

        }

    }
}
