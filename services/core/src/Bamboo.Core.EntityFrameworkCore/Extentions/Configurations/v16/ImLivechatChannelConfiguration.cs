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

                        entity.HasIndex(e => e.IsPublished, "im_livechat_channel__is_published_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
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
                        entity.Property(e => e.InputPlaceholder)
                            .HasColumnType("jsonb")
                            .HasColumnName("input_placeholder");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.TitleColor).HasColumnName("title_color");
                        entity.Property(e => e.WebsiteDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_description");
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

                        // entity.HasMany(d => d.User).WithMany(p => p.Channel)
                        entity.HasMany(d => d.User).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ImLivechatChannelImUser",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("UserId")
                                    .HasConstraintName("im_livechat_channel_im_user_user_id_fkey"),
                                l => l.HasOne<ImLivechatChannel>().WithMany()
                                    .HasForeignKey("ChannelId")
                                    .HasConstraintName("im_livechat_channel_im_user_channel_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ChannelId", "UserId").HasName("im_livechat_channel_im_user_pkey");
                                    j.ToTable("im_livechat_channel_im_user");
                                    j.HasIndex(new[] { "UserId", "ChannelId" }, "im_livechat_channel_im_user_user_id_channel_id_idx");
                                    j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                                    j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}