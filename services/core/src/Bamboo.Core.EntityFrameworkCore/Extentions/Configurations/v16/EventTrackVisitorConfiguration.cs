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
        public static void ConfigureEventTrackVisitor(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventTrackVisitor>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_track_visitor_pkey");

            entity.ToTable("event_track_visitor");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.PartnerId, "event_track_visitor_partner_id_index");

            entity.HasIndex(e => e.TrackId, "event_track_visitor_track_id_index");

            entity.HasIndex(e => e.VisitorId, "event_track_visitor_visitor_id_index");

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
            entity.Property(e => e.IsBlacklisted).HasColumnName("is_blacklisted");
            entity.Property(e => e.IsWishlisted).HasColumnName("is_wishlisted");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.QuizCompleted).HasColumnName("quiz_completed");
            entity.Property(e => e.QuizPoints).HasColumnName("quiz_points");
            entity.Property(e => e.TrackId).HasColumnName("track_id");
            entity.Property(e => e.VisitorId).HasColumnName("visitor_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.EventTrackVisitorCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_track_visitor_create_uid_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.EventTrackVisitor)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_track_visitor_partner_id_fkey");

            entity.HasOne(d => d.Track).WithMany(p => p.EventTrackVisitor)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_track_visitor_track_id_fkey");

            entity.HasOne(d => d.Visitor).WithMany(p => p.EventTrackVisitor)
                .HasForeignKey(d => d.VisitorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_track_visitor_visitor_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.EventTrackVisitorWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("event_track_visitor_write_uid_fkey");
            });
        }
    }
}