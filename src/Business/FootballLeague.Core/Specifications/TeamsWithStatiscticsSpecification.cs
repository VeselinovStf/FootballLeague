using FootballLeague.Core.Entities;

namespace FootballLeague.Core.Specifications
{
    public class TeamsWithStatiscticsSpecification : BaseSpecification<Team>
    {
        public TeamsWithStatiscticsSpecification(bool isDeleted) : base(s => s.IsDeleted == isDeleted)
        {
            AddInclude(t => t.Statistic);

        }
    }
}
