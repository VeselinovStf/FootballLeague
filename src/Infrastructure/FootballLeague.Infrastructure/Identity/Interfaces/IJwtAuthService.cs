using FootballLeague.Infrastructure.Identity.Models;
using System.Threading.Tasks;

namespace FootballLeague.Infrastructure.Identity.Interfaces
{
    public interface IJwtAuthService
    {
        Task<JwtAuthResult> GenerateLogin(string userName);
    }
}