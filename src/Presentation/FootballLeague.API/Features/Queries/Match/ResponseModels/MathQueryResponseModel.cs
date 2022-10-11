using System;

namespace FootballLeague.API.Features.Queries.Match.ResponseModels
{
    public class MathQueryResponseModel
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get;  set; }
     
        public int AwayTeamId { get;  set; }
        
        public DateTime Date { get;  set; }

        public int HomeTeamScore { get;  set; }
        public int AwayTeamScore { get;  set; }
    }
}
