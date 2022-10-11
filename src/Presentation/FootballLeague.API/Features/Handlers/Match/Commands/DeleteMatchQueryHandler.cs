using FootballLeague.API.Features.Commands.Match;
using FootballLeague.API.Features.Commands.Match.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Match.Commands
{
    public class DeleteMatchQueryHandler : IRequestHandler<DeleteMatchRequestModel, DeleteMatchResponseModel>
    {
        private readonly IMatchService _matchService;

        public DeleteMatchQueryHandler(IMatchService matchService)
        {
            this._matchService = matchService;
        }

        public async Task<DeleteMatchResponseModel> Handle(DeleteMatchRequestModel request, CancellationToken cancellationToken)
        {
            await this._matchService
                .DeleteMatchAsync(request.MatchId);

            return new DeleteMatchResponseModel(true, "Deleted", request.MatchId);
        }
    }
}
