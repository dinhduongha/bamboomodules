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
        public static void ConfigureSmsTracker(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmsTracker>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sms_tracker_pkey");

                entity.ToTable("sms_tracker");

                entity.HasIndex(e => e.SmsUuid, "sms_tracker_sms_uuid_unique").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.MailNotificationId).HasColumnName("mail_notification_id");
                entity.Property(e => e.MailingTraceId).HasColumnName("mailing_trace_id");
                entity.Property(e => e.SmsUuid).HasColumnName("sms_uuid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_tracker_create_uid_fkey");

                entity.HasOne(d => d.MailNotification).WithMany()
                    .HasForeignKey(d => d.MailNotificationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sms_tracker_mail_notification_id_fkey");

                entity.HasOne(d => d.MailingTrace).WithMany(p => p.SmsTrackers)
                    .HasForeignKey(d => d.MailingTraceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sms_tracker_mailing_trace_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sms_tracker_write_uid_fkey");
            });
        }
    }
}