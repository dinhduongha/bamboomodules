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
        public static void ConfigureProductReplenish(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductReplenish>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_replenish_pkey");

            entity.ToTable("product_replenish");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.BomId).HasColumnName("bom_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DatePlanned)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_planned");
            entity.Property(e => e.ProductHasVariants).HasColumnName("product_has_variants");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
            entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Bom).WithMany(p => p.ProductReplenish)
                .HasForeignKey(d => d.BomId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_replenish_bom_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.ProductReplenish)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_replenish_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductReplenishCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_replenish_create_uid_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.ProductReplenish)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_replenish_product_id_fkey");

            entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductReplenish)
                .HasForeignKey(d => d.ProductTmplId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_replenish_product_tmpl_id_fkey");

            // entity.HasOne(d => d.ProductUom).WithMany(p => p.ProductReplenish)
            entity.HasOne(d => d.ProductUom).WithMany()
                .HasForeignKey(d => d.ProductUomId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_replenish_product_uom_id_fkey");

            entity.HasOne(d => d.Route).WithMany(p => p.ProductReplenish)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_replenish_route_id_fkey");

            entity.HasOne(d => d.Supplier).WithMany(p => p.ProductReplenish)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_replenish_supplier_id_fkey");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.ProductReplenish)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_replenish_warehouse_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductReplenishWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_replenish_write_uid_fkey");

            // entity.HasMany(d => d.StockRoute).WithMany(p => p.ProductReplenish)
            entity.HasMany(d => d.StockRoute).WithMany(p => p.ProductReplenish)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductReplenishStockRouteRel",
                    r => r.HasOne<StockRoute>().WithMany()
                        .HasForeignKey("StockRouteId")
                        .HasConstraintName("product_replenish_stock_route_rel_stock_route_id_fkey"),
                    l => l.HasOne<ProductReplenish>().WithMany()
                        .HasForeignKey("ProductReplenishId")
                        .HasConstraintName("product_replenish_stock_route_rel_product_replenish_id_fkey"),
                    j =>
                    {
                        j.HasKey("ProductReplenishId", "StockRouteId").HasName("product_replenish_stock_route_rel_pkey");
                        j.ToTable("product_replenish_stock_route_rel");
                        j.HasIndex(new[] { "StockRouteId", "ProductReplenishId" }, "product_replenish_stock_route_stock_route_id_product_replen_idx");
                        j.IndexerProperty<Guid>("ProductReplenishId").HasColumnName("product_replenish_id");
                        j.IndexerProperty<Guid>("StockRouteId").HasColumnName("stock_route_id");
                    });
            });
        }
    }
}
