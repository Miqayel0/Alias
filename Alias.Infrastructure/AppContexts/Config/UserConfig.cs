using Alias.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alias.infrastructure.AppContexts.Config
{
    public class UserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Surname);
            builder.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(b => b.Surname)
                .HasMaxLength(50)
                .IsRequired();           
        }
    }
}
