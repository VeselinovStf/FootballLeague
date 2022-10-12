using FootballLeague.API.Extensions;
using FootballLeague.API.Features.Commands.Team;
using FootballLeague.API.Features.Commands.Team.ResponseModels;
using FootballLeague.API.Features.Queries.Team;
using FootballLeague.API.Features.Queries.Team.ResponseModels;
using FootballLeague.API.Features.Team.Queries.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

        [AllowAnonymous]
        [HttpGet("rankings")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamsRankingQueryResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GetTeamsRankingQueryResponseModel))]

        public async Task<IActionResult> GetTeamsRankings()
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(new GetTeamsRankingQuery()));
        }

        [AllowAnonymous]
        [HttpGet("played")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamsPlayedMatchesQueryResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GetTeamsPlayedMatchesQueryResponseModel))]

        public async Task<IActionResult> GetTeamsPlayedMatches()
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(new GetTeamsPlayedMatchesQuery()));
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamsQueryResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GetTeamsQueryResponseModel))]

        public async Task<IActionResult> GetTeams()
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(new GetTeamsQuery()));
        }

        [AllowAnonymous]
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamQueryResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GetTeamQueryResponseModel))]
        public async Task<IActionResult> GetTeam([Required] int id)
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(new GetTeamQuery(id)));
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateTeamResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateTeamResponseModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateTeam(CreateTeamRequest request)
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(request));
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateTeamResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateTeamResponseModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateTeam(UpdateTeamRequest request)
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(request));
        }

        [Authorize(Roles = "ADMINISTRATOR")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteTeamResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DeleteTeamResponseModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteTeam(DeleteTeamRequest request)
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(request));
        }
    }
}
