using FootballLeague.API.Features.Commands.Match.ResponseModels;
using FootballLeague.API.Features.Commands.Match;
using MediatR;
using MediatR.Pipeline;
using System;
using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.Core.Interfaces;

namespace FootballLeague.API.Features.Handlers.Match.Commands
{
    public class DeleteMatchExceptionHandler : RequestExceptionHandler<DeleteMatchRequestModel, DeleteMatchResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public DeleteMatchExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(DeleteMatchRequestModel request, Exception exception, RequestExceptionHandlerState<DeleteMatchResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new DeleteMatchResponseModel(false, exception.Message));
        }
    }
}
