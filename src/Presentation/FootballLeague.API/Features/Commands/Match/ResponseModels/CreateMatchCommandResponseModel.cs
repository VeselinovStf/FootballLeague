using System;

namespace FootballLeague.API.Features.Commands.Match.ResponseModels
{
    public class CreateMatchCommandResponseModel
    {
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }
        public int MatchId { get; set; }

        public DateTime MatchDate { get; set; }

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }
    }
}
