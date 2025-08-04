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
        public static void ConfigureSlideAnswer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideAnswer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("slide_answer_pkey");

                entity.ToTable("slide_answer", tb => tb.HasComment("Slide Question's Answer"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Comment)
                    .HasComment("Comment")
                    .HasColumnType("jsonb")
                    .HasColumnName("comment");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.IsCorrect)
                    .HasComment("Is correct answer")
                    .HasColumnName("is_correct");
                entity.Property(e => e.QuestionId)
                    .HasComment("Question")
                    .HasColumnName("question_id");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
                entity.Property(e => e.TextValue)
                    .HasComment("Answer")
                    .HasColumnType("jsonb")
                    .HasColumnName("text_value");
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
                    .HasConstraintName("slide_answer_create_uid_fkey");

                entity.HasOne(d => d.Question).WithMany(p => p.SlideAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("slide_answer_question_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_answer_write_uid_fkey");
            });
        }
    }
}