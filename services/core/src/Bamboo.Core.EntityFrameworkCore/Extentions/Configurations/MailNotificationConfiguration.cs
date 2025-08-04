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
        public static void ConfigureMailNotification(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailNotification>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_notification_pkey");

                entity.ToTable("mail_notification");

                entity.HasIndex(e => new { e.AuthorId, e.NotificationStatus }, "mail_notification_author_id_notification_status_failure").HasFilter("(notification_status = ANY (ARRAY[('bounce'::character varying)::text, ('exception'::character varying)::text]))");

                entity.HasIndex(e => e.IsRead, "mail_notification_is_read_index");

                entity.HasIndex(e => e.LetterId, "mail_notification_letter_id_index").HasFilter("(letter_id IS NOT NULL)");

                entity.HasIndex(e => e.MailMailId, "mail_notification_mail_mail_id_index");

                entity.HasIndex(e => e.MailMessageId, "mail_notification_mail_message_id_index");

                entity.HasIndex(e => e.NotificationStatus, "mail_notification_notification_status_index");

                entity.HasIndex(e => e.NotificationType, "mail_notification_notification_type_index");

                entity.HasIndex(e => e.ResPartnerId, "mail_notification_res_partner_id_index");

                entity.HasIndex(e => new { e.ResPartnerId, e.IsRead, e.NotificationStatus, e.MailMessageId }, "mail_notification_res_partner_id_is_read_notification_status_ma");

                entity.HasIndex(e => e.SmsId, "mail_notification_sms_id_index").HasFilter("(sms_id IS NOT NULL)");

                entity.HasIndex(e => new { e.MailMessageId, e.ResPartnerId }, "unique_mail_message_id_res_partner_id_if_set")
                    .IsUnique()
                    .HasFilter("(res_partner_id IS NOT NULL)");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AuthorId).HasColumnName("author_id");
                entity.Property(e => e.FailureReason).HasColumnName("failure_reason");
                entity.Property(e => e.FailureType).HasColumnName("failure_type");
                entity.Property(e => e.IsRead).HasColumnName("is_read");
                entity.Property(e => e.LetterId).HasColumnName("letter_id");
                entity.Property(e => e.MailMailId).HasColumnName("mail_mail_id");
                entity.Property(e => e.MailMessageId).HasColumnName("mail_message_id");
                entity.Property(e => e.NotificationStatus).HasColumnName("notification_status");
                entity.Property(e => e.NotificationType).HasColumnName("notification_type");
                entity.Property(e => e.ReadDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("read_date");
                entity.Property(e => e.ResPartnerId).HasColumnName("res_partner_id");
                entity.Property(e => e.SmsId).HasColumnName("sms_id");
                entity.Property(e => e.SmsNumber).HasColumnName("sms_number");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");

                entity.HasOne(d => d.Author).WithMany(p => p.MailNotificationAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_notification_author_id_fkey");

                entity.HasOne(d => d.Letter).WithMany(p => p.MailNotifications)
                    .HasForeignKey(d => d.LetterId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_notification_letter_id_fkey");

                entity.HasOne(d => d.MailMail).WithMany(p => p.MailNotifications)
                    .HasForeignKey(d => d.MailMailId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_notification_mail_mail_id_fkey");

                entity.HasOne(d => d.MailMessage).WithMany(p => p.MailNotifications)
                    .HasForeignKey(d => d.MailMessageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_notification_mail_message_id_fkey");

                entity.HasOne(d => d.ResPartner).WithMany(p => p.MailNotificationResPartners)
                    .HasForeignKey(d => d.ResPartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_notification_res_partner_id_fkey");

                entity.HasOne(d => d.Sms).WithMany(p => p.MailNotifications)
                    .HasForeignKey(d => d.SmsId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_notification_sms_id_fkey");
            });
        }
    }
}