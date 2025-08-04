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
        public static void ConfigureHrDepartment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrDepartment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_department_pkey");

                entity.ToTable("hr_department");

                entity.HasIndex(e => e.TenantId, "hr_department_company_id_index");

                entity.HasIndex(e => e.ParentId, "hr_department_parent_id_index");

                entity.HasIndex(e => e.ParentPath, "hr_department_parent_path_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CompleteName).HasColumnName("complete_name");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                entity.Property(e => e.MasterDepartmentId).HasColumnName("master_department_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_department_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_department_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_department_manager_id_fkey");

                entity.HasOne(d => d.MasterDepartment).WithMany(p => p.InverseMasterDepartment)
                    .HasForeignKey(d => d.MasterDepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_department_master_department_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrDepartments)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_department_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_department_parent_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_department_write_uid_fkey");
            });
        }
    }
}