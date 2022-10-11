using FootballLeague.API.Features.Queries.Team;
using FootballLeague.API.Features.Queries.Team.ResponseModels;
using FootballLeague.API.Features.Team.Queries.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.API.Controllers
{
    public class TeamsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("rankings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamsRankingQueryResponseModel))]
        public async Task<IActionResult> GetTeamsRankings()
        {
            return Ok(await this._mediator.Send(new GetTeamsRankingQuery()));
        }

        [HttpGet("played")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamsPlayedMatchesQueryResponseModel))]
        public async Task<IActionResult> GetTeamsPlayedMatches()
        {
            return Ok(await this._mediator.Send(new GetTeamsPlayedMatchesQuery()));
        }
    }
}
