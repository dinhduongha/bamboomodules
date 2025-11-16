using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureFleetVehicleLogContract(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<FleetVehicleLogContract>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("fleet_vehicle_log_contract_pkey");

                        entity.ToTable("fleet_vehicle_log_contract");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.UserId, "fleet_vehicle_log_contract__user_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Amount).HasColumnName("amount");

                        entity.Property(e => e.CostFrequency).HasColumnName("cost_frequency");
                        entity.Property(e => e.CostGenerated).HasColumnName("cost_generated");
                        entity.Property(e => e.CostSubtypeId).HasColumnName("cost_subtype_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
                        entity.Property(e => e.InsRef).HasColumnName("ins_ref");
                        entity.Property(e => e.InsurerId).HasColumnName("insurer_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Notes).HasColumnName("notes");
                        entity.Property(e => e.StartDate).HasColumnName("start_date");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.FleetVehicleLogContract) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_contract_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_contract_company_id_fkey");

                        entity.HasOne(d => d.CostSubtype).WithMany(p => p.FleetVehicleLogContractNavigation)
                            .HasForeignKey(d => d.CostSubtypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_contract_cost_subtype_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.FleetVehicleLogContractCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_contract_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_contract_create_uid_fkey");

                        // entity.HasOne(d => d.Insurer).WithMany(p => p.FleetVehicleLogContract) .HasForeignKey(d => d.InsurerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_contract_insurer_id_fkey");
                        entity.HasOne(d => d.Insurer).WithMany()
                            .HasForeignKey(d => d.InsurerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_contract_insurer_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.FleetVehicleLogContractUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_contract_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_contract_user_id_fkey");

                        entity.HasOne(d => d.Vehicle).WithMany(p => p.FleetVehicleLogContract)
                            .HasForeignKey(d => d.VehicleId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("fleet_vehicle_log_contract_vehicle_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.FleetVehicleLogContractWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("fleet_vehicle_log_contract_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("fleet_vehicle_log_contract_write_uid_fkey");

                        // entity.HasMany(d => d.FleetServiceType).WithMany(p => p.FleetVehicleLogContract)
                        entity.HasMany(d => d.FleetServiceType).WithMany(p => p.FleetVehicleLogContract)
                            .UsingEntity<Dictionary<string, object>>(
                                "FleetServiceTypeFleetVehicleLogContractRel",
                                r => r.HasOne<FleetServiceType>().WithMany()
                                    .HasForeignKey("FleetServiceTypeId")
                                    .HasConstraintName("fleet_service_type_fleet_vehicle_log_fleet_service_type_id_fkey"),
                                l => l.HasOne<FleetVehicleLogContract>().WithMany()
                                    .HasForeignKey("FleetVehicleLogContractId")
                                    .HasConstraintName("fleet_service_type_fleet_vehi_fleet_vehicle_log_contract_i_fkey"),
                                j =>
                                {
                                    j.HasKey("FleetVehicleLogContractId", "FleetServiceTypeId").HasName("fleet_service_type_fleet_vehicle_log_contract_rel_pkey");
                                    j.ToTable("fleet_service_type_fleet_vehicle_log_contract_rel");
                                    j.HasIndex(new[] { "FleetServiceTypeId", "FleetVehicleLogContractId" }, "fleet_service_type_fleet_vehi_fleet_service_type_id_fleet_v_idx");
                                    j.IndexerProperty<Guid>("FleetVehicleLogContractId").HasColumnName("fleet_vehicle_log_contract_id");
                                    j.IndexerProperty<Guid>("FleetServiceTypeId").HasColumnName("fleet_service_type_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}