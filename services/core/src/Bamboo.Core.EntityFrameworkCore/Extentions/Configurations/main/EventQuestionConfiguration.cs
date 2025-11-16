using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventQuestion(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventQuestion>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_question_pkey");

                        entity.ToTable("event_question");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
                        entity.Property(e => e.IsMandatoryAnswer).HasColumnName("is_mandatory_answer");
                        entity.Property(e => e.OncePerOrder).HasColumnName("once_per_order");
                        entity.Property(e => e.QuestionType).HasColumnName("question_type");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Title)
                            .HasColumnType("jsonb")
                            .HasColumnName("title");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventQuestionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_question_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_question_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventQuestion)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_question_event_id_fkey");

                        entity.HasOne(d => d.EventType).WithMany(p => p.EventQuestion)
                            .HasForeignKey(d => d.EventTypeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_question_event_type_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventQuestionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_question_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_question_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}