using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCandidateSendMail(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CandidateSendMail>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("candidate_send_mail_pkey");

            entity.ToTable("candidate_send_mail");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
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

            entity.HasOne(d => d.Author).WithMany()
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("candidate_send_mail_author_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.CandidateSendMailCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("candidate_send_mail_create_uid_fkey");

            entity.HasOne(d => d.Template).WithMany(p => p.CandidateSendMail)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("candidate_send_mail_template_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.CandidateSendMailWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("candidate_send_mail_write_uid_fkey");

            // entity.HasMany(d => d.HrCandidate).WithMany(p => p.CandidateSendMail)
            entity.HasMany(d => d.HrCandidate).WithMany(p => p.CandidateSendMail)
                .UsingEntity<Dictionary<string, object>>(
                    "CandidateSendMailHrCandidateRel",
                    r => r.HasOne<HrCandidate>().WithMany()
                        .HasForeignKey("HrCandidateId")
                        .HasConstraintName("candidate_send_mail_hr_candidate_rel_hr_candidate_id_fkey"),
                    l => l.HasOne<CandidateSendMail>().WithMany()
                        .HasForeignKey("CandidateSendMailId")
                        .HasConstraintName("candidate_send_mail_hr_candidate_re_candidate_send_mail_id_fkey"),
                    j =>
                    {
                        j.HasKey("CandidateSendMailId", "HrCandidateId").HasName("candidate_send_mail_hr_candidate_rel_pkey");
                        j.ToTable("candidate_send_mail_hr_candidate_rel");
                        j.HasIndex(new[] { "HrCandidateId", "CandidateSendMailId" }, "candidate_send_mail_hr_candid_hr_candidate_id_candidate_sen_idx");
                        j.IndexerProperty<Guid>("CandidateSendMailId").HasColumnName("candidate_send_mail_id");
                        j.IndexerProperty<Guid>("HrCandidateId").HasColumnName("hr_candidate_id");
                    });

            // entity.HasMany(d => d.IrAttachment).WithMany(p => p.CandidateSendMail)
            entity.HasMany(d => d.IrAttachment).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "CandidateSendMailIrAttachmentRel",
                    r => r.HasOne<IrAttachment>().WithMany()
                        .HasForeignKey("IrAttachmentId")
                        .HasConstraintName("candidate_send_mail_ir_attachment_rel_ir_attachment_id_fkey"),
                    l => l.HasOne<CandidateSendMail>().WithMany()
                        .HasForeignKey("CandidateSendMailId")
                        .HasConstraintName("candidate_send_mail_ir_attachment_r_candidate_send_mail_id_fkey"),
                    j =>
                    {
                        j.HasKey("CandidateSendMailId", "IrAttachmentId").HasName("candidate_send_mail_ir_attachment_rel_pkey");
                        j.ToTable("candidate_send_mail_ir_attachment_rel");
                        j.HasIndex(new[] { "IrAttachmentId", "CandidateSendMailId" }, "candidate_send_mail_ir_attach_ir_attachment_id_candidate_se_idx");
                        j.IndexerProperty<Guid>("CandidateSendMailId").HasColumnName("candidate_send_mail_id");
                        j.IndexerProperty<Guid>("IrAttachmentId").HasColumnName("ir_attachment_id");
                    });
            });
        }
    }
}