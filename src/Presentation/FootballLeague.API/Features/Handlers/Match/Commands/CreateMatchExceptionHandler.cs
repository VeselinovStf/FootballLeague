using FootballLeague.API.Features.Commands.Match;
using FootballLeague.API.Features.Commands.Match.ResponseModels;
using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.Core.Interfaces;
using MediatR.Pipeline;
using System;

namespace FootballLeague.API.Features.Handlers.Match.Commands
{
    public class CreateMatchExceptionHandler : RequestExceptionHandler<CreateMatchRequest, CreateMatchResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public CreateMatchExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(CreateMatchRequest request, Exception exception, RequestExceptionHandlerState<CreateMatchResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new CreateMatchResponseModel(false, "Unable To Create Match"));
        }
    }
}
