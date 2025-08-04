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
        public static void ConfigureSurveyUserInput(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyUserInput>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("survey_user_input_pkey");

                entity.ToTable("survey_user_input", tb => tb.HasComment("Survey User Input"));

                entity.HasIndex(e => e.SlidePartnerId, "survey_user_input_slide_partner_id_index").HasFilter("(slide_partner_id IS NOT NULL)");

                entity.HasIndex(e => e.AccessToken, "survey_user_input_unique_token").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessToken)
                    .HasComment("Identification token")
                    .HasColumnType("character varying")
                    .HasColumnName("access_token");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Deadline)
                    .HasComment("Deadline")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("deadline");
                entity.Property(e => e.Email)
                    .HasComment("Email")
                    .HasColumnType("character varying")
                    .HasColumnName("email");
                entity.Property(e => e.EndDatetime)
                    .HasComment("End date and time")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("end_datetime");
                entity.Property(e => e.InviteToken)
                    .HasComment("Invite token")
                    .HasColumnType("character varying")
                    .HasColumnName("invite_token");
                entity.Property(e => e.IsSessionAnswer)
                    .HasComment("Is in a Session")
                    .HasColumnName("is_session_answer");
                entity.Property(e => e.LastDisplayedPageId)
                    .HasComment("Last displayed question/page")
                    .HasColumnName("last_displayed_page_id");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Nickname)
                    .HasComment("Nickname")
                    .HasColumnType("character varying")
                    .HasColumnName("nickname");
                entity.Property(e => e.PartnerId)
                    .HasComment("Contact")
                    .HasColumnName("partner_id");
                entity.Property(e => e.ScoringPercentage)
                    .HasComment("Score (%)")
                    .HasColumnName("scoring_percentage");
                entity.Property(e => e.ScoringSuccess)
                    .HasComment("Quizz Passed")
                    .HasColumnName("scoring_success");
                entity.Property(e => e.ScoringTotal)
                    .HasComment("Total Score")
                    .HasColumnName("scoring_total");
                entity.Property(e => e.SlideId)
                    .HasComment("Related course slide")
                    .HasColumnName("slide_id");
                entity.Property(e => e.SlidePartnerId)
                    .HasComment("Subscriber information")
                    .HasColumnName("slide_partner_id");
                entity.Property(e => e.StartDatetime)
                    .HasComment("Start date and time")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("start_datetime");
                entity.Property(e => e.State)
                    .HasComment("Status")
                    .HasColumnType("character varying")
                    .HasColumnName("state");
                entity.Property(e => e.SurveyId)
                    .HasComment("Survey")
                    .HasColumnName("survey_id");
                entity.Property(e => e.TestEntry)
                    .HasComment("Test Entry")
                    .HasColumnName("test_entry");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_create_uid_fkey");

                entity.HasOne(d => d.LastDisplayedPage).WithMany(p => p.SurveyUserInputsNavigation)
                    .HasForeignKey(d => d.LastDisplayedPageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_last_displayed_page_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_message_main_attachment_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_partner_id_fkey");

                entity.HasOne(d => d.Slide).WithMany(p => p.SurveyUserInputs)
                    .HasForeignKey(d => d.SlideId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_slide_id_fkey");

                entity.HasOne(d => d.SlidePartner).WithMany(p => p.SurveyUserInputs)
                    .HasForeignKey(d => d.SlidePartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_slide_partner_id_fkey");

                entity.HasOne(d => d.Survey).WithMany(p => p.SurveyUserInputs)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("survey_user_input_survey_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_write_uid_fkey");

                entity.HasMany(d => d.SurveyQuestions).WithMany(p => p.SurveyUserInputs)
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
                            j.ToTable("survey_question_survey_user_input_rel", tb => tb.HasComment("RELATION BETWEEN survey_user_input AND survey_question"));
                            j.HasIndex(new[] { "SurveyQuestionId", "SurveyUserInputId" }, "survey_question_survey_user_i_survey_question_id_survey_use_idx");
                            j.IndexerProperty<Guid>("SurveyUserInputId").HasColumnName("survey_user_input_id");
                            j.IndexerProperty<Guid>("SurveyQuestionId").HasColumnName("survey_question_id");
                        });
            });
        }
    }
}