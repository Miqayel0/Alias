using Alias.Domain.Entities.TeamAggregat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alias.infrastructure.AppContexts.Config
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Team.TeamGames));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}

