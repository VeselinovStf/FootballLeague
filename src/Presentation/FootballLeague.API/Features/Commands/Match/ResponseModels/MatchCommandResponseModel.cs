using System;

namespace FootballLeague.API.Features.Commands.Match.ResponseModels
{
    public class MatchCommandResponseModel
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public DateTime MatchDate { get; set; }

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }
    }
}
