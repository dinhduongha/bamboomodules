using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockLandedCost(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockLandedCost>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_landed_cost_pkey");

                        entity.ToTable("stock_landed_cost");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AccountMoveId, "stock_landed_cost__account_move_id_index").HasFilter("(account_move_id IS NOT NULL)");

                        entity.HasIndex(e => e.VendorBillId, "stock_landed_cost__vendor_bill_id_index").HasFilter("(vendor_bill_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountJournalId).HasColumnName("account_journal_id");
                        entity.Property(e => e.AccountMoveId).HasColumnName("account_move_id");
                        entity.Property(e => e.AmountTotal).HasColumnName("amount_total");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.TargetModel).HasColumnName("target_model");
                        entity.Property(e => e.VendorBillId).HasColumnName("vendor_bill_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AccountJournal).WithMany(p => p.StockLandedCost)
                            .HasForeignKey(d => d.AccountJournalId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_landed_cost_account_journal_id_fkey");

                        entity.HasOne(d => d.AccountMove).WithMany(p => p.StockLandedCostAccountMove)
                            .HasForeignKey(d => d.AccountMoveId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_landed_cost_account_move_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockLandedCost) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_landed_cost_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_landed_cost_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockLandedCostCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_landed_cost_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_landed_cost_create_uid_fkey");

                        entity.HasOne(d => d.VendorBill).WithMany(p => p.StockLandedCostVendorBill)
                            .HasForeignKey(d => d.VendorBillId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_landed_cost_vendor_bill_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockLandedCostWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_landed_cost_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_landed_cost_write_uid_fkey");

                        // entity.HasMany(d => d.MrpProduction).WithMany(p => p.StockLandedCost)
                        entity.HasMany(d => d.MrpProduction).WithMany(p => p.StockLandedCost)
                            .UsingEntity<Dictionary<string, object>>(
                                "MrpProductionStockLandedCostRel",
                                r => r.HasOne<MrpProduction>().WithMany()
                                    .HasForeignKey("MrpProductionId")
                                    .HasConstraintName("mrp_production_stock_landed_cost_rel_mrp_production_id_fkey"),
                                l => l.HasOne<StockLandedCost>().WithMany()
                                    .HasForeignKey("StockLandedCostId")
                                    .HasConstraintName("mrp_production_stock_landed_cost_rel_stock_landed_cost_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockLandedCostId", "MrpProductionId").HasName("mrp_production_stock_landed_cost_rel_pkey");
                                    j.ToTable("mrp_production_stock_landed_cost_rel");
                                    j.HasIndex(new[] { "MrpProductionId", "StockLandedCostId" }, "mrp_production_stock_landed_c_mrp_production_id_stock_lande_idx");
                                    j.IndexerProperty<Guid>("StockLandedCostId").HasColumnName("stock_landed_cost_id");
                                    j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                                });

                        // entity.HasMany(d => d.StockPicking).WithMany(p => p.StockLandedCost)
                        entity.HasMany(d => d.StockPicking).WithMany(p => p.StockLandedCost)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockLandedCostStockPickingRel",
                                r => r.HasOne<StockPicking>().WithMany()
                                    .HasForeignKey("StockPickingId")
                                    .HasConstraintName("stock_landed_cost_stock_picking_rel_stock_picking_id_fkey"),
                                l => l.HasOne<StockLandedCost>().WithMany()
                                    .HasForeignKey("StockLandedCostId")
                                    .HasConstraintName("stock_landed_cost_stock_picking_rel_stock_landed_cost_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockLandedCostId", "StockPickingId").HasName("stock_landed_cost_stock_picking_rel_pkey");
                                    j.ToTable("stock_landed_cost_stock_picking_rel");
                                    j.HasIndex(new[] { "StockPickingId", "StockLandedCostId" }, "stock_landed_cost_stock_picki_stock_picking_id_stock_landed_idx");
                                    j.IndexerProperty<Guid>("StockLandedCostId").HasColumnName("stock_landed_cost_id");
                                    j.IndexerProperty<Guid>("StockPickingId").HasColumnName("stock_picking_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}