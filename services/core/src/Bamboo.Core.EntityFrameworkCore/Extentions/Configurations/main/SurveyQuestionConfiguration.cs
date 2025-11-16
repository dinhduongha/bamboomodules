using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSurveyQuestion(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SurveyQuestion>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("survey_question_pkey");

                        entity.ToTable("survey_question");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.SurveyId, "survey_question__survey_id_index").HasFilter("(survey_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AnswerDate).HasColumnName("answer_date");
                        entity.Property(e => e.AnswerDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("answer_datetime");
                        entity.Property(e => e.AnswerNumericalBox).HasColumnName("answer_numerical_box");
                        entity.Property(e => e.AnswerScore).HasColumnName("answer_score");
                        entity.Property(e => e.CommentCountAsAnswer).HasColumnName("comment_count_as_answer");
                        entity.Property(e => e.CommentsAllowed).HasColumnName("comments_allowed");
                        entity.Property(e => e.CommentsMessage)
                            .HasColumnType("jsonb")
                            .HasColumnName("comments_message");
                        entity.Property(e => e.ConstrErrorMsg)
                            .HasColumnType("jsonb")
                            .HasColumnName("constr_error_msg");
                        entity.Property(e => e.ConstrMandatory).HasColumnName("constr_mandatory");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.IsPage).HasColumnName("is_page");
                        entity.Property(e => e.IsScoredQuestion).HasColumnName("is_scored_question");
                        entity.Property(e => e.IsTimeCustomized).HasColumnName("is_time_customized");
                        entity.Property(e => e.IsTimeLimited).HasColumnName("is_time_limited");
                        entity.Property(e => e.MatrixSubtype).HasColumnName("matrix_subtype");
                        entity.Property(e => e.PageId).HasColumnName("page_id");
                        entity.Property(e => e.QuestionPlaceholder)
                            .HasColumnType("jsonb")
                            .HasColumnName("question_placeholder");
                        entity.Property(e => e.QuestionType).HasColumnName("question_type");
                        entity.Property(e => e.RandomQuestionsCount).HasColumnName("random_questions_count");
                        entity.Property(e => e.SaveAsEmail).HasColumnName("save_as_email");
                        entity.Property(e => e.SaveAsNickname).HasColumnName("save_as_nickname");
                        entity.Property(e => e.ScaleMax).HasColumnName("scale_max");
                        entity.Property(e => e.ScaleMaxLabel)
                            .HasColumnType("jsonb")
                            .HasColumnName("scale_max_label");
                        entity.Property(e => e.ScaleMidLabel)
                            .HasColumnType("jsonb")
                            .HasColumnName("scale_mid_label");
                        entity.Property(e => e.ScaleMin).HasColumnName("scale_min");
                        entity.Property(e => e.ScaleMinLabel)
                            .HasColumnType("jsonb")
                            .HasColumnName("scale_min_label");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SurveyId).HasColumnName("survey_id");
                        entity.Property(e => e.TimeLimit).HasColumnName("time_limit");
                        entity.Property(e => e.Title)
                            .HasColumnType("jsonb")
                            .HasColumnName("title");
                        entity.Property(e => e.ValidationEmail).HasColumnName("validation_email");
                        entity.Property(e => e.ValidationErrorMsg)
                            .HasColumnType("jsonb")
                            .HasColumnName("validation_error_msg");
                        entity.Property(e => e.ValidationLengthMax).HasColumnName("validation_length_max");
                        entity.Property(e => e.ValidationLengthMin).HasColumnName("validation_length_min");
                        entity.Property(e => e.ValidationMaxDate).HasColumnName("validation_max_date");
                        entity.Property(e => e.ValidationMaxDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("validation_max_datetime");
                        entity.Property(e => e.ValidationMaxFloatValue).HasColumnName("validation_max_float_value");
                        entity.Property(e => e.ValidationMinDate).HasColumnName("validation_min_date");
                        entity.Property(e => e.ValidationMinDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("validation_min_datetime");
                        entity.Property(e => e.ValidationMinFloatValue).HasColumnName("validation_min_float_value");
                        entity.Property(e => e.ValidationRequired).HasColumnName("validation_required");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.SurveyQuestionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_question_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_question_create_uid_fkey");

                        entity.HasOne(d => d.Page).WithMany(p => p.InversePage)
                            .HasForeignKey(d => d.PageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_question_page_id_fkey");

                        entity.HasOne(d => d.Survey).WithMany(p => p.SurveyQuestion)
                            .HasForeignKey(d => d.SurveyId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("survey_question_survey_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.SurveyQuestionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_question_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("survey_question_write_uid_fkey");

                        // entity.HasMany(d => d.SurveyQuestionAnswer).WithMany(p => p.SurveyQuestion)
                        entity.HasMany(d => d.SurveyQuestionAnswer).WithMany(p => p.SurveyQuestion)
                            .UsingEntity<Dictionary<string, object>>(
                                "SurveyQuestionSurveyQuestionAnswerRel",
                                r => r.HasOne<SurveyQuestionAnswer>().WithMany()
                                    .HasForeignKey("SurveyQuestionAnswerId")
                                    .HasConstraintName("survey_question_survey_question__survey_question_answer_id_fkey"),
                                l => l.HasOne<SurveyQuestion>().WithMany()
                                    .HasForeignKey("SurveyQuestionId")
                                    .HasConstraintName("survey_question_survey_question_answer__survey_question_id_fkey"),
                                j =>
                                {
                                    j.HasKey("SurveyQuestionId", "SurveyQuestionAnswerId").HasName("survey_question_survey_question_answer_rel_pkey");
                                    j.ToTable("survey_question_survey_question_answer_rel");
                                    j.HasIndex(new[] { "SurveyQuestionAnswerId", "SurveyQuestionId" }, "survey_question_survey_questi_survey_question_answer_id_sur_idx");
                                    j.IndexerProperty<Guid>("SurveyQuestionId").HasColumnName("survey_question_id");
                                    j.IndexerProperty<Guid>("SurveyQuestionAnswerId").HasColumnName("survey_question_answer_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}