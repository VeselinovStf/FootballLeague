using FootballLeague.API.Features.Commands.Team;
using FootballLeague.API.Features.Commands.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR.Pipeline;
using System;

namespace FootballLeague.API.Features.Handlers.Team.Commands
{
    public class UpdateTeamExceptionHandler : RequestExceptionHandler<UpdateTeamRequest, UpdateTeamResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public UpdateTeamExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }

        protected override void Handle(UpdateTeamRequest request, Exception exception, RequestExceptionHandlerState<UpdateTeamResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new UpdateTeamResponseModel(false, exception.Message));
        }
    }
}
