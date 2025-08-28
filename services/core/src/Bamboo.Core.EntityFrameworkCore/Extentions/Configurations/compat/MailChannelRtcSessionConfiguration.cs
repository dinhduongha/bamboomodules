using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMailChannelRtcSession(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MailChannelRtcSession>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mail_channel_rtc_session_pkey");

                        entity.ToTable("mail_channel_rtc_session");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ChannelMemberId, "mail_channel_rtc_session_channel_member_unique").IsUnique();

                        entity.HasIndex(e => e.LastModificationTime, "mail_channel_rtc_session_write_date_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
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
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Channel).WithMany(p => p.MailChannelRtcSession)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_rtc_session_channel_id_fkey");

                        entity.HasOne(d => d.ChannelMember).WithOne(p => p.MailChannelRtcSession)
                            .HasForeignKey<MailChannelRtcSession>(d => d.ChannelMemberId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mail_channel_rtc_session_channel_member_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MailChannelRtcSessionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_channel_rtc_session_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_rtc_session_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MailChannelRtcSessionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mail_channel_rtc_session_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mail_channel_rtc_session_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}