using Alias.Domain.Entities.TeamAggregat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alias.infrastructure.AppContexts.Config
{
    public class TeamGameConfig : IEntityTypeConfiguration<TeamGame>
    {
        public void Configure(EntityTypeBuilder<TeamGame> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(TeamGame.Pages));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Team).WithMany(x => x.TeamGames).HasForeignKey(x => x.TeamId);
            builder.HasOne(x => x.Game).WithMany(x => x.TeamGames).HasForeignKey(x => x.GameId);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}

