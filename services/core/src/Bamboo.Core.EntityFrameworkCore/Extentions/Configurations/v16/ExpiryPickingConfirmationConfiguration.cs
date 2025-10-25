using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureExpiryPickingConfirmation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ExpiryPickingConfirmation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("expiry_picking_confirmation_pkey");

                        entity.ToTable("expiry_picking_confirmation");

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
                        entity.Property(e => e.WorkorderId).HasColumnName("workorder_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ExpiryPickingConfirmationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("expiry_picking_confirmation_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("expiry_picking_confirmation_create_uid_fkey");

                        entity.HasOne(d => d.Workorder).WithMany(p => p.ExpiryPickingConfirmation)
                            .HasForeignKey(d => d.WorkorderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("expiry_picking_confirmation_workorder_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ExpiryPickingConfirmationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("expiry_picking_confirmation_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("expiry_picking_confirmation_write_uid_fkey");

                        // entity.HasMany(d => d.MrpProduction).WithMany(p => p.ExpiryPickingConfirmation)
                        entity.HasMany(d => d.MrpProduction).WithMany(p => p.ExpiryPickingConfirmation)
                            .UsingEntity<Dictionary<string, object>>(
                                "ExpiryPickingConfirmationMrpProductionRel",
                                r => r.HasOne<MrpProduction>().WithMany()
                                    .HasForeignKey("MrpProductionId")
                                    .HasConstraintName("expiry_picking_confirmation_mrp_producti_mrp_production_id_fkey"),
                                l => l.HasOne<ExpiryPickingConfirmation>().WithMany()
                                    .HasForeignKey("ExpiryPickingConfirmationId")
                                    .HasConstraintName("expiry_picking_confirmation_m_expiry_picking_confirmation__fkey"),
                                j =>
                                {
                                    j.HasKey("ExpiryPickingConfirmationId", "MrpProductionId").HasName("expiry_picking_confirmation_mrp_production_rel_pkey");
                                    j.ToTable("expiry_picking_confirmation_mrp_production_rel");
                                    j.HasIndex(new[] { "MrpProductionId", "ExpiryPickingConfirmationId" }, "expiry_picking_confirmation_m_mrp_production_id_expiry_pick_idx");
                                    j.IndexerProperty<Guid>("ExpiryPickingConfirmationId").HasColumnName("expiry_picking_confirmation_id");
                                    j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                                });

                        // entity.HasMany(d => d.StockLot).WithMany(p => p.ExpiryPickingConfirmation)
                        entity.HasMany(d => d.StockLot).WithMany(p => p.ExpiryPickingConfirmation)
                            .UsingEntity<Dictionary<string, object>>(
                                "ExpiryPickingConfirmationStockLotRel",
                                r => r.HasOne<StockLot>().WithMany()
                                    .HasForeignKey("StockLotId")
                                    .HasConstraintName("expiry_picking_confirmation_stock_lot_rel_stock_lot_id_fkey"),
                                l => l.HasOne<ExpiryPickingConfirmation>().WithMany()
                                    .HasForeignKey("ExpiryPickingConfirmationId")
                                    .HasConstraintName("expiry_picking_confirmation_s_expiry_picking_confirmation__fkey"),
                                j =>
                                {
                                    j.HasKey("ExpiryPickingConfirmationId", "StockLotId").HasName("expiry_picking_confirmation_stock_lot_rel_pkey");
                                    j.ToTable("expiry_picking_confirmation_stock_lot_rel");
                                    j.HasIndex(new[] { "StockLotId", "ExpiryPickingConfirmationId" }, "expiry_picking_confirmation_s_stock_lot_id_expiry_picking_c_idx");
                                    j.IndexerProperty<Guid>("ExpiryPickingConfirmationId").HasColumnName("expiry_picking_confirmation_id");
                                    j.IndexerProperty<Guid>("StockLotId").HasColumnName("stock_lot_id");
                                });

                        // entity.HasMany(d => d.StockPicking).WithMany(p => p.ExpiryPickingConfirmation)
                        entity.HasMany(d => d.StockPicking).WithMany(p => p.ExpiryPickingConfirmation)
                            .UsingEntity<Dictionary<string, object>>(
                                "ExpiryPickingConfirmationStockPickingRel",
                                r => r.HasOne<StockPicking>().WithMany()
                                    .HasForeignKey("StockPickingId")
                                    .HasConstraintName("expiry_picking_confirmation_stock_picking_stock_picking_id_fkey"),
                                l => l.HasOne<ExpiryPickingConfirmation>().WithMany()
                                    .HasForeignKey("ExpiryPickingConfirmationId")
                                    .HasConstraintName("expiry_picking_confirmation__expiry_picking_confirmation__fkey1"),
                                j =>
                                {
                                    j.HasKey("ExpiryPickingConfirmationId", "StockPickingId").HasName("expiry_picking_confirmation_stock_picking_rel_pkey");
                                    j.ToTable("expiry_picking_confirmation_stock_picking_rel");
                                    j.HasIndex(new[] { "StockPickingId", "ExpiryPickingConfirmationId" }, "expiry_picking_confirmation_s_stock_picking_id_expiry_picki_idx");
                                    j.IndexerProperty<Guid>("ExpiryPickingConfirmationId").HasColumnName("expiry_picking_confirmation_id");
                                    j.IndexerProperty<Guid>("StockPickingId").HasColumnName("stock_picking_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}