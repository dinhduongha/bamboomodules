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
        public static void ConfigureChatbotMessage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatbotMessage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("chatbot_message_pkey");

                entity.ToTable("chatbot_message", tb => tb.HasComment("Chatbot Message"));

                entity.HasIndex(e => e.MailMessageId, "chatbot_message__unique_mail_message_id").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.MailChannelId)
                    .HasComment("Discussion Channel")
                    .HasColumnName("mail_channel_id");
                entity.Property(e => e.MailMessageId)
                    .HasComment("Related Mail Message")
                    .HasColumnName("mail_message_id");
                entity.Property(e => e.ScriptStepId)
                    .HasComment("Chatbot Step")
                    .HasColumnName("script_step_id");
                entity.Property(e => e.UserRawAnswer)
                    .HasComment("User's raw answer")
                    .HasColumnName("user_raw_answer");
                entity.Property(e => e.UserScriptAnswerId)
                    .HasComment("User's answer")
                    .HasColumnName("user_script_answer_id");
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
                    .HasConstraintName("chatbot_message_create_uid_fkey");

                entity.HasOne<MailChannel>().WithMany()
                    .HasForeignKey(d => d.MailChannelId)
                    .HasConstraintName("chatbot_message_mail_channel_id_fkey");

                entity.HasOne<MailMessage>().WithOne()
                    .HasForeignKey<ChatbotMessage>(d => d.MailMessageId)
                    .HasConstraintName("chatbot_message_mail_message_id_fkey");

                entity.HasOne(d => d.ScriptStep).WithMany(p => p.ChatbotMessages)
                    .HasForeignKey(d => d.ScriptStepId)
                    .HasConstraintName("chatbot_message_script_step_id_fkey");

                entity.HasOne(d => d.UserScriptAnswer).WithMany(p => p.ChatbotMessages)
                    .HasForeignKey(d => d.UserScriptAnswerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("chatbot_message_user_script_answer_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("chatbot_message_write_uid_fkey");
            });
        }
    }
}