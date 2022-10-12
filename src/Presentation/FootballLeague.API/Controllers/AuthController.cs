using FootballLeague.API.Extensions;
using FootballLeague.API.Features.Commands.Auth;
using FootballLeague.API.Features.Commands.Auth.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResponseModel))]
        public async Task<IActionResult> Authenticate(AuthenticationRequest request)
        {
            return ApiResponseExtensions.ValidateResponseModel(await this._mediator.Send(request));
        }
    }
}
