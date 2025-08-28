using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrApplicant(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrApplicant>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_applicant_pkey");

                        entity.ToTable("hr_applicant");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Active, "hr_applicant__active_index");

                        entity.HasIndex(e => e.CampaignId, "hr_applicant__campaign_id_index").HasFilter("(campaign_id IS NOT NULL)");

                        entity.HasIndex(e => e.CandidateId, "hr_applicant__candidate_id_index");

                        entity.HasIndex(e => e.DateLastStageUpdate, "hr_applicant__date_last_stage_update_index");

                        entity.HasIndex(e => e.JobId, "hr_applicant__job_id_index");

                        entity.HasIndex(e => e.MediumId, "hr_applicant__medium_id_index").HasFilter("(medium_id IS NOT NULL)");

                        entity.HasIndex(e => e.MessageMainAttachmentId, "hr_applicant__message_main_attachment_id_index").HasFilter("(message_main_attachment_id IS NOT NULL)");

                        entity.HasIndex(e => e.SourceId, "hr_applicant__source_id_index").HasFilter("(source_id IS NOT NULL)");

                        entity.HasIndex(e => e.StageId, "hr_applicant__stage_id_index");

                        entity.HasIndex(e => new { e.JobId, e.StageId }, "hr_applicant_job_id_stage_id_idx").HasFilter("(active IS TRUE)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.ApplicantNotes).HasColumnName("applicant_notes");
                        entity.Property(e => e.ApplicantProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("applicant_properties");
                        entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                        entity.Property(e => e.CandidateId).HasColumnName("candidate_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateClosed)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_closed");
                        entity.Property(e => e.DateLastStageUpdate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_last_stage_update");
                        entity.Property(e => e.DateOpen)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_open");
                        entity.Property(e => e.DelayClose).HasColumnName("delay_close");
                        entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                        entity.Property(e => e.EmailCc).HasColumnName("email_cc");
                        entity.Property(e => e.JobId).HasColumnName("job_id");
                        entity.Property(e => e.KanbanState).HasColumnName("kanban_state");
                        entity.Property(e => e.LastStageId).HasColumnName("last_stage_id");
                        entity.Property(e => e.MediumId).HasColumnName("medium_id");
                        entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.Probability).HasColumnName("probability");
                        entity.Property(e => e.RefuseDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("refuse_date");
                        entity.Property(e => e.RefuseReasonId).HasColumnName("refuse_reason_id");
                        entity.Property(e => e.SalaryExpected).HasColumnName("salary_expected");
                        entity.Property(e => e.SalaryExpectedExtra).HasColumnName("salary_expected_extra");
                        entity.Property(e => e.SalaryProposed).HasColumnName("salary_proposed");
                        entity.Property(e => e.SalaryProposedExtra).HasColumnName("salary_proposed_extra");
                        entity.Property(e => e.SourceId).HasColumnName("source_id");
                        entity.Property(e => e.StageId).HasColumnName("stage_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Campaign).WithMany(p => p.HrApplicant)
                            .HasForeignKey(d => d.CampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_campaign_id_fkey");

                        entity.HasOne(d => d.Candidate).WithMany(p => p.HrApplicant)
                            .HasForeignKey(d => d.CandidateId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_applicant_candidate_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrApplicant) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_applicant_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrApplicantCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_applicant_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_create_uid_fkey");

                        entity.HasOne(d => d.Department).WithMany(p => p.HrApplicant)
                            .HasForeignKey(d => d.DepartmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_department_id_fkey");

                        entity.HasOne(d => d.Job).WithMany(p => p.HrApplicant)
                            .HasForeignKey(d => d.JobId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_job_id_fkey");

                        entity.HasOne(d => d.LastStage).WithMany(p => p.HrApplicantLastStage)
                            .HasForeignKey(d => d.LastStageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_last_stage_id_fkey");

                        entity.HasOne(d => d.Medium).WithMany(p => p.HrApplicant)
                            .HasForeignKey(d => d.MediumId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_medium_id_fkey");

                        // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrApplicant) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_applicant_message_main_attachment_id_fkey");
                        entity.HasOne(d => d.MessageMainAttachment).WithMany()
                            .HasForeignKey(d => d.MessageMainAttachmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_message_main_attachment_id_fkey");

                        entity.HasOne(d => d.RefuseReason).WithMany(p => p.HrApplicant)
                            .HasForeignKey(d => d.RefuseReasonId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_refuse_reason_id_fkey");

                        entity.HasOne(d => d.Source).WithMany(p => p.HrApplicant)
                            .HasForeignKey(d => d.SourceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_source_id_fkey");

                        entity.HasOne(d => d.Stage).WithMany(p => p.HrApplicantStage)
                            .HasForeignKey(d => d.StageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_applicant_stage_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.HrApplicantUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_applicant_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrApplicantWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_applicant_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_write_uid_fkey");

                        // entity.HasMany(d => d.HrApplicantCategory).WithMany(p => p.HrApplicant)
                        entity.HasMany(d => d.HrApplicantCategory).WithMany(p => p.HrApplicant)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrApplicantHrApplicantCategoryRel",
                                r => r.HasOne<HrApplicantCategory>().WithMany()
                                    .HasForeignKey("HrApplicantCategoryId")
                                    .HasConstraintName("hr_applicant_hr_applicant_categor_hr_applicant_category_id_fkey"),
                                l => l.HasOne<HrApplicant>().WithMany()
                                    .HasForeignKey("HrApplicantId")
                                    .HasConstraintName("hr_applicant_hr_applicant_category_rel_hr_applicant_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrApplicantId", "HrApplicantCategoryId").HasName("hr_applicant_hr_applicant_category_rel_pkey");
                                    j.ToTable("hr_applicant_hr_applicant_category_rel");
                                    j.HasIndex(new[] { "HrApplicantCategoryId", "HrApplicantId" }, "hr_applicant_hr_applicant_cat_hr_applicant_category_id_hr_a_idx");
                                    j.IndexerProperty<Guid>("HrApplicantId").HasColumnName("hr_applicant_id");
                                    j.IndexerProperty<Guid>("HrApplicantCategoryId").HasColumnName("hr_applicant_category_id");
                                });

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.HrApplicant)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "HrApplicantResUsersInterviewersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("hr_applicant_res_users_interviewers_rel_res_users_id_fkey"),
                                l => l.HasOne<HrApplicant>().WithMany()
                                    .HasForeignKey("HrApplicantId")
                                    .HasConstraintName("hr_applicant_res_users_interviewers_rel_hr_applicant_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrApplicantId", "ResUsersId").HasName("hr_applicant_res_users_interviewers_rel_pkey");
                                    j.ToTable("hr_applicant_res_users_interviewers_rel");
                                    j.HasIndex(new[] { "ResUsersId", "HrApplicantId" }, "hr_applicant_res_users_intervi_res_users_id_hr_applicant_id_idx");
                                    j.IndexerProperty<Guid>("HrApplicantId").HasColumnName("hr_applicant_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}