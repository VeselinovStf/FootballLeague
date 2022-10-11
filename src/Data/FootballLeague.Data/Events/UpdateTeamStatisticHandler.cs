using FootballLeague.Core.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FootballLeague.Data.Events
{
    public class UpdateTeamStatisticHandler : INotificationHandler<UpdateTeamStatisticEvent>
    {
        private readonly FootballLeagueDbContext dbContext;

        public UpdateTeamStatisticHandler(FootballLeagueDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(UpdateTeamStatisticEvent notification, CancellationToken cancellationToken)
        {
            var statistic = await this.dbContext
                .Teams
                .Include(e => e.Statistic)
                .FirstOrDefaultAsync(s => s.Id == notification.TeamId);

            statistic.UpdateStatistics(notification.HomeTeamScore, notification.AwayTeamScore);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
