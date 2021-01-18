using KaptastFormula1Api.Repository.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace KaptastFormula1Api.Repository
{
    /// <summary>
    /// Database context for storing Teams and Users.
    /// </summary>
    public class FormulaDbContext : IdentityDbContext
    {
        public DbSet<Team> Teams { get; set; }

        public FormulaDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Set the unique constraint for team names
            builder.Entity<Team>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            //Test data
            builder.Entity<Team>().HasData(new Team[] {
                new Team() {Id = Guid.NewGuid(), Name = "Ferrari"},
                new Team() {Id = Guid.NewGuid(), Name = "Mercedes"}
            });
        }
    }
}
