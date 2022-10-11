using FootballLeague.API.Features.Queries.Match.ResponseModels;
using MediatR;

namespace FootballLeague.API.Features.Queries.Match
{
    public class GetMatchesQuery : IRequest<GetMatchesQueryResponseModel>
    {
    }
}
