using Alias.Domain.Entities.TeamAggregat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alias.infrastructure.AppContexts.Config
{
    public class PageWordConfig : IEntityTypeConfiguration<PageWord>
    {
        public void Configure(EntityTypeBuilder<PageWord> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Word).WithMany().HasForeignKey(x => x.WordId);
            builder.HasOne(x => x.Page).WithMany(x => x.PageWords).HasForeignKey(x => x.PageId);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}

