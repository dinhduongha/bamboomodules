using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureChatbotScriptStep(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ChatbotScriptStep>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("chatbot_script_step_pkey");

                        entity.ToTable("chatbot_script_step");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ChatbotScriptId, "chatbot_script_step__chatbot_script_id_index");

                        entity.HasIndex(e => e.CrmTeamId, "chatbot_script_step__crm_team_id_index").HasFilter("(crm_team_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ChatbotScriptId).HasColumnName("chatbot_script_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CrmTeamId).HasColumnName("crm_team_id");
                        entity.Property(e => e.Message)
                            .HasColumnType("jsonb")
                            .HasColumnName("message");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.StepType).HasColumnName("step_type");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.ChatbotScript).WithMany(p => p.ChatbotScriptStep)
                            .HasForeignKey(d => d.ChatbotScriptId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("chatbot_script_step_chatbot_script_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ChatbotScriptStepCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("chatbot_script_step_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_script_step_create_uid_fkey");

                        entity.HasOne(d => d.CrmTeam).WithMany(p => p.ChatbotScriptStep)
                            .HasForeignKey(d => d.CrmTeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_script_step_crm_team_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ChatbotScriptStepWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("chatbot_script_step_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_script_step_write_uid_fkey");

                        // entity.HasMany(d => d.ChatbotScriptAnswerNavigation).WithMany(p => p.ChatbotScriptStep)
                        entity.HasMany(d => d.ChatbotScriptAnswerNavigation).WithMany(p => p.ChatbotScriptStep)
                            .UsingEntity<Dictionary<string, object>>(
                                "ChatbotScriptAnswerChatbotScriptStepRel",
                                r => r.HasOne<ChatbotScriptAnswer>().WithMany()
                                    .HasForeignKey("ChatbotScriptAnswerId")
                                    .HasConstraintName("chatbot_script_answer_chatbot_scr_chatbot_script_answer_id_fkey"),
                                l => l.HasOne<ChatbotScriptStep>().WithMany()
                                    .HasForeignKey("ChatbotScriptStepId")
                                    .HasConstraintName("chatbot_script_answer_chatbot_scrip_chatbot_script_step_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ChatbotScriptStepId", "ChatbotScriptAnswerId").HasName("chatbot_script_answer_chatbot_script_step_rel_pkey");
                                    j.ToTable("chatbot_script_answer_chatbot_script_step_rel");
                                    j.HasIndex(new[] { "ChatbotScriptAnswerId", "ChatbotScriptStepId" }, "chatbot_script_answer_chatbot_chatbot_script_answer_id_chat_idx");
                                    j.IndexerProperty<Guid>("ChatbotScriptStepId").HasColumnName("chatbot_script_step_id");
                                    j.IndexerProperty<Guid>("ChatbotScriptAnswerId").HasColumnName("chatbot_script_answer_id");
                                });

                        // entity.HasMany(d => d.ImLivechatExpertise).WithMany(p => p.ChatbotScriptStep)
                        entity.HasMany(d => d.ImLivechatExpertise).WithMany(p => p.ChatbotScriptStep)
                            .UsingEntity<Dictionary<string, object>>(
                                "ChatbotScriptStepImLivechatExpertiseRel",
                                r => r.HasOne<ImLivechatExpertise>().WithMany()
                                    .HasForeignKey("ImLivechatExpertiseId")
                                    .HasConstraintName("chatbot_script_step_im_livechat_e_im_livechat_expertise_id_fkey"),
                                l => l.HasOne<ChatbotScriptStep>().WithMany()
                                    .HasForeignKey("ChatbotScriptStepId")
                                    .HasConstraintName("chatbot_script_step_im_livechat_exp_chatbot_script_step_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ChatbotScriptStepId", "ImLivechatExpertiseId").HasName("chatbot_script_step_im_livechat_expertise_rel_pkey");
                                    j.ToTable("chatbot_script_step_im_livechat_expertise_rel");
                                    j.HasIndex(new[] { "ImLivechatExpertiseId", "ChatbotScriptStepId" }, "chatbot_script_step_im_livech_im_livechat_expertise_id_chat_idx");
                                    j.IndexerProperty<Guid>("ChatbotScriptStepId").HasColumnName("chatbot_script_step_id");
                                    j.IndexerProperty<Guid>("ImLivechatExpertiseId").HasColumnName("im_livechat_expertise_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}