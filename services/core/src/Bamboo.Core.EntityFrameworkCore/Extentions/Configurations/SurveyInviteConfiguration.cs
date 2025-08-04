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
        public static void ConfigureSurveyInvite(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyInvite>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("survey_invite_pkey");

                entity.ToTable("survey_invite", tb => tb.HasComment("Survey Invitation Wizard"));

                entity.HasIndex(e => e.AuthorId, "survey_invite_author_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AuthorId)
                    .HasComment("Author")
                    .HasColumnName("author_id");
                entity.Property(e => e.Body)
                    .HasComment("Contents")
                    .HasColumnName("body");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Deadline)
                    .HasComment("Answer deadline")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("deadline");
                entity.Property(e => e.EmailFrom)
                    .HasComment("From")
                    .HasColumnType("character varying")
                    .HasColumnName("email_from");
                entity.Property(e => e.Emails)
                    .HasComment("Additional emails")
                    .HasColumnName("emails");
                entity.Property(e => e.ExistingMode)
                    .HasComment("Handle existing")
                    .HasColumnType("character varying")
                    .HasColumnName("existing_mode");
                entity.Property(e => e.Lang)
                    .HasComment("Language")
                    .HasColumnType("character varying")
                    .HasColumnName("lang");
                entity.Property(e => e.MailServerId)
                    .HasComment("Outgoing mail server")
                    .HasColumnName("mail_server_id");
                entity.Property(e => e.Subject)
                    .HasComment("Subject")
                    .HasColumnType("character varying")
                    .HasColumnName("subject");
                entity.Property(e => e.SurveyId)
                    .HasComment("Survey")
                    .HasColumnName("survey_id");
                entity.Property(e => e.TemplateId)
                    .HasComment("Mail Template")
                    .HasColumnName("template_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Author).WithMany()
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_invite_author_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_invite_create_uid_fkey");

                entity.HasOne(d => d.MailServer).WithMany()
                    .HasForeignKey(d => d.MailServerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_invite_mail_server_id_fkey");

                entity.HasOne(d => d.Survey).WithMany(p => p.SurveyInvites)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("survey_invite_survey_id_fkey");

                entity.HasOne(d => d.Template).WithMany()
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_invite_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_invite_write_uid_fkey");

                entity.HasMany(d => d.Attachments).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "SurveyMailComposeMessageIrAttachmentsRel",
                        r => r.HasOne<IrAttachment>().WithMany()
                            .HasForeignKey("AttachmentId")
                            .HasConstraintName("survey_mail_compose_message_ir_attachments_r_attachment_id_fkey"),
                        l => l.HasOne<SurveyInvite>().WithMany()
                            .HasForeignKey("WizardId")
                            .HasConstraintName("survey_mail_compose_message_ir_attachments_rel_wizard_id_fkey"),
                        j =>
                        {
                            j.HasKey("WizardId", "AttachmentId").HasName("survey_mail_compose_message_ir_attachments_rel_pkey");
                            j.ToTable("survey_mail_compose_message_ir_attachments_rel", tb => tb.HasComment("RELATION BETWEEN survey_invite AND ir_attachment"));
                            j.HasIndex(new[] { "AttachmentId", "WizardId" }, "survey_mail_compose_message_ir_atta_attachment_id_wizard_id_idx");
                            j.IndexerProperty<Guid>("WizardId").HasColumnName("wizard_id");
                            j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                        });

                entity.HasMany(d => d.Partners).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "SurveyInvitePartnerId",
                        r => r.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("PartnerId")
                            .HasConstraintName("survey_invite_partner_ids_partner_id_fkey"),
                        l => l.HasOne<SurveyInvite>().WithMany()
                            .HasForeignKey("InviteId")
                            .HasConstraintName("survey_invite_partner_ids_invite_id_fkey"),
                        j =>
                        {
                            j.HasKey("InviteId", "PartnerId").HasName("survey_invite_partner_ids_pkey");
                            j.ToTable("survey_invite_partner_ids", tb => tb.HasComment("RELATION BETWEEN survey_invite AND res_partner"));
                            j.HasIndex(new[] { "PartnerId", "InviteId" }, "survey_invite_partner_ids_partner_id_invite_id_idx");
                            j.IndexerProperty<Guid>("InviteId").HasColumnName("invite_id");
                            j.IndexerProperty<Guid>("PartnerId").HasColumnName("partner_id");
                        });
            });
        }
    }
}