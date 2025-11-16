using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureChatbotMessage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ChatbotMessage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("chatbot_message_pkey");

                        entity.ToTable("chatbot_message");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.DiscussChannelId, "chatbot_message__discuss_channel_id_index");

                        entity.HasIndex(e => e.ScriptStepId, "chatbot_message__script_step_id_index").HasFilter("(script_step_id IS NOT NULL)");

                        entity.HasIndex(e => new { e.DiscussChannelId, e.UserRawScriptAnswerId }, "chatbot_message_channel_id_user_raw_script_answer_id_idx").HasFilter("(user_raw_script_answer_id IS NOT NULL)");

                        entity.HasIndex(e => e.MailMessageId, "chatbot_message_unique_mail_message_id").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DiscussChannelId).HasColumnName("discuss_channel_id");
                        entity.Property(e => e.MailMessageId).HasColumnName("mail_message_id");
                        entity.Property(e => e.ScriptStepId).HasColumnName("script_step_id");
                        entity.Property(e => e.UserRawAnswer).HasColumnName("user_raw_answer");
                        entity.Property(e => e.UserRawScriptAnswerId).HasColumnName("user_raw_script_answer_id");
                        entity.Property(e => e.UserScriptAnswerId).HasColumnName("user_script_answer_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ChatbotMessageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("chatbot_message_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_message_create_uid_fkey");

                        entity.HasOne(d => d.DiscussChannel).WithMany(p => p.ChatbotMessage)
                            .HasForeignKey(d => d.DiscussChannelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("chatbot_message_discuss_channel_id_fkey");

                        entity.HasOne(d => d.MailMessage).WithOne(p => p.ChatbotMessage)
                            .HasForeignKey<ChatbotMessage>(d => d.MailMessageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_message_mail_message_id_fkey");

                        entity.HasOne(d => d.ScriptStep).WithMany(p => p.ChatbotMessage)
                            .HasForeignKey(d => d.ScriptStepId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_message_script_step_id_fkey");

                        entity.HasOne(d => d.UserScriptAnswer).WithMany(p => p.ChatbotMessage)
                            .HasForeignKey(d => d.UserScriptAnswerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_message_user_script_answer_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ChatbotMessageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("chatbot_message_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_message_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}