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
        public static void ConfigureResPartnerGrade(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResPartnerGrade>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_partner_grade_pkey");

            entity.ToTable("res_partner_grade");

            entity.HasIndex(e => e.IsPublished, "res_partner_grade__is_published_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.IsPublished).HasColumnName("is_published");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.PartnerWeight).HasColumnName("partner_weight");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ResPartnerGradeCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_grade_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ResPartnerGradeWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_partner_grade_write_uid_fkey");
            });
        }
    }
}
