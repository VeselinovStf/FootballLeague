using System.Collections.Generic;

namespace FootballLeague.API.Features.Queries.Team.ResponseModels
{
    public class TeamPlayedMatchesResponseModel
    {
        public TeamModel Team { get; set; }
        public List<TeamPlayedMatchResponseModel> HomeMatches { get; set; }
        public List<TeamPlayedMatchResponseModel> AwayMatches { get; set; }
    }
}