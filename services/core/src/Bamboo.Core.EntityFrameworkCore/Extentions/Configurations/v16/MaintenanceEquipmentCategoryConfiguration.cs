using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMaintenanceEquipmentCategory(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MaintenanceEquipmentCategory>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("maintenance_equipment_category_pkey");

            entity.ToTable("maintenance_equipment_category");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AliasId).HasColumnName("alias_id");
            entity.Property(e => e.Color).HasColumnName("color");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.EquipmentPropertiesDefinition)
                .HasColumnType("jsonb")
                .HasColumnName("equipment_properties_definition");
            entity.Property(e => e.Fold).HasColumnName("fold");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasColumnType("jsonb")
                .HasColumnName("note");
            entity.Property(e => e.TechnicianUserId).HasColumnName("technician_user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Alias).WithMany(p => p.MaintenanceEquipmentCategory)
                .HasForeignKey(d => d.AliasId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("maintenance_equipment_category_alias_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.MaintenanceEquipmentCategory)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("maintenance_equipment_category_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MaintenanceEquipmentCategoryCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("maintenance_equipment_category_create_uid_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.MaintenanceEquipmentCategory)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("maintenance_equipment_category_message_main_attachment_id_fkey");

            entity.HasOne(d => d.TechnicianUser).WithMany()
                .HasForeignKey(d => d.TechnicianUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("maintenance_equipment_category_technician_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MaintenanceEquipmentCategoryWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("maintenance_equipment_category_write_uid_fkey");
            });
        }
    }
}
