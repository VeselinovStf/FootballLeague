using FootballLeague.API.Features.Commands.Auth;
using FootballLeague.API.Features.Commands.Auth.ResponseModel;
using FootballLeague.Core.Interfaces;
using FootballLeague.Infrastructure.Identity.Entities;
using FootballLeague.Infrastructure.Identity.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Auth.Command
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticationRequest, AuthenticationResponseModel>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtAuthService _jwtAuthService;
        private readonly IAppLogger<AuthenticateCommandHandler> _logger;

        public AuthenticateCommandHandler(
            SignInManager<AppUser> signInManager,
            IJwtAuthService jwtAuthService,
            IAppLogger<AuthenticateCommandHandler> logger)
        {
            this._signInManager = signInManager;
            this._jwtAuthService = jwtAuthService;
            this._logger = logger;
        }
        public async Task<AuthenticationResponseModel> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);

            if (!result.Succeeded)
            {
                this._logger.LogWarn($"Sign In Result: {result.Succeeded.ToString()}",result);

                return new AuthenticationResponseModel(false, "Unable to login");
            }

            var newToken = await _jwtAuthService
                .GenerateLogin(request.UserName);

            if (!newToken.Success)
            {
                this._logger.LogWarn(newToken.Message);

                return new AuthenticationResponseModel(false, "Unable to login");
            }

            return new AuthenticationResponseModel(true, "User Authenticated",
                new AccessResponseModel()
                {
                    AccessToken = newToken.AccessToken
                });
        }
    }
}
