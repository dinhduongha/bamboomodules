using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventQuizAnswer(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventQuizAnswer>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_quiz_answer_pkey");

                        entity.ToTable("event_quiz_answer");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.QuestionId, "event_quiz_answer__question_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AwardedPoints).HasColumnName("awarded_points");
                        entity.Property(e => e.Comment)
                            .HasColumnType("jsonb")
                            .HasColumnName("comment");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
                        entity.Property(e => e.QuestionId).HasColumnName("question_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TextValue)
                            .HasColumnType("jsonb")
                            .HasColumnName("text_value");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventQuizAnswerCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_quiz_answer_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_quiz_answer_create_uid_fkey");

                        entity.HasOne(d => d.Question).WithMany(p => p.EventQuizAnswer)
                            .HasForeignKey(d => d.QuestionId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_quiz_answer_question_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventQuizAnswerWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_quiz_answer_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_quiz_answer_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}