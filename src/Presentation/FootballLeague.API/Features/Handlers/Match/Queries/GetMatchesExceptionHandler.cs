using FootballLeague.API.Features.Queries.Match.ResponseModels;
using FootballLeague.API.Features.Queries.Match;
using MediatR;
using MediatR.Pipeline;
using System;
using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.Core.Interfaces;
using FootballLeague.API.Features.Commands.Match.ResponseModels;

namespace FootballLeague.API.Features.Handlers.Match.Queries
{
    public class GetMatchesExceptionHandler : RequestExceptionHandler<GetMatchesQuery, GetMatchesQueryResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public GetMatchesExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(GetMatchesQuery request, Exception exception, RequestExceptionHandlerState<GetMatchesQueryResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new GetMatchesQueryResponseModel(false, "Mathes Not Found"));
        }
    }
}
