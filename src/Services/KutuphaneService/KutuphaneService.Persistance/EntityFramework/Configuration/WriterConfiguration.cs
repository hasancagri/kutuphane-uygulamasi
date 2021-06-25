using KutuphaneService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KutuphaneService.Persistance.EntityFramework.Configuration
{
    public class WriterConfiguration
         : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.Property(x => x.WriterName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
