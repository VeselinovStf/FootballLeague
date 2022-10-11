using FootballLeague.API.Features.Queries.Match.ResponseModels;
using FootballLeague.API.Features.Queries.Match;
using MediatR.Pipeline;
using System;
using FootballLeague.API.Features.Handlers.Team.Commands;
using FootballLeague.Core.Interfaces;

namespace FootballLeague.API.Features.Handlers.Match.Queries
{
    public class GetMatchExceptionHandler : RequestExceptionHandler<GetMatchQuery, GetMatchQueryResponseModel>
    {
        private readonly IAppLogger<DeleteTeamExceptionHandler> _appLogger;

        public GetMatchExceptionHandler(IAppLogger<DeleteTeamExceptionHandler> appLogger)
        {
            this._appLogger = appLogger;
        }
        protected override void Handle(GetMatchQuery request, Exception exception, RequestExceptionHandlerState<GetMatchQueryResponseModel> state)
        {
            _appLogger.LogError(exception.Message, exception);

            state.SetHandled(new GetMatchQueryResponseModel(false, exception.Message));
        }
    }
}
