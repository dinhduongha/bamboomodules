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
        public static void ConfigureEventRegistrationAnswer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRegistrationAnswer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_registration_answer_pkey");

                entity.ToTable("event_registration_answer");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.QuestionId).HasColumnName("question_id");
                entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
                entity.Property(e => e.ValueAnswerId).HasColumnName("value_answer_id");
                entity.Property(e => e.ValueTextBox).HasColumnName("value_text_box");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_answer_create_uid_fkey");

                entity.HasOne(d => d.Question).WithMany(p => p.EventRegistrationAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("event_registration_answer_question_id_fkey");

                entity.HasOne(d => d.Registration).WithMany(p => p.EventRegistrationAnswers)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("event_registration_answer_registration_id_fkey");

                entity.HasOne(d => d.ValueAnswer).WithMany(p => p.EventRegistrationAnswers)
                    .HasForeignKey(d => d.ValueAnswerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_answer_value_answer_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_answer_write_uid_fkey");
            });
        }
    }
}