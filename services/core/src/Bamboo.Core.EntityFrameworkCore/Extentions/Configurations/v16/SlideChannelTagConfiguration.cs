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
        public static void ConfigureSlideChannelTag(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SlideChannelTag>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("slide_channel_tag_pkey");

            entity.ToTable("slide_channel_tag");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.GroupId, "slide_channel_tag__group_id_index");

            entity.HasIndex(e => e.GroupSequence, "slide_channel_tag__group_sequence_index");

            entity.HasIndex(e => e.Sequence, "slide_channel_tag__sequence_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.GroupSequence).HasColumnName("group_sequence");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SlideChannelTagCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("slide_channel_tag_create_uid_fkey");

            entity.HasOne(d => d.Group).WithMany(p => p.SlideChannelTag)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("slide_channel_tag_group_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SlideChannelTagWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("slide_channel_tag_write_uid_fkey");
            });
        }
    }
}
