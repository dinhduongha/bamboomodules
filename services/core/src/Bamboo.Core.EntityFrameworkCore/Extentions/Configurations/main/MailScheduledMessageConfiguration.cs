using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailScheduledMessage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailScheduledMessage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_scheduled_message_pkey");

                        entity.ToTable("mail_scheduled_message");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AuthorId).HasColumnName("author_id");
                        entity.Property(e => e.Body).HasColumnName("body");
                        entity.Property(e => e.CompositionCommentOption).HasColumnName("composition_comment_option");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsNote).HasColumnName("is_note");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.NotificationParameters).HasColumnName("notification_parameters");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.ScheduledDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("scheduled_date");
                        entity.Property(e => e.SendContext)
                            .HasColumnType("jsonb")
                            .HasColumnName("send_context");
                        entity.Property(e => e.Subject).HasColumnName("subject");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Author).WithMany(p => p.MailScheduledMessage) .HasForeignKey(d => d.AuthorId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mail_scheduled_message_author_id_fkey");
                        entity.HasOne(d => d.Author).WithMany()
                            .HasForeignKey(d => d.AuthorId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mail_scheduled_message_author_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailScheduledMessageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_scheduled_message_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_scheduled_message_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailScheduledMessageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_scheduled_message_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_scheduled_message_write_uid_fkey");

                        // entity.HasMany(d => d.Attachment).WithMany(p => p.ScheduledMessage)
                        entity.HasMany(d => d.Attachment).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ScheduledMessageAttachmentRel",
                                r => r.HasOne<IrAttachment>().WithMany()
                                    .HasForeignKey("AttachmentId")
                                    .HasConstraintName("scheduled_message_attachment_rel_attachment_id_fkey"),
                                l => l.HasOne<MailScheduledMessage>().WithMany()
                                    .HasForeignKey("ScheduledMessageId")
                                    .HasConstraintName("scheduled_message_attachment_rel_scheduled_message_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ScheduledMessageId", "AttachmentId").HasName("scheduled_message_attachment_rel_pkey");
                                    j.ToTable("scheduled_message_attachment_rel");
                                    j.HasIndex(new[] { "AttachmentId", "ScheduledMessageId" }, "scheduled_message_attachment__attachment_id_scheduled_messa_idx");
                                    j.IndexerProperty<Guid>("ScheduledMessageId").HasColumnName("scheduled_message_id");
                                    j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                                });

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.MailScheduledMessageNavigation)
                        entity.HasMany(d => d.ResPartner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "MailScheduledMessageResPartnerRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("mail_scheduled_message_res_partner_rel_res_partner_id_fkey"),
                                l => l.HasOne<MailScheduledMessage>().WithMany()
                                    .HasForeignKey("MailScheduledMessageId")
                                    .HasConstraintName("mail_scheduled_message_res_partn_mail_scheduled_message_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MailScheduledMessageId", "ResPartnerId").HasName("mail_scheduled_message_res_partner_rel_pkey");
                                    j.ToTable("mail_scheduled_message_res_partner_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "MailScheduledMessageId" }, "mail_scheduled_message_res_pa_res_partner_id_mail_scheduled_idx");
                                    j.IndexerProperty<Guid>("MailScheduledMessageId").HasColumnName("mail_scheduled_message_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}