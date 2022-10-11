using FootballLeague.API.Features.Commands.Team;
using FootballLeague.API.Features.Commands.Team.ResponseModels;
using FootballLeague.API.Features.Queries.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Team.Commands
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamRequest, CreateTeamResponseModel>
    {
        private readonly ITeamService _teamService;

        public CreateTeamCommandHandler(ITeamService teamService)
        {
            this._teamService = teamService;
        }
        public async Task<CreateTeamResponseModel> Handle(CreateTeamRequest request, CancellationToken cancellationToken)
        {
            var createdTeam = await this._teamService
                .CreateTeamAsync(request.Name);

            return new CreateTeamResponseModel(true, "Team Created", new TeamResponseModel()
            {
                Id = createdTeam.Id,
                Name = createdTeam.Name
            });
        }
    }
}
