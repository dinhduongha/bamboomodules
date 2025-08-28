using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockQuant(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockQuant>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_quant_pkey");

                        entity.ToTable("stock_quant");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LocationId, "stock_quant__location_id_index");

                        entity.HasIndex(e => e.LotId, "stock_quant__lot_id_index");

                        entity.HasIndex(e => e.OwnerId, "stock_quant__owner_id_index").HasFilter("(owner_id IS NOT NULL)");

                        entity.HasIndex(e => e.PackageId, "stock_quant__package_id_index");

                        entity.HasIndex(e => e.ProductId, "stock_quant__product_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountingDate).HasColumnName("accounting_date");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ExpirationDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("expiration_date");
                        entity.Property(e => e.InDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("in_date");
                        entity.Property(e => e.InventoryDate).HasColumnName("inventory_date");
                        entity.Property(e => e.InventoryDiffQuantity).HasColumnName("inventory_diff_quantity");
                        entity.Property(e => e.InventoryQuantity).HasColumnName("inventory_quantity");
                        entity.Property(e => e.InventoryQuantitySet).HasColumnName("inventory_quantity_set");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.LotId).HasColumnName("lot_id");
                        entity.Property(e => e.OwnerId).HasColumnName("owner_id");
                        entity.Property(e => e.PackageId).HasColumnName("package_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.Quantity).HasColumnName("quantity");
                        entity.Property(e => e.RemovalDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("removal_date");
                        entity.Property(e => e.ReservedQuantity).HasColumnName("reserved_quantity");
                        entity.Property(e => e.StorageCategoryId).HasColumnName("storage_category_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockQuant) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_quant_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockQuantCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_quant_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_create_uid_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.StockQuant)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_quant_location_id_fkey");

                        entity.HasOne(d => d.Lot).WithMany(p => p.StockQuant)
                            .HasForeignKey(d => d.LotId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_quant_lot_id_fkey");

                        // entity.HasOne(d => d.Owner).WithMany(p => p.StockQuant) .HasForeignKey(d => d.OwnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_quant_owner_id_fkey");
                        entity.HasOne(d => d.Owner).WithMany()
                            .HasForeignKey(d => d.OwnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_owner_id_fkey");

                        entity.HasOne(d => d.Package).WithMany(p => p.StockQuant)
                            .HasForeignKey(d => d.PackageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_quant_package_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockQuant) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_quant_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_quant_product_id_fkey");

                        entity.HasOne(d => d.StorageCategory).WithMany(p => p.StockQuant)
                            .HasForeignKey(d => d.StorageCategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_storage_category_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.StockQuantUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_quant_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockQuantWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_quant_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}