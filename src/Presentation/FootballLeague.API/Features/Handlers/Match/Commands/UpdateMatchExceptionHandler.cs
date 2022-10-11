using FootballLeague.API.Features.Commands.Match.ResponseModels;
using FootballLeague.API.Features.Commands.Match;
using MediatR.Pipeline;
using System;
using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.Core.Interfaces;
using FootballLeague.API.Features.Commands.Team.ResponseModels;

namespace FootballLeague.API.Features.Handlers.Match.Commands
{
    public class UpdateMatchExceptionHandler : RequestExceptionHandler<UpdateMatchRequest, UpdateMatchResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public UpdateMatchExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(UpdateMatchRequest request, Exception exception, RequestExceptionHandlerState<UpdateMatchResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new UpdateMatchResponseModel(false, exception.Message));
        }
    }
}
