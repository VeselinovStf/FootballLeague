using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.API.Features.Queries.Team;
using FootballLeague.Core.Interfaces;
using MediatR.Pipeline;
using FootballLeague.API.Features.Team.Queries.ResponseModels;
using System;

namespace FootballLeague.API.Features.Handlers.Team.Queries
{
    public class GetTeamsRankingExceptionHandler : RequestExceptionHandler<GetTeamsRankingQuery, GetTeamsRankingQueryResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public GetTeamsRankingExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }

        protected override void Handle(GetTeamsRankingQuery request, Exception exception, RequestExceptionHandlerState<GetTeamsRankingQueryResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new GetTeamsRankingQueryResponseModel(false, exception.Message));
        }
    }
}