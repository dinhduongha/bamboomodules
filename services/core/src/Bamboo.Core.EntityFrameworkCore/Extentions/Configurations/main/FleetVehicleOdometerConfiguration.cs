using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureFleetVehicleOdometer(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<FleetVehicleOdometer>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("fleet_vehicle_odometer_pkey");

                        entity.ToTable("fleet_vehicle_odometer");

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
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.DriverId).HasColumnName("driver_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Value).HasColumnName("value");
                        entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.FleetVehicleOdometerCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_odometer_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_odometer_create_uid_fkey");

                        // entity.HasOne(d => d.Driver).WithMany(p => p.FleetVehicleOdometer) .HasForeignKey(d => d.DriverId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_odometer_driver_id_fkey");
                        entity.HasOne(d => d.Driver).WithMany()
                            .HasForeignKey(d => d.DriverId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_odometer_driver_id_fkey");

                        entity.HasOne(d => d.Vehicle).WithMany(p => p.FleetVehicleOdometer)
                            .HasForeignKey(d => d.VehicleId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("fleet_vehicle_odometer_vehicle_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.FleetVehicleOdometerWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_odometer_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_odometer_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}