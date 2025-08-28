using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockPickingBatch(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockPickingBatch>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_picking_batch_pkey");

                        entity.ToTable("stock_picking_batch");

                        entity.HasIndex(e => e.TenantId, "stock_picking_batch__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.PickingTypeId, "stock_picking_batch__picking_type_id_index");

                        entity.HasIndex(e => e.State, "stock_picking_batch__state_index");

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
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.DockId).HasColumnName("dock_id");
                        entity.Property(e => e.DriverId).HasColumnName("driver_id");
                        entity.Property(e => e.EndDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("end_date");
                        entity.Property(e => e.IsWave).HasColumnName("is_wave");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                        entity.Property(e => e.Properties)
                            .HasColumnType("jsonb")
                            .HasColumnName("properties");
                        entity.Property(e => e.ScheduledDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("scheduled_date");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.VehicleCategoryId).HasColumnName("vehicle_category_id");
                        entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockPickingBatch) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_picking_batch_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_picking_batch_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPickingBatchCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_batch_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_batch_create_uid_fkey");

                        entity.HasOne(d => d.Dock).WithMany(p => p.StockPickingBatch)
                            .HasForeignKey(d => d.DockId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_batch_dock_id_fkey");

                        // entity.HasOne(d => d.Driver).WithMany(p => p.StockPickingBatch) .HasForeignKey(d => d.DriverId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_batch_driver_id_fkey");
                        entity.HasOne(d => d.Driver).WithMany()
                            .HasForeignKey(d => d.DriverId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_batch_driver_id_fkey");

                        entity.HasOne(d => d.PickingType).WithMany(p => p.StockPickingBatch)
                            .HasForeignKey(d => d.PickingTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_batch_picking_type_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.StockPickingBatchUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_batch_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_batch_user_id_fkey");

                        entity.HasOne(d => d.VehicleCategory).WithMany(p => p.StockPickingBatch)
                            .HasForeignKey(d => d.VehicleCategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_batch_vehicle_category_id_fkey");

                        entity.HasOne(d => d.Vehicle).WithMany(p => p.StockPickingBatch)
                            .HasForeignKey(d => d.VehicleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_batch_vehicle_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPickingBatchWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_batch_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_picking_batch_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}