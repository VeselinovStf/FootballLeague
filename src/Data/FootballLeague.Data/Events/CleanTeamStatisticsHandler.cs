using FootballLeague.Core.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.Data.Events
{
    public class CleanTeamStatisticsHandler : INotificationHandler<CleanTeamStatisticsEvent>
    {
        private readonly FootballLeagueDbContext dbContext;

        public CleanTeamStatisticsHandler(FootballLeagueDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(CleanTeamStatisticsEvent notification, CancellationToken cancellationToken)
        {
            var statistic = await this.dbContext
                .Teams
                .Include(e => e.Statistic)
                .FirstOrDefaultAsync(s => s.Id == notification.TeamId);

            statistic.CleanStatistics(notification.HomeTeamScore, notification.AwayTeamScore);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
