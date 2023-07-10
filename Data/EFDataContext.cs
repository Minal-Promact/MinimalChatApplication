using Microsoft.EntityFrameworkCore;
using MinimalChatApplication.Model;

namespace MinimalChatApplication.Data
{
    public class EFDataContext : DbContext
    {
        public EFDataContext()
        {

        }

        public EFDataContext(DbContextOptions<EFDataContext> options)
           : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RequestLogging> RequestLoggingMiddlewares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            

            modelBuilder.UseSerialColumns();

            // Configure other entities...

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("WebApiDatabase");
            }

        }
    }
}
