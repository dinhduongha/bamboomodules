using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureDiscussCallHistory(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<DiscussCallHistory>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("discuss_call_history_pkey");

                        entity.ToTable("discuss_call_history");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ChannelId, "discuss_call_history__channel_id_index");

                        entity.HasIndex(e => e.StartCallMessageId, "discuss_call_history__start_call_message_id_index");

                        entity.HasIndex(e => e.StartDt, "discuss_call_history__start_dt_index");

                        entity.HasIndex(e => new { e.ChannelId, e.EndDt }, "discuss_call_history_channel_id_end_dt_idx").HasFilter("(end_dt IS NULL)");

                        entity.HasIndex(e => e.StartCallMessageId, "discuss_call_history_message_id_unique_constraint").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EndDt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("end_dt");
                        entity.Property(e => e.StartCallMessageId).HasColumnName("start_call_message_id");
                        entity.Property(e => e.StartDt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("start_dt");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Channel).WithMany(p => p.DiscussCallHistory)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("discuss_call_history_channel_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.DiscussCallHistoryCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("discuss_call_history_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_call_history_create_uid_fkey");

                        entity.HasOne(d => d.StartCallMessage).WithOne(p => p.DiscussCallHistory)
                            .HasForeignKey<DiscussCallHistory>(d => d.StartCallMessageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_call_history_start_call_message_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.DiscussCallHistoryWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("discuss_call_history_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_call_history_write_uid_fkey");

                        // entity.HasMany(d => d.ImLivechatChannelMemberHistory).WithMany(p => p.DiscussCallHistory)
                        entity.HasMany(d => d.ImLivechatChannelMemberHistory).WithMany(p => p.DiscussCallHistory)
                            .UsingEntity<Dictionary<string, object>>(
                                "DiscussCallHistoryImLivechatChannelMemberHistoryRel",
                                r => r.HasOne<ImLivechatChannelMemberHistory>().WithMany()
                                    .HasForeignKey("ImLivechatChannelMemberHistoryId")
                                    .HasConstraintName("discuss_call_history_im_livec_im_livechat_channel_member_h_fkey"),
                                l => l.HasOne<DiscussCallHistory>().WithMany()
                                    .HasForeignKey("DiscussCallHistoryId")
                                    .HasConstraintName("discuss_call_history_im_livechat_c_discuss_call_history_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DiscussCallHistoryId", "ImLivechatChannelMemberHistoryId").HasName("discuss_call_history_im_livechat_channel_member_history_re_pkey");
                                    j.ToTable("discuss_call_history_im_livechat_channel_member_history_rel");
                                    j.HasIndex(new[] { "ImLivechatChannelMemberHistoryId", "DiscussCallHistoryId" }, "discuss_call_history_im_livec_im_livechat_channel_member_hi_idx");
                                    j.IndexerProperty<Guid>("DiscussCallHistoryId").HasColumnName("discuss_call_history_id");
                                    j.IndexerProperty<Guid>("ImLivechatChannelMemberHistoryId").HasColumnName("im_livechat_channel_member_history_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}