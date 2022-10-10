using FootballLeague.Core.Entities;
using FootballLeague.Core.Interfaces;
using FootballLeague.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IAsyncRepository<Team> _teamRepository;

        public TeamService(IAsyncRepository<Team> teamRepository)
        {
            this._teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await this._teamRepository.ListAllAsync();
        }

        public async Task<IEnumerable<Team>> GetAllTeamsWithStatisticsAsync()
        {
            var teamWitStatisticsSpecification = new TeamsWithStatiscticsSpecification(false);

            return await this._teamRepository.ListAsyncBySpec(teamWitStatisticsSpecification);

        }

        public async Task<Team> GetTeamByIdAsync(int expectedId)
        {
            return await this._teamRepository.GetByIdAsync(expectedId);
        }

        public async Task<IEnumerable<Team>> GetTeamsWithMatches()
        {
            var teamWitMatchesSpecification = new TeamsWithPlayedMatchesSpecification(false);

            return await this._teamRepository.ListAsyncBySpec(teamWitMatchesSpecification);
        }
    }
}
