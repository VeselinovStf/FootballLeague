using FootballLeague.API.Features.Queries.Team.ResponseModels;
using FootballLeague.API.Features.Queries.Team;
using MediatR;
using MediatR.Pipeline;
using System;
using FootballLeague.API.Features.Commands.Team.ResponseModels;
using FootballLeague.Core.Interfaces;
using FootballLeague.API.Features.Handlers.Team.Commands;

namespace FootballLeague.API.Features.Handlers.Team.Queries
{
    public class GetTeamsPlayedMatchesExceptionHandler : RequestExceptionHandler<GetTeamsPlayedMatchesQuery, GetTeamsPlayedMatchesQueryResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public GetTeamsPlayedMatchesExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
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
