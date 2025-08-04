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
        public static void ConfigureResourceCalendarAttendance(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceCalendarAttendance>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("resource_calendar_attendance_pkey");

                entity.ToTable("resource_calendar_attendance");

                entity.HasIndex(e => e.TenantId, "hr_resource_calendar_attendance_company_id_index");

                entity.HasIndex(e => e.Dayofweek, "resource_calendar_attendance_dayofweek_index");

                entity.HasIndex(e => e.HourFrom, "resource_calendar_attendance_hour_from_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CalendarId).HasColumnName("calendar_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateFrom).HasColumnName("date_from");
                entity.Property(e => e.DateTo).HasColumnName("date_to");
                entity.Property(e => e.DayPeriod).HasColumnName("day_period");
                entity.Property(e => e.Dayofweek).HasColumnName("dayofweek");
                entity.Property(e => e.DisplayType).HasColumnName("display_type");
                entity.Property(e => e.HourFrom).HasColumnName("hour_from");
                entity.Property(e => e.HourTo).HasColumnName("hour_to");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.ResourceId).HasColumnName("resource_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.WeekType).HasColumnName("week_type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Calendar).WithMany(p => p.ResourceCalendarAttendances)
                    .HasForeignKey(d => d.CalendarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("resource_calendar_attendance_calendar_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("resource_calendar_attendance_create_uid_fkey");

                entity.HasOne(d => d.Resource).WithMany(p => p.ResourceCalendarAttendances)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("resource_calendar_attendance_resource_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("resource_calendar_attendance_write_uid_fkey");
            });
        }
    }
}