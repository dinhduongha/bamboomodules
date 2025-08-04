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
        public static void ConfigureMaintenanceEquipment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaintenanceEquipment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("maintenance_equipment_pkey");

                entity.ToTable("maintenance_equipment");

                entity.HasIndex(e => e.TenantId, "maintenance_equipment_company_idx_index");

                entity.HasIndex(e => new { e.TenantId, e.SerialNo }, "maintenance_equipment_serial_no").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AssignDate).HasColumnName("assign_date");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Cost).HasColumnName("cost");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.EffectiveDate).HasColumnName("effective_date");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.EquipmentAssignTo).HasColumnName("equipment_assign_to");
                entity.Property(e => e.Location).HasColumnName("location");
                entity.Property(e => e.MaintenanceCount).HasColumnName("maintenance_count");
                entity.Property(e => e.MaintenanceDuration).HasColumnName("maintenance_duration");
                entity.Property(e => e.MaintenanceOpenCount).HasColumnName("maintenance_open_count");
                entity.Property(e => e.MaintenanceTeamId).HasColumnName("maintenance_team_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Model).HasColumnName("model");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.NextActionDate).HasColumnName("next_action_date");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.OwnerUserId).HasColumnName("owner_user_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PartnerRef).HasColumnName("partner_ref");
                entity.Property(e => e.Period).HasColumnName("period");
                entity.Property(e => e.ScrapDate).HasColumnName("scrap_date");
                entity.Property(e => e.SerialNo).HasColumnName("serial_no");
                entity.Property(e => e.TechnicianUserId).HasColumnName("technician_user_id");
                entity.Property(e => e.WarrantyDate).HasColumnName("warranty_date");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Category).WithMany(p => p.MaintenanceEquipments)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_category_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_create_uid_fkey");

                entity.HasOne(d => d.Department).WithMany(p => p.MaintenanceEquipments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_department_id_fkey");

                entity.HasOne(d => d.Employee).WithMany(p => p.MaintenanceEquipments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_employee_id_fkey");

                entity.HasOne(d => d.MaintenanceTeam).WithMany(p => p.MaintenanceEquipments)
                    .HasForeignKey(d => d.MaintenanceTeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_maintenance_team_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.MaintenanceEquipments)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.OwnerUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_owner_user_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_partner_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.TechnicianUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_technician_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_write_uid_fkey");
            });
        }
    }
}