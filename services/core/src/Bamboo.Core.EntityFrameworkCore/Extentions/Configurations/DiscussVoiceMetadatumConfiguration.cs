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
        public static void ConfigureDiscussVoiceMetadatum(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscussVoiceMetadatum>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("discuss_voice_metadata_pkey");

                entity.ToTable("discuss_voice_metadata");

                entity.HasIndex(e => e.AttachmentId, "discuss_voice_metadata__attachment_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AttachmentId).HasColumnName("attachment_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Attachment).WithMany(p => p.DiscussVoiceMetadata)
                    .HasForeignKey(d => d.AttachmentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("discuss_voice_metadata_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_voice_metadata_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("discuss_voice_metadata_write_uid_fkey");
            });
        }
    }
}