namespace FootballLeague.Core.Events
{
    public class CleanTeamStatisticsEvent : BaseDomainEvent
    {
        public CleanTeamStatisticsEvent(int teamId, int homeTeamScore, int awayTeamScore)
        {
            TeamId = teamId;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }

        public int TeamId { get; }
        public int HomeTeamScore { get; }
        public int AwayTeamScore { get; }
    }
}
