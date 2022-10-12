using FootballLeague.API.Features.Queries.Match;
using FootballLeague.API.Features.Queries.Match.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Match.Queries
{
    public class GetMatchQueryHandler : IRequestHandler<GetMatchQuery, GetMatchQueryResponseModel>
    {
        private readonly IMatchService _matchService;

        public GetMatchQueryHandler(IMatchService matchService)
        {
            this._matchService = matchService;
        }
        public async Task<GetMatchQueryResponseModel> Handle(GetMatchQuery request, CancellationToken cancellationToken)
        {
            var serviceCall = await this._matchService
                .GetMatchByIdAsync(request.Id);

            if (serviceCall == null) return new GetMatchQueryResponseModel(false, "Unable to find Match");

            return new GetMatchQueryResponseModel(true, "Returning Match", new MathQueryResponseModel()
            {
                MatchId = serviceCall.Id,
                AwayTeamId = serviceCall.AwayTeamId,
                HomeTeamId = serviceCall.HomeTeamId,
                AwayTeamScore = serviceCall.AwayTeamScore,
                Date = serviceCall.Date,
                HomeTeamScore = serviceCall.HomeTeamScore
            });
        }
    }
}
