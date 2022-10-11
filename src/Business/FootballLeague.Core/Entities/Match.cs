using FootballLeague.Core.Events;
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
        public Match(int homeTeamId, int awayTeamId, DateTime date, int homeTeamScore, int awayTeamScore)
        {
            Guard.ValueLessThenEqual(0, homeTeamId);
            Guard.ValueLessThenEqual(0, awayTeamId);
            Guard.ValueLessThenEqual(-1, homeTeamScore);
            Guard.ValueLessThenEqual(-1, awayTeamScore);

            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            Date = date;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;

            Events.Add(new UpdateTeamStatisticEvent(HomeTeamId, homeTeamScore, awayTeamScore));
            Events.Add(new UpdateTeamStatisticEvent(AwayTeamId, awayTeamScore, homeTeamScore));
        }

        public int HomeTeamId { get;private set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get;private set; }
        public Team AwayTeam { get; set; }

        public DateTime Date { get; private set; }

        public int HomeTeamScore { get; private set; }
        public int AwayTeamScore { get; private set; }

        public void UpdateMatchResult(int homeTeamScore, int awayTeamScore)
        {
            Guard.ValueLessThenEqual(-1, homeTeamScore);
            Guard.ValueLessThenEqual(-1, awayTeamScore);

            this.HomeTeamScore = homeTeamScore;
            this.AwayTeamScore = awayTeamScore;

            Events.Add(new CleanTeamStatisticsEvent(HomeTeamId, homeTeamScore, awayTeamScore));
            Events.Add(new CleanTeamStatisticsEvent(AwayTeamId, awayTeamScore, homeTeamScore));
        }

        public void UpdateMatchDate(DateTime newDate)
        {
            this.Date = newDate;
        }
    }
}
