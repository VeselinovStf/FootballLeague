namespace FootballLeague.API.Features.Queries.Team.ResponseModels
{
    public class TeamPlayedMatchResponseModel
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public MatchResultResponseModel MatchResult { get; set; }
    }
}