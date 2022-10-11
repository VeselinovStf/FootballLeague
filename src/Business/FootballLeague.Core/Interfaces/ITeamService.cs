using FootballLeague.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Interfaces
{
    public interface ITeamService
    {
        Task<Team> CreateTeamAsync(string name);
        Task<Team> GetTeamByIdAsync(int expectedId);
        Task<IEnumerable<Team>> GetAllTeamsAsync();

        Task UpdateTeamAsync(int id, string newName);

        Task DeleteTeamAsync(int id);
        Task<IEnumerable<Team>> GetAllTeamsWithStatisticsAsync();

        Task<IEnumerable<Team>> GetTeamsWithMatches();
    }
}
