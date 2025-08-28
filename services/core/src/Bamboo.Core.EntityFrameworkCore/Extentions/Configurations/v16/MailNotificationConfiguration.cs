using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsRead, "mail_notification__is_read_index");

                        entity.HasIndex(e => e.LetterId, "mail_notification__letter_id_index").HasFilter("(letter_id IS NOT NULL)");

                        entity.HasIndex(e => e.MailMailId, "mail_notification__mail_mail_id_index");

                        entity.HasIndex(e => e.MailMessageId, "mail_notification__mail_message_id_index");

                        entity.HasIndex(e => e.NotificationStatus, "mail_notification__notification_status_index");

                        entity.HasIndex(e => e.NotificationType, "mail_notification__notification_type_index");

                        entity.HasIndex(e => e.ResPartnerId, "mail_notification__res_partner_id_index");

                        entity.HasIndex(e => e.SmsIdInt, "mail_notification__sms_id_int_index").HasFilter("(sms_id_int IS NOT NULL)");

                        entity.HasIndex(e => new { e.AuthorId, e.NotificationStatus }, "mail_notification_author_id_notification_status_failure").HasFilter("(notification_status = ANY (ARRAY[('bounce'::character varying)::text, ('exception'::character varying)::text]))");

                        entity.HasIndex(e => new { e.ResPartnerId, e.IsRead, e.NotificationStatus, e.MailMessageId }, "mail_notification_res_partner_id_is_read_notification_status_ma");

                        entity.HasIndex(e => new { e.MailMessageId, e.ResPartnerId }, "unique_mail_message_id_res_partner_id_if_set")
                            .IsUnique()
                            .HasFilter("(res_partner_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
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
                        entity.Property(e => e.SmsIdInt).HasColumnName("sms_id_int");
                        entity.Property(e => e.SmsNumber).HasColumnName("sms_number");

                        // entity.HasOne(d => d.Author).WithMany(p => p.MailNotificationAuthor) .HasForeignKey(d => d.AuthorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_notification_author_id_fkey");
                        entity.HasOne(d => d.Author).WithMany()
                            .HasForeignKey(d => d.AuthorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_notification_author_id_fkey");

                        entity.HasOne(d => d.Letter).WithMany(p => p.MailNotification)
                            .HasForeignKey(d => d.LetterId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_notification_letter_id_fkey");

                        entity.HasOne(d => d.MailMail).WithMany(p => p.MailNotification)
                            .HasForeignKey(d => d.MailMailId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_notification_mail_mail_id_fkey");

                        entity.HasOne(d => d.MailMessage).WithMany(p => p.MailNotification)
                            .HasForeignKey(d => d.MailMessageId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_notification_mail_message_id_fkey");

                        // entity.HasOne(d => d.ResPartner).WithMany(p => p.MailNotificationResPartner) .HasForeignKey(d => d.ResPartnerId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("mail_notification_res_partner_id_fkey");
                        entity.HasOne(d => d.ResPartner).WithMany()
                            .HasForeignKey(d => d.ResPartnerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_notification_res_partner_id_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}