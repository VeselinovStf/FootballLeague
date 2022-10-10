namespace FootballLeague.Core.Entities
{
    public class Statistic : BaseEntity
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int Wins { get; set; }

        public int Looses { get; set; }

        public int Draws { get; set; }

        public int TotalScore { get; set; }
    }
}