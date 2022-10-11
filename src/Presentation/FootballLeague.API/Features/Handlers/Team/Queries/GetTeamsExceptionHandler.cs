using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.API.Features.Queries.Team;
using FootballLeague.API.Features.Queries.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR.Pipeline;
using System;

namespace FootballLeague.API.Features.Handlers.Team.Queries
{
    public class GetTeamsExceptionHandler : RequestExceptionHandler<GetTeamsPlayedMatchesQuery, GetTeamsPlayedMatchesQueryResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public GetTeamsExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(GetTeamsPlayedMatchesQuery request, Exception exception, RequestExceptionHandlerState<GetTeamsPlayedMatchesQueryResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new GetTeamsPlayedMatchesQueryResponseModel(false, exception.Message));
        }
    }
}
