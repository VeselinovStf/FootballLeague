using FootballLeague.Core.Entities;
using FootballLeague.Core.Interfaces;
using FootballLeague.Core.Validations;
using System;
using System.Collections.Generic;
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

            var newMatch = new Match(
                homeTeamId,
                awayTeamId,
                matchDate,
                homeTeamScore,
                awayTeamScore
            );

            return await this._matchRepository.AddAsync(newMatch);
        }

        public async Task DeleteMatchAsync(int id)
        {
            Guard.ValueLessThenEqual(0, id);

            var currentMatch = await this._matchRepository.GetByIdAsync(id);

            Guard.NotNull(currentMatch);

            // NOTE: Match is marked as Deleted! Removing scores from Team Statistic
            // TODO: What is happening if Match is from as Deleted=false in db!
            currentMatch.DeleteMatchResult(currentMatch.HomeTeamScore, currentMatch.AwayTeamScore);

            await this._matchRepository.DeleteAsync(currentMatch);
        }

        public async Task<IEnumerable<Match>> GetAllMatchesAsync()
        {
            return await this._matchRepository.ListAllAsync();
        }

        public async Task<Match> GetMatchByIdAsync(int expectedId)
        {
            Guard.ValueLessThenEqual(0, expectedId);

            return await this._matchRepository.GetByIdAsync(expectedId);
        }

        public async Task UpdateMatchAsync(
            int id,
            DateTime matchDate,
            int homeTeamResult,
            int awayTeamResult)
        {
            Guard.ValueLessThenEqual(0, id);
            Guard.ValueLessThenEqual(-1, homeTeamResult);
            Guard.ValueLessThenEqual(-1, awayTeamResult);

            var currentMatch = await this._matchRepository.GetByIdAsync(id);

            Guard.NotNull(currentMatch);

            currentMatch.UpdateMatchResult(homeTeamResult, awayTeamResult);
            currentMatch.UpdateMatchDate(matchDate);

            await this._matchRepository.UpdateAsync(currentMatch);
        }
    }
}
