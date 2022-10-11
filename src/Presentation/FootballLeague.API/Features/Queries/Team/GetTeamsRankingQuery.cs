using FootballLeague.API.Features.Team.Queries.ResponseModels;
using MediatR;

namespace FootballLeague.API.Features.Queries.Team
{
    public class GetTeamsRankingQuery : IRequest<GetTeamsRankingQueryResponseModel>
    {
    }
}
