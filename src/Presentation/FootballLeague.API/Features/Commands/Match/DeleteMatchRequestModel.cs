using FootballLeague.API.Features.Commands.Match.ResponseModels;
using MediatR;

namespace FootballLeague.API.Features.Commands.Match
{
    public class DeleteMatchRequestModel : IRequest<DeleteMatchResponseModel>
    {
        public int MatchId { get; set; }
    }
}
