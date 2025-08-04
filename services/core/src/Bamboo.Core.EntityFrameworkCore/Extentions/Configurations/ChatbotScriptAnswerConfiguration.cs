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
        public static void ConfigureChatbotScriptAnswer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatbotScriptAnswer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("chatbot_script_answer_pkey");

                entity.ToTable("chatbot_script_answer", tb => tb.HasComment("Chatbot Script Answer"));

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
                entity.Property(e => e.Name)
                    .HasComment("Answer")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.RedirectLink)
                    .HasComment("Redirect Link")
                    .HasColumnType("character varying")
                    .HasColumnName("redirect_link");
                entity.Property(e => e.ScriptStepId)
                    .HasComment("Script Step")
                    .HasColumnName("script_step_id");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
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
                    .HasConstraintName("chatbot_script_answer_create_uid_fkey");

                entity.HasOne(d => d.ScriptStep).WithMany(p => p.ChatbotScriptAnswers)
                    .HasForeignKey(d => d.ScriptStepId)
                    .HasConstraintName("chatbot_script_answer_script_step_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("chatbot_script_answer_write_uid_fkey");
            });
        }
    }
}