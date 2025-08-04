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
        public static void ConfigureImLivechatChannel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImLivechatChannel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("im_livechat_channel_pkey");

                entity.ToTable("im_livechat_channel", tb => tb.HasComment("Livechat Channel"));

                entity.HasIndex(e => e.IsPublished, "im_livechat_channel_is_published_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ButtonBackgroundColor)
                    .HasComment("Button Background Color")
                    .HasColumnType("character varying")
                    .HasColumnName("button_background_color");
                entity.Property(e => e.ButtonText)
                    .HasComment("Text of the Button")
                    .HasColumnType("character varying")
                    .HasColumnName("button_text");
                entity.Property(e => e.ButtonTextColor)
                    .HasComment("Button Text Color")
                    .HasColumnType("character varying")
                    .HasColumnName("button_text_color");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.DefaultMessage)
                    .HasComment("Welcome Message")
                    .HasColumnType("character varying")
                    .HasColumnName("default_message");
                entity.Property(e => e.HeaderBackgroundColor)
                    .HasComment("Header Background Color")
                    .HasColumnType("character varying")
                    .HasColumnName("header_background_color");
                entity.Property(e => e.InputPlaceholder)
                    .HasComment("Chat Input Placeholder")
                    .HasColumnType("character varying")
                    .HasColumnName("input_placeholder");
                entity.Property(e => e.IsPublished)
                    .HasComment("Is Published")
                    .HasColumnName("is_published");
                entity.Property(e => e.Name)
                    .HasComment("Channel Name")
                    .HasColumnType("character varying")
                    .HasColumnName("name");
                entity.Property(e => e.TitleColor)
                    .HasComment("Title Color")
                    .HasColumnType("character varying")
                    .HasColumnName("title_color");
                entity.Property(e => e.WebsiteDescription)
                    .HasComment("Website description")
                    .HasColumnType("jsonb")
                    .HasColumnName("website_description");
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
                    .HasConstraintName("im_livechat_channel_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("im_livechat_channel_write_uid_fkey");

                entity.HasMany(d => d.Users).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ImLivechatChannelImUser",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("im_livechat_channel_im_user_user_id_fkey"),
                        l => l.HasOne<ImLivechatChannel>().WithMany()
                            .HasForeignKey("ChannelId")
                            .HasConstraintName("im_livechat_channel_im_user_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("ChannelId", "UserId").HasName("im_livechat_channel_im_user_pkey");
                            j.ToTable("im_livechat_channel_im_user", tb => tb.HasComment("RELATION BETWEEN im_livechat_channel AND res_users"));
                            j.HasIndex(new[] { "UserId", "ChannelId" }, "im_livechat_channel_im_user_user_id_channel_id_idx");
                            j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                            j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
                        });
            });
        }
    }
}