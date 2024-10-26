using Microsoft.EntityFrameworkCore;
using model;

namespace ModelRepo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
