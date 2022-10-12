using FootballLeague.API.Features.Commands.Auth.ResponseModel;
using MediatR;

namespace FootballLeague.API.Features.Commands.Auth
{
    public class AuthenticationRequest : IRequest<AuthenticationResponseModel>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
