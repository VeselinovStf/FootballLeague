using FootballLeague.Core.Entities;

namespace FootballLeague.Core.Specifications
{
    public class TeamsWithPlayedMatchesSpecification : BaseSpecification<Team>
    {
        public TeamsWithPlayedMatchesSpecification(bool isDeleted) : base(s => s.IsDeleted == isDeleted)
        {
            AddInclude(t => t.HomeMatches);
            AddInclude(t => t.AwayMatches);
        }
    }
}
