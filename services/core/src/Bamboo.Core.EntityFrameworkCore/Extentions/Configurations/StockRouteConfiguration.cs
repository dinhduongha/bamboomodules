using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockRoute(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockRoute>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_route_pkey");

                entity.ToTable("stock_route");

                entity.HasIndex(e => e.TenantId, "stock_route_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.PackagingSelectable).HasColumnName("packaging_selectable");
                entity.Property(e => e.ProductCategSelectable).HasColumnName("product_categ_selectable");
                entity.Property(e => e.ProductSelectable).HasColumnName("product_selectable");
                entity.Property(e => e.SaleSelectable).HasColumnName("sale_selectable");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.SuppliedWhId).HasColumnName("supplied_wh_id");
                entity.Property(e => e.SupplierWhId).HasColumnName("supplier_wh_id");
                entity.Property(e => e.WarehouseSelectable).HasColumnName("warehouse_selectable");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_route_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_route_create_uid_fkey");

                entity.HasOne(d => d.SuppliedWh).WithMany(p => p.StockRouteSuppliedWhs)
                    .HasForeignKey(d => d.SuppliedWhId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_route_supplied_wh_id_fkey");

                entity.HasOne(d => d.SupplierWh).WithMany(p => p.StockRouteSupplierWhs)
                    .HasForeignKey(d => d.SupplierWhId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_route_supplier_wh_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_route_write_uid_fkey");

                //entity.HasMany(d => d.Categs).WithMany(p => p.Routes)
                entity.HasMany<ProductCategory>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockRouteCateg",
                        r => r.HasOne<ProductCategory>().WithMany()
                            .HasForeignKey("CategId")
                            .HasConstraintName("stock_route_categ_categ_id_fkey"),
                        l => l.HasOne<StockRoute>().WithMany()
                            .HasForeignKey("RouteId")
                            .HasConstraintName("stock_route_categ_route_id_fkey"),
                        j =>
                        {
                            j.HasKey("RouteId", "CategId").HasName("stock_route_categ_pkey");
                            j.ToTable("stock_route_categ");
                            j.HasIndex(new[] { "CategId", "RouteId" }, "stock_route_categ_categ_id_route_id_idx");
                        });

                //entity.HasMany(d => d.Packagings).WithMany(p => p.Routes)
                entity.HasMany<ProductPackaging>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockRoutePackaging",
                        r => r.HasOne<ProductPackaging>().WithMany()
                            .HasForeignKey("PackagingId")
                            .HasConstraintName("stock_route_packaging_packaging_id_fkey"),
                        l => l.HasOne<StockRoute>().WithMany()
                            .HasForeignKey("RouteId")
                            .HasConstraintName("stock_route_packaging_route_id_fkey"),
                        j =>
                        {
                            j.HasKey("RouteId", "PackagingId").HasName("stock_route_packaging_pkey");
                            j.ToTable("stock_route_packaging");
                            j.HasIndex(new[] { "PackagingId", "RouteId" }, "stock_route_packaging_packaging_id_route_id_idx");
                        });

                //entity.HasMany(d => d.Products).WithMany(p => p.Routes)
                entity.HasMany<ProductTemplate>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockRouteProduct",
                        r => r.HasOne<ProductTemplate>().WithMany()
                            .HasForeignKey("ProductId")
                            .HasConstraintName("stock_route_product_product_id_fkey"),
                        l => l.HasOne<StockRoute>().WithMany()
                            .HasForeignKey("RouteId")
                            .HasConstraintName("stock_route_product_route_id_fkey"),
                        j =>
                        {
                            j.HasKey("RouteId", "ProductId").HasName("stock_route_product_pkey");
                            j.ToTable("stock_route_product");
                            j.HasIndex(new[] { "ProductId", "RouteId" }, "stock_route_product_product_id_route_id_idx");
                        });

                //entity.HasMany(d => d.Warehouses).WithMany(p => p.Routes)
                entity.HasMany<StockWarehouse>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockRouteWarehouse",
                        r => r.HasOne<StockWarehouse>().WithMany()
                            .HasForeignKey("WarehouseId")
                            .HasConstraintName("stock_route_warehouse_warehouse_id_fkey"),
                        l => l.HasOne<StockRoute>().WithMany()
                            .HasForeignKey("RouteId")
                            .HasConstraintName("stock_route_warehouse_route_id_fkey"),
                        j =>
                        {
                            j.HasKey("RouteId", "WarehouseId").HasName("stock_route_warehouse_pkey");
                            j.ToTable("stock_route_warehouse");
                            j.HasIndex(new[] { "WarehouseId", "RouteId" }, "stock_route_warehouse_warehouse_id_route_id_idx");
                        });
            });
        }
    }
}