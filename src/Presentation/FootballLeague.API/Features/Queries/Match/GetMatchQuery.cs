using FootballLeague.API.Features.Queries.Match.ResponseModels;
using MediatR;

namespace FootballLeague.API.Features.Queries.Match
{
    public class GetMatchQuery : IRequest<GetMatchQueryResponseModel>
    {
        public GetMatchQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
