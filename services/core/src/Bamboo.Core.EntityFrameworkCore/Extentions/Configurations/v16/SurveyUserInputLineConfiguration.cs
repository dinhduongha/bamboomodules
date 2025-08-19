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
        public static void ConfigureSurveyUserInputLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SurveyUserInputLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("survey_user_input_line_pkey");

            entity.ToTable("survey_user_input_line");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.QuestionId, "survey_user_input_line__question_id_index");

            entity.HasIndex(e => e.UserInputId, "survey_user_input_line__user_input_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AnswerIsCorrect).HasColumnName("answer_is_correct");
            entity.Property(e => e.AnswerScore).HasColumnName("answer_score");
            entity.Property(e => e.AnswerType).HasColumnName("answer_type");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MatrixRowId).HasColumnName("matrix_row_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.QuestionSequence).HasColumnName("question_sequence");
            entity.Property(e => e.Skipped).HasColumnName("skipped");
            entity.Property(e => e.SuggestedAnswerId).HasColumnName("suggested_answer_id");
            entity.Property(e => e.SurveyId).HasColumnName("survey_id");
            entity.Property(e => e.UserInputId).HasColumnName("user_input_id");
            entity.Property(e => e.ValueCharBox).HasColumnName("value_char_box");
            entity.Property(e => e.ValueDate).HasColumnName("value_date");
            entity.Property(e => e.ValueDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("value_datetime");
            entity.Property(e => e.ValueNumericalBox).HasColumnName("value_numerical_box");
            entity.Property(e => e.ValueScale).HasColumnName("value_scale");
            entity.Property(e => e.ValueTextBox).HasColumnName("value_text_box");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SurveyUserInputLineCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_line_create_uid_fkey");

            entity.HasOne(d => d.MatrixRow).WithMany(p => p.SurveyUserInputLineMatrixRow)
                .HasForeignKey(d => d.MatrixRowId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_line_matrix_row_id_fkey");

            entity.HasOne(d => d.Question).WithMany(p => p.SurveyUserInputLine)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("survey_user_input_line_question_id_fkey");

            entity.HasOne(d => d.SuggestedAnswer).WithMany(p => p.SurveyUserInputLineSuggestedAnswer)
                .HasForeignKey(d => d.SuggestedAnswerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_line_suggested_answer_id_fkey");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyUserInputLine)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_line_survey_id_fkey");

            entity.HasOne(d => d.UserInput).WithMany(p => p.SurveyUserInputLine)
                .HasForeignKey(d => d.UserInputId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("survey_user_input_line_user_input_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SurveyUserInputLineWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_user_input_line_write_uid_fkey");
            });
        }
    }
}
