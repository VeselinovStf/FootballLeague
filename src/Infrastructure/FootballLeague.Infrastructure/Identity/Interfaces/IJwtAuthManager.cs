using FootballLeague.Infrastructure.Identity.Models;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;

namespace FootballLeague.Infrastructure.Identity.Interfaces
{
    public interface IJwtAuthManager
    {
        JwtAuthResult GenerateTokens(string username, List<Claim> claims, DateTime now);

        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }
}