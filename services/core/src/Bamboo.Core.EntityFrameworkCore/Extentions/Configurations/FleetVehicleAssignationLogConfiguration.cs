using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureFleetVehicleAssignationLog(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FleetVehicleAssignationLog>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("fleet_vehicle_assignation_log_pkey");

                entity.ToTable("fleet_vehicle_assignation_log");

                entity.HasIndex(e => e.TenantId, "fleet_vehicle_assignation_log_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateEnd).HasColumnName("date_end");
                entity.Property(e => e.DateStart).HasColumnName("date_start");
                entity.Property(e => e.DriverEmployeeId).HasColumnName("driver_employee_id");
                entity.Property(e => e.DriverId).HasColumnName("driver_id");
                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_assignation_log_create_uid_fkey");

                entity.HasOne(d => d.DriverEmployee).WithMany(p => p.FleetVehicleAssignationLogs)
                    .HasForeignKey(d => d.DriverEmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_assignation_log_driver_employee_id_fkey");

                entity.HasOne(d => d.Driver).WithMany(p => p.FleetVehicleAssignationLogs)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fleet_vehicle_assignation_log_driver_id_fkey");

                entity.HasOne(d => d.Vehicle).WithMany(p => p.FleetVehicleAssignationLogs)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fleet_vehicle_assignation_log_vehicle_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_assignation_log_write_uid_fkey");
            });
        }
    }
}