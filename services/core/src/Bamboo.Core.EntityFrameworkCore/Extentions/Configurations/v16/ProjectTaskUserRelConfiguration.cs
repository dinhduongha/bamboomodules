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
        public static void ConfigureProjectTaskUserRel(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectTaskUserRel>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_task_user_rel_pkey");

            entity.ToTable("project_task_user_rel");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.TaskId, "project_task_user_rel__task_id_index");

            entity.HasIndex(e => e.UserId, "project_task_user_rel__user_id_index");

            entity.HasIndex(e => new { e.TaskId, e.UserId }, "project_task_user_rel_project_personal_stage_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.StageId).HasColumnName("stage_id");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectTaskUserRelCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("project_task_user_rel_create_uid_fkey");

            entity.HasOne(d => d.Stage).WithMany(p => p.ProjectTaskUserRel)
                .HasForeignKey(d => d.StageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("project_task_user_rel_stage_id_fkey");

            entity.HasOne(d => d.Task).WithMany(p => p.ProjectTaskUserRel)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("project_task_user_rel_task_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.ProjectTaskUserRelUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("project_task_user_rel_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectTaskUserRelWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("project_task_user_rel_write_uid_fkey");
            });
        }
    }
}
