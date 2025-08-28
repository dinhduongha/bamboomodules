using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockAddToWave(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockAddToWave>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_add_to_wave_pkey");

                        entity.ToTable("stock_add_to_wave");

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
                        entity.Property(e => e.Mode).HasColumnName("mode");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.WaveId).HasColumnName("wave_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockAddToWaveCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_add_to_wave_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_add_to_wave_create_uid_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.StockAddToWaveUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_add_to_wave_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_add_to_wave_user_id_fkey");

                        entity.HasOne(d => d.Wave).WithMany(p => p.StockAddToWave)
                            .HasForeignKey(d => d.WaveId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_add_to_wave_wave_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockAddToWaveWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_add_to_wave_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_add_to_wave_write_uid_fkey");

                        // entity.HasMany(d => d.StockMoveLine).WithMany(p => p.StockAddToWave)
                        entity.HasMany(d => d.StockMoveLine).WithMany(p => p.StockAddToWave)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockAddToWaveStockMoveLineRel",
                                r => r.HasOne<StockMoveLine>().WithMany()
                                    .HasForeignKey("StockMoveLineId")
                                    .HasConstraintName("stock_add_to_wave_stock_move_line_rel_stock_move_line_id_fkey"),
                                l => l.HasOne<StockAddToWave>().WithMany()
                                    .HasForeignKey("StockAddToWaveId")
                                    .HasConstraintName("stock_add_to_wave_stock_move_line_rel_stock_add_to_wave_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockAddToWaveId", "StockMoveLineId").HasName("stock_add_to_wave_stock_move_line_rel_pkey");
                                    j.ToTable("stock_add_to_wave_stock_move_line_rel");
                                    j.HasIndex(new[] { "StockMoveLineId", "StockAddToWaveId" }, "stock_add_to_wave_stock_move__stock_move_line_id_stock_add__idx");
                                    j.IndexerProperty<Guid>("StockAddToWaveId").HasColumnName("stock_add_to_wave_id");
                                    j.IndexerProperty<Guid>("StockMoveLineId").HasColumnName("stock_move_line_id");
                                });

                        // entity.HasMany(d => d.StockPicking).WithMany(p => p.StockAddToWave)
                        entity.HasMany(d => d.StockPicking).WithMany(p => p.StockAddToWave)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockAddToWaveStockPickingRel",
                                r => r.HasOne<StockPicking>().WithMany()
                                    .HasForeignKey("StockPickingId")
                                    .HasConstraintName("stock_add_to_wave_stock_picking_rel_stock_picking_id_fkey"),
                                l => l.HasOne<StockAddToWave>().WithMany()
                                    .HasForeignKey("StockAddToWaveId")
                                    .HasConstraintName("stock_add_to_wave_stock_picking_rel_stock_add_to_wave_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockAddToWaveId", "StockPickingId").HasName("stock_add_to_wave_stock_picking_rel_pkey");
                                    j.ToTable("stock_add_to_wave_stock_picking_rel");
                                    j.HasIndex(new[] { "StockPickingId", "StockAddToWaveId" }, "stock_add_to_wave_stock_picki_stock_picking_id_stock_add_to_idx");
                                    j.IndexerProperty<Guid>("StockAddToWaveId").HasColumnName("stock_add_to_wave_id");
                                    j.IndexerProperty<Guid>("StockPickingId").HasColumnName("stock_picking_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}