using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SprintRecord.Models
{
    public partial class SprintContext : DbContext
    {
        public SprintContext()
        {
        }

        public SprintContext(DbContextOptions<SprintContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Developers> Developers { get; set; }
        public virtual DbSet<Sprints> Sprints { get; set; }
        public virtual DbSet<TeamDeveloper> TeamDeveloper { get; set; }
        public virtual DbSet<TeamSprint> TeamSprint { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developers>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Sprints>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
