using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("im_livechat_channel_rule");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ChannelId, "im_livechat_channel_rule__channel_id_index").HasFilter("(channel_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Action).HasColumnName("action");
                        entity.Property(e => e.AutoPopupTimer).HasColumnName("auto_popup_timer");
                        entity.Property(e => e.ChannelId).HasColumnName("channel_id");
                        entity.Property(e => e.ChatbotEnabledCondition).HasColumnName("chatbot_enabled_condition");
                        entity.Property(e => e.ChatbotScriptId).HasColumnName("chatbot_script_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.RegexUrl).HasColumnName("regex_url");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Channel).WithMany(p => p.ImLivechatChannelRule)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_rule_channel_id_fkey");

                        entity.HasOne(d => d.ChatbotScript).WithMany(p => p.ImLivechatChannelRule)
                            .HasForeignKey(d => d.ChatbotScriptId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_rule_chatbot_script_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ImLivechatChannelRuleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("im_livechat_channel_rule_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_rule_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ImLivechatChannelRuleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("im_livechat_channel_rule_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("im_livechat_channel_rule_write_uid_fkey");

                        // entity.HasMany(d => d.Country).WithMany(p => p.Channel)
                        entity.HasMany(d => d.Country).WithMany()
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
                                    j.ToTable("im_livechat_channel_country_rel");
                                    j.HasIndex(new[] { "CountryId", "ChannelId" }, "im_livechat_channel_country_rel_country_id_channel_id_idx");
                                    j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                                    j.IndexerProperty<Guid>("CountryId").HasColumnName("country_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}