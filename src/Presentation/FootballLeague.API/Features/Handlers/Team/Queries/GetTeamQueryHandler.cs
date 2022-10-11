using FootballLeague.API.Features.Queries.Team;
using FootballLeague.API.Features.Queries.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Team.Queries
{
    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, GetTeamQueryResponseModel>
    {
        private readonly ITeamService _teamService;

        public GetTeamQueryHandler(ITeamService teamService)
        {
            this._teamService = teamService;
        }
        public async Task<GetTeamQueryResponseModel> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var serviceCall = await this._teamService
                .GetTeamByIdAsync(request.Id);

            return new GetTeamQueryResponseModel(true, "Returning Team", new TeamModel()
            {
                TeamId = serviceCall.Id,
                TeamName = serviceCall.Name
            });
        }
    }
}
