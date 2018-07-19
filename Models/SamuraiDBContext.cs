using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models
{
    public partial class SamuraiDBContext : DbContext
    {
        public SamuraiDBContext()
        {
        }

        public SamuraiDBContext(DbContextOptions<SamuraiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Battles> Battles { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<SamuraiBattle> SamuraiBattle { get; set; }
        public virtual DbSet<Samurais> Samurais { get; set; }
        public virtual DbSet<SecretIdendity> SecretIdendity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.HasIndex(e => e.SamuraiId);

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.SamuraiId);
            });

            modelBuilder.Entity<SamuraiBattle>(entity =>
            {
                entity.HasKey(e => new { e.SamuraiId, e.BattleId });

                entity.HasIndex(e => e.BattleId);

                entity.HasOne(d => d.Battle)
                    .WithMany(p => p.SamuraiBattle)
                    .HasForeignKey(d => d.BattleId);

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.SamuraiBattle)
                    .HasForeignKey(d => d.SamuraiId);
            });

            modelBuilder.Entity<SecretIdendity>(entity =>
            {
                entity.HasIndex(e => e.SamuraiId)
                    .IsUnique();

                entity.HasOne(d => d.Samurai)
                    .WithOne(p => p.SecretIdendity)
                    .HasForeignKey<SecretIdendity>(d => d.SamuraiId);
            });
        }
    }
}
