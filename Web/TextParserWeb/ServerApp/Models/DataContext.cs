using Microsoft.EntityFrameworkCore;
namespace ServerApp.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Fragment> Fragments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Document>()
                .HasMany<Fragment>(p => p.Fragments)
                .WithOne(r => r.Document)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
