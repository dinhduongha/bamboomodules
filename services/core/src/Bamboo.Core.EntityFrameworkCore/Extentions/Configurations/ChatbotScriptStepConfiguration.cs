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
        public static void ConfigureChatbotScriptStep(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatbotScriptStep>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("chatbot_script_step_pkey");

                entity.ToTable("chatbot_script_step", tb => tb.HasComment("Chatbot Script Step"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
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
                entity.Property(e => e.CrmTeamId)
                    .HasComment("Sales Team")
                    .HasColumnName("crm_team_id");
                entity.Property(e => e.Message)
                    .HasComment("Message")
                    .HasColumnType("jsonb")
                    .HasColumnName("message");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
                entity.Property(e => e.StepType)
                    .HasComment("Step Type")
                    .HasColumnType("character varying")
                    .HasColumnName("step_type");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.ChatbotScript).WithMany(p => p.ChatbotScriptSteps)
                    .HasForeignKey(d => d.ChatbotScriptId)
                    .HasConstraintName("chatbot_script_step_chatbot_script_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("chatbot_script_step_create_uid_fkey");

                entity.HasOne<CrmTeam>().WithMany()
                    .HasForeignKey(d => d.CrmTeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("chatbot_script_step_crm_team_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("chatbot_script_step_write_uid_fkey");

                entity.HasMany(d => d.ChatbotScriptAnswersNavigation).WithMany(p => p.ChatbotScriptSteps)
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
                            j.ToTable("chatbot_script_answer_chatbot_script_step_rel", tb => tb.HasComment("RELATION BETWEEN chatbot_script_step AND chatbot_script_answer"));
                            j.HasIndex(new[] { "ChatbotScriptAnswerId", "ChatbotScriptStepId" }, "chatbot_script_answer_chatbot_chatbot_script_answer_id_chat_idx");
                            j.IndexerProperty<Guid>("ChatbotScriptStepId").HasColumnName("chatbot_script_step_id");
                            j.IndexerProperty<Guid>("ChatbotScriptAnswerId").HasColumnName("chatbot_script_answer_id");
                        });
            });
        }
    }
}