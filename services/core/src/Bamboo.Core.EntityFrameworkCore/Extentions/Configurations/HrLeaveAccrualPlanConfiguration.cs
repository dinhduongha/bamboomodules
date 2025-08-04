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
        public static void ConfigureHrLeaveAccrualPlan(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrLeaveAccrualPlan>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_leave_accrual_plan_pkey");

                entity.ToTable("hr_leave_accrual_plan");

                entity.HasIndex(e => e.TenantId, "hr_leave_accrual_plan_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.TimeOffTypeId).HasColumnName("time_off_type_id");
                entity.Property(e => e.TransitionMode).HasColumnName("transition_mode");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_accrual_plan_create_uid_fkey");

                entity.HasOne(d => d.TimeOffType).WithMany(p => p.HrLeaveAccrualPlans)
                    .HasForeignKey(d => d.TimeOffTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_accrual_plan_time_off_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_accrual_plan_write_uid_fkey");
            });
        }
    }
}