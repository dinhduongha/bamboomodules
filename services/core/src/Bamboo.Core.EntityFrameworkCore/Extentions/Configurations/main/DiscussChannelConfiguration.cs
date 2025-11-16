using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureDiscussChannel(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<DiscussChannel>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("discuss_channel_pkey");

                        entity.ToTable("discuss_channel");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LastInterestDt, "discuss_channel__last_interest_dt_index");

                        entity.HasIndex(e => e.LivechatChannelId, "discuss_channel__livechat_channel_id_index").HasFilter("(livechat_channel_id IS NOT NULL)");

                        entity.HasIndex(e => e.LivechatOperatorId, "discuss_channel__livechat_operator_id_index").HasFilter("(livechat_operator_id IS NOT NULL)");

                        entity.HasIndex(e => e.LivechatVisitorId, "discuss_channel__livechat_visitor_id_index").HasFilter("(livechat_visitor_id IS NOT NULL)");

                        entity.HasIndex(e => e.ParentChannelId, "discuss_channel__parent_channel_id_index");

                        entity.HasIndex(e => e.FromMessageId, "discuss_channel_from_message_id_unique").IsUnique();

                        entity.HasIndex(e => e.HasCrmLead, "discuss_channel_has_crm_lead_index").HasFilter("(has_crm_lead IS TRUE)");

                        entity.HasIndex(e => new { e.ChannelType, e.CreationTime }, "discuss_channel_livechat_channel_type_create_date_idx").HasFilter("(channel_type = 'livechat'::text)");

                        entity.HasIndex(e => e.LivechatEndDt, "discuss_channel_livechat_end_dt_idx").HasFilter("(livechat_end_dt IS NULL)");

                        entity.HasIndex(e => e.LivechatFailure, "discuss_channel_livechat_failure_idx").HasFilter("(livechat_failure = ANY (ARRAY[('no_answer'::character varying)::text, ('no_agent'::character varying)::text]))");

                        entity.HasIndex(e => e.LivechatIsEscalated, "discuss_channel_livechat_is_escalated_idx").HasFilter("(livechat_is_escalated IS TRUE)");

                        entity.HasIndex(e => e.Uuid, "discuss_channel_uuid_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.ChannelType).HasColumnName("channel_type");
                        entity.Property(e => e.ChatbotCurrentStepId).HasColumnName("chatbot_current_step_id");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefaultDisplayMode).HasColumnName("default_display_mode");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.FromMessageId).HasColumnName("from_message_id");
                        entity.Property(e => e.GroupPublicId).HasColumnName("group_public_id");
                        entity.Property(e => e.HasCrmLead).HasColumnName("has_crm_lead");
                        entity.Property(e => e.IsPendingChatRequest).HasColumnName("is_pending_chat_request");
                        entity.Property(e => e.LastInterestDt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_interest_dt");
                        entity.Property(e => e.LivechatAgentProvidingHelpHistory).HasColumnName("livechat_agent_providing_help_history");
                        entity.Property(e => e.LivechatAgentRequestingHelpHistory).HasColumnName("livechat_agent_requesting_help_history");
                        entity.Property(e => e.LivechatChannelId).HasColumnName("livechat_channel_id");
                        entity.Property(e => e.LivechatEndDt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("livechat_end_dt");
                        entity.Property(e => e.LivechatFailure).HasColumnName("livechat_failure");
                        entity.Property(e => e.LivechatIsEscalated).HasColumnName("livechat_is_escalated");
                        entity.Property(e => e.LivechatLangId).HasColumnName("livechat_lang_id");
                        entity.Property(e => e.LivechatNote).HasColumnName("livechat_note");
                        entity.Property(e => e.LivechatOperatorId).HasColumnName("livechat_operator_id");
                        entity.Property(e => e.LivechatOutcome).HasColumnName("livechat_outcome");
                        entity.Property(e => e.LivechatStartHour).HasColumnName("livechat_start_hour");
                        entity.Property(e => e.LivechatStatus).HasColumnName("livechat_status");
                        entity.Property(e => e.LivechatVisitorId).HasColumnName("livechat_visitor_id");
                        entity.Property(e => e.LivechatWeekDay).HasColumnName("livechat_week_day");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ParentChannelId).HasColumnName("parent_channel_id");
                        entity.Property(e => e.RatingLastText).HasColumnName("rating_last_text");
                        entity.Property(e => e.RatingLastValue).HasColumnName("rating_last_value");
                        entity.Property(e => e.SfuChannelUuid).HasColumnName("sfu_channel_uuid");
                        entity.Property(e => e.SfuServerUrl).HasColumnName("sfu_server_url");
                        entity.Property(e => e.Uuid).HasColumnName("uuid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.ChatbotCurrentStep).WithMany(p => p.DiscussChannel)
                            .HasForeignKey(d => d.ChatbotCurrentStepId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_chatbot_current_step_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.DiscussChannel) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("discuss_channel_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.DiscussChannelCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("discuss_channel_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_create_uid_fkey");

                        entity.HasOne(d => d.FromMessage).WithOne(p => p.DiscussChannel)
                            .HasForeignKey<DiscussChannel>(d => d.FromMessageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_from_message_id_fkey");

                        entity.HasOne(d => d.GroupPublic).WithMany(p => p.DiscussChannel)
                            .HasForeignKey(d => d.GroupPublicId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_group_public_id_fkey");

                        entity.HasOne(d => d.LivechatAgentProvidingHelpHistoryNavigation).WithMany(p => p.DiscussChannelLivechatAgentProvidingHelpHistoryNavigation)
                            .HasForeignKey(d => d.LivechatAgentProvidingHelpHistory)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_livechat_agent_providing_help_history_fkey");

                        entity.HasOne(d => d.LivechatAgentRequestingHelpHistoryNavigation).WithMany(p => p.DiscussChannelLivechatAgentRequestingHelpHistoryNavigation)
                            .HasForeignKey(d => d.LivechatAgentRequestingHelpHistory)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_livechat_agent_requesting_help_history_fkey");

                        entity.HasOne(d => d.LivechatChannel).WithMany(p => p.DiscussChannel)
                            .HasForeignKey(d => d.LivechatChannelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_livechat_channel_id_fkey");

                        entity.HasOne(d => d.LivechatLang).WithMany(p => p.DiscussChannel)
                            .HasForeignKey(d => d.LivechatLangId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_livechat_lang_id_fkey");

                        // entity.HasOne(d => d.LivechatOperator).WithMany(p => p.DiscussChannel) .HasForeignKey(d => d.LivechatOperatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("discuss_channel_livechat_operator_id_fkey");
                        entity.HasOne(d => d.LivechatOperator).WithMany()
                            .HasForeignKey(d => d.LivechatOperatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_livechat_operator_id_fkey");

                        entity.HasOne(d => d.LivechatVisitor).WithMany(p => p.DiscussChannel)
                            .HasForeignKey(d => d.LivechatVisitorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_livechat_visitor_id_fkey");

                        entity.HasOne(d => d.ParentChannel).WithMany(p => p.InverseParentChannel)
                            .HasForeignKey(d => d.ParentChannelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("discuss_channel_parent_channel_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.DiscussChannelWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("discuss_channel_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("discuss_channel_write_uid_fkey");

                        // entity.HasMany(d => d.HrDepartment).WithMany(p => p.DiscussChannel)
                        entity.HasMany(d => d.HrDepartment).WithMany(p => p.DiscussChannel)
                            .UsingEntity<Dictionary<string, object>>(
                                "DiscussChannelHrDepartmentRel",
                                r => r.HasOne<HrDepartment>().WithMany()
                                    .HasForeignKey("HrDepartmentId")
                                    .HasConstraintName("discuss_channel_hr_department_rel_hr_department_id_fkey"),
                                l => l.HasOne<DiscussChannel>().WithMany()
                                    .HasForeignKey("DiscussChannelId")
                                    .HasConstraintName("discuss_channel_hr_department_rel_discuss_channel_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DiscussChannelId", "HrDepartmentId").HasName("discuss_channel_hr_department_rel_pkey");
                                    j.ToTable("discuss_channel_hr_department_rel");
                                    j.HasIndex(new[] { "HrDepartmentId", "DiscussChannelId" }, "discuss_channel_hr_department_hr_department_id_discuss_chan_idx");
                                    j.IndexerProperty<Guid>("DiscussChannelId").HasColumnName("discuss_channel_id");
                                    j.IndexerProperty<Guid>("HrDepartmentId").HasColumnName("hr_department_id");
                                });

                        // entity.HasMany(d => d.ImLivechatConversationTag).WithMany(p => p.DiscussChannel)
                        entity.HasMany(d => d.ImLivechatConversationTag).WithMany(p => p.DiscussChannel)
                            .UsingEntity<Dictionary<string, object>>(
                                "LivechatConversationTagRel",
                                r => r.HasOne<ImLivechatConversationTag>().WithMany()
                                    .HasForeignKey("ImLivechatConversationTagId")
                                    .HasConstraintName("livechat_conversation_tag_rel_im_livechat_conversation_tag_fkey"),
                                l => l.HasOne<DiscussChannel>().WithMany()
                                    .HasForeignKey("DiscussChannelId")
                                    .HasConstraintName("livechat_conversation_tag_rel_discuss_channel_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DiscussChannelId", "ImLivechatConversationTagId").HasName("livechat_conversation_tag_rel_pkey");
                                    j.ToTable("livechat_conversation_tag_rel");
                                    j.HasIndex(new[] { "ImLivechatConversationTagId", "DiscussChannelId" }, "livechat_conversation_tag_rel_im_livechat_conversation_tag__idx");
                                    j.IndexerProperty<Guid>("DiscussChannelId").HasColumnName("discuss_channel_id");
                                    j.IndexerProperty<Guid>("ImLivechatConversationTagId").HasColumnName("im_livechat_conversation_tag_id");
                                });

                        // entity.HasMany(d => d.ImLivechatExpertise).WithMany(p => p.DiscussChannel)
                        entity.HasMany(d => d.ImLivechatExpertise).WithMany(p => p.DiscussChannel)
                            .UsingEntity<Dictionary<string, object>>(
                                "DiscussChannelImLivechatExpertiseRel",
                                r => r.HasOne<ImLivechatExpertise>().WithMany()
                                    .HasForeignKey("ImLivechatExpertiseId")
                                    .HasConstraintName("discuss_channel_im_livechat_exper_im_livechat_expertise_id_fkey"),
                                l => l.HasOne<DiscussChannel>().WithMany()
                                    .HasForeignKey("DiscussChannelId")
                                    .HasConstraintName("discuss_channel_im_livechat_expertise_r_discuss_channel_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DiscussChannelId", "ImLivechatExpertiseId").HasName("discuss_channel_im_livechat_expertise_rel_pkey");
                                    j.ToTable("discuss_channel_im_livechat_expertise_rel");
                                    j.HasIndex(new[] { "ImLivechatExpertiseId", "DiscussChannelId" }, "discuss_channel_im_livechat_e_im_livechat_expertise_id_disc_idx");
                                    j.IndexerProperty<Guid>("DiscussChannelId").HasColumnName("discuss_channel_id");
                                    j.IndexerProperty<Guid>("ImLivechatExpertiseId").HasColumnName("im_livechat_expertise_id");
                                });

                        // entity.HasMany(d => d.ResGroups).WithMany(p => p.DiscussChannelNavigation)
                        entity.HasMany(d => d.ResGroups).WithMany(p => p.DiscussChannelNavigation)
                            .UsingEntity<Dictionary<string, object>>(
                                "DiscussChannelResGroupsRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("ResGroupsId")
                                    .HasConstraintName("discuss_channel_res_groups_rel_res_groups_id_fkey"),
                                l => l.HasOne<DiscussChannel>().WithMany()
                                    .HasForeignKey("DiscussChannelId")
                                    .HasConstraintName("discuss_channel_res_groups_rel_discuss_channel_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DiscussChannelId", "ResGroupsId").HasName("discuss_channel_res_groups_rel_pkey");
                                    j.ToTable("discuss_channel_res_groups_rel");
                                    j.HasIndex(new[] { "ResGroupsId", "DiscussChannelId" }, "discuss_channel_res_groups_re_res_groups_id_discuss_channel_idx");
                                    j.IndexerProperty<Guid>("DiscussChannelId").HasColumnName("discuss_channel_id");
                                    j.IndexerProperty<Guid>("ResGroupsId").HasColumnName("res_groups_id");
                                });

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.DiscussChannelNavigation)
                        entity.HasMany(d => d.ResPartner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ImLivechatChannelMemberHistoryDiscussChannelAgentRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("im_livechat_channel_member_history_discuss__res_partner_id_fkey"),
                                l => l.HasOne<DiscussChannel>().WithMany()
                                    .HasForeignKey("DiscussChannelId")
                                    .HasConstraintName("im_livechat_channel_member_history_disc_discuss_channel_id_fkey"),
                                j =>
                                {
                                    j.HasKey("DiscussChannelId", "ResPartnerId").HasName("im_livechat_channel_member_history_discuss_channel_agent_r_pkey");
                                    j.ToTable("im_livechat_channel_member_history_discuss_channel_agent_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "DiscussChannelId" }, "im_livechat_channel_member_hi_res_partner_id_discuss_channe_idx");
                                    j.IndexerProperty<Guid>("DiscussChannelId").HasColumnName("discuss_channel_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                        // entity.HasMany(d => d.ResPartner1).WithMany(p => p.DiscussChannel2)
                        entity.HasMany(d => d.ResPartner1).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ImLivechatChannelMemberHistoryDiscussChannelCustomerRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("im_livechat_channel_member_history_discuss_res_partner_id_fkey2"),
                                l => l.HasOne<DiscussChannel>().WithMany()
                                    .HasForeignKey("DiscussChannelId")
                                    .HasConstraintName("im_livechat_channel_member_history_dis_discuss_channel_id_fkey2"),
                                j =>
                                {
                                    j.HasKey("DiscussChannelId", "ResPartnerId").HasName("im_livechat_channel_member_history_discuss_channel_custome_pkey");
                                    j.ToTable("im_livechat_channel_member_history_discuss_channel_customer_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "DiscussChannelId" }, "im_livechat_channel_member_hi_res_partner_id_discuss_chann_idx2");
                                    j.IndexerProperty<Guid>("DiscussChannelId").HasColumnName("discuss_channel_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                        // entity.HasMany(d => d.ResPartnerNavigation).WithMany(p => p.DiscussChannel1)
                        entity.HasMany(d => d.ResPartnerNavigation).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ImLivechatChannelMemberHistoryDiscussChannelBotRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("im_livechat_channel_member_history_discuss_res_partner_id_fkey1"),
                                l => l.HasOne<DiscussChannel>().WithMany()
                                    .HasForeignKey("DiscussChannelId")
                                    .HasConstraintName("im_livechat_channel_member_history_dis_discuss_channel_id_fkey1"),
                                j =>
                                {
                                    j.HasKey("DiscussChannelId", "ResPartnerId").HasName("im_livechat_channel_member_history_discuss_channel_bot_rel_pkey");
                                    j.ToTable("im_livechat_channel_member_history_discuss_channel_bot_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "DiscussChannelId" }, "im_livechat_channel_member_hi_res_partner_id_discuss_chann_idx1");
                                    j.IndexerProperty<Guid>("DiscussChannelId").HasColumnName("discuss_channel_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}