using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId, "stock_route__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.SuppliedWhId, "stock_route__supplied_wh_id_index").HasFilter("(supplied_wh_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PackageTypeSelectable).HasColumnName("package_type_selectable");
                        entity.Property(e => e.ProductCategSelectable).HasColumnName("product_categ_selectable");
                        entity.Property(e => e.ProductSelectable).HasColumnName("product_selectable");
                        entity.Property(e => e.SaleSelectable).HasColumnName("sale_selectable");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.ShippingSelectable).HasColumnName("shipping_selectable");
                        entity.Property(e => e.SuppliedWhId).HasColumnName("supplied_wh_id");
                        entity.Property(e => e.SupplierWhId).HasColumnName("supplier_wh_id");
                        entity.Property(e => e.WarehouseSelectable).HasColumnName("warehouse_selectable");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockRoute) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_route_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_route_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockRouteCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_route_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_route_create_uid_fkey");

                        entity.HasOne(d => d.SuppliedWh).WithMany(p => p.StockRouteSuppliedWh)
                            .HasForeignKey(d => d.SuppliedWhId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_route_supplied_wh_id_fkey");

                        entity.HasOne(d => d.SupplierWh).WithMany(p => p.StockRouteSupplierWh)
                            .HasForeignKey(d => d.SupplierWhId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_route_supplier_wh_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockRouteWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_route_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_route_write_uid_fkey");

                        // entity.HasMany(d => d.Categ).WithMany(p => p.Route)
                        entity.HasMany(d => d.Categ).WithMany(p => p.Route)
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
                                    j.IndexerProperty<Guid>("RouteId").HasColumnName("route_id");
                                    j.IndexerProperty<Guid>("CategId").HasColumnName("categ_id");
                                });

                        // entity.HasMany(d => d.Product).WithMany(p => p.Route)
                        entity.HasMany(d => d.Product).WithMany(p => p.Route)
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
                                    j.IndexerProperty<Guid>("RouteId").HasColumnName("route_id");
                                    j.IndexerProperty<Guid>("ProductId").HasColumnName("product_id");
                                });

                        // entity.HasMany(d => d.Warehouse).WithMany(p => p.Route)
                        entity.HasMany(d => d.Warehouse).WithMany(p => p.Route)
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
                                    j.IndexerProperty<Guid>("RouteId").HasColumnName("route_id");
                                    j.IndexerProperty<Guid>("WarehouseId").HasColumnName("warehouse_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}