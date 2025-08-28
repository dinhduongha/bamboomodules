using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockWarnInsufficientQtyRepair(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockWarnInsufficientQtyRepair>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_warn_insufficient_qty_repair_pkey");

                        entity.ToTable("stock_warn_insufficient_qty_repair");

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
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductUomName).HasColumnName("product_uom_name");
                        entity.Property(e => e.Quantity).HasColumnName("quantity");
                        entity.Property(e => e.RepairId).HasColumnName("repair_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockWarnInsufficientQtyRepairCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_warn_insufficient_qty_repair_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warn_insufficient_qty_repair_create_uid_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.StockWarnInsufficientQtyRepair)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_warn_insufficient_qty_repair_location_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockWarnInsufficientQtyRepair) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("stock_warn_insufficient_qty_repair_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_warn_insufficient_qty_repair_product_id_fkey");

                        entity.HasOne(d => d.Repair).WithMany(p => p.StockWarnInsufficientQtyRepair)
                            .HasForeignKey(d => d.RepairId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warn_insufficient_qty_repair_repair_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockWarnInsufficientQtyRepairWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_warn_insufficient_qty_repair_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warn_insufficient_qty_repair_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}