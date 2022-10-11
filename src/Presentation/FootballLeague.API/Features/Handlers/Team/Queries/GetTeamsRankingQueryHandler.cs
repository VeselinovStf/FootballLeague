using FootballLeague.API.Features.Queries.Team;
using FootballLeague.API.Features.Team.Queries.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Team.Queries
{
    public class GetTeamsRankingQueryHandler : IRequestHandler<GetTeamsRankingQuery, GetTeamsRankingQueryResponseModel>
    {
        private readonly ITeamService _teamService;

        public GetTeamsRankingQueryHandler(
            ITeamService teamService)
        {
            this._teamService = teamService;
        }

        public async Task<GetTeamsRankingQueryResponseModel> Handle(GetTeamsRankingQuery request, CancellationToken cancellationToken)
        {
            var serviceCall = await _teamService.GetAllTeamsWithStatisticsAsync();

            return new GetTeamsRankingQueryResponseModel(true, "Returning Teams Ranking",
                new List<TeamsRankingResponseModel>(serviceCall.Select(t => new TeamsRankingResponseModel()
                {
                    Score = t.Statistic.TotalScore,
                    TeamName = t.Name
                })));
        }
    }
}
