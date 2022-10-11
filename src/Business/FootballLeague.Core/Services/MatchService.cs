using FootballLeague.Core.Entities;
using FootballLeague.Core.Interfaces;
using FootballLeague.Core.Validations;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IAsyncRepository<Match> _matchRepository;
        private readonly IAsyncRepository<Team> _teamRepository;

        public MatchService(
            IAsyncRepository<Match> matchRepository,
            IAsyncRepository<Team> teamRepository)
        {
            this._matchRepository = matchRepository;
            this._teamRepository = teamRepository;
        }

        public async Task<Match> CreateMatchAsync(
            int homeTeamId, 
            int awayTeamId, 
            DateTime matchDate, 
            int homeTeamScore, 
            int awayTeamScore)
        {
            Guard.ValueLessThenEqual(0, homeTeamId);
            Guard.ValueLessThenEqual(0, awayTeamId);

            var homeTeam = await this._teamRepository.GetByIdAsync(homeTeamId);
            var awayTeam = await this._teamRepository.GetByIdAsync(awayTeamId);

            // Validate Teams - are they existing?
            Guard.NotNull(homeTeam);
            Guard.NotNull(awayTeam);

            var newMatch = new Match(homeTeamId, awayTeamId, matchDate, new MatchResult()
            {
                HomeTeamScore = homeTeamScore,
                AwayTeamScore = awayTeamScore
            });

            return await this._matchRepository.AddAsync(newMatch);
        }
    }
}
