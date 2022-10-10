using System;

namespace FootballLeague.Core.Entities
{
    public class Match : BaseEntity
    {
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public DateTime Date { get; set; }

        public MatchResult Result { get; set; }
    }
}
