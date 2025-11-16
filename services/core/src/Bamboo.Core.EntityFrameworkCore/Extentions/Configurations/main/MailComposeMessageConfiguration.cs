using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AuthorId).HasColumnName("author_id");
                        entity.Property(e => e.AutoDelete).HasColumnName("auto_delete");
                        entity.Property(e => e.AutoDeleteKeepLog).HasColumnName("auto_delete_keep_log");
                        entity.Property(e => e.Body).HasColumnName("body");
                        entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                        entity.Property(e => e.CompositionMode).HasColumnName("composition_mode");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EmailAddSignature).HasColumnName("email_add_signature");
                        entity.Property(e => e.EmailFrom).HasColumnName("email_from");
                        entity.Property(e => e.EmailLayoutXmlid).HasColumnName("email_layout_xmlid");
                        entity.Property(e => e.ForceSend).HasColumnName("force_send");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.MailActivityTypeId).HasColumnName("mail_activity_type_id");
                        entity.Property(e => e.MailServerId).HasColumnName("mail_server_id");
                        entity.Property(e => e.MassMailingId).HasColumnName("mass_mailing_id");
                        entity.Property(e => e.MassMailingName).HasColumnName("mass_mailing_name");
                        entity.Property(e => e.MessageType).HasColumnName("message_type");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.RecordAliasDomainId).HasColumnName("record_alias_domain_id");
                        entity.Property(e => e.RecordCompanyId).HasColumnName("record_company_id");
                        entity.Property(e => e.RecordName).HasColumnName("record_name");
                        entity.Property(e => e.ReplyTo).HasColumnName("reply_to");
                        entity.Property(e => e.ReplyToForceNew).HasColumnName("reply_to_force_new");
                        entity.Property(e => e.ResDomain).HasColumnName("res_domain");
                        entity.Property(e => e.ResDomainUserId).HasColumnName("res_domain_user_id");
                        entity.Property(e => e.ResIds).HasColumnName("res_ids");
                        entity.Property(e => e.ScheduledDate).HasColumnName("scheduled_date");
                        entity.Property(e => e.Subject).HasColumnName("subject");
                        entity.Property(e => e.SubtypeId).HasColumnName("subtype_id");
                        entity.Property(e => e.TemplateId).HasColumnName("template_id");
                        entity.Property(e => e.TemplateName).HasColumnName("template_name");
                        entity.Property(e => e.UseExclusionList).HasColumnName("use_exclusion_list");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Author).WithMany(p => p.MailComposeMessage) .HasForeignKey(d => d.AuthorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_compose_message_author_id_fkey");
                        entity.HasOne(d => d.Author).WithMany()
                            .HasForeignKey(d => d.AuthorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_author_id_fkey");

                        entity.HasOne(d => d.Campaign).WithMany(p => p.MailComposeMessage)
                            .HasForeignKey(d => d.CampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_campaign_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailComposeMessageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_compose_message_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_create_uid_fkey");

                        entity.HasOne(d => d.MailActivityType).WithMany(p => p.MailComposeMessage)
                            .HasForeignKey(d => d.MailActivityTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_mail_activity_type_id_fkey");

                        entity.HasOne(d => d.MailServer).WithMany(p => p.MailComposeMessage)
                            .HasForeignKey(d => d.MailServerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_mail_server_id_fkey");

                        entity.HasOne(d => d.MassMailing).WithMany(p => p.MailComposeMessage)
                            .HasForeignKey(d => d.MassMailingId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_compose_message_mass_mailing_id_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.MailComposeMessage)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_parent_id_fkey");

                        entity.HasOne(d => d.RecordAliasDomain).WithMany(p => p.MailComposeMessage)
                            .HasForeignKey(d => d.RecordAliasDomainId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_record_alias_domain_id_fkey");

                        // entity.HasOne(d => d.RecordCompany).WithMany(p => p.MailComposeMessage) .HasForeignKey(d => d.RecordCompanyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_compose_message_record_company_id_fkey");
                        entity.HasOne(d => d.RecordCompany).WithMany()
                            .HasForeignKey(d => d.RecordCompanyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_record_company_id_fkey");

                        // entity.HasOne(d => d.ResDomainUser).WithMany(p => p.MailComposeMessageResDomainUser) .HasForeignKey(d => d.ResDomainUserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_compose_message_res_domain_user_id_fkey");
                        entity.HasOne(d => d.ResDomainUser).WithMany()
                            .HasForeignKey(d => d.ResDomainUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_res_domain_user_id_fkey");

                        entity.HasOne(d => d.Subtype).WithMany(p => p.MailComposeMessage)
                            .HasForeignKey(d => d.SubtypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_subtype_id_fkey");

                        entity.HasOne(d => d.Template).WithMany(p => p.MailComposeMessage)
                            .HasForeignKey(d => d.TemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_template_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailComposeMessageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_compose_message_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_compose_message_write_uid_fkey");

                        // entity.HasMany(d => d.Attachment).WithMany(p => p.WizardNavigation)
                        entity.HasMany(d => d.Attachment).WithMany()
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
                                    j.IndexerProperty<Guid>("WizardId").HasColumnName("wizard_id");
                                    j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                                });

                        // entity.HasMany(d => d.MailingList).WithMany(p => p.MailComposeMessage)
                        entity.HasMany(d => d.MailingList).WithMany(p => p.MailComposeMessage)
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

                        // entity.HasMany(d => d.Partner).WithMany(p => p.Wizard)
                        entity.HasMany(d => d.Partner).WithMany()
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
                                    j.IndexerProperty<Guid>("WizardId").HasColumnName("wizard_id");
                                    j.IndexerProperty<Guid>("PartnerId").HasColumnName("partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}