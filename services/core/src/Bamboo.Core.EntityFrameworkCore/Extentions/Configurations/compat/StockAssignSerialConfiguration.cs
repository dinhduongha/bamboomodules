using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockAssignSerial(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockAssignSerial>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_assign_serial_pkey");

                        entity.ToTable("stock_assign_serial");

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
                        entity.Property(e => e.ExpectedQty).HasColumnName("expected_qty");
                        entity.Property(e => e.MoveId).HasColumnName("move_id");
                        entity.Property(e => e.MultipleLotComponentsNames).HasColumnName("multiple_lot_components_names");
                        entity.Property(e => e.NextSerialCount).HasColumnName("next_serial_count");
                        entity.Property(e => e.NextSerialNumber).HasColumnName("next_serial_number");
                        entity.Property(e => e.ProducedQty).HasColumnName("produced_qty");
                        entity.Property(e => e.ProductionId).HasColumnName("production_id");
                        entity.Property(e => e.SerialNumbers).HasColumnName("serial_numbers");
                        entity.Property(e => e.ShowApply).HasColumnName("show_apply");
                        entity.Property(e => e.ShowBackorders).HasColumnName("show_backorders");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockAssignSerialCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_assign_serial_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_assign_serial_create_uid_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.StockAssignSerial)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_assign_serial_move_id_fkey");

                        entity.HasOne(d => d.Production).WithMany(p => p.StockAssignSerial)
                            .HasForeignKey(d => d.ProductionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_assign_serial_production_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockAssignSerialWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_assign_serial_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_assign_serial_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}