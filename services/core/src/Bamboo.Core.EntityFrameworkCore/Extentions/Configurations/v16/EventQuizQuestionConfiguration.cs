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
        public static void ConfigureEventQuizQuestion(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventQuizQuestion>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_quiz_question_pkey");

            entity.ToTable("event_quiz_question");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.EventQuizQuestionCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_quiz_question_create_uid_fkey");

            entity.HasOne(d => d.Quiz).WithMany(p => p.EventQuizQuestion)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_quiz_question_quiz_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.EventQuizQuestionWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_quiz_question_write_uid_fkey");
            });
        }
    }
}