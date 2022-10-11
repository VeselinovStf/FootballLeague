using FootballLeague.API.Features.Commands.Match.ResponseModels;
using FootballLeague.API.Features.Commands.Match;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace FootballLeague.API.Features.Handlers.Match.Commands
{
    public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchRequest, UpdateMatchResponseModel>
    {
        private readonly IMatchService _matchService;

        public UpdateMatchCommandHandler(IMatchService matchService)
        {
            this._matchService = matchService;
        }

        public Task<UpdateMatchResponseModel> Handle(UpdateMatchRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
