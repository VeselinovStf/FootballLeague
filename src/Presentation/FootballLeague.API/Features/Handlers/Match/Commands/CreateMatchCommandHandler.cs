﻿using FootballLeague.API.Features.Commands.Match;
using FootballLeague.API.Features.Commands.Match.ResponseModels;
using FootballLeague.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.API.Features.Handlers.Match.Commands
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchRequest, CreateMatchResponseModel>
    {
        private readonly IMatchService _matchService;

        public CreateMatchCommandHandler(IMatchService matchService)
        {
            this._matchService = matchService;
        }
        public async Task<CreateMatchResponseModel> Handle(CreateMatchRequest request, CancellationToken cancellationToken)
        {
            var createdMatch = await this._matchService
                .CreateMatchAsync(
                    request.HomeTeamId, 
                    request.AwayTeamId, 
                    request.MatchDate, 
                    request.HomeTeamScore, 
                    request.AwayTeamScore);

            return new CreateMatchResponseModel(true, "Match Created", new MatchResponseModel()
            {
                AwayTeamId = createdMatch.AwayTeamId,
                HomeTeamId = createdMatch.HomeTeamId,
                AwayTeamScore = createdMatch.Result.AwayTeamScore,
                HomeTeamScore = createdMatch.Result.HomeTeamScore,
                MatchDate = createdMatch.Date
            });
        }
    }
}
