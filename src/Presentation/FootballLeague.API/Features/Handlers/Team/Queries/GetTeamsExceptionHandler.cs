using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.API.Features.Queries.Team;
using FootballLeague.API.Features.Queries.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR.Pipeline;
using System;

namespace FootballLeague.API.Features.Handlers.Team.Queries
{
    public class GetTeamsExceptionHandler : RequestExceptionHandler<GetTeamsQuery, GetTeamsQueryResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public GetTeamsExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(GetTeamsQuery request, Exception exception, RequestExceptionHandlerState<GetTeamsQueryResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new GetTeamsQueryResponseModel(false, "Teams Not Found"));
        }
    }
}
