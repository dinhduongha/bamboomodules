using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailResendMessage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailResendMessage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_resend_message_pkey");

                        entity.ToTable("mail_resend_message");

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
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailResendMessageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_resend_message_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_resend_message_create_uid_fkey");

                        entity.HasOne(d => d.MailMessage).WithMany(p => p.MailResendMessage)
                            .HasForeignKey(d => d.MailMessageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_resend_message_mail_message_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailResendMessageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_resend_message_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_resend_message_write_uid_fkey");

                        // entity.HasMany(d => d.MailNotification).WithMany(p => p.MailResendMessage)
                        entity.HasMany(d => d.MailNotification).WithMany(p => p.MailResendMessage)
                            .UsingEntity<Dictionary<string, object>>(
                                "MailNotificationMailResendMessageRel",
                                r => r.HasOne<MailNotification>().WithMany()
                                    .HasForeignKey("MailNotificationId")
                                    .HasConstraintName("mail_notification_mail_resend_message_mail_notification_id_fkey"),
                                l => l.HasOne<MailResendMessage>().WithMany()
                                    .HasForeignKey("MailResendMessageId")
                                    .HasConstraintName("mail_notification_mail_resend_messa_mail_resend_message_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MailResendMessageId", "MailNotificationId").HasName("mail_notification_mail_resend_message_rel_pkey");
                                    j.ToTable("mail_notification_mail_resend_message_rel");
                                    j.HasIndex(new[] { "MailNotificationId", "MailResendMessageId" }, "mail_notification_mail_resend_mail_notification_id_mail_res_idx");
                                    j.IndexerProperty<Guid>("MailResendMessageId").HasColumnName("mail_resend_message_id");
                                    j.IndexerProperty<Guid>("MailNotificationId").HasColumnName("mail_notification_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}