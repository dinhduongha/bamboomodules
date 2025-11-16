using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccrualPlanId).HasColumnName("accrual_plan_id");
                        entity.Property(e => e.AccrualValidity).HasColumnName("accrual_validity");
                        entity.Property(e => e.AccrualValidityCount).HasColumnName("accrual_validity_count");
                        entity.Property(e => e.AccrualValidityType).HasColumnName("accrual_validity_type");
                        entity.Property(e => e.ActionWithUnusedAccruals).HasColumnName("action_with_unused_accruals");
                        entity.Property(e => e.AddedValue).HasColumnName("added_value");
                        entity.Property(e => e.AddedValueType).HasColumnName("added_value_type");
                        entity.Property(e => e.CapAccruedTime).HasColumnName("cap_accrued_time");
                        entity.Property(e => e.CapAccruedTimeYearly).HasColumnName("cap_accrued_time_yearly");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.FirstDay).HasColumnName("first_day");
                        entity.Property(e => e.FirstMonth).HasColumnName("first_month");
                        entity.Property(e => e.FirstMonthDay).HasColumnName("first_month_day");
                        entity.Property(e => e.Frequency).HasColumnName("frequency");
                        entity.Property(e => e.FrequencyHourlySource).HasColumnName("frequency_hourly_source");
                        entity.Property(e => e.MaximumLeave).HasColumnName("maximum_leave");
                        entity.Property(e => e.MaximumLeaveYearly).HasColumnName("maximum_leave_yearly");
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

                        entity.HasOne(d => d.AccrualPlan).WithMany(p => p.HrLeaveAccrualLevel)
                            .HasForeignKey(d => d.AccrualPlanId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_leave_accrual_level_accrual_plan_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrLeaveAccrualLevelCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_accrual_level_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_accrual_level_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrLeaveAccrualLevelWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_leave_accrual_level_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_leave_accrual_level_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}