using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.API.Features.Queries.Team.ResponseModels;
using FootballLeague.API.Features.Queries.Team;
using FootballLeague.Core.Interfaces;
using MediatR.Pipeline;
using System;

namespace FootballLeague.API.Features.Handlers.Team.Queries
{
    public class GetTeamExceptionHandler : RequestExceptionHandler<GetTeamQuery, GetTeamQueryResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public GetTeamExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(GetTeamQuery request, Exception exception, RequestExceptionHandlerState<GetTeamQueryResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new GetTeamQueryResponseModel(false, "Team not found"));
        }
    }
}