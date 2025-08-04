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
        public static void ConfigureMaintenanceRequest(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaintenanceRequest>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("maintenance_request_pkey");

                entity.ToTable("maintenance_request");

                entity.HasIndex(e => e.EquipmentId, "maintenance_request_equipment_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Archive).HasColumnName("archive");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.CloseDate).HasColumnName("close_date");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Duration).HasColumnName("duration");
                entity.Property(e => e.EmailCc).HasColumnName("email_cc");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
                entity.Property(e => e.KanbanState).HasColumnName("kanban_state");
                entity.Property(e => e.MaintenanceTeamId).HasColumnName("maintenance_team_id");
                entity.Property(e => e.MaintenanceType).HasColumnName("maintenance_type");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OwnerUserId).HasColumnName("owner_user_id");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.RequestDate).HasColumnName("request_date");
                entity.Property(e => e.ScheduleDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("schedule_date");
                entity.Property(e => e.StageId).HasColumnName("stage_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Category).WithMany(p => p.MaintenanceRequests)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_request_category_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_request_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_request_create_uid_fkey");

                entity.HasOne(d => d.Employee).WithMany(p => p.MaintenanceRequests)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_request_employee_id_fkey");

                entity.HasOne(d => d.Equipment).WithMany(p => p.MaintenanceRequests)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("maintenance_request_equipment_id_fkey");

                entity.HasOne(d => d.MaintenanceTeam).WithMany(p => p.MaintenanceRequests)
                    .HasForeignKey(d => d.MaintenanceTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("maintenance_request_maintenance_team_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.MaintenanceRequests)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_request_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.OwnerUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_request_owner_user_id_fkey");

                entity.HasOne(d => d.Stage).WithMany(p => p.MaintenanceRequests)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("maintenance_request_stage_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_request_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_request_write_uid_fkey");
            });
        }
    }
}