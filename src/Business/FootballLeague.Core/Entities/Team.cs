using System.Collections.Generic;

namespace FootballLeague.Core.Entities
{
    public class Team : BaseEntity
    {
        public Team()
        {
            HomeMatches = new HashSet<Match>();
            AwayMatches = new HashSet<Match>();
            Statistic = new Statistic();
        }

        public string Name { get; set; }
        public ICollection<Match> HomeMatches { get; set; }
        public ICollection<Match> AwayMatches { get; set; }

        public Statistic Statistic { get; set; }
    }
}
