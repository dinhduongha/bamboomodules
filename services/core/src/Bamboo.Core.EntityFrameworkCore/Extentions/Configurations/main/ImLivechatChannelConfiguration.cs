using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureImLivechatChannel(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ImLivechatChannel>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("im_livechat_channel_pkey");

                        entity.ToTable("im_livechat_channel");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BlockAssignmentDuringCall).HasColumnName("block_assignment_during_call");
                        entity.Property(e => e.ButtonBackgroundColor).HasColumnName("button_background_color");
                        entity.Property(e => e.ButtonText)
                            .HasColumnType("jsonb")
                            .HasColumnName("button_text");
                        entity.Property(e => e.ButtonTextColor).HasColumnName("button_text_color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefaultMessage)
                            .HasColumnType("jsonb")
                            .HasColumnName("default_message");
                        entity.Property(e => e.HeaderBackgroundColor).HasColumnName("header_background_color");
                        entity.Property(e => e.MaxSessions).HasColumnName("max_sessions");
                        entity.Property(e => e.MaxSessionsMode).HasColumnName("max_sessions_mode");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ReviewLink).HasColumnName("review_link");
                        entity.Property(e => e.TitleColor).HasColumnName("title_color");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ImLivechatChannelCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("im_livechat_channel_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ImLivechatChannelWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("im_livechat_channel_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}