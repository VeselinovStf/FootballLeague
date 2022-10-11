using FootballLeague.Core.Entities;
using System.Linq;

namespace FootballLeague.Core.Specifications
{
    public class TeamsWithPlayedMatchesSpecification : BaseSpecification<Team>
    {
        public TeamsWithPlayedMatchesSpecification(bool isDeleted) : base(s => s.IsDeleted == isDeleted)
        {
            AddInclude(t => t.HomeMatches.Where(e => !e.IsDeleted));
            AddInclude(t => t.AwayMatches.Where(e => !e.IsDeleted));
        }
    }
}
