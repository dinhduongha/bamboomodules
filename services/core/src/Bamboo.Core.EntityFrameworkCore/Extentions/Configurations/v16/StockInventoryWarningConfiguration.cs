using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockInventoryWarning(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockInventoryWarning>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_inventory_warning_pkey");

                        entity.ToTable("stock_inventory_warning");

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
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockInventoryWarningCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_inventory_warning_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_inventory_warning_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockInventoryWarningWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_inventory_warning_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_inventory_warning_write_uid_fkey");

                        // entity.HasMany(d => d.StockQuant).WithMany(p => p.StockInventoryWarning)
                        entity.HasMany(d => d.StockQuant).WithMany(p => p.StockInventoryWarning)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockInventoryWarningStockQuantRel",
                                r => r.HasOne<StockQuant>().WithMany()
                                    .HasForeignKey("StockQuantId")
                                    .HasConstraintName("stock_inventory_warning_stock_quant_rel_stock_quant_id_fkey"),
                                l => l.HasOne<StockInventoryWarning>().WithMany()
                                    .HasForeignKey("StockInventoryWarningId")
                                    .HasConstraintName("stock_inventory_warning_stock_q_stock_inventory_warning_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockInventoryWarningId", "StockQuantId").HasName("stock_inventory_warning_stock_quant_rel_pkey");
                                    j.ToTable("stock_inventory_warning_stock_quant_rel");
                                    j.HasIndex(new[] { "StockQuantId", "StockInventoryWarningId" }, "stock_inventory_warning_stock_stock_quant_id_stock_inventor_idx");
                                    j.IndexerProperty<Guid>("StockInventoryWarningId").HasColumnName("stock_inventory_warning_id");
                                    j.IndexerProperty<Guid>("StockQuantId").HasColumnName("stock_quant_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}