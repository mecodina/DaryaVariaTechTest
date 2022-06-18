using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HealthCareProducts.Models
{
    public partial class DaryaVariaContext : DbContext
    {
        public DaryaVariaContext()
        {
        }

        public DaryaVariaContext(DbContextOptions<DaryaVariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HealthCareProduct> HealthCareProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=LD-CN\\SQLEXPRESS;Database=DaryaVaria;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HealthCareProduct>(entity =>
            {
                entity.Property(e => e.Composition).IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Dosage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Indication).IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Segment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrademarkName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
