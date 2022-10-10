using FootballLeague.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Interfaces
{
    public interface ITeamService
    {
        Task<Team> GetTeamByIdAsync(int expectedId);
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<IEnumerable<Team>> GetAllTeamsWithStatisticsAsync();

        Task<IEnumerable<Team>> GetTeamsWithMatches();
    }
}
