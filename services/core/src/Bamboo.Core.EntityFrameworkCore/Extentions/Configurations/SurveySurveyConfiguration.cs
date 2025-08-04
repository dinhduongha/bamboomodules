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
        public static void ConfigureSurveySurvey(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveySurvey>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("survey_survey_pkey");

                entity.ToTable("survey_survey", tb => tb.HasComment("Survey"));

                entity.HasIndex(e => e.AccessToken, "survey_survey_access_token_unique").IsUnique();

                entity.HasIndex(e => e.CertificationBadgeId, "survey_survey_badge_uniq").IsUnique();

                entity.HasIndex(e => e.SessionCode, "survey_survey_session_code_unique").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessMode)
                    .HasComment("Access Mode")
                    .HasColumnType("character varying")
                    .HasColumnName("access_mode");
                entity.Property(e => e.AccessToken)
                    .HasComment("Access Token")
                    .HasColumnType("character varying")
                    .HasColumnName("access_token");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.AttemptsLimit)
                    .HasComment("Number of attempts")
                    .HasColumnName("attempts_limit");
                entity.Property(e => e.Certification)
                    .HasComment("Is a Certification")
                    .HasColumnName("certification");
                entity.Property(e => e.CertificationBadgeId)
                    .HasComment("Certification Badge")
                    .HasColumnName("certification_badge_id");
                entity.Property(e => e.CertificationGiveBadge)
                    .HasComment("Give Badge")
                    .HasColumnName("certification_give_badge");
                entity.Property(e => e.CertificationMailTemplateId)
                    .HasComment("Certified Email Template")
                    .HasColumnName("certification_mail_template_id");
                entity.Property(e => e.CertificationReportLayout)
                    .HasComment("Certification template")
                    .HasColumnType("character varying")
                    .HasColumnName("certification_report_layout");
                entity.Property(e => e.Color)
                    .HasComment("Color Index")
                    .HasColumnName("color");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasComment("Description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.DescriptionDone)
                    .HasComment("End Message")
                    .HasColumnType("jsonb")
                    .HasColumnName("description_done");
                entity.Property(e => e.IsAttemptsLimited)
                    .HasComment("Limited number of attempts")
                    .HasColumnName("is_attempts_limited");
                entity.Property(e => e.IsTimeLimited)
                    .HasComment("The survey is limited in time")
                    .HasColumnName("is_time_limited");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.ProgressionMode)
                    .HasComment("Display Progress as")
                    .HasColumnType("character varying")
                    .HasColumnName("progression_mode");
                entity.Property(e => e.QuestionsLayout)
                    .HasComment("Pagination")
                    .HasColumnType("character varying")
                    .HasColumnName("questions_layout");
                entity.Property(e => e.QuestionsSelection)
                    .HasComment("Question Selection")
                    .HasColumnType("character varying")
                    .HasColumnName("questions_selection");
                entity.Property(e => e.ScoringSuccessMin)
                    .HasComment("Required Score (%)")
                    .HasColumnName("scoring_success_min");
                entity.Property(e => e.ScoringType)
                    .HasComment("Scoring")
                    .HasColumnType("character varying")
                    .HasColumnName("scoring_type");
                entity.Property(e => e.SessionCode)
                    .HasComment("Session Code")
                    .HasColumnType("character varying")
                    .HasColumnName("session_code");
                entity.Property(e => e.SessionQuestionId)
                    .HasComment("Current Question")
                    .HasColumnName("session_question_id");
                entity.Property(e => e.SessionQuestionStartTime)
                    .HasComment("Current Question Start Time")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("session_question_start_time");
                entity.Property(e => e.SessionSpeedRating)
                    .HasComment("Reward quick answers")
                    .HasColumnName("session_speed_rating");
                entity.Property(e => e.SessionStartTime)
                    .HasComment("Current Session Start Time")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("session_start_time");
                entity.Property(e => e.SessionState)
                    .HasComment("Session State")
                    .HasColumnType("character varying")
                    .HasColumnName("session_state");
                entity.Property(e => e.TimeLimit)
                    .HasComment("Time limit (minutes)")
                    .HasColumnName("time_limit");
                entity.Property(e => e.Title)
                    .HasComment("Survey Title")
                    .HasColumnType("jsonb")
                    .HasColumnName("title");
                entity.Property(e => e.UserId)
                    .HasComment("Responsible")
                    .HasColumnName("user_id");
                entity.Property(e => e.UsersCanGoBack)
                    .HasComment("Users can go back")
                    .HasColumnName("users_can_go_back");
                entity.Property(e => e.UsersLoginRequired)
                    .HasComment("Require Login")
                    .HasColumnName("users_login_required");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.CertificationBadge).WithOne(p => p.SurveySurvey)
                    .HasForeignKey<SurveySurvey>(d => d.CertificationBadgeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_survey_certification_badge_id_fkey");

                entity.HasOne(d => d.CertificationMailTemplate).WithMany()
                    .HasForeignKey(d => d.CertificationMailTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_survey_certification_mail_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_survey_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_survey_message_main_attachment_id_fkey");

                entity.HasOne(d => d.SessionQuestion).WithMany(p => p.SurveySurveys)
                    .HasForeignKey(d => d.SessionQuestionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_survey_session_question_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_survey_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_survey_write_uid_fkey");

                //entity.HasMany(d => d.ResUsers).WithMany(p => p.SurveySurveys)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ResUsersSurveySurveyRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("ResUsersId")
                            .HasConstraintName("res_users_survey_survey_rel_res_users_id_fkey"),
                        l => l.HasOne<SurveySurvey>().WithMany()
                            .HasForeignKey("SurveySurveyId")
                            .HasConstraintName("res_users_survey_survey_rel_survey_survey_id_fkey"),
                        j =>
                        {
                            j.HasKey("SurveySurveyId", "ResUsersId").HasName("res_users_survey_survey_rel_pkey");
                            j.ToTable("res_users_survey_survey_rel");
                            j.HasIndex(new[] { "ResUsersId", "SurveySurveyId" }, "res_users_survey_survey_rel_res_users_id_survey_survey_id_idx");
                            j.IndexerProperty<Guid>("SurveySurveyId").HasColumnName("survey_survey_id");
                            j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                        });
            });
        }
    }
}