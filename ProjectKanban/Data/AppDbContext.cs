using Microsoft.EntityFrameworkCore;
using ProjectKanban.Models;
using System.Diagnostics;

namespace ProjectKanban.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
        }

        public DbSet<ActivityModel> Activity { get; set; }
        public DbSet<StatusModel> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StatusModel>().HasData(
                    new StatusModel { Id = 1, Nome = "Pendente"},
                    new StatusModel { Id = 2, Nome = "Em Andamento"},
                    new StatusModel { Id = 3, Nome = "Finalizada"}

                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
