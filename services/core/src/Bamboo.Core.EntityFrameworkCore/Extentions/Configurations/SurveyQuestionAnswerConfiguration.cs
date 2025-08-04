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
        public static void ConfigureSurveyQuestionAnswer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyQuestionAnswer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("survey_question_answer_pkey");

                entity.ToTable("survey_question_answer", tb => tb.HasComment("Survey Label"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AnswerScore)
                    .HasComment("Score")
                    .HasColumnName("answer_score");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.IsCorrect)
                    .HasComment("Correct")
                    .HasColumnName("is_correct");
                entity.Property(e => e.MatrixQuestionId)
                    .HasComment("Question (as matrix row)")
                    .HasColumnName("matrix_question_id");
                entity.Property(e => e.QuestionId)
                    .HasComment("Question")
                    .HasColumnName("question_id");
                entity.Property(e => e.Sequence)
                    .HasComment("Label Sequence order")
                    .HasColumnName("sequence");
                entity.Property(e => e.Value)
                    .HasComment("Suggested value")
                    .HasColumnType("jsonb")
                    .HasColumnName("value");
                entity.Property(e => e.ValueImageFilename)
                    .HasComment("Image Filename")
                    .HasColumnType("character varying")
                    .HasColumnName("value_image_filename");
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
                    .HasConstraintName("survey_question_answer_create_uid_fkey");

                entity.HasOne(d => d.MatrixQuestion).WithMany(p => p.SurveyQuestionAnswerMatrixQuestions)
                    .HasForeignKey(d => d.MatrixQuestionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("survey_question_answer_matrix_question_id_fkey");

                entity.HasOne(d => d.Question).WithMany(p => p.SurveyQuestionAnswerQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("survey_question_answer_question_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_question_answer_write_uid_fkey");
            });
        }
    }
}