using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockLot(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockLot>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_lot_pkey");

                        entity.ToTable("stock_lot");

                        entity.HasIndex(e => e.TenantId, "stock_lot__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Name, "stock_lot__name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.ProductId, "stock_lot__product_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AlertDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("alert_date");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ExpirationDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("expiration_date");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.LotProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("lot_properties");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.ProductExpiryReminded).HasColumnName("product_expiry_reminded");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                        entity.Property(e => e.Ref).HasColumnName("ref");
                        entity.Property(e => e.RemovalDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("removal_date");
                        entity.Property(e => e.StandardPrice)
                            .HasColumnType("jsonb")
                            .HasColumnName("standard_price");
                        entity.Property(e => e.UseDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("use_date");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockLot) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_lot_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_lot_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockLotCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_lot_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_lot_create_uid_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.StockLot)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_lot_location_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockLot) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_lot_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_lot_product_id_fkey");

                        // entity.HasOne(d => d.ProductUom).WithMany(p => p.StockLot) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_lot_product_uom_id_fkey");
                        entity.HasOne(d => d.ProductUom).WithMany()
                            .HasForeignKey(d => d.ProductUomId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_lot_product_uom_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockLotWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_lot_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_lot_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}