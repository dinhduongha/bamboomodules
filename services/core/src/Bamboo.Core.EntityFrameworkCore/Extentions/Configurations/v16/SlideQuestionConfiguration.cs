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
        public static void ConfigureSlideQuestion(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SlideQuestion>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("slide_question_pkey");

            entity.ToTable("slide_question");

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
            entity.Property(e => e.Question)
                .HasColumnType("jsonb")
                .HasColumnName("question");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.SlideId).HasColumnName("slide_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SlideQuestionCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("slide_question_create_uid_fkey");

            entity.HasOne(d => d.Slide).WithMany(p => p.SlideQuestion)
                .HasForeignKey(d => d.SlideId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("slide_question_slide_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SlideQuestionWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("slide_question_write_uid_fkey");
            });
        }
    }
}