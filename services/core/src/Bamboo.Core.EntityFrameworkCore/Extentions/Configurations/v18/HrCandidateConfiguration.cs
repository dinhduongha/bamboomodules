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
        public static void ConfigureHrCandidate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrCandidate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_candidate_pkey");

            entity.ToTable("hr_candidate");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.Active, "hr_candidate__active_index");

            entity.HasIndex(e => e.EmailFrom, "hr_candidate__email_from_index")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.HasIndex(e => e.EmailNormalized, "hr_candidate__email_normalized_index")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.HasIndex(e => e.MessageMainAttachmentId, "hr_candidate__message_main_attachment_id_index").HasFilter("(message_main_attachment_id IS NOT NULL)");

            entity.HasIndex(e => e.PartnerId, "hr_candidate__partner_id_index").HasFilter("(partner_id IS NOT NULL)");

            entity.HasIndex(e => e.PartnerPhone, "hr_candidate__partner_phone_index").HasFilter("(partner_phone IS NOT NULL)");

            entity.HasIndex(e => e.PartnerPhoneSanitized, "hr_candidate__partner_phone_sanitized_index").HasFilter("(partner_phone_sanitized IS NOT NULL)");

            entity.HasIndex(e => new { e.EmailNormalized, e.PartnerPhoneSanitized }, "hr_candidate_email_partner_phone_mobile");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.CandidateProperties)
                .HasColumnType("jsonb")
                .HasColumnName("candidate_properties");
            entity.Property(e => e.Color).HasColumnName("color");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.EmailCc).HasColumnName("email_cc");
            entity.Property(e => e.EmailFrom).HasColumnName("email_from");
            entity.Property(e => e.EmailNormalized).HasColumnName("email_normalized");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.LinkedinProfile).HasColumnName("linkedin_profile");
            entity.Property(e => e.MessageBounce).HasColumnName("message_bounce");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PartnerName).HasColumnName("partner_name");
            entity.Property(e => e.PartnerPhone).HasColumnName("partner_phone");
            entity.Property(e => e.PartnerPhoneSanitized).HasColumnName("partner_phone_sanitized");
            entity.Property(e => e.PhoneSanitized).HasColumnName("phone_sanitized");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.HrCandidate)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_candidate_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrCandidateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_candidate_create_uid_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrCandidate)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_candidate_employee_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrCandidate)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_candidate_message_main_attachment_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.HrCandidate)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_candidate_partner_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.HrCandidate)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_candidate_type_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.HrCandidateUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_candidate_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrCandidateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_candidate_write_uid_fkey");

            // entity.HasMany(d => d.HrApplicantCategory).WithMany(p => p.HrCandidate)
            entity.HasMany(d => d.HrApplicantCategory).WithMany(p => p.HrCandidate)
                .UsingEntity<Dictionary<string, object>>(
                    "HrApplicantCategoryHrCandidateRel",
                    r => r.HasOne<HrApplicantCategory>().WithMany()
                        .HasForeignKey("HrApplicantCategoryId")
                        .HasConstraintName("hr_applicant_category_hr_candidat_hr_applicant_category_id_fkey"),
                    l => l.HasOne<HrCandidate>().WithMany()
                        .HasForeignKey("HrCandidateId")
                        .HasConstraintName("hr_applicant_category_hr_candidate_rel_hr_candidate_id_fkey"),
                    j =>
                    {
                        j.HasKey("HrCandidateId", "HrApplicantCategoryId").HasName("hr_applicant_category_hr_candidate_rel_pkey");
                        j.ToTable("hr_applicant_category_hr_candidate_rel");
                        j.HasIndex(new[] { "HrApplicantCategoryId", "HrCandidateId" }, "hr_applicant_category_hr_cand_hr_applicant_category_id_hr_c_idx");
                        j.IndexerProperty<Guid>("HrCandidateId").HasColumnName("hr_candidate_id");
                        j.IndexerProperty<Guid>("HrApplicantCategoryId").HasColumnName("hr_applicant_category_id");
                    });

            // entity.HasMany(d => d.HrSkill).WithMany(p => p.HrCandidate)
            entity.HasMany(d => d.HrSkill).WithMany(p => p.HrCandidate)
                .UsingEntity<Dictionary<string, object>>(
                    "HrCandidateHrSkillRel",
                    r => r.HasOne<HrSkill>().WithMany()
                        .HasForeignKey("HrSkillId")
                        .HasConstraintName("hr_candidate_hr_skill_rel_hr_skill_id_fkey"),
                    l => l.HasOne<HrCandidate>().WithMany()
                        .HasForeignKey("HrCandidateId")
                        .HasConstraintName("hr_candidate_hr_skill_rel_hr_candidate_id_fkey"),
                    j =>
                    {
                        j.HasKey("HrCandidateId", "HrSkillId").HasName("hr_candidate_hr_skill_rel_pkey");
                        j.ToTable("hr_candidate_hr_skill_rel");
                        j.HasIndex(new[] { "HrSkillId", "HrCandidateId" }, "hr_candidate_hr_skill_rel_hr_skill_id_hr_candidate_id_idx");
                        j.IndexerProperty<Guid>("HrCandidateId").HasColumnName("hr_candidate_id");
                        j.IndexerProperty<Guid>("HrSkillId").HasColumnName("hr_skill_id");
                    });
            });
        }
    }
}