using FootballLeague.Core.Entities;
using FootballLeague.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FootballLeague.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
      
        public FootballLeagueDbContext(DbContextOptions<FootballLeagueDbContext> options, IMediator mediator) : base(options)
        {
            this._mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            this.ApplyDataEvents().GetAwaiter().GetResult();
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private async Task ApplyDataEvents()
        {
            var entitiesWithEvents = ChangeTracker
                .Entries()
                .Select(e => e.Entity as BaseEntity)
                .Where(e => e?.Events != null && e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();

                entity.Events.Clear();

                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            await this.ApplyDataEvents();
            this.ApplyAuditInfoRules();
            return await base.SaveChangesAsync();
        }

        private void ApplyAuditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModifiable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
                else
                {
                    entity.ModifiedAt = DateTime.Now;

                    if (entity.IsDeleted == true)
                    {
                        entity.DeletedOn = DateTime.Now;
                    }
                }
            }
        }
    }
}
