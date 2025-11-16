using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("survey_invite");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AuthorId, "survey_invite__author_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
                        entity.Property(e => e.AuthorId).HasColumnName("author_id");
                        entity.Property(e => e.Body).HasColumnName("body");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Deadline)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("deadline");
                        entity.Property(e => e.Emails).HasColumnName("emails");
                        entity.Property(e => e.ExistingMode).HasColumnName("existing_mode");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.MailServerId).HasColumnName("mail_server_id");
                        entity.Property(e => e.Subject).HasColumnName("subject");
                        entity.Property(e => e.SurveyId).HasColumnName("survey_id");
                        entity.Property(e => e.TemplateId).HasColumnName("template_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Applicant).WithMany(p => p.SurveyInvite)
                            .HasForeignKey(d => d.ApplicantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_invite_applicant_id_fkey");

                        // entity.HasOne(d => d.Author).WithMany(p => p.SurveyInvite) .HasForeignKey(d => d.AuthorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_invite_author_id_fkey");
                        entity.HasOne(d => d.Author).WithMany()
                            .HasForeignKey(d => d.AuthorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_invite_author_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SurveyInviteCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_invite_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_invite_create_uid_fkey");

                        entity.HasOne(d => d.MailServer).WithMany(p => p.SurveyInvite)
                            .HasForeignKey(d => d.MailServerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_invite_mail_server_id_fkey");

                        entity.HasOne(d => d.Survey).WithMany(p => p.SurveyInvite)
                            .HasForeignKey(d => d.SurveyId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("survey_invite_survey_id_fkey");

                        entity.HasOne(d => d.Template).WithMany(p => p.SurveyInvite)
                            .HasForeignKey(d => d.TemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_invite_template_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SurveyInviteWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_invite_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_invite_write_uid_fkey");

                        // entity.HasMany(d => d.Attachment).WithMany(p => p.Wizard1)
                        entity.HasMany(d => d.Attachment).WithMany()
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
                                    j.ToTable("survey_mail_compose_message_ir_attachments_rel");
                                    j.HasIndex(new[] { "AttachmentId", "WizardId" }, "survey_mail_compose_message_ir_atta_attachment_id_wizard_id_idx");
                                    j.IndexerProperty<Guid>("WizardId").HasColumnName("wizard_id");
                                    j.IndexerProperty<Guid>("AttachmentId").HasColumnName("attachment_id");
                                });

                        // entity.HasMany(d => d.Partner).WithMany(p => p.Invite)
                        entity.HasMany(d => d.Partner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "SurveyInvitePartnerIds",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("PartnerId")
                                    .HasConstraintName("survey_invite_partner_ids_partner_id_fkey"),
                                l => l.HasOne<SurveyInvite>().WithMany()
                                    .HasForeignKey("InviteId")
                                    .HasConstraintName("survey_invite_partner_ids_invite_id_fkey"),
                                j =>
                                {
                                    j.HasKey("InviteId", "PartnerId").HasName("survey_invite_partner_ids_pkey");
                                    j.ToTable("survey_invite_partner_ids");
                                    j.HasIndex(new[] { "PartnerId", "InviteId" }, "survey_invite_partner_ids_partner_id_invite_id_idx");
                                    j.IndexerProperty<Guid>("InviteId").HasColumnName("invite_id");
                                    j.IndexerProperty<Guid>("PartnerId").HasColumnName("partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}