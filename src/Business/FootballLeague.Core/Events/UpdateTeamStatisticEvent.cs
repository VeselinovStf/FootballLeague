namespace FootballLeague.Core.Events
{
    public class UpdateTeamStatisticEvent : BaseDomainEvent
    {
        public UpdateTeamStatisticEvent(int teamId, int homeTeamScore, int awayTeamScore)
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
