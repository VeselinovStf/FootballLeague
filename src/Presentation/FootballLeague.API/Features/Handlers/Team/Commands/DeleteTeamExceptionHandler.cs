using FootballLeague.API.Features.Commands.Team.ResponseModels;
using FootballLeague.API.Features.Commands.Team;
using MediatR.Pipeline;
using System;
using System.Net;
using FootballLeague.Core.Interfaces;

namespace FootballLeague.API.Features.Handlers.Team.Commands
{
    public class DeleteTeamExceptionHandler : RequestExceptionHandler<DeleteTeamRequest, DeleteTeamResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public DeleteTeamExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(DeleteTeamRequest request, Exception exception, RequestExceptionHandlerState<DeleteTeamResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new DeleteTeamResponseModel(false, exception.Message));
        }
    }
}
