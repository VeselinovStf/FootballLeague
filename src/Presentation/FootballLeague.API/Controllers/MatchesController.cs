using FootballLeague.API.Features.Commands.Team.ResponseModels;
using FootballLeague.API.Features.Commands.Team;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using FootballLeague.API.Features.Commands.Match.ResponseModels;
using FootballLeague.API.Features.Commands.Match;

namespace FootballLeague.API.Controllers
{
    public class MatchesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public MatchesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateMatchResponseModel))]
        public async Task<IActionResult> CreateTeam(CreateMatchRequest request)
        {
            return Ok(await this._mediator.Send(request));
        }
    }
}
