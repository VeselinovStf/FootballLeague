using System.Collections.Generic;

namespace FootballLeague.API.Features.Queries.Team.ResponseModels
{
    public class TeamPlayedMatchesResponseModel
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }
        public List<TeamPlayedMatchResponseModel> HomeMatches { get; set; }
        public List<TeamPlayedMatchResponseModel> AwayMatches { get; set; }
    }
}