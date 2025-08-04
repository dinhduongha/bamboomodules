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
        public static void ConfigureSurveyQuestion(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyQuestion>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("survey_question_pkey");

                entity.ToTable("survey_question", tb => tb.HasComment("Survey Question"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AnswerDate)
                    .HasComment("Correct date answer")
                    .HasColumnName("answer_date");
                entity.Property(e => e.AnswerDatetime)
                    .HasComment("Correct datetime answer")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("answer_datetime");
                entity.Property(e => e.AnswerNumericalBox)
                    .HasComment("Correct numerical answer")
                    .HasColumnName("answer_numerical_box");
                entity.Property(e => e.AnswerScore)
                    .HasComment("Score")
                    .HasColumnName("answer_score");
                entity.Property(e => e.CommentCountAsAnswer)
                    .HasComment("Comment is an answer")
                    .HasColumnName("comment_count_as_answer");
                entity.Property(e => e.CommentsAllowed)
                    .HasComment("Show Comments Field")
                    .HasColumnName("comments_allowed");
                entity.Property(e => e.CommentsMessage)
                    .HasComment("Comment Message")
                    .HasColumnType("jsonb")
                    .HasColumnName("comments_message");
                entity.Property(e => e.ConstrErrorMsg)
                    .HasComment("Error message")
                    .HasColumnType("jsonb")
                    .HasColumnName("constr_error_msg");
                entity.Property(e => e.ConstrMandatory)
                    .HasComment("Mandatory Answer")
                    .HasColumnName("constr_mandatory");
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
                entity.Property(e => e.IsConditional)
                    .HasComment("Conditional Display")
                    .HasColumnName("is_conditional");
                entity.Property(e => e.IsPage)
                    .HasComment("Is a page?")
                    .HasColumnName("is_page");
                entity.Property(e => e.IsScoredQuestion)
                    .HasComment("Scored")
                    .HasColumnName("is_scored_question");
                entity.Property(e => e.IsTimeLimited)
                    .HasComment("The question is limited in time")
                    .HasColumnName("is_time_limited");
                entity.Property(e => e.MatrixSubtype)
                    .HasComment("Matrix Type")
                    .HasColumnType("character varying")
                    .HasColumnName("matrix_subtype");
                entity.Property(e => e.PageId)
                    .HasComment("Page")
                    .HasColumnName("page_id");
                entity.Property(e => e.QuestionPlaceholder)
                    .HasComment("Placeholder")
                    .HasColumnType("jsonb")
                    .HasColumnName("question_placeholder");
                entity.Property(e => e.QuestionType)
                    .HasComment("Question Type")
                    .HasColumnType("character varying")
                    .HasColumnName("question_type");
                entity.Property(e => e.RandomQuestionsCount)
                    .HasComment("# Questions Randomly Picked")
                    .HasColumnName("random_questions_count");
                entity.Property(e => e.SaveAsEmail)
                    .HasComment("Save as user email")
                    .HasColumnName("save_as_email");
                entity.Property(e => e.SaveAsNickname)
                    .HasComment("Save as user nickname")
                    .HasColumnName("save_as_nickname");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
                entity.Property(e => e.SurveyId)
                    .HasComment("Survey")
                    .HasColumnName("survey_id");
                entity.Property(e => e.TimeLimit)
                    .HasComment("Time limit (seconds)")
                    .HasColumnName("time_limit");
                entity.Property(e => e.Title)
                    .HasComment("Title")
                    .HasColumnType("jsonb")
                    .HasColumnName("title");
                entity.Property(e => e.TriggeringAnswerId)
                    .HasComment("Triggering Answer")
                    .HasColumnName("triggering_answer_id");
                entity.Property(e => e.TriggeringQuestionId)
                    .HasComment("Triggering Question")
                    .HasColumnName("triggering_question_id");
                entity.Property(e => e.ValidationEmail)
                    .HasComment("Input must be an email")
                    .HasColumnName("validation_email");
                entity.Property(e => e.ValidationErrorMsg)
                    .HasComment("Validation Error message")
                    .HasColumnType("jsonb")
                    .HasColumnName("validation_error_msg");
                entity.Property(e => e.ValidationLengthMax)
                    .HasComment("Maximum Text Length")
                    .HasColumnName("validation_length_max");
                entity.Property(e => e.ValidationLengthMin)
                    .HasComment("Minimum Text Length")
                    .HasColumnName("validation_length_min");
                entity.Property(e => e.ValidationMaxDate)
                    .HasComment("Maximum Date")
                    .HasColumnName("validation_max_date");
                entity.Property(e => e.ValidationMaxDatetime)
                    .HasComment("Maximum Datetime")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("validation_max_datetime");
                entity.Property(e => e.ValidationMaxFloatValue)
                    .HasComment("Maximum value")
                    .HasColumnName("validation_max_float_value");
                entity.Property(e => e.ValidationMinDate)
                    .HasComment("Minimum Date")
                    .HasColumnName("validation_min_date");
                entity.Property(e => e.ValidationMinDatetime)
                    .HasComment("Minimum Datetime")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("validation_min_datetime");
                entity.Property(e => e.ValidationMinFloatValue)
                    .HasComment("Minimum value")
                    .HasColumnName("validation_min_float_value");
                entity.Property(e => e.ValidationRequired)
                    .HasComment("Validate entry")
                    .HasColumnName("validation_required");
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
                    .HasConstraintName("survey_question_create_uid_fkey");

                entity.HasOne(d => d.Page).WithMany(p => p.InversePage)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_question_page_id_fkey");

                entity.HasOne(d => d.Survey).WithMany(p => p.SurveyQuestions)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("survey_question_survey_id_fkey");

                entity.HasOne(d => d.TriggeringAnswer).WithMany()
                    .HasForeignKey(d => d.TriggeringAnswerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_question_triggering_answer_id_fkey");

                entity.HasOne(d => d.TriggeringQuestion).WithMany()
                    .HasForeignKey(d => d.TriggeringQuestionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_question_triggering_question_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_question_write_uid_fkey");

                //entity.HasMany(d => d.SurveyQuestionAnswers).WithMany(p => p.SurveyQuestions)
                entity.HasMany<SurveyQuestionAnswer>().WithMany()
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
            });
        }
    }
}