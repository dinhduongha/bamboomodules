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
        public static void ConfigureHomeworkLocationWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HomeworkLocationWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("homework_location_wizard_pkey");

            entity.ToTable("homework_location_wizard");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

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
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Weekly).HasColumnName("weekly");
            entity.Property(e => e.WorkLocationId).HasColumnName("work_location_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HomeworkLocationWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("homework_location_wizard_create_uid_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.HomeworkLocationWizard)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("homework_location_wizard_employee_id_fkey");

            entity.HasOne(d => d.WorkLocation).WithMany(p => p.HomeworkLocationWizard)
                .HasForeignKey(d => d.WorkLocationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("homework_location_wizard_work_location_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HomeworkLocationWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("homework_location_wizard_write_uid_fkey");
            });
        }
    }
}