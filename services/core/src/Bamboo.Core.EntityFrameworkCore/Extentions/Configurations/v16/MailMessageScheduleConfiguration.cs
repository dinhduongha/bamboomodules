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
        public static void ConfigureMailMessageSchedule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailMessageSchedule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_message_schedule_pkey");

            entity.ToTable("mail_message_schedule");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MailMessageId).HasColumnName("mail_message_id");
            entity.Property(e => e.NotificationParameters).HasColumnName("notification_parameters");
            entity.Property(e => e.ScheduledDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_datetime");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MailMessageScheduleCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_message_schedule_create_uid_fkey");

            entity.HasOne(d => d.MailMessage).WithMany(p => p.MailMessageSchedule)
                .HasForeignKey(d => d.MailMessageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mail_message_schedule_mail_message_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MailMessageScheduleWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mail_message_schedule_write_uid_fkey");
            });
        }
    }
}