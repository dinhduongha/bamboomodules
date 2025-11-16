using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailMessage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailMessage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_message_pkey");

                        entity.ToTable("mail_message");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AuthorId, "mail_message__author_id_index");

                        entity.HasIndex(e => e.MailActivityTypeId, "mail_message__mail_activity_type_id_index").HasFilter("(mail_activity_type_id IS NOT NULL)");

                        entity.HasIndex(e => e.MessageId, "mail_message__message_id_index");

                        entity.HasIndex(e => e.ParentId, "mail_message__parent_id_index").HasFilter("(parent_id IS NOT NULL)");

                        entity.HasIndex(e => e.SubtypeId, "mail_message__subtype_id_index");

                        entity.HasIndex(e => new { e.Date, e.ResId, e.Id }, "mail_message_date_res_id_id_for_burndown_chart").HasFilter("((model = 'project.task'::text) AND (message_type = 'notification'::text))");

                        entity.HasIndex(e => new { e.Model, e.ResId, e.Id }, "mail_message_model_res_id_id_idx");

                        entity.HasIndex(e => new { e.Model, e.ResId }, "mail_message_model_res_id_idx");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AuthorGuestId).HasColumnName("author_guest_id");
                        entity.Property(e => e.AuthorId).HasColumnName("author_id");
                        entity.Property(e => e.Body).HasColumnName("body");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date");
                        entity.Property(e => e.EmailAddSignature).HasColumnName("email_add_signature");
                        entity.Property(e => e.EmailFrom).HasColumnName("email_from");
                        entity.Property(e => e.EmailLayoutXmlid).HasColumnName("email_layout_xmlid");
                        entity.Property(e => e.IncomingEmailCc).HasColumnName("incoming_email_cc");
                        entity.Property(e => e.IncomingEmailTo).HasColumnName("incoming_email_to");
                        entity.Property(e => e.IsInternal).HasColumnName("is_internal");
                        entity.Property(e => e.MailActivityTypeId).HasColumnName("mail_activity_type_id");
                        entity.Property(e => e.MailServerId).HasColumnName("mail_server_id");
                        entity.Property(e => e.MessageId).HasColumnName("message_id");
                        entity.Property(e => e.MessageType).HasColumnName("message_type");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.OutgoingEmailTo).HasColumnName("outgoing_email_to");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.PinnedAt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("pinned_at");
                        entity.Property(e => e.RecordAliasDomainId).HasColumnName("record_alias_domain_id");
                        entity.Property(e => e.RecordCompanyId).HasColumnName("record_company_id");
                        entity.Property(e => e.ReplyTo).HasColumnName("reply_to");
                        entity.Property(e => e.ReplyToForceNew).HasColumnName("reply_to_force_new");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.Subject).HasColumnName("subject");
                        entity.Property(e => e.SubtypeId).HasColumnName("subtype_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AuthorGuest).WithMany(p => p.MailMessage)
                            .HasForeignKey(d => d.AuthorGuestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_author_guest_id_fkey");

                        // entity.HasOne(d => d.Author).WithMany(p => p.MailMessage) .HasForeignKey(d => d.AuthorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_message_author_id_fkey");
                        entity.HasOne(d => d.Author).WithMany()
                            .HasForeignKey(d => d.AuthorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_author_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailMessageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_message_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_create_uid_fkey");

                        entity.HasOne(d => d.MailActivityType).WithMany(p => p.MailMessage)
                            .HasForeignKey(d => d.MailActivityTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_mail_activity_type_id_fkey");

                        entity.HasOne(d => d.MailServer).WithMany(p => p.MailMessage)
                            .HasForeignKey(d => d.MailServerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_mail_server_id_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_parent_id_fkey");

                        entity.HasOne(d => d.RecordAliasDomain).WithMany(p => p.MailMessage)
                            .HasForeignKey(d => d.RecordAliasDomainId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_record_alias_domain_id_fkey");

                        // entity.HasOne(d => d.RecordCompany).WithMany(p => p.MailMessage) .HasForeignKey(d => d.RecordCompanyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_message_record_company_id_fkey");
                        entity.HasOne(d => d.RecordCompany).WithMany()
                            .HasForeignKey(d => d.RecordCompanyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_record_company_id_fkey");

                        entity.HasOne(d => d.Subtype).WithMany(p => p.MailMessage)
                            .HasForeignKey(d => d.SubtypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_subtype_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailMessageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_message_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_message_write_uid_fkey");

                        // entity.HasMany(d => d.Attachment).WithMany(p => p.Message)
                        entity.HasMany(d => d.Attachment).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "MessageAttachmentRel",
                                r => r.HasOne<IrAttachment>().WithMany()
                                    .HasForeignKey("AttachmentId")
                                    .HasConstraintName("message_attachment_rel_attachment_id_fkey"),
                                l => l.HasOne<MailMessage>().WithMany()
                                    .HasForeignKey("MessageId")
                                    .HasConstraintName("message_attachment_rel_message_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MessageId", "AttachmentId").HasName("message_attachment_rel_pkey");
                                    j.ToTable("message_attachment_rel");
                                    j.HasIndex(new[] { "AttachmentId", "MessageId" }, "message_attachment_rel_attachment_id_message_id_idx");
                                    j.IndexerProperty<Guid>("MessageId").HasColumnName("message_id");
                                    j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                                });

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.MailMessageNavigation)
                        entity.HasMany(d => d.ResPartner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "MailMessageResPartnerRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("mail_message_res_partner_rel_res_partner_id_fkey"),
                                l => l.HasOne<MailMessage>().WithMany()
                                    .HasForeignKey("MailMessageId")
                                    .HasConstraintName("mail_message_res_partner_rel_mail_message_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MailMessageId", "ResPartnerId").HasName("mail_message_res_partner_rel_pkey");
                                    j.ToTable("mail_message_res_partner_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "MailMessageId" }, "mail_message_res_partner_rel_res_partner_id_mail_message_id_idx");
                                    j.IndexerProperty<Guid>("MailMessageId").HasColumnName("mail_message_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                        // entity.HasMany(d => d.ResPartnerNavigation).WithMany(p => p.MailMessage1)
                        entity.HasMany(d => d.ResPartnerNavigation).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "MailMessageResPartnerStarredRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("mail_message_res_partner_starred_rel_res_partner_id_fkey"),
                                l => l.HasOne<MailMessage>().WithMany()
                                    .HasForeignKey("MailMessageId")
                                    .HasConstraintName("mail_message_res_partner_starred_rel_mail_message_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MailMessageId", "ResPartnerId").HasName("mail_message_res_partner_starred_rel_pkey");
                                    j.ToTable("mail_message_res_partner_starred_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "MailMessageId" }, "mail_message_res_partner_star_res_partner_id_mail_message_i_idx");
                                    j.IndexerProperty<Guid>("MailMessageId").HasColumnName("mail_message_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}