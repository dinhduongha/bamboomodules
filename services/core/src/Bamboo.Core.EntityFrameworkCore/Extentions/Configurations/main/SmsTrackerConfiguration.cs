using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.MailNotificationId, "sms_tracker__mail_notification_id_index").HasFilter("(mail_notification_id IS NOT NULL)");

                        entity.HasIndex(e => e.MailingTraceId, "sms_tracker__mailing_trace_id_index").HasFilter("(mailing_trace_id IS NOT NULL)");

                        entity.HasIndex(e => e.SmsUuid, "sms_tracker_sms_uuid_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.MailNotificationId).HasColumnName("mail_notification_id");
                        entity.Property(e => e.MailingTraceId).HasColumnName("mailing_trace_id");
                        entity.Property(e => e.SmsTwilioSid).HasColumnName("sms_twilio_sid");
                        entity.Property(e => e.SmsUuid).HasColumnName("sms_uuid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SmsTrackerCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sms_tracker_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_tracker_create_uid_fkey");

                        entity.HasOne(d => d.MailNotification).WithMany(p => p.SmsTracker)
                            .HasForeignKey(d => d.MailNotificationId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("sms_tracker_mail_notification_id_fkey");

                        entity.HasOne(d => d.MailingTrace).WithMany(p => p.SmsTracker)
                            .HasForeignKey(d => d.MailingTraceId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("sms_tracker_mailing_trace_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SmsTrackerWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("sms_tracker_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("sms_tracker_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}