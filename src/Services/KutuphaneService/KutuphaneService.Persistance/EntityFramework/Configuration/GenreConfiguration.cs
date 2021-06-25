using KutuphaneService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KutuphaneService.Persistance.EntityFramework.Configuration
{
    public class GenreConfiguration
         : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.GenreName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
