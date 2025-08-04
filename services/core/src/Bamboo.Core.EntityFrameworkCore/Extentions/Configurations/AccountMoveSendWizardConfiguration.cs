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
        public static void ConfigureAccountMoveSendWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMoveSendWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_move_send_wizard_pkey");

                entity.ToTable("account_move_send_wizard");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ExtraEdiCheckboxes)
                    .HasColumnType("jsonb")
                    .HasColumnName("extra_edi_checkboxes");
                entity.Property(e => e.MailAttachmentsWidget)
                    .HasColumnType("jsonb")
                    .HasColumnName("mail_attachments_widget");
                entity.Property(e => e.MailBody).HasColumnName("mail_body");
                entity.Property(e => e.MailSubject).HasColumnName("mail_subject");
                entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");
                entity.Property(e => e.MoveId).HasColumnName("move_id");
                entity.Property(e => e.PdfReportId).HasColumnName("pdf_report_id");
                entity.Property(e => e.SendingMethodCheckboxes)
                    .HasColumnType("jsonb")
                    .HasColumnName("sending_method_checkboxes");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_send_wizard_create_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasOne(d => d.MailTemplate).WithMany(p => p.AccountMoveSendWizards)
                entity.HasOne(d => d.MailTemplate).WithMany()
                    .HasForeignKey(d => d.MailTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_send_wizard_mail_template_id_fkey");

                // TODO: CHECK RELATION
                //entity.HasOne(d => d.Move).WithMany(p => p.AccountMoveSendWizards)
                entity.HasOne(d => d.Move).WithMany()
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_move_send_wizard_move_id_fkey");

                entity.HasOne(d => d.PdfReport).WithMany(p => p.AccountMoveSendWizards)
                    .HasForeignKey(d => d.PdfReportId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_send_wizard_pdf_report_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_send_wizard_write_uid_fkey");

                // TODO: CHECK RELATION
                entity.HasMany(d => d.ResPartners).WithMany()
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
            });
        }
    }
}