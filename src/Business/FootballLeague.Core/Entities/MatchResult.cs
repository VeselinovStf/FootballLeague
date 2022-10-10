namespace FootballLeague.Core.Entities
{
    public class MatchResult : BaseEntity
    {
        public int MatchId { get; set; }

        public Match Match { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }
}