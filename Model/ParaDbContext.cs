using Microsoft.EntityFrameworkCore;

namespace MovePara.Model
{
    public class ParaDbContext:DbContext
    {
        public ParaDbContext(DbContextOptions<ParaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Para>()
                .HasData(new Para { ParaId = "A", ParaText = "This is Para A" },
                    new Para{ ParaId = "B", ParaText = "This is Para B" }, 
                    new Para { ParaId = "C", ParaText = "This is Para C" }, 
                    new Para { ParaId = "D", ParaText = "This is Para D" }
                    );
        }
        public DbSet<Para> para { get; set; }
        public DbSet<ParaLeft> paraLeft { get; set; }
        public DbSet<ParaRight> paraRight { get; set; }
    }
}
