using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrAttendanceOvertimeRule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrAttendanceOvertimeRule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_attendance_overtime_rule_pkey");

                        entity.ToTable("hr_attendance_overtime_rule");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.RulesetId, "hr_attendance_overtime_rule__ruleset_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AmountRate).HasColumnName("amount_rate");
                        entity.Property(e => e.BaseOff).HasColumnName("base_off");
                        entity.Property(e => e.CompensableAsLeave).HasColumnName("compensable_as_leave");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.EmployeeTolerance).HasColumnName("employee_tolerance");
                        entity.Property(e => e.EmployerTolerance).HasColumnName("employer_tolerance");
                        entity.Property(e => e.ExpectedHours).HasColumnName("expected_hours");
                        entity.Property(e => e.ExpectedHoursFromContract).HasColumnName("expected_hours_from_contract");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Paid).HasColumnName("paid");
                        entity.Property(e => e.QuantityPeriod).HasColumnName("quantity_period");
                        entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                        entity.Property(e => e.RulesetId).HasColumnName("ruleset_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TimingStart).HasColumnName("timing_start");
                        entity.Property(e => e.TimingStop).HasColumnName("timing_stop");
                        entity.Property(e => e.TimingType).HasColumnName("timing_type");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrAttendanceOvertimeRuleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_attendance_overtime_rule_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_attendance_overtime_rule_create_uid_fkey");

                        entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.HrAttendanceOvertimeRule)
                            .HasForeignKey(d => d.ResourceCalendarId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_attendance_overtime_rule_resource_calendar_id_fkey");

                        entity.HasOne(d => d.Ruleset).WithMany(p => p.HrAttendanceOvertimeRule)
                            .HasForeignKey(d => d.RulesetId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_attendance_overtime_rule_ruleset_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrAttendanceOvertimeRuleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_attendance_overtime_rule_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_attendance_overtime_rule_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}