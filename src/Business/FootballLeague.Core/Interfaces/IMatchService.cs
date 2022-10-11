using FootballLeague.Core.Entities;
using System;
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
    }
}
