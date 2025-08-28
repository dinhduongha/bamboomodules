using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("survey_survey");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AccessToken, "survey_survey_access_token_unique").IsUnique();

                        entity.HasIndex(e => e.CertificationBadgeId, "survey_survey_badge_uniq").IsUnique();

                        entity.HasIndex(e => e.SessionCode, "survey_survey_session_code_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessMode).HasColumnName("access_mode");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AttemptsLimit).HasColumnName("attempts_limit");
                        entity.Property(e => e.Certification).HasColumnName("certification");
                        entity.Property(e => e.CertificationBadgeId).HasColumnName("certification_badge_id");
                        entity.Property(e => e.CertificationGiveBadge).HasColumnName("certification_give_badge");
                        entity.Property(e => e.CertificationMailTemplateId).HasColumnName("certification_mail_template_id");
                        entity.Property(e => e.CertificationReportLayout).HasColumnName("certification_report_layout");
                        entity.Property(e => e.CertificationValidityMonths).HasColumnName("certification_validity_months");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.DescriptionDone)
                            .HasColumnType("jsonb")
                            .HasColumnName("description_done");
                        entity.Property(e => e.IsAttemptsLimited).HasColumnName("is_attempts_limited");
                        entity.Property(e => e.IsTimeLimited).HasColumnName("is_time_limited");
                        entity.Property(e => e.ProgressionMode).HasColumnName("progression_mode");
                        entity.Property(e => e.QuestionsLayout).HasColumnName("questions_layout");
                        entity.Property(e => e.QuestionsSelection).HasColumnName("questions_selection");
                        entity.Property(e => e.ScoringSuccessMin).HasColumnName("scoring_success_min");
                        entity.Property(e => e.ScoringType).HasColumnName("scoring_type");
                        entity.Property(e => e.SessionCode).HasColumnName("session_code");
                        entity.Property(e => e.SessionQuestionId).HasColumnName("session_question_id");
                        entity.Property(e => e.SessionQuestionStartTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("session_question_start_time");
                        entity.Property(e => e.SessionSpeedRating).HasColumnName("session_speed_rating");
                        entity.Property(e => e.SessionSpeedRatingTimeLimit).HasColumnName("session_speed_rating_time_limit");
                        entity.Property(e => e.SessionStartTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("session_start_time");
                        entity.Property(e => e.SessionState).HasColumnName("session_state");
                        entity.Property(e => e.SurveyType).HasColumnName("survey_type");
                        entity.Property(e => e.TimeLimit).HasColumnName("time_limit");
                        entity.Property(e => e.Title)
                            .HasColumnType("jsonb")
                            .HasColumnName("title");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.UsersCanGoBack).HasColumnName("users_can_go_back");
                        entity.Property(e => e.UsersLoginRequired).HasColumnName("users_login_required");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.CertificationBadge).WithOne(p => p.SurveySurvey)
                            .HasForeignKey<SurveySurvey>(d => d.CertificationBadgeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_survey_certification_badge_id_fkey");

                        entity.HasOne(d => d.CertificationMailTemplate).WithMany(p => p.SurveySurvey)
                            .HasForeignKey(d => d.CertificationMailTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_survey_certification_mail_template_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SurveySurveyCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_survey_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_survey_create_uid_fkey");

                        entity.HasOne(d => d.SessionQuestion).WithMany(p => p.SurveySurvey)
                            .HasForeignKey(d => d.SessionQuestionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_survey_session_question_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.SurveySurveyUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_survey_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_survey_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SurveySurveyWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_survey_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_survey_write_uid_fkey");

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.SurveySurvey)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ResUsersSurveySurveyRel",
                                r => r.HasOne<ResUsers>().WithMany()
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

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}