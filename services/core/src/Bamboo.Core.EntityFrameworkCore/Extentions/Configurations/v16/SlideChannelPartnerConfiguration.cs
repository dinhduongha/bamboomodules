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
        public static void ConfigureSlideChannelPartner(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SlideChannelPartner>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("slide_channel_partner_pkey");

            entity.ToTable("slide_channel_partner");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.ChannelId, "slide_channel_partner__channel_id_index");

            entity.HasIndex(e => e.PartnerId, "slide_channel_partner__partner_id_index");

            entity.HasIndex(e => new { e.ChannelId, e.PartnerId }, "slide_channel_partner_channel_partner_uniq").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.ChannelId).HasColumnName("channel_id");
            entity.Property(e => e.Completed).HasColumnName("completed");
            entity.Property(e => e.CompletedSlidesCount).HasColumnName("completed_slides_count");
            entity.Property(e => e.Completion).HasColumnName("completion");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.LastInvitationDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_invitation_date");
            entity.Property(e => e.MemberStatus).HasColumnName("member_status");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.SurveyCertificationSuccess).HasColumnName("survey_certification_success");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Channel).WithMany(p => p.SlideChannelPartner)
                .HasForeignKey(d => d.ChannelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("slide_channel_partner_channel_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SlideChannelPartnerCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("slide_channel_partner_create_uid_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.SlideChannelPartner)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("slide_channel_partner_partner_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SlideChannelPartnerWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("slide_channel_partner_write_uid_fkey");
            });
        }
    }
}
