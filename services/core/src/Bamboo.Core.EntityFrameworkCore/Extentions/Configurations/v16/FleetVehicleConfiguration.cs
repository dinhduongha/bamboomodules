using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureFleetVehicle(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<FleetVehicle>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("fleet_vehicle_pkey");

                        entity.ToTable("fleet_vehicle");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AcquisitionDate).HasColumnName("acquisition_date");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.BrandId).HasColumnName("brand_id");
                        entity.Property(e => e.CarValue).HasColumnName("car_value");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");
                        entity.Property(e => e.Co2).HasColumnName("co2");
                        entity.Property(e => e.Co2Standard).HasColumnName("co2_standard");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.Doors).HasColumnName("doors");
                        entity.Property(e => e.DriverEmployeeId).HasColumnName("driver_employee_id");
                        entity.Property(e => e.DriverId).HasColumnName("driver_id");
                        entity.Property(e => e.ElectricAssistance).HasColumnName("electric_assistance");
                        entity.Property(e => e.FirstContractDate).HasColumnName("first_contract_date");
                        entity.Property(e => e.FrameSize).HasColumnName("frame_size");
                        entity.Property(e => e.FrameType).HasColumnName("frame_type");
                        entity.Property(e => e.FuelType).HasColumnName("fuel_type");
                        entity.Property(e => e.FutureDriverEmployeeId).HasColumnName("future_driver_employee_id");
                        entity.Property(e => e.FutureDriverId).HasColumnName("future_driver_id");
                        entity.Property(e => e.Horsepower).HasColumnName("horsepower");
                        entity.Property(e => e.HorsepowerTax).HasColumnName("horsepower_tax");
                        entity.Property(e => e.LicensePlate).HasColumnName("license_plate");
                        entity.Property(e => e.Location).HasColumnName("location");
                        entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                        entity.Property(e => e.MobilityCard).HasColumnName("mobility_card");
                        entity.Property(e => e.ModelId).HasColumnName("model_id");
                        entity.Property(e => e.ModelYear).HasColumnName("model_year");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.NetCarValue).HasColumnName("net_car_value");
                        entity.Property(e => e.NextAssignationDate).HasColumnName("next_assignation_date");
                        entity.Property(e => e.OdometerUnit).HasColumnName("odometer_unit");
                        entity.Property(e => e.OrderDate).HasColumnName("order_date");
                        entity.Property(e => e.PlanToChangeBike).HasColumnName("plan_to_change_bike");
                        entity.Property(e => e.PlanToChangeCar).HasColumnName("plan_to_change_car");
                        entity.Property(e => e.Power).HasColumnName("power");
                        entity.Property(e => e.PowerUnit).HasColumnName("power_unit");
                        entity.Property(e => e.ResidualValue).HasColumnName("residual_value");
                        entity.Property(e => e.Seats).HasColumnName("seats");
                        entity.Property(e => e.StateId).HasColumnName("state_id");
                        entity.Property(e => e.TrailerHook).HasColumnName("trailer_hook");
                        entity.Property(e => e.Transmission).HasColumnName("transmission");
                        entity.Property(e => e.VehicleProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("vehicle_properties");
                        entity.Property(e => e.VehicleRange).HasColumnName("vehicle_range");
                        entity.Property(e => e.VinSn).HasColumnName("vin_sn");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.WriteOffDate).HasColumnName("write_off_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Brand).WithMany(p => p.FleetVehicle)
                            .HasForeignKey(d => d.BrandId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_brand_id_fkey");

                        entity.HasOne(d => d.Category).WithMany(p => p.FleetVehicle)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_category_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.FleetVehicle) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.FleetVehicleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_create_uid_fkey");

                        entity.HasOne(d => d.DriverEmployee).WithMany(p => p.FleetVehicleDriverEmployee)
                            .HasForeignKey(d => d.DriverEmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_driver_employee_id_fkey");

                        // entity.HasOne(d => d.Driver).WithMany(p => p.FleetVehicleDriver) .HasForeignKey(d => d.DriverId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_driver_id_fkey");
                        entity.HasOne(d => d.Driver).WithMany()
                            .HasForeignKey(d => d.DriverId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_driver_id_fkey");

                        entity.HasOne(d => d.FutureDriverEmployee).WithMany(p => p.FleetVehicleFutureDriverEmployee)
                            .HasForeignKey(d => d.FutureDriverEmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_future_driver_employee_id_fkey");

                        // entity.HasOne(d => d.FutureDriver).WithMany(p => p.FleetVehicleFutureDriver) .HasForeignKey(d => d.FutureDriverId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_future_driver_id_fkey");
                        entity.HasOne(d => d.FutureDriver).WithMany()
                            .HasForeignKey(d => d.FutureDriverId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_future_driver_id_fkey");

                        // entity.HasOne(d => d.Manager).WithMany(p => p.FleetVehicleManager) .HasForeignKey(d => d.ManagerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_manager_id_fkey");
                        entity.HasOne(d => d.Manager).WithMany()
                            .HasForeignKey(d => d.ManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_manager_id_fkey");

                        entity.HasOne(d => d.Model).WithMany(p => p.FleetVehicle)
                            .HasForeignKey(d => d.ModelId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("fleet_vehicle_model_id_fkey");

                        entity.HasOne(d => d.State).WithMany(p => p.FleetVehicle)
                            .HasForeignKey(d => d.StateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_state_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.FleetVehicleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_write_uid_fkey");

                        // entity.HasMany(d => d.Tag).WithMany(p => p.VehicleTag)
                        entity.HasMany(d => d.Tag).WithMany(p => p.VehicleTag)
                            .UsingEntity<Dictionary<string, object>>(
                                "FleetVehicleVehicleTagRel",
                                r => r.HasOne<FleetVehicleTag>().WithMany()
                                    .HasForeignKey("TagId")
                                    .HasConstraintName("fleet_vehicle_vehicle_tag_rel_tag_id_fkey"),
                                l => l.HasOne<FleetVehicle>().WithMany()
                                    .HasForeignKey("VehicleTagId")
                                    .HasConstraintName("fleet_vehicle_vehicle_tag_rel_vehicle_tag_id_fkey"),
                                j =>
                                {
                                    j.HasKey("VehicleTagId", "TagId").HasName("fleet_vehicle_vehicle_tag_rel_pkey");
                                    j.ToTable("fleet_vehicle_vehicle_tag_rel");
                                    j.HasIndex(new[] { "TagId", "VehicleTagId" }, "fleet_vehicle_vehicle_tag_rel_tag_id_vehicle_tag_id_idx");
                                    j.IndexerProperty<Guid>("VehicleTagId").HasColumnName("vehicle_tag_id");
                                    j.IndexerProperty<Guid>("TagId").HasColumnName("tag_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}