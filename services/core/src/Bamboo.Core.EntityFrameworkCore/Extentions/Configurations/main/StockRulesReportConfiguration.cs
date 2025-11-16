using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockRulesReport(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockRulesReport>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_rules_report_pkey");

                        entity.ToTable("stock_rules_report");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ProductHasVariants).HasColumnName("product_has_variants");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockRulesReportCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_rules_report_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_rules_report_create_uid_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockRulesReport) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("stock_rules_report_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_rules_report_product_id_fkey");

                        entity.HasOne(d => d.ProductTmpl).WithMany(p => p.StockRulesReport)
                            .HasForeignKey(d => d.ProductTmplId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_rules_report_product_tmpl_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockRulesReportWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_rules_report_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_rules_report_write_uid_fkey");

                        // entity.HasMany(d => d.StockRoute).WithMany(p => p.StockRulesReport)
                        entity.HasMany(d => d.StockRoute).WithMany(p => p.StockRulesReport)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockRouteStockRulesReportRel",
                                r => r.HasOne<StockRoute>().WithMany()
                                    .HasForeignKey("StockRouteId")
                                    .HasConstraintName("stock_route_stock_rules_report_rel_stock_route_id_fkey"),
                                l => l.HasOne<StockRulesReport>().WithMany()
                                    .HasForeignKey("StockRulesReportId")
                                    .HasConstraintName("stock_route_stock_rules_report_rel_stock_rules_report_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockRulesReportId", "StockRouteId").HasName("stock_route_stock_rules_report_rel_pkey");
                                    j.ToTable("stock_route_stock_rules_report_rel");
                                    j.HasIndex(new[] { "StockRouteId", "StockRulesReportId" }, "stock_route_stock_rules_repor_stock_route_id_stock_rules_re_idx");
                                    j.IndexerProperty<Guid>("StockRulesReportId").HasColumnName("stock_rules_report_id");
                                    j.IndexerProperty<Guid>("StockRouteId").HasColumnName("stock_route_id");
                                });

                        // entity.HasMany(d => d.StockWarehouse).WithMany(p => p.StockRulesReport)
                        entity.HasMany(d => d.StockWarehouse).WithMany(p => p.StockRulesReport)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockRulesReportStockWarehouseRel",
                                r => r.HasOne<StockWarehouse>().WithMany()
                                    .HasForeignKey("StockWarehouseId")
                                    .HasConstraintName("stock_rules_report_stock_warehouse_rel_stock_warehouse_id_fkey"),
                                l => l.HasOne<StockRulesReport>().WithMany()
                                    .HasForeignKey("StockRulesReportId")
                                    .HasConstraintName("stock_rules_report_stock_warehouse_r_stock_rules_report_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockRulesReportId", "StockWarehouseId").HasName("stock_rules_report_stock_warehouse_rel_pkey");
                                    j.ToTable("stock_rules_report_stock_warehouse_rel");
                                    j.HasIndex(new[] { "StockWarehouseId", "StockRulesReportId" }, "stock_rules_report_stock_ware_stock_warehouse_id_stock_rule_idx");
                                    j.IndexerProperty<Guid>("StockRulesReportId").HasColumnName("stock_rules_report_id");
                                    j.IndexerProperty<Guid>("StockWarehouseId").HasColumnName("stock_warehouse_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}