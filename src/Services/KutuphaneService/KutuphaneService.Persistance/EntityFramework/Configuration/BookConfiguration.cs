using KutuphaneService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KutuphaneService.Persistance.EntityFramework.Configuration
{
    public class BookConfiguration
         : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.BookName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ISBN)
                .HasMaxLength(50);
        }
    }
}
