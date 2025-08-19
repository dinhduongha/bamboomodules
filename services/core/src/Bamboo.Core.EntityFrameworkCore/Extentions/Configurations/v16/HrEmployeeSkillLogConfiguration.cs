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
        public static void ConfigureHrEmployeeSkillLog(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrEmployeeSkillLog>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_employee_skill_log_pkey");

            entity.ToTable("hr_employee_skill_log");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.EmployeeId, e.DepartmentId, e.SkillId, e.Date }, "hr_employee_skill_log__unique_skill_log").IsUnique();

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
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.LevelProgress).HasColumnName("level_progress");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.SkillLevelId).HasColumnName("skill_level_id");
            entity.Property(e => e.SkillTypeId).HasColumnName("skill_type_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrEmployeeSkillLogCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_employee_skill_log_create_uid_fkey");

            entity.HasOne(d => d.Department).WithMany(p => p.HrEmployeeSkillLog)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_employee_skill_log_department_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrEmployeeSkillLog)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hr_employee_skill_log_employee_id_fkey");

            entity.HasOne(d => d.Skill).WithMany(p => p.HrEmployeeSkillLog)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hr_employee_skill_log_skill_id_fkey");

            entity.HasOne(d => d.SkillLevel).WithMany(p => p.HrEmployeeSkillLog)
                .HasForeignKey(d => d.SkillLevelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hr_employee_skill_log_skill_level_id_fkey");

            entity.HasOne(d => d.SkillType).WithMany(p => p.HrEmployeeSkillLog)
                .HasForeignKey(d => d.SkillTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hr_employee_skill_log_skill_type_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrEmployeeSkillLogWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_employee_skill_log_write_uid_fkey");
            });
        }
    }
}