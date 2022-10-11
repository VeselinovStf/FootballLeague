using MediatR;

namespace FootballLeague.API.Controllers
{
    public class MatchesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public MatchesController(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }
}
