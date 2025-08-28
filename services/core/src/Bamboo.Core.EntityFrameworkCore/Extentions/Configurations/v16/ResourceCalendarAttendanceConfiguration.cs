using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResourceCalendarAttendance(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResourceCalendarAttendance>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("resource_calendar_attendance_pkey");

                        entity.ToTable("resource_calendar_attendance");

                        entity.HasIndex(e => e.Dayofweek, "resource_calendar_attendance__dayofweek_index");

                        entity.HasIndex(e => e.HourFrom, "resource_calendar_attendance__hour_from_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");
                        entity.Property(e => e.CalendarId).HasColumnName("calendar_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateFrom).HasColumnName("date_from");
                        entity.Property(e => e.DateTo).HasColumnName("date_to");
                        entity.Property(e => e.DayPeriod).HasColumnName("day_period");
                        entity.Property(e => e.Dayofweek).HasColumnName("dayofweek");
                        entity.Property(e => e.DisplayType).HasColumnName("display_type");
                        entity.Property(e => e.DurationDays).HasColumnName("duration_days");
                        entity.Property(e => e.HourFrom).HasColumnName("hour_from");
                        entity.Property(e => e.HourTo).HasColumnName("hour_to");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ResourceId).HasColumnName("resource_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.WeekType).HasColumnName("week_type");
                        entity.Property(e => e.WorkEntryTypeId).HasColumnName("work_entry_type_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Calendar).WithMany(p => p.ResourceCalendarAttendance)
                            .HasForeignKey(d => d.CalendarId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("resource_calendar_attendance_calendar_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResourceCalendarAttendanceCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("resource_calendar_attendance_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_attendance_create_uid_fkey");

                        entity.HasOne(d => d.Resource).WithMany(p => p.ResourceCalendarAttendance)
                            .HasForeignKey(d => d.ResourceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_attendance_resource_id_fkey");

                        entity.HasOne(d => d.WorkEntryType).WithMany(p => p.ResourceCalendarAttendance)
                            .HasForeignKey(d => d.WorkEntryTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_attendance_work_entry_type_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResourceCalendarAttendanceWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("resource_calendar_attendance_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("resource_calendar_attendance_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}