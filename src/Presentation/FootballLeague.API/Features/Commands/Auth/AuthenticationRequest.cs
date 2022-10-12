using FootballLeague.API.Features.Commands.Auth.ResponseModel;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FootballLeague.API.Features.Commands.Auth
{
    public class AuthenticationRequest : IRequest<AuthenticationResponseModel>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
