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
        public static void ConfigureSmsResendRecipient(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SmsResendRecipient>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("sms_resend_recipient_pkey");

            entity.ToTable("sms_resend_recipient");

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
            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.PartnerName).HasColumnName("partner_name");
            entity.Property(e => e.Resend).HasColumnName("resend");
            entity.Property(e => e.SmsNumber).HasColumnName("sms_number");
            entity.Property(e => e.SmsResendId).HasColumnName("sms_resend_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SmsResendRecipientCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sms_resend_recipient_create_uid_fkey");

            entity.HasOne(d => d.Notification).WithMany(p => p.SmsResendRecipient)
                .HasForeignKey(d => d.NotificationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sms_resend_recipient_notification_id_fkey");

            entity.HasOne(d => d.SmsResend).WithMany(p => p.SmsResendRecipient)
                .HasForeignKey(d => d.SmsResendId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("sms_resend_recipient_sms_resend_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SmsResendRecipientWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sms_resend_recipient_write_uid_fkey");
            });
        }
    }
}