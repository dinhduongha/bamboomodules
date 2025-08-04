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
        public static void ConfigureSlideQuestion(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideQuestion>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("slide_question_pkey");

                entity.ToTable("slide_question", tb => tb.HasComment("Content Quiz Question"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Question)
                    .HasComment("Question Name")
                    .HasColumnType("jsonb")
                    .HasColumnName("question");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
                entity.Property(e => e.SlideId)
                    .HasComment("Content")
                    .HasColumnName("slide_id");
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
                    .HasConstraintName("slide_question_create_uid_fkey");

                entity.HasOne(d => d.Slide).WithMany(p => p.SlideQuestions)
                    .HasForeignKey(d => d.SlideId)
                    .HasConstraintName("slide_question_slide_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_question_write_uid_fkey");
            });
        }
    }
}