using KutuphaneService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KutuphaneService.Persistance.EntityFramework.Configuration
{
    public class PublisherConfiguration
         : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(x => x.PublisherName)
                 .IsRequired()
                 .HasMaxLength(50);
        }
    }
}
