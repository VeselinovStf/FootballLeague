using FootballLeague.API.Features.Commands.Team;
using FootballLeague.API.Features.Commands.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Team.Commands
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamRequest, UpdateTeamResponseModel>
    {
        private readonly ITeamService _teamService;

        public UpdateTeamCommandHandler(ITeamService teamService)
        {
            this._teamService = teamService;
        }
        public async Task<UpdateTeamResponseModel> Handle(UpdateTeamRequest request, CancellationToken cancellationToken)
        {
             await this._teamService
                .UpdateTeamAsync(request.TeamId, request.Name);

            return new UpdateTeamResponseModel(true, "Updated", new TeamResponseModel()
            {
                Id = request.TeamId,
                Name = request.Name
            });
        }
    }
}
