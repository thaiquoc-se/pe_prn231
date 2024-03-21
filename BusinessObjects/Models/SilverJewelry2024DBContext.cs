using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models
{
    public partial class SilverJewelry2024DBContext : DbContext
    {
        public SilverJewelry2024DBContext()
        {
        }

        public SilverJewelry2024DBContext(DbContextOptions<SilverJewelry2024DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BranchAccount> BranchAccounts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<SilverJewelry> SilverJewelries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        public string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:SilverJewelry2024DB"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__BranchAc__349DA5861BFC7E86");

                entity.ToTable("BranchAccount");

                entity.HasIndex(e => e.EmailAddress, "UQ__BranchAc__49A147405CEE7522")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountID");

                entity.Property(e => e.AccountPassword).HasMaxLength(40);

                entity.Property(e => e.EmailAddress).HasMaxLength(60);

                entity.Property(e => e.FullName).HasMaxLength(60);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasMaxLength(30);

                entity.Property(e => e.CategoryDescription).HasMaxLength(250);

                entity.Property(e => e.CategoryName).HasMaxLength(100);

                entity.Property(e => e.FromCountry).HasMaxLength(160);
            });

            modelBuilder.Entity<SilverJewelry>(entity =>
            {
                entity.ToTable("SilverJewelry");

                entity.Property(e => e.SilverJewelryId).HasMaxLength(200);

                entity.Property(e => e.CategoryId).HasMaxLength(30);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MetalWeight).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SilverJewelryDescription).HasMaxLength(250);

                entity.Property(e => e.SilverJewelryName).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SilverJewelries)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SilverJew__Categ__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
