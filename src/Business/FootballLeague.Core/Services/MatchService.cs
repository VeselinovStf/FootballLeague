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

            var homeTeamCall = this._teamRepository.GetByIdAsync(homeTeamId);
            var awayTeamCall = this._teamRepository.GetByIdAsync(awayTeamId);

            await Task.WhenAll(new Task[] { homeTeamCall, awayTeamCall });

            var homeTeam = homeTeamCall.Result;
            var awayTeam = awayTeamCall.Result;

            // Validate Teams - are they existing?
            Guard.NotNull(homeTeam);
            Guard.NotNull(awayTeam);

            var newMatch = new Match()
            {
                HomeTeamId = homeTeamId,
                AwayTeamId = awayTeamId,
                Date = matchDate,
                Result = new MatchResult()
                {
                    HomeTeamScore = homeTeamScore,
                    AwayTeamScore = awayTeamScore
                }
            };

            return await this._matchRepository.AddAsync(newMatch);
        }
    }
}
