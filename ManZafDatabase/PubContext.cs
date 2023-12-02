using ManZafModels.BL;
using Microsoft.EntityFrameworkCore;

namespace ManZafDatabase
{
    public class PubContext : DbContext
    {
        public PubContext(DbContextOptions<PubContext> options) : base(options)
        {

        }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Worker>().HasMany(w => w.Workers).WithOne().HasForeignKey(w => w.ManagerId);
        }
    }
}
