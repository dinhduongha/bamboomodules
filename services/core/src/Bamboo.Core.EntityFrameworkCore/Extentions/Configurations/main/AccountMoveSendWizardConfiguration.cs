using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountMoveSendWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountMoveSendWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_move_send_wizard_pkey");

                        entity.ToTable("account_move_send_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Body).HasColumnName("body");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ExtraEdiCheckboxes)
                            .HasColumnType("jsonb")
                            .HasColumnName("extra_edi_checkboxes");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.MailAttachmentsWidget)
                            .HasColumnType("jsonb")
                            .HasColumnName("mail_attachments_widget");
                        entity.Property(e => e.Model).HasColumnName("model");
                        entity.Property(e => e.MoveId).HasColumnName("move_id");
                        entity.Property(e => e.PdfReportId).HasColumnName("pdf_report_id");
                        entity.Property(e => e.ResIds).HasColumnName("res_ids");
                        entity.Property(e => e.SendingMethodCheckboxes)
                            .HasColumnType("jsonb")
                            .HasColumnName("sending_method_checkboxes");
                        entity.Property(e => e.Subject).HasColumnName("subject");
                        entity.Property(e => e.TemplateId).HasColumnName("template_id");
                        entity.Property(e => e.TemplateName).HasColumnName("template_name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountMoveSendWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_move_send_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_send_wizard_create_uid_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.AccountMoveSendWizard)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_move_send_wizard_move_id_fkey");

                        entity.HasOne(d => d.PdfReport).WithMany(p => p.AccountMoveSendWizard)
                            .HasForeignKey(d => d.PdfReportId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_send_wizard_pdf_report_id_fkey");

                        entity.HasOne(d => d.Template).WithMany(p => p.AccountMoveSendWizard)
                            .HasForeignKey(d => d.TemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_send_wizard_template_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountMoveSendWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_move_send_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_send_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.AccountMoveSendWizard)
                        entity.HasMany(d => d.ResPartner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountMoveSendWizardResPartnerRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("account_move_send_wizard_res_partner_rel_res_partner_id_fkey"),
                                l => l.HasOne<AccountMoveSendWizard>().WithMany()
                                    .HasForeignKey("AccountMoveSendWizardId")
                                    .HasConstraintName("account_move_send_wizard_res_p_account_move_send_wizard_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountMoveSendWizardId", "ResPartnerId").HasName("account_move_send_wizard_res_partner_rel_pkey");
                                    j.ToTable("account_move_send_wizard_res_partner_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "AccountMoveSendWizardId" }, "account_move_send_wizard_res__res_partner_id_account_move_s_idx");
                                    j.IndexerProperty<Guid>("AccountMoveSendWizardId").HasColumnName("account_move_send_wizard_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}