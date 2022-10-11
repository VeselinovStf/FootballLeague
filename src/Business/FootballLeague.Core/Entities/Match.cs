using FootballLeague.Core.Validations;
using System;

namespace FootballLeague.Core.Entities
{
    public class Match : BaseEntity
    {
        /// <summary>
        /// EF CTOR
        /// </summary>
        public Match()
        {

        }
        public Match(int homeTeamId, int awayTeamId, DateTime date, MatchResult result)
        {
            Guard.ValueLessThenEqual(0, homeTeamId);
            Guard.ValueLessThenEqual(0, awayTeamId);
            Guard.NotNull(result);

            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            Date = date;
            Result = result;
        }

        public int HomeTeamId { get;private set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get;private set; }
        public Team AwayTeam { get; set; }

        public DateTime Date { get; private set; }

        public MatchResult Result { get; private set; }

        public void UpdateMatchResult(int homeTeamScore, int awayTeamScore)
        {
            Guard.ValueLessThenEqual(-1, homeTeamScore);
            Guard.ValueLessThenEqual(-1, awayTeamScore);

            this.Result.HomeTeamScore = homeTeamScore;
            this.Result.AwayTeamScore = awayTeamScore;
        }

        public void UpdateMatchDate(DateTime newDate)
        {
            this.Date = newDate;
        }
    }
}
