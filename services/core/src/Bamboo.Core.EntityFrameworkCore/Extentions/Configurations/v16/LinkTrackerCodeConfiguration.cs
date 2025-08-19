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
        public static void ConfigureLinkTrackerCode(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LinkTrackerCode>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("link_tracker_code_pkey");

            entity.ToTable("link_tracker_code");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.Code, "link_tracker_code_code").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.LinkId).HasColumnName("link_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.LinkTrackerCodeCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("link_tracker_code_create_uid_fkey");

            entity.HasOne(d => d.Link).WithMany(p => p.LinkTrackerCode)
                .HasForeignKey(d => d.LinkId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("link_tracker_code_link_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.LinkTrackerCodeWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("link_tracker_code_write_uid_fkey");
            });
        }
    }
}