using FootballLeague.API.Extensions;
using FootballLeague.API.Features.Commands.Match;
using FootballLeague.API.Features.Commands.Match.ResponseModels;
using FootballLeague.API.Features.Queries.Match;
using FootballLeague.API.Features.Queries.Match.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.API.Controllers
{
    [Authorize(Roles = "ADMINISTRATOR")]
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
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(request));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetMatchesQueryResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GetMatchesQueryResponseModel))]
        public async Task<IActionResult> GetMatches()
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(new GetMatchesQuery()));
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetMatchQueryResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GetMatchQueryResponseModel))]
        public async Task<IActionResult> GetMatch(int id)
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(new GetMatchQuery(id)));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateMatchResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateMatchResponseModel))]
        public async Task<IActionResult> UpdateMatch(UpdateMatchRequest request)
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(request));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteMatchResponseModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DeleteMatchResponseModel))]
        public async Task<IActionResult> DeleteMatch(DeleteMatchRequestModel request)
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(request));
        }
    }
}
