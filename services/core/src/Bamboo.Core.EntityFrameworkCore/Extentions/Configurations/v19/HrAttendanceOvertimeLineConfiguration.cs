using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrAttendanceOvertimeLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrAttendanceOvertimeLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_attendance_overtime_line_pkey");

                        entity.ToTable("hr_attendance_overtime_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Date, "hr_attendance_overtime_line__date_index");

                        entity.HasIndex(e => e.EmployeeId, "hr_attendance_overtime_line__employee_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AmountRate).HasColumnName("amount_rate");
                        entity.Property(e => e.CompensableAsLeave).HasColumnName("compensable_as_leave");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.Duration).HasColumnName("duration");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.ManualDuration).HasColumnName("manual_duration");
                        entity.Property(e => e.Status).HasColumnName("status");
                        entity.Property(e => e.TimeStart)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("time_start");
                        entity.Property(e => e.TimeStop)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("time_stop");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrAttendanceOvertimeLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_attendance_overtime_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_attendance_overtime_line_create_uid_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrAttendanceOvertimeLine)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_attendance_overtime_line_employee_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrAttendanceOvertimeLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_attendance_overtime_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_attendance_overtime_line_write_uid_fkey");

                        // entity.HasMany(d => d.HrAttendanceOvertimeRule).WithMany(p => p.HrAttendanceOvertimeLine)
                        entity.HasMany(d => d.HrAttendanceOvertimeRule).WithMany(p => p.HrAttendanceOvertimeLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrAttendanceOvertimeLineHrAttendanceOvertimeRuleRel",
                                r => r.HasOne<HrAttendanceOvertimeRule>().WithMany()
                                    .HasForeignKey("HrAttendanceOvertimeRuleId")
                                    .HasConstraintName("hr_attendance_overtime_line_h_hr_attendance_overtime_rule__fkey"),
                                l => l.HasOne<HrAttendanceOvertimeLine>().WithMany()
                                    .HasForeignKey("HrAttendanceOvertimeLineId")
                                    .HasConstraintName("hr_attendance_overtime_line_h_hr_attendance_overtime_line__fkey"),
                                j =>
                                {
                                    j.HasKey("HrAttendanceOvertimeLineId", "HrAttendanceOvertimeRuleId").HasName("hr_attendance_overtime_line_hr_attendance_overtime_rule_re_pkey");
                                    j.ToTable("hr_attendance_overtime_line_hr_attendance_overtime_rule_rel");
                                    j.HasIndex(new[] { "HrAttendanceOvertimeRuleId", "HrAttendanceOvertimeLineId" }, "hr_attendance_overtime_line_h_hr_attendance_overtime_rule_i_idx");
                                    j.IndexerProperty<Guid>("HrAttendanceOvertimeLineId").HasColumnName("hr_attendance_overtime_line_id");
                                    j.IndexerProperty<Guid>("HrAttendanceOvertimeRuleId").HasColumnName("hr_attendance_overtime_rule_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}