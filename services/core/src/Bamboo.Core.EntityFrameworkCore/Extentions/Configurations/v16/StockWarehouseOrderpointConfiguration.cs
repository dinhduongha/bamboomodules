using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockWarehouseOrderpoint(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockWarehouseOrderpoint>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_warehouse_orderpoint_pkey");

                        entity.ToTable("stock_warehouse_orderpoint");

                        entity.HasIndex(e => e.TenantId, "stock_warehouse_orderpoint__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LocationId, "stock_warehouse_orderpoint__location_id_index");

                        entity.HasIndex(e => new { e.ProductId, e.LocationId, e.TenantId }, "stock_warehouse_orderpoint_product_location_check").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.BomId).HasColumnName("bom_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.GroupId).HasColumnName("group_id");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.ManufacturingVisibilityDays).HasColumnName("manufacturing_visibility_days");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductMaxQty).HasColumnName("product_max_qty");
                        entity.Property(e => e.ProductMinQty).HasColumnName("product_min_qty");
                        entity.Property(e => e.ProductSupplierId).HasColumnName("product_supplier_id");
                        entity.Property(e => e.PurchaseVisibilityDays).HasColumnName("purchase_visibility_days");
                        entity.Property(e => e.QtyMultiple).HasColumnName("qty_multiple");
                        entity.Property(e => e.QtyToOrderManual).HasColumnName("qty_to_order_manual");
                        entity.Property(e => e.RouteId).HasColumnName("route_id");
                        entity.Property(e => e.SnoozedUntil).HasColumnName("snoozed_until");
                        entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
                        entity.Property(e => e.Trigger).HasColumnName("trigger");
                        entity.Property(e => e.VendorId).HasColumnName("vendor_id");
                        entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Bom).WithMany(p => p.StockWarehouseOrderpoint)
                            .HasForeignKey(d => d.BomId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warehouse_orderpoint_bom_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockWarehouseOrderpoint) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_warehouse_orderpoint_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_warehouse_orderpoint_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockWarehouseOrderpointCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_warehouse_orderpoint_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warehouse_orderpoint_create_uid_fkey");

                        entity.HasOne(d => d.Group).WithMany(p => p.StockWarehouseOrderpoint)
                            .HasForeignKey(d => d.GroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warehouse_orderpoint_group_id_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.StockWarehouseOrderpoint)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_warehouse_orderpoint_location_id_fkey");

                        entity.HasOne(d => d.ProductCategory).WithMany(p => p.StockWarehouseOrderpoint)
                            .HasForeignKey(d => d.ProductCategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warehouse_orderpoint_product_category_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockWarehouseOrderpoint) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("stock_warehouse_orderpoint_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_warehouse_orderpoint_product_id_fkey");

                        // entity.HasOne(d => d.ProductSupplier).WithMany(p => p.StockWarehouseOrderpointProductSupplier) .HasForeignKey(d => d.ProductSupplierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_warehouse_orderpoint_product_supplier_id_fkey");
                        entity.HasOne(d => d.ProductSupplier).WithMany()
                            .HasForeignKey(d => d.ProductSupplierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warehouse_orderpoint_product_supplier_id_fkey");

                        entity.HasOne(d => d.Route).WithMany(p => p.StockWarehouseOrderpoint)
                            .HasForeignKey(d => d.RouteId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warehouse_orderpoint_route_id_fkey");

                        entity.HasOne(d => d.Supplier).WithMany(p => p.StockWarehouseOrderpoint)
                            .HasForeignKey(d => d.SupplierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warehouse_orderpoint_supplier_id_fkey");

                        // entity.HasOne(d => d.Vendor).WithMany(p => p.StockWarehouseOrderpointVendor) .HasForeignKey(d => d.VendorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_warehouse_orderpoint_vendor_id_fkey");
                        entity.HasOne(d => d.Vendor).WithMany()
                            .HasForeignKey(d => d.VendorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warehouse_orderpoint_vendor_id_fkey");

                        entity.HasOne(d => d.Warehouse).WithMany(p => p.StockWarehouseOrderpoint)
                            .HasForeignKey(d => d.WarehouseId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_warehouse_orderpoint_warehouse_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockWarehouseOrderpointWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_warehouse_orderpoint_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_warehouse_orderpoint_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}