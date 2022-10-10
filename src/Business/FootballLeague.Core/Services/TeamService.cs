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

            var repoEntities = this._teamRepository.GetAllBySpec(teamWitStatisticsSpecification);

            return await Task.FromResult(repoEntities);
        }

        public async Task<IEnumerable<Team>> GetTeamsWithMatches()
        {
            var teamWitMatchesSpecification = new TeamsWithPlayedMatchesSpecification(false);

            var repoEntities = this._teamRepository.GetAllBySpec(teamWitMatchesSpecification);

            return await Task.FromResult(repoEntities);
        }
    }
}
