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
        public static void ConfigureSurveyUserInputLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyUserInputLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("survey_user_input_line_pkey");

                entity.ToTable("survey_user_input_line", tb => tb.HasComment("Survey User Input Line"));

                entity.HasIndex(e => e.UserInputId, "survey_user_input_line_user_input_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AnswerIsCorrect)
                    .HasComment("Correct")
                    .HasColumnName("answer_is_correct");
                entity.Property(e => e.AnswerScore)
                    .HasComment("Score")
                    .HasColumnName("answer_score");
                entity.Property(e => e.AnswerType)
                    .HasComment("Answer Type")
                    .HasColumnType("character varying")
                    .HasColumnName("answer_type");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.MatrixRowId)
                    .HasComment("Row answer")
                    .HasColumnName("matrix_row_id");
                entity.Property(e => e.QuestionId)
                    .HasComment("Question")
                    .HasColumnName("question_id");
                entity.Property(e => e.QuestionSequence)
                    .HasComment("Sequence")
                    .HasColumnName("question_sequence");
                entity.Property(e => e.Skipped)
                    .HasComment("Skipped")
                    .HasColumnName("skipped");
                entity.Property(e => e.SuggestedAnswerId)
                    .HasComment("Suggested answer")
                    .HasColumnName("suggested_answer_id");
                entity.Property(e => e.SurveyId)
                    .HasComment("Survey")
                    .HasColumnName("survey_id");
                entity.Property(e => e.UserInputId)
                    .HasComment("User Input")
                    .HasColumnName("user_input_id");
                entity.Property(e => e.ValueCharBox)
                    .HasComment("Text answer")
                    .HasColumnType("character varying")
                    .HasColumnName("value_char_box");
                entity.Property(e => e.ValueDate)
                    .HasComment("Date answer")
                    .HasColumnName("value_date");
                entity.Property(e => e.ValueDatetime)
                    .HasComment("Datetime answer")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("value_datetime");
                entity.Property(e => e.ValueNumericalBox)
                    .HasComment("Numerical answer")
                    .HasColumnName("value_numerical_box");
                entity.Property(e => e.ValueTextBox)
                    .HasComment("Free Text answer")
                    .HasColumnName("value_text_box");
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
                    .HasConstraintName("survey_user_input_line_create_uid_fkey");

                entity.HasOne(d => d.MatrixRow).WithMany(p => p.SurveyUserInputLineMatrixRows)
                    .HasForeignKey(d => d.MatrixRowId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_line_matrix_row_id_fkey");

                entity.HasOne(d => d.Question).WithMany(p => p.SurveyUserInputLines)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("survey_user_input_line_question_id_fkey");

                entity.HasOne(d => d.SuggestedAnswer).WithMany(p => p.SurveyUserInputLineSuggestedAnswers)
                    .HasForeignKey(d => d.SuggestedAnswerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_line_suggested_answer_id_fkey");

                entity.HasOne(d => d.Survey).WithMany(p => p.SurveyUserInputLines)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_line_survey_id_fkey");

                entity.HasOne(d => d.UserInput).WithMany(p => p.SurveyUserInputLines)
                    .HasForeignKey(d => d.UserInputId)
                    .HasConstraintName("survey_user_input_line_user_input_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_line_write_uid_fkey");
            });
        }
    }
}