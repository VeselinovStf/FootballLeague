using FootballLeague.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsWithStatisticsAsync();

        Task<IEnumerable<Team>> GetTeamsWithMatches();
    }
}
