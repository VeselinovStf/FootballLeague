using FootballLeague.API.Features.Commands.Team;
using FootballLeague.API.Features.Commands.Team.ResponseModels;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamsQueryResponseModel))]
        public async Task<IActionResult> GetTeams()
        {
            return Ok(await this._mediator.Send(new GetTeamsQuery()));
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamQueryResponseModel))]
        public async Task<IActionResult> GetTeam(int id)
        {
            return Ok(await this._mediator.Send(new GetTeamQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateTeamResponseModel))]
        public async Task<IActionResult> CreateTeam(CreateTeamRequest request)
        {
            return Ok(await this._mediator.Send(request));
        }


    }
}
