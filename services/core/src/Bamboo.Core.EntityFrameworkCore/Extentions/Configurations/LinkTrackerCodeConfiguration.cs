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
        public static void ConfigureLinkTrackerCode(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkTrackerCode>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("link_tracker_code_pkey");

                entity.ToTable("link_tracker_code", tb => tb.HasComment("Link Tracker Code"));

                entity.HasIndex(e => e.Code, "link_tracker_code_code").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Code)
                    .HasComment("Short URL Code")
                    .HasColumnType("character varying")
                    .HasColumnName("code");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.LinkId)
                    .HasComment("Link")
                    .HasColumnName("link_id");
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
                    .HasConstraintName("link_tracker_code_create_uid_fkey");

                entity.HasOne(d => d.Link).WithMany(p => p.LinkTrackerCodes)
                    .HasForeignKey(d => d.LinkId)
                    .HasConstraintName("link_tracker_code_link_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_code_write_uid_fkey");
            });
        }
    }
}