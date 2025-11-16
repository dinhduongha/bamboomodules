using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureFleetVehicleLogServices(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<FleetVehicleLogServices>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("fleet_vehicle_log_services_pkey");

                        entity.ToTable("fleet_vehicle_log_services");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AccountMoveLineId, "fleet_vehicle_log_services__account_move_line_id_index").HasFilter("(account_move_line_id IS NOT NULL)");

                        entity.HasIndex(e => e.VehicleId, "fleet_vehicle_log_services__vehicle_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountMoveLineId).HasColumnName("account_move_line_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.BrandId).HasColumnName("brand_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.InvRef).HasColumnName("inv_ref");
                        entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                        entity.Property(e => e.ModelId).HasColumnName("model_id");
                        entity.Property(e => e.Notes).HasColumnName("notes");
                        entity.Property(e => e.OdometerId).HasColumnName("odometer_id");
                        entity.Property(e => e.PurchaserEmployeeId).HasColumnName("purchaser_employee_id");
                        entity.Property(e => e.PurchaserId).HasColumnName("purchaser_id");
                        entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
                        entity.Property(e => e.VendorId).HasColumnName("vendor_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AccountMoveLine).WithMany(p => p.FleetVehicleLogServices)
                            .HasForeignKey(d => d.AccountMoveLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_account_move_line_id_fkey");

                        entity.HasOne(d => d.Brand).WithMany(p => p.FleetVehicleLogServices)
                            .HasForeignKey(d => d.BrandId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_brand_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.FleetVehicleLogServices) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_services_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.FleetVehicleLogServicesCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_services_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_create_uid_fkey");

                        // entity.HasOne(d => d.Manager).WithMany(p => p.FleetVehicleLogServicesManager) .HasForeignKey(d => d.ManagerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_services_manager_id_fkey");
                        entity.HasOne(d => d.Manager).WithMany()
                            .HasForeignKey(d => d.ManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_manager_id_fkey");

                        entity.HasOne(d => d.Model).WithMany(p => p.FleetVehicleLogServices)
                            .HasForeignKey(d => d.ModelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_model_id_fkey");

                        entity.HasOne(d => d.Odometer).WithMany(p => p.FleetVehicleLogServices)
                            .HasForeignKey(d => d.OdometerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_odometer_id_fkey");

                        entity.HasOne(d => d.PurchaserEmployee).WithMany(p => p.FleetVehicleLogServices)
                            .HasForeignKey(d => d.PurchaserEmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_purchaser_employee_id_fkey");

                        // entity.HasOne(d => d.Purchaser).WithMany(p => p.FleetVehicleLogServicesPurchaser) .HasForeignKey(d => d.PurchaserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_services_purchaser_id_fkey");
                        entity.HasOne(d => d.Purchaser).WithMany()
                            .HasForeignKey(d => d.PurchaserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_purchaser_id_fkey");

                        entity.HasOne(d => d.ServiceType).WithMany(p => p.FleetVehicleLogServices)
                            .HasForeignKey(d => d.ServiceTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("fleet_vehicle_log_services_service_type_id_fkey");

                        entity.HasOne(d => d.Vehicle).WithMany(p => p.FleetVehicleLogServices)
                            .HasForeignKey(d => d.VehicleId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("fleet_vehicle_log_services_vehicle_id_fkey");

                        // entity.HasOne(d => d.Vendor).WithMany(p => p.FleetVehicleLogServicesVendor) .HasForeignKey(d => d.VendorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_services_vendor_id_fkey");
                        entity.HasOne(d => d.Vendor).WithMany()
                            .HasForeignKey(d => d.VendorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_vendor_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.FleetVehicleLogServicesWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_services_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_services_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}