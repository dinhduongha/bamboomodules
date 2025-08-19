using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockQuantRelocate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockQuantRelocate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_quant_relocate_pkey");

            entity.ToTable("stock_quant_relocate");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DestLocationId).HasColumnName("dest_location_id");
            entity.Property(e => e.DestPackageId).HasColumnName("dest_package_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockQuantRelocateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_quant_relocate_create_uid_fkey");

            entity.HasOne(d => d.DestLocation).WithMany(p => p.StockQuantRelocate)
                .HasForeignKey(d => d.DestLocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_quant_relocate_dest_location_id_fkey");

            entity.HasOne(d => d.DestPackage).WithMany(p => p.StockQuantRelocate)
                .HasForeignKey(d => d.DestPackageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_quant_relocate_dest_package_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockQuantRelocateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_quant_relocate_write_uid_fkey");

            // entity.HasMany(d => d.StockQuant).WithMany(p => p.StockQuantRelocate)
            entity.HasMany(d => d.StockQuant).WithMany(p => p.StockQuantRelocate)
                .UsingEntity<Dictionary<string, object>>(
                    "StockQuantStockQuantRelocateRel",
                    r => r.HasOne<StockQuant>().WithMany()
                        .HasForeignKey("StockQuantId")
                        .HasConstraintName("stock_quant_stock_quant_relocate_rel_stock_quant_id_fkey"),
                    l => l.HasOne<StockQuantRelocate>().WithMany()
                        .HasForeignKey("StockQuantRelocateId")
                        .HasConstraintName("stock_quant_stock_quant_relocate_r_stock_quant_relocate_id_fkey"),
                    j =>
                    {
                        j.HasKey("StockQuantRelocateId", "StockQuantId").HasName("stock_quant_stock_quant_relocate_rel_pkey");
                        j.ToTable("stock_quant_stock_quant_relocate_rel");
                        j.HasIndex(new[] { "StockQuantId", "StockQuantRelocateId" }, "stock_quant_stock_quant_reloc_stock_quant_id_stock_quant_re_idx");
                        j.IndexerProperty<Guid>("StockQuantRelocateId").HasColumnName("stock_quant_relocate_id");
                        j.IndexerProperty<Guid>("StockQuantId").HasColumnName("stock_quant_id");
                    });
            });
        }
    }
}