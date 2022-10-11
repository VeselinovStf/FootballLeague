using FootballLeague.API.Features.Queries.Match;
using FootballLeague.API.Features.Queries.Match.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Match.Queries
{
    public class GetMatchesQueryHandler : IRequestHandler<GetMatchesQuery, GetMatchesQueryResponseModel>
    {
        private readonly IMatchService _matchService;

        public GetMatchesQueryHandler(IMatchService matchService)
        {
            this._matchService = matchService;
        }

        public async Task<GetMatchesQueryResponseModel> Handle(GetMatchesQuery request, CancellationToken cancellationToken)
        {
            var serviceCall = await this._matchService
                .GetAllMatchesAsync();

            return new GetMatchesQueryResponseModel(true, "Returning Matches",
                new List<MathQueryResponseModel>(serviceCall.Select(m => new MathQueryResponseModel()
                {
                    MatchId = m.Id,
                    AwayTeamId = m.AwayTeamId,
                    AwayTeamScore = m.AwayTeamScore,
                    Date = m.Date,
                    HomeTeamId = m.HomeTeamId,
                    HomeTeamScore = m.HomeTeamScore
                })));
        }
    }
}
