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
        public static void ConfigureCalendarAlarm(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CalendarAlarm>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("calendar_alarm_pkey");

            entity.ToTable("calendar_alarm");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AlarmType).HasColumnName("alarm_type");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.Interval).HasColumnName("interval");
            entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.SmsNotifyResponsible).HasColumnName("sms_notify_responsible");
            entity.Property(e => e.SmsTemplateId).HasColumnName("sms_template_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.CalendarAlarmCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_alarm_create_uid_fkey");

            entity.HasOne(d => d.MailTemplate).WithMany(p => p.CalendarAlarm)
                .HasForeignKey(d => d.MailTemplateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_alarm_mail_template_id_fkey");

            entity.HasOne(d => d.SmsTemplate).WithMany(p => p.CalendarAlarm)
                .HasForeignKey(d => d.SmsTemplateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_alarm_sms_template_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.CalendarAlarmWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_alarm_write_uid_fkey");
            });
        }
    }
}
