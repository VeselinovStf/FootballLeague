﻿using FootballLeague.Core.Entities;
using FootballLeague.Core.Interfaces;
using FootballLeague.Core.Specifications;
using FootballLeague.Core.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootballLeague.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IAsyncRepository<Team> _teamRepository;

        public TeamService(IAsyncRepository<Team> teamRepository)
        {
            this._teamRepository = teamRepository;
        }

        public async Task<Team> CreateTeamAsync(string name)
        {
            Guard.StringIsNullEmptyOrWhiteSpace(name);

            return await this._teamRepository.AddAsync(new Team() { Name = name });
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
            Guard.ValueLessThenEqual(0, expectedId);

            return await this._teamRepository.GetByIdAsync(expectedId);
        }

        public async Task<IEnumerable<Team>> GetTeamsWithMatches()
        {
            var teamWitMatchesSpecification = new TeamsWithPlayedMatchesSpecification(false);

            return await this._teamRepository.ListAsyncBySpec(teamWitMatchesSpecification);
        }

        public async Task UpdateTeamAsync(int id, string newName)
        {
            Guard.ValueLessThenEqual(0, id);
            Guard.StringIsNullEmptyOrWhiteSpace(newName);

            var currentTeam = await this._teamRepository.GetByIdAsync(id);

            Guard.NotNull(currentTeam);

            currentTeam.Name = newName;

            await this._teamRepository.UpdateAsync(currentTeam);
        }

        public async Task DeleteTeamAsync(int id)
        {
            Guard.ValueLessThenEqual(0, id);
          
            var currentTeam = await this._teamRepository.GetByIdAsync(id);

            Guard.NotNull(currentTeam);      

            await this._teamRepository.DeleteAsync(currentTeam);
        }
    }
}
