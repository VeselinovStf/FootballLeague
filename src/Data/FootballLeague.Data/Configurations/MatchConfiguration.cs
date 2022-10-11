using FootballLeague.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FootballLeague.Data.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasOne(t => t.HomeTeam)
                  .WithMany(t => t.HomeMatches)
                  .HasForeignKey(m => m.HomeTeamId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.AwayTeam)
               .WithMany(t => t.AwayMatches)
               .HasForeignKey(m => m.AwayTeamId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
