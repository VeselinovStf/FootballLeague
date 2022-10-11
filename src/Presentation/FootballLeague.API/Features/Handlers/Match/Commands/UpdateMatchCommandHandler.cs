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

        public async Task<UpdateMatchResponseModel> Handle(UpdateMatchRequest request, CancellationToken cancellationToken)
        {
            await this._matchService
                .UpdateMatchAsync(
                    request.MatchId,
                    request.Date,
                    request.HomeTeamScore,
                    request.AwayTeamScore);

            return new UpdateMatchResponseModel(true, "Updated", new MatchCommandResponseModel()
            {
                MatchId = request.MatchId,
                AwayTeamScore = request.AwayTeamScore,
                HomeTeamScore = request.HomeTeamScore,
                MatchDate = request.Date
            });
        }
    }
}
