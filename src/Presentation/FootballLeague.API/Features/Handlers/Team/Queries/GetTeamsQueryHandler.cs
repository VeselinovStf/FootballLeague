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
    public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, GetTeamsQueryResponseModel>
    {
        private readonly ITeamService _teamService;

        public GetTeamsQueryHandler(ITeamService teamService)
        {
            this._teamService = teamService;
        }
        public async Task<GetTeamsQueryResponseModel> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            var serviceCall = await this._teamService
                .GetAllTeamsAsync();

            return new GetTeamsQueryResponseModel(true, "Returning Teams",
                new List<TeamModel>(serviceCall.Select(t => new TeamModel()
                {
                    TeamId = t.Id,
                    TeamName = t.Name
                })));
        }
    }
}
