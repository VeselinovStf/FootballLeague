using FootballLeague.API.Features.Queries.Match;
using FootballLeague.API.Features.Queries.Match.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
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

        public Task<GetMatchesQueryResponseModel> Handle(GetMatchesQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
