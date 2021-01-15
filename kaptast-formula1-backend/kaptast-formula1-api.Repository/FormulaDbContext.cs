using kaptast_formula1_api.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace kaptast_formula1_api.Repository
{
    public class FormulaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(":memory:");
        }
    }
}
