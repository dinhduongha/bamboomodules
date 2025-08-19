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
        public static void ConfigureHrLeaveAccrualPlan(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrLeaveAccrualPlan>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_leave_accrual_plan_pkey");

            entity.ToTable("hr_leave_accrual_plan");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccruedGainTime).HasColumnName("accrued_gain_time");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AddedValueType).HasColumnName("added_value_type");
            entity.Property(e => e.CarryoverDate).HasColumnName("carryover_date");
            entity.Property(e => e.CarryoverDay).HasColumnName("carryover_day");
            entity.Property(e => e.CarryoverMonth).HasColumnName("carryover_month");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.IsBasedOnWorkedTime).HasColumnName("is_based_on_worked_time");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.TimeOffTypeId).HasColumnName("time_off_type_id");
            entity.Property(e => e.TransitionMode).HasColumnName("transition_mode");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.HrLeaveAccrualPlan)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_accrual_plan_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrLeaveAccrualPlanCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_accrual_plan_create_uid_fkey");

            entity.HasOne(d => d.TimeOffType).WithMany(p => p.HrLeaveAccrualPlan)
                .HasForeignKey(d => d.TimeOffTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_accrual_plan_time_off_type_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrLeaveAccrualPlanWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_leave_accrual_plan_write_uid_fkey");
            });
        }
    }
}
