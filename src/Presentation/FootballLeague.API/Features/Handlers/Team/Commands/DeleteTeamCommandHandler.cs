using FootballLeague.API.Features.Commands.Team;
using FootballLeague.API.Features.Commands.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Team.Commands
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamRequest, DeleteTeamResponseModel>
    {
        private readonly ITeamService _teamService;

        public DeleteTeamCommandHandler(ITeamService teamService)
        {
            this._teamService = teamService;
        }
        public async Task<DeleteTeamResponseModel> Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
        {
            await this._teamService
               .DeleteTeamAsync(request.TeamId);

            return new DeleteTeamResponseModel(true, "Deleted", request.TeamId);
        }
    }
}
