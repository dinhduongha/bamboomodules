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
        public static void ConfigureHrLeaveAccrualLevel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrLeaveAccrualLevel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_leave_accrual_level_pkey");

                entity.ToTable("hr_leave_accrual_level");

                entity.HasIndex(e => e.TenantId, "hr_leave_accrual_level_company_id_index");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccrualPlanId).HasColumnName("accrual_plan_id");
                entity.Property(e => e.ActionWithUnusedAccruals).HasColumnName("action_with_unused_accruals");
                entity.Property(e => e.AddedValue).HasColumnName("added_value");
                entity.Property(e => e.AddedValueType).HasColumnName("added_value_type");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.FirstDay).HasColumnName("first_day");
                entity.Property(e => e.FirstMonth).HasColumnName("first_month");
                entity.Property(e => e.FirstMonthDay).HasColumnName("first_month_day");
                entity.Property(e => e.Frequency).HasColumnName("frequency");
                entity.Property(e => e.IsBasedOnWorkedTime).HasColumnName("is_based_on_worked_time");
                entity.Property(e => e.MaximumLeave).HasColumnName("maximum_leave");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.PostponeMaxDays).HasColumnName("postpone_max_days");
                entity.Property(e => e.SecondDay).HasColumnName("second_day");
                entity.Property(e => e.SecondMonth).HasColumnName("second_month");
                entity.Property(e => e.SecondMonthDay).HasColumnName("second_month_day");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.StartCount).HasColumnName("start_count");
                entity.Property(e => e.StartType).HasColumnName("start_type");
                entity.Property(e => e.WeekDay).HasColumnName("week_day");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                entity.Property(e => e.YearlyDay).HasColumnName("yearly_day");
                entity.Property(e => e.YearlyMonth).HasColumnName("yearly_month");

                entity.HasOne(d => d.AccrualPlan).WithMany(p => p.HrLeaveAccrualLevels)
                    .HasForeignKey(d => d.AccrualPlanId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_leave_accrual_level_accrual_plan_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_accrual_level_create_uid_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_accrual_level_parent_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_accrual_level_write_uid_fkey");
            });
        }
    }
}