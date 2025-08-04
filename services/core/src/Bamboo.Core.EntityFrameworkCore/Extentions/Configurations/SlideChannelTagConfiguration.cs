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
        public static void ConfigureSlideChannelTag(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideChannelTag>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("slide_channel_tag_pkey");

                entity.ToTable("slide_channel_tag", tb => tb.HasComment("Channel/Course Tag"));

                entity.HasIndex(e => e.GroupId, "slide_channel_tag_group_id_index");

                entity.HasIndex(e => e.Sequence, "slide_channel_tag_sequence_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Color)
                    .HasComment("Color Index")
                    .HasColumnName("color");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.GroupId)
                    .HasComment("Group")
                    .HasColumnName("group_id");
                entity.Property(e => e.GroupSequence)
                    .HasComment("Group sequence")
                    .HasColumnName("group_sequence");
                entity.Property(e => e.Name)
                    .HasComment("Name")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
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
                    .HasConstraintName("slide_channel_tag_create_uid_fkey");

                entity.HasOne(d => d.Group).WithMany(p => p.SlideChannelTags)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("slide_channel_tag_group_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_tag_write_uid_fkey");
            });
        }
    }
}