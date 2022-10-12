using FootballLeague.API.Features.Commands.Auth.ResponseModel;
using FootballLeague.API.Features.Commands.Auth;
using MediatR.Pipeline;
using System;
using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.Core.Interfaces;

namespace FootballLeague.API.Features.Handlers.Auth.Command
{
    public class AuthenticationExceptionHandler : RequestExceptionHandler<AuthenticationRequest, AuthenticationResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public AuthenticationExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(AuthenticationRequest request, Exception exception, RequestExceptionHandlerState<AuthenticationResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new AuthenticationResponseModel(false, exception.Message));
        }
    }
}
