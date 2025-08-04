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
        public static void ConfigureImLivechatChannelRule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImLivechatChannelRule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("im_livechat_channel_rule_pkey");

                entity.ToTable("im_livechat_channel_rule", tb => tb.HasComment("Livechat Channel Rules"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Action)
                    .HasComment("Live Chat Button")
                    .HasColumnType("character varying")
                    .HasColumnName("action");
                entity.Property(e => e.AutoPopupTimer)
                    .HasComment("Open automatically timer")
                    .HasColumnName("auto_popup_timer");
                entity.Property(e => e.ChannelId)
                    .HasComment("Channel")
                    .HasColumnName("channel_id");
                entity.Property(e => e.ChatbotOnlyIfNoOperator)
                    .HasComment("Enabled only if no operator")
                    .HasColumnName("chatbot_only_if_no_operator");
                entity.Property(e => e.ChatbotScriptId)
                    .HasComment("Chatbot")
                    .HasColumnName("chatbot_script_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.RegexUrl)
                    .HasComment("URL Regex")
                    .HasColumnType("character varying")
                    .HasColumnName("regex_url");
                entity.Property(e => e.Sequence)
                    .HasComment("Matching order")
                    .HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Channel).WithMany(p => p.ImLivechatChannelRules)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("im_livechat_channel_rule_channel_id_fkey");

                entity.HasOne(d => d.ChatbotScript).WithMany(p => p.ImLivechatChannelRules)
                    .HasForeignKey(d => d.ChatbotScriptId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("im_livechat_channel_rule_chatbot_script_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("im_livechat_channel_rule_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("im_livechat_channel_rule_write_uid_fkey");

                entity.HasMany(d => d.Countries).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ImLivechatChannelCountryRel",
                        r => r.HasOne<ResCountry>().WithMany()
                            .HasForeignKey("CountryId")
                            .HasConstraintName("im_livechat_channel_country_rel_country_id_fkey"),
                        l => l.HasOne<ImLivechatChannelRule>().WithMany()
                            .HasForeignKey("ChannelId")
                            .HasConstraintName("im_livechat_channel_country_rel_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("ChannelId", "CountryId").HasName("im_livechat_channel_country_rel_pkey");
                            j.ToTable("im_livechat_channel_country_rel", tb => tb.HasComment("RELATION BETWEEN im_livechat_channel_rule AND res_country"));
                            j.HasIndex(new[] { "CountryId", "ChannelId" }, "im_livechat_channel_country_rel_country_id_channel_id_idx");
                            j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                            j.IndexerProperty<Guid>("CountryId").HasColumnName("country_id");
                        });
            });
        }
    }
}