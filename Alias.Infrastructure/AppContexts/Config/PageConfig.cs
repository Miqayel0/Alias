using Alias.Domain.Entities.TeamAggregat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alias.infrastructure.AppContexts.Config
{
    public class PageConfig : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Page.PageWords));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.TeamGame).WithMany(x => x.Pages).HasForeignKey(x => x.TeamGameId);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}

