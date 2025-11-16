using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureDiscussChannelRtcSession(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<DiscussChannelRtcSession>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("discuss_channel_rtc_session_pkey");

                        entity.ToTable("discuss_channel_rtc_session");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ChannelId, "discuss_channel_rtc_session__channel_id_index").HasFilter("(channel_id IS NOT NULL)");

                        entity.HasIndex(e => e.PartnerId, "discuss_channel_rtc_session__partner_id_index");

                        entity.HasIndex(e => e.LastModificationTime, "discuss_channel_rtc_session__write_date_index");

                        entity.HasIndex(e => e.ChannelMemberId, "discuss_channel_rtc_session_channel_member_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                        entity.Property(e => e.ChannelMemberId).HasColumnName("channel_member_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsCameraOn).HasColumnName("is_camera_on");
                        entity.Property(e => e.IsDeaf).HasColumnName("is_deaf");
                        entity.Property(e => e.IsMuted).HasColumnName("is_muted");
                        entity.Property(e => e.IsScreenSharingOn).HasColumnName("is_screen_sharing_on");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Channel).WithMany(p => p.DiscussChannelRtcSession)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_rtc_session_channel_id_fkey");

                        entity.HasOne(d => d.ChannelMember).WithOne(p => p.DiscussChannelRtcSession)
                            .HasForeignKey<DiscussChannelRtcSession>(d => d.ChannelMemberId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("discuss_channel_rtc_session_channel_member_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.DiscussChannelRtcSessionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("discuss_channel_rtc_session_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_rtc_session_create_uid_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.DiscussChannelRtcSession) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("discuss_channel_rtc_session_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_rtc_session_partner_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.DiscussChannelRtcSessionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("discuss_channel_rtc_session_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_rtc_session_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}