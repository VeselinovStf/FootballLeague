using FootballLeague.API.Features.Queries.Team;
using FootballLeague.API.Features.Queries.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Team.Queries
{
    public class GetTeamsPlayedMatchesQueryHandler : IRequestHandler<GetTeamsPlayedMatchesQuery, GetTeamsPlayedMatchesQueryResponseModel>
    {
        private readonly ITeamService _teamService;

        public GetTeamsPlayedMatchesQueryHandler(ITeamService teamService)
        {
            this._teamService = teamService;
        }
        public async Task<GetTeamsPlayedMatchesQueryResponseModel> Handle(GetTeamsPlayedMatchesQuery request, CancellationToken cancellationToken)
        {
            var teamsMatches = await this._teamService
                .GetTeamsWithMatches();

            return new GetTeamsPlayedMatchesQueryResponseModel(true, "Returning Teams With Matches",
                new List<TeamPlayedMatchesResponseModel>(teamsMatches.Select(t => new TeamPlayedMatchesResponseModel()
                {
                    TeamId = t.Id,
                    TeamName = t.Name,
                    HomeMatches = new List<TeamPlayedMatchResponseModel>(t.HomeMatches.Select(h => new TeamPlayedMatchResponseModel()
                    {
                        TeamId = h.Id,
                        TeamName = h.HomeTeam.Name,
                        Result = h.HomeTeamScore,
                    })),
                    AwayMatches = new List<TeamPlayedMatchResponseModel>(t.AwayMatches.Select(a => new TeamPlayedMatchResponseModel()
                    {
                        TeamId = a.Id,
                        TeamName = a.AwayTeam.Name,
                        Result = a.AwayTeamScore
                    }))
                })));
        }
    }
}
