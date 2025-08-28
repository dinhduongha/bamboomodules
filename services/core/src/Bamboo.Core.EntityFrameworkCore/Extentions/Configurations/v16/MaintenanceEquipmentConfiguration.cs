using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMaintenanceEquipment(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MaintenanceEquipment>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("maintenance_equipment_pkey");

                        entity.ToTable("maintenance_equipment");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.SerialNo, "maintenance_equipment_serial_no").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AssignDate).HasColumnName("assign_date");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.Cost).HasColumnName("cost");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                        entity.Property(e => e.EffectiveDate).HasColumnName("effective_date");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.EquipmentAssignTo).HasColumnName("equipment_assign_to");
                        entity.Property(e => e.EquipmentProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("equipment_properties");
                        entity.Property(e => e.ExpectedMtbf).HasColumnName("expected_mtbf");
                        entity.Property(e => e.Location).HasColumnName("location");
                        entity.Property(e => e.MaintenanceCount).HasColumnName("maintenance_count");
                        entity.Property(e => e.MaintenanceOpenCount).HasColumnName("maintenance_open_count");
                        entity.Property(e => e.MaintenanceTeamId).HasColumnName("maintenance_team_id");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.OwnerUserId).HasColumnName("owner_user_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PartnerRef).HasColumnName("partner_ref");
                        entity.Property(e => e.ScrapDate).HasColumnName("scrap_date");
                        entity.Property(e => e.SerialNo).HasColumnName("serial_no");
                        entity.Property(e => e.TechnicianUserId).HasColumnName("technician_user_id");
                        entity.Property(e => e.WarrantyDate).HasColumnName("warranty_date");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Category).WithMany(p => p.MaintenanceEquipment)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_category_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.MaintenanceEquipment) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("maintenance_equipment_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MaintenanceEquipmentCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("maintenance_equipment_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_create_uid_fkey");

                        entity.HasOne(d => d.Department).WithMany(p => p.MaintenanceEquipment)
                            .HasForeignKey(d => d.DepartmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_department_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.MaintenanceEquipment)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_employee_id_fkey");

                        entity.HasOne(d => d.MaintenanceTeam).WithMany(p => p.MaintenanceEquipment)
                            .HasForeignKey(d => d.MaintenanceTeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_maintenance_team_id_fkey");

                        // entity.HasOne(d => d.OwnerUser).WithMany(p => p.MaintenanceEquipmentOwnerUser) .HasForeignKey(d => d.OwnerUserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("maintenance_equipment_owner_user_id_fkey");
                        entity.HasOne(d => d.OwnerUser).WithMany()
                            .HasForeignKey(d => d.OwnerUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_owner_user_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.MaintenanceEquipment) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("maintenance_equipment_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_partner_id_fkey");

                        // entity.HasOne(d => d.TechnicianUser).WithMany(p => p.MaintenanceEquipmentTechnicianUser) .HasForeignKey(d => d.TechnicianUserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("maintenance_equipment_technician_user_id_fkey");
                        entity.HasOne(d => d.TechnicianUser).WithMany()
                            .HasForeignKey(d => d.TechnicianUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_technician_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MaintenanceEquipmentWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("maintenance_equipment_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("maintenance_equipment_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}