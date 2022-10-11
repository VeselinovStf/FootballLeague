using FootballLeague.API.Features.Queries.Team.ResponseModels;
using MediatR;

namespace FootballLeague.API.Features.Queries.Team
{
    public class GetTeamsQuery : IRequest<GetTeamsQueryResponseModel>
    {
    }
}
