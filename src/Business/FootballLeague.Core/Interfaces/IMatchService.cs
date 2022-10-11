using FootballLeague.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Interfaces
{
    public interface IMatchService
    {
        Task<Match> CreateMatchAsync(
             int homeTeamId,
             int awayTeamId,
             DateTime matchDate,
             int homeTeamScore,
             int awayTeamScore);

        Task<Match> GetMatchByIdAsync(int expectedId);
        Task<IEnumerable<Match>> GetAllMatchesAsync();

        Task UpdateMatchAsync(int id,
            DateTime matchDate,
            int homeTeamResult,
            int awayTeamResult);

        Task DeleteMatchAsync(int id);
    }
}
