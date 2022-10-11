using FootballLeague.Core.Validations;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Core.Entities
{
    public class Team : BaseEntity
    {
        /// <summary>
        /// EF CTOR
        /// </summary>
        public Team()
        {

        }
        public Team(string name, Statistic statistic)
        {
            Guard.StringIsNullEmptyOrWhiteSpace(name);
            Guard.NotNull(statistic);

            Name = name;
            Statistic = statistic;
        }

        public string Name { get; private set; }

        private readonly List<Match> _homeMatches = new List<Match>();
        private readonly List<Match> _awayMatches = new List<Match>();

        public IEnumerable<Match> HomeMatches => _homeMatches.AsReadOnly();
        public IEnumerable<Match> AwayMatches => _awayMatches.AsReadOnly();

        public Statistic Statistic { get; private set; }

        public void UpdateName(string name)
        {
            Guard.StringIsNullEmptyOrWhiteSpace(name);

            this.Name = name;
        }

        public Match AddNewMatch(Match homeMatch, Match awayMatch)
        {
            Guard.NotNull(homeMatch);
            Guard.NotNull(awayMatch);

            _homeMatches.Add(homeMatch);
            _awayMatches.Add(awayMatch);

            return homeMatch;
        }

        public void RemoveMatch(int homeMatchId, int awayMatchId)
        {
            Guard.ValueLessThenEqual(0, homeMatchId);
            Guard.ValueLessThenEqual(0, awayMatchId);

            var homeMatch = this._homeMatches
                .FirstOrDefault(m => m.Id == homeMatchId);

            var awayMatch = this._awayMatches
                .FirstOrDefault(m => m.Id == awayMatchId);

            Guard.NotNull(homeMatch);
            Guard.NotNull(awayMatch);


            this._homeMatches.Remove(homeMatch);
            this._awayMatches.Remove(homeMatch);
        }

        public void UpdateStatistics(int homeTeamScore, int awayTeamScore)
        {
            if (homeTeamScore > awayTeamScore)
            {
                this.Statistic.TotalScore += 3;
                this.Statistic.Wins++;
            }
            else if (awayTeamScore > homeTeamScore)
            {
                this.Statistic.Looses++;
            }
            else
            {
                this.Statistic.TotalScore += 1;
                this.Statistic.Draws++;
            }
        }

        public void CleanStatistics(int homeTeamScore, int awayTeamScore)
        {
            if (homeTeamScore > awayTeamScore)
            {
                this.Statistic.TotalScore -= 3;
                this.Statistic.Wins--;
            }
            else if (awayTeamScore > homeTeamScore)
            {
                this.Statistic.Looses--;
            }
            else
            {
                this.Statistic.TotalScore -= 1;
                this.Statistic.Draws--;
            }
        }
    }
}
