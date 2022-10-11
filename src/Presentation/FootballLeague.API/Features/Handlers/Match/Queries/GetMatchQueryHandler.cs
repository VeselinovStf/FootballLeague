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
        public Task<GetMatchQueryResponseModel> Handle(GetMatchQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
