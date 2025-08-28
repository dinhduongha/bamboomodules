using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockBackorderConfirmation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockBackorderConfirmation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_backorder_confirmation_pkey");

                        entity.ToTable("stock_backorder_confirmation");

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
                        entity.Property(e => e.ShowTransfers).HasColumnName("show_transfers");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockBackorderConfirmationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_backorder_confirmation_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_backorder_confirmation_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockBackorderConfirmationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_backorder_confirmation_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_backorder_confirmation_write_uid_fkey");

                        // entity.HasMany(d => d.StockPicking).WithMany(p => p.StockBackorderConfirmation)
                        entity.HasMany(d => d.StockPicking).WithMany(p => p.StockBackorderConfirmation)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockPickingBackorderRel",
                                r => r.HasOne<StockPicking>().WithMany()
                                    .HasForeignKey("StockPickingId")
                                    .HasConstraintName("stock_picking_backorder_rel_stock_picking_id_fkey"),
                                l => l.HasOne<StockBackorderConfirmation>().WithMany()
                                    .HasForeignKey("StockBackorderConfirmationId")
                                    .HasConstraintName("stock_picking_backorder_rel_stock_backorder_confirmation_i_fkey"),
                                j =>
                                {
                                    j.HasKey("StockBackorderConfirmationId", "StockPickingId").HasName("stock_picking_backorder_rel_pkey");
                                    j.ToTable("stock_picking_backorder_rel");
                                    j.HasIndex(new[] { "StockPickingId", "StockBackorderConfirmationId" }, "stock_picking_backorder_rel_stock_picking_id_stock_backorde_idx");
                                    j.IndexerProperty<Guid>("StockBackorderConfirmationId").HasColumnName("stock_backorder_confirmation_id");
                                    j.IndexerProperty<Guid>("StockPickingId").HasColumnName("stock_picking_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}