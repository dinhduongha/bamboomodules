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
        public static void ConfigureMailComposeMessage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailComposeMessage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mail_compose_message_pkey");

                entity.ToTable("mail_compose_message");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ActiveDomain).HasColumnName("active_domain");
                entity.Property(e => e.AuthorId).HasColumnName("author_id");
                entity.Property(e => e.AutoDelete).HasColumnName("auto_delete");
                entity.Property(e => e.AutoDeleteMessage).HasColumnName("auto_delete_message");
                entity.Property(e => e.Body).HasColumnName("body");
                entity.Property(e => e.CompositionMode).HasColumnName("composition_mode");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.EmailAddSignature).HasColumnName("email_add_signature");
                entity.Property(e => e.EmailFrom).HasColumnName("email_from");
                entity.Property(e => e.EmailLayoutXmlid).HasColumnName("email_layout_xmlid");
                entity.Property(e => e.IsLog).HasColumnName("is_log");
                entity.Property(e => e.Lang).HasColumnName("lang");
                entity.Property(e => e.MailActivityTypeId).HasColumnName("mail_activity_type_id");
                entity.Property(e => e.MailServerId).HasColumnName("mail_server_id");
                entity.Property(e => e.MessageType).HasColumnName("message_type");
                entity.Property(e => e.Model).HasColumnName("model");
                entity.Property(e => e.Notify).HasColumnName("notify");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.RecordName).HasColumnName("record_name");
                entity.Property(e => e.ReplyTo).HasColumnName("reply_to");
                entity.Property(e => e.ReplyToForceNew).HasColumnName("reply_to_force_new");
                entity.Property(e => e.ResId).HasColumnName("res_id");
                entity.Property(e => e.Subject).HasColumnName("subject");
                entity.Property(e => e.SubtypeId).HasColumnName("subtype_id");
                entity.Property(e => e.TemplateId).HasColumnName("template_id");
                entity.Property(e => e.UseActiveDomain).HasColumnName("use_active_domain");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Author).WithMany(p => p.MailComposeMessages)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_compose_message_author_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_compose_message_create_uid_fkey");

                entity.HasOne(d => d.MailActivityType).WithMany(p => p.MailComposeMessages)
                    .HasForeignKey(d => d.MailActivityTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_compose_message_mail_activity_type_id_fkey");

                entity.HasOne(d => d.MailServer).WithMany(p => p.MailComposeMessages)
                    .HasForeignKey(d => d.MailServerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_compose_message_mail_server_id_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.MailComposeMessages)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_compose_message_parent_id_fkey");

                entity.HasOne(d => d.Subtype).WithMany(p => p.MailComposeMessages)
                    .HasForeignKey(d => d.SubtypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_compose_message_subtype_id_fkey");

                entity.HasOne(d => d.Template).WithMany(p => p.MailComposeMessages)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_compose_message_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_compose_message_write_uid_fkey");

                //entity.HasMany(d => d.Attachments).WithMany(p => p.Wizards)
                entity.HasMany<IrAttachment>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MailComposeMessageIrAttachmentsRel",
                        r => r.HasOne<IrAttachment>().WithMany()
                            .HasForeignKey("AttachmentId")
                            .HasConstraintName("mail_compose_message_ir_attachments_rel_attachment_id_fkey"),
                        l => l.HasOne<MailComposeMessage>().WithMany()
                            .HasForeignKey("WizardId")
                            .HasConstraintName("mail_compose_message_ir_attachments_rel_wizard_id_fkey"),
                        j =>
                        {
                            j.HasKey("WizardId", "AttachmentId").HasName("mail_compose_message_ir_attachments_rel_pkey");
                            j.ToTable("mail_compose_message_ir_attachments_rel");
                            j.HasIndex(new[] { "AttachmentId", "WizardId" }, "mail_compose_message_ir_attachments_attachment_id_wizard_id_idx");
                        });

                entity.HasMany(d => d.MailingLists).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MailComposeMessageMailingListRel",
                        r => r.HasOne<MailingList>().WithMany()
                            .HasForeignKey("MailingListId")
                            .HasConstraintName("mail_compose_message_mailing_list_rel_mailing_list_id_fkey"),
                        l => l.HasOne<MailComposeMessage>().WithMany()
                            .HasForeignKey("MailComposeMessageId")
                            .HasConstraintName("mail_compose_message_mailing_list__mail_compose_message_id_fkey"),
                        j =>
                        {
                            j.HasKey("MailComposeMessageId", "MailingListId").HasName("mail_compose_message_mailing_list_rel_pkey");
                            j.ToTable("mail_compose_message_mailing_list_rel");
                            j.HasIndex(new[] { "MailingListId", "MailComposeMessageId" }, "mail_compose_message_mailing__mailing_list_id_mail_compose__idx");
                            j.IndexerProperty<Guid>("MailComposeMessageId").HasColumnName("mail_compose_message_id");
                            j.IndexerProperty<Guid>("MailingListId").HasColumnName("mailing_list_id");
                        });

                //entity.HasMany(d => d.Partners).WithMany(p => p.Wizards)
                entity.HasMany<ResPartner>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "MailComposeMessageResPartnerRel",
                        r => r.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("PartnerId")
                            .HasConstraintName("mail_compose_message_res_partner_rel_partner_id_fkey"),
                        l => l.HasOne<MailComposeMessage>().WithMany()
                            .HasForeignKey("WizardId")
                            .HasConstraintName("mail_compose_message_res_partner_rel_wizard_id_fkey"),
                        j =>
                        {
                            j.HasKey("WizardId", "PartnerId").HasName("mail_compose_message_res_partner_rel_pkey");
                            j.ToTable("mail_compose_message_res_partner_rel");
                            j.HasIndex(new[] { "PartnerId", "WizardId" }, "mail_compose_message_res_partner_rel_partner_id_wizard_id_idx");
                        });
            });
        }
    }
}