using kaptast_formula1_api.Repository.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace kaptast_formula1_api.Repository
{
    public class FormulaDbContext : IdentityDbContext
    {
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=:memory:");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Team>().HasData(new Team[] {
                new Team() {Id = Guid.NewGuid(), Name = "Ferrari"},
                new Team() {Id = Guid.NewGuid(), Name = "Mercedes"}
            });
        }
    }
}
