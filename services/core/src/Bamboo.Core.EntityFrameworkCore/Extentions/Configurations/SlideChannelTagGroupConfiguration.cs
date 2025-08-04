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
        public static void ConfigureSlideChannelTagGroup(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlideChannelTagGroup>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("slide_channel_tag_group_pkey");

                entity.ToTable("slide_channel_tag_group", tb => tb.HasComment("Channel/Course Groups"));

                entity.HasIndex(e => e.IsPublished, "slide_channel_tag_group_is_published_index");

                entity.HasIndex(e => e.Sequence, "slide_channel_tag_group_sequence_index");

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
                entity.Property(e => e.IsPublished)
                    .HasComment("Is Published")
                    .HasColumnName("is_published");
                entity.Property(e => e.Name)
                    .HasComment("Group Name")
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
                    .HasConstraintName("slide_channel_tag_group_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_tag_group_write_uid_fkey");
            });
        }
    }
}