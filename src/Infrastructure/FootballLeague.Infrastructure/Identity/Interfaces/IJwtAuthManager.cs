using FootballLeague.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FootballLeague.Infrastructure.Identity.Interfaces
{
    public interface IJwtAuthManager
    {
        JwtAuthResult GenerateTokens(string username, List<Claim> claims, DateTime now);

        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }
}