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
        public static void ConfigureSurveyUserInput(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SurveyUserInput>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("survey_user_input_pkey");

            entity.ToTable("survey_user_input");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.ApplicantId, "survey_user_input__applicant_id_index").HasFilter("(applicant_id IS NOT NULL)");

            entity.HasIndex(e => e.PartnerId, "survey_user_input__partner_id_index").HasFilter("(partner_id IS NOT NULL)");

            entity.HasIndex(e => e.SlidePartnerId, "survey_user_input__slide_partner_id_index").HasFilter("(slide_partner_id IS NOT NULL)");

            entity.HasIndex(e => e.SurveyId, "survey_user_input__survey_id_index");

            entity.HasIndex(e => e.AccessToken, "survey_user_input_unique_token").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccessToken).HasColumnName("access_token");
            entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Deadline)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deadline");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EndDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_datetime");
            entity.Property(e => e.InviteToken).HasColumnName("invite_token");
            entity.Property(e => e.IsSessionAnswer).HasColumnName("is_session_answer");
            entity.Property(e => e.LastDisplayedPageId).HasColumnName("last_displayed_page_id");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.Nickname).HasColumnName("nickname");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ScoringPercentage).HasColumnName("scoring_percentage");
            entity.Property(e => e.ScoringSuccess).HasColumnName("scoring_success");
            entity.Property(e => e.ScoringTotal).HasColumnName("scoring_total");
            entity.Property(e => e.SlideId).HasColumnName("slide_id");
            entity.Property(e => e.SlidePartnerId).HasColumnName("slide_partner_id");
            entity.Property(e => e.StartDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_datetime");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.SurveyFirstSubmitted).HasColumnName("survey_first_submitted");
            entity.Property(e => e.SurveyId).HasColumnName("survey_id");
            entity.Property(e => e.TestEntry).HasColumnName("test_entry");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Applicant).WithMany(p => p.SurveyUserInput)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_applicant_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SurveyUserInputCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_create_uid_fkey");

            entity.HasOne(d => d.LastDisplayedPage).WithMany(p => p.SurveyUserInputNavigation)
                .HasForeignKey(d => d.LastDisplayedPageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_last_displayed_page_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.SurveyUserInput)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_message_main_attachment_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.SurveyUserInput)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_partner_id_fkey");

            entity.HasOne(d => d.Slide).WithMany(p => p.SurveyUserInput)
                .HasForeignKey(d => d.SlideId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_slide_id_fkey");

            entity.HasOne(d => d.SlidePartner).WithMany(p => p.SurveyUserInput)
                .HasForeignKey(d => d.SlidePartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_slide_partner_id_fkey");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyUserInput)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("survey_user_input_survey_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SurveyUserInputWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_write_uid_fkey");

            // entity.HasMany(d => d.SurveyQuestion).WithMany(p => p.SurveyUserInput)
            entity.HasMany(d => d.SurveyQuestion).WithMany(p => p.SurveyUserInput)
                .UsingEntity<Dictionary<string, object>>(
                    "SurveyQuestionSurveyUserInputRel",
                    r => r.HasOne<SurveyQuestion>().WithMany()
                        .HasForeignKey("SurveyQuestionId")
                        .HasConstraintName("survey_question_survey_user_input_rel_survey_question_id_fkey"),
                    l => l.HasOne<SurveyUserInput>().WithMany()
                        .HasForeignKey("SurveyUserInputId")
                        .HasConstraintName("survey_question_survey_user_input_rel_survey_user_input_id_fkey"),
                    j =>
                    {
                        j.HasKey("SurveyUserInputId", "SurveyQuestionId").HasName("survey_question_survey_user_input_rel_pkey");
                        j.ToTable("survey_question_survey_user_input_rel");
                        j.HasIndex(new[] { "SurveyQuestionId", "SurveyUserInputId" }, "survey_question_survey_user_i_survey_question_id_survey_use_idx");
                        j.IndexerProperty<Guid>("SurveyUserInputId").HasColumnName("survey_user_input_id");
                        j.IndexerProperty<Guid>("SurveyQuestionId").HasColumnName("survey_question_id");
                    });
            });
        }
    }
}
