using FootballLeague.API.Features.Commands.Team;
using FootballLeague.API.Features.Commands.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR.Pipeline;
using System;

namespace FootballLeague.API.Features.Handlers.Team.Commands
{
    public class CreateTeamExceptionHandler : RequestExceptionHandler<CreateTeamRequest, CreateTeamResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public CreateTeamExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }

        protected override void Handle(CreateTeamRequest request, Exception exception, RequestExceptionHandlerState<CreateTeamResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new CreateTeamResponseModel(false, "Unable to Create Team"));
        }
    }
}
