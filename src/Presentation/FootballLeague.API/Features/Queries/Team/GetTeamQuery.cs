using FootballLeague.API.Features.Queries.Team.ResponseModels;
using MediatR;

namespace FootballLeague.API.Features.Queries.Team
{
    public class GetTeamQuery : IRequest<GetTeamQueryResponseModel>
    {
        public GetTeamQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
