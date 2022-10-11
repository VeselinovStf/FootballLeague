using FootballLeague.Core.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FootballLeague.API.Features.Commands.Match;
using FootballLeague.API.Features.Commands.Match.ResponseModels;

namespace FootballLeague.API.Features.Handlers.Match.Commands
{
    public class DeleteMatchQueryHandler : IRequestHandler<DeleteMatchRequestModel, DeleteMatchResponseModel>
    {
        private readonly IMatchService _matchService;

        public DeleteMatchQueryHandler(IMatchService matchService)
        {
            this._matchService = matchService;
        }

        public Task<DeleteMatchResponseModel> Handle(DeleteMatchRequestModel request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
