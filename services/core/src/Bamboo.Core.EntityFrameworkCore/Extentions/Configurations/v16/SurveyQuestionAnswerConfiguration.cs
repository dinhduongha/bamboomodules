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
        public static void ConfigureSurveyQuestionAnswer(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SurveyQuestionAnswer>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("survey_question_answer_pkey");

            entity.ToTable("survey_question_answer");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.MatrixQuestionId, "survey_question_answer__matrix_question_id_index").HasFilter("(matrix_question_id IS NOT NULL)");

            entity.HasIndex(e => e.QuestionId, "survey_question_answer__question_id_index").HasFilter("(question_id IS NOT NULL)");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AnswerScore).HasColumnName("answer_score");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
            entity.Property(e => e.MatrixQuestionId).HasColumnName("matrix_question_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.Value)
                .HasColumnType("jsonb")
                .HasColumnName("value");
            entity.Property(e => e.ValueImageFilename).HasColumnName("value_image_filename");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SurveyQuestionAnswerCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_question_answer_create_uid_fkey");

            entity.HasOne(d => d.MatrixQuestion).WithMany(p => p.SurveyQuestionAnswerMatrixQuestion)
                .HasForeignKey(d => d.MatrixQuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("survey_question_answer_matrix_question_id_fkey");

            entity.HasOne(d => d.Question).WithMany(p => p.SurveyQuestionAnswerQuestion)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("survey_question_answer_question_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SurveyQuestionAnswerWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("survey_question_answer_write_uid_fkey");
            });
        }
    }
}
