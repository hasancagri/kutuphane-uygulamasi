using KutuphaneService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneService.Persistance.EntityFramework
{
    public class KutuphaneContext
         : DbContext
    {
        public KutuphaneContext(DbContextOptions<KutuphaneContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KutuphaneContext).Assembly);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
