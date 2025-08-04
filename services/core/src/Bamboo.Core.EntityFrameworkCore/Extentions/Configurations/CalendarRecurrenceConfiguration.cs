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
        public static void ConfigureCalendarRecurrence(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalendarRecurrence>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("calendar_recurrence_pkey");

                entity.ToTable("calendar_recurrence");

                entity.HasIndex(e => e.TenantId, "calendar_recurrence_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.BaseEventId).HasColumnName("base_event_id");
                entity.Property(e => e.Byday).HasColumnName("byday");
                entity.Property(e => e.Count).HasColumnName("count");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Day).HasColumnName("day");
                entity.Property(e => e.EndType).HasColumnName("end_type");
                entity.Property(e => e.EventTz).HasColumnName("event_tz");
                entity.Property(e => e.Fri).HasColumnName("fri");
                entity.Property(e => e.Interval).HasColumnName("interval");
                entity.Property(e => e.Mon).HasColumnName("mon");
                entity.Property(e => e.MonthBy).HasColumnName("month_by");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Rrule).HasColumnName("rrule");
                entity.Property(e => e.RruleType).HasColumnName("rrule_type");
                entity.Property(e => e.Sat).HasColumnName("sat");
                entity.Property(e => e.Sun).HasColumnName("sun");
                entity.Property(e => e.Thu).HasColumnName("thu");
                entity.Property(e => e.Tue).HasColumnName("tue");
                entity.Property(e => e.Until).HasColumnName("until");
                entity.Property(e => e.Wed).HasColumnName("wed");
                entity.Property(e => e.Weekday).HasColumnName("weekday");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.BaseEvent).WithMany(p => p.CalendarRecurrences)
                    .HasForeignKey(d => d.BaseEventId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_recurrence_base_event_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_recurrence_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_recurrence_write_uid_fkey");
            });
        }
    }
}