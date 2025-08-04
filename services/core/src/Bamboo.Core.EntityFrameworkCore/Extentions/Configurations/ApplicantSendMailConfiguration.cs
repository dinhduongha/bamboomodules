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
        public static void ConfigureApplicantSendMail(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantSendMail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("applicant_send_mail_pkey");

                entity.ToTable("applicant_send_mail");

                entity.HasIndex(e => e.TenantId, "mail_applicant_send_mail_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AuthorId).HasColumnName("author_id");
                entity.Property(e => e.Body).HasColumnName("body");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Lang).HasColumnName("lang");
                entity.Property(e => e.Subject).HasColumnName("subject");
                entity.Property(e => e.TemplateId).HasColumnName("template_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Author).WithMany(p => p.ApplicantSendMails)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("applicant_send_mail_author_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("applicant_send_mail_create_uid_fkey");

                entity.HasOne(d => d.Template).WithMany(p => p.ApplicantSendMails)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("applicant_send_mail_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("applicant_send_mail_write_uid_fkey");

                //entity.HasMany(d => d.HrApplicants).WithMany(p => p.ApplicantSendMails)
                entity.HasMany<HrApplicant>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ApplicantSendMailHrApplicantRel",
                        r => r.HasOne<HrApplicant>().WithMany()
                            .HasForeignKey("HrApplicantId")
                            .HasConstraintName("applicant_send_mail_hr_applicant_rel_hr_applicant_id_fkey"),
                        l => l.HasOne<ApplicantSendMail>().WithMany()
                            .HasForeignKey("ApplicantSendMailId")
                            .HasConstraintName("applicant_send_mail_hr_applicant_re_applicant_send_mail_id_fkey"),
                        j =>
                        {
                            j.HasKey("ApplicantSendMailId", "HrApplicantId").HasName("applicant_send_mail_hr_applicant_rel_pkey");
                            j.ToTable("applicant_send_mail_hr_applicant_rel");
                            j.HasIndex(new[] { "HrApplicantId", "ApplicantSendMailId" }, "applicant_send_mail_hr_applic_hr_applicant_id_applicant_sen_idx");
                            j.IndexerProperty<Guid>("ApplicantSendMailId").HasColumnName("applicant_send_mail_id");
                            j.IndexerProperty<Guid>("HrApplicantId").HasColumnName("hr_applicant_id");
                        });

                entity.HasMany(d => d.IrAttachments).WithMany(p => p.ApplicantSendMails)
                    .UsingEntity<Dictionary<string, object>>(
                        "ApplicantSendMailIrAttachmentRel",
                        r => r.HasOne<IrAttachment>().WithMany()
                            .HasForeignKey("IrAttachmentId")
                            .HasConstraintName("applicant_send_mail_ir_attachment_rel_ir_attachment_id_fkey"),
                        l => l.HasOne<ApplicantSendMail>().WithMany()
                            .HasForeignKey("ApplicantSendMailId")
                            .HasConstraintName("applicant_send_mail_ir_attachment_r_applicant_send_mail_id_fkey"),
                        j =>
                        {
                            j.HasKey("ApplicantSendMailId", "IrAttachmentId").HasName("applicant_send_mail_ir_attachment_rel_pkey");
                            j.ToTable("applicant_send_mail_ir_attachment_rel");
                            j.HasIndex(new[] { "IrAttachmentId", "ApplicantSendMailId" }, "applicant_send_mail_ir_attach_ir_attachment_id_applicant_se_idx");
                            j.IndexerProperty<Guid>("ApplicantSendMailId").HasColumnName("applicant_send_mail_id");
                            j.IndexerProperty<Guid>("IrAttachmentId").HasColumnName("ir_attachment_id");
                        });
            });
        }
    }
}