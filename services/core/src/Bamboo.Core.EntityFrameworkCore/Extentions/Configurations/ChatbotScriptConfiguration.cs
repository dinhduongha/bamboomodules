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
        public static void ConfigureChatbotScript(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatbotScript>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("chatbot_script_pkey");

                entity.ToTable("chatbot_script", tb => tb.HasComment("Chatbot Script"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.OperatorPartnerId)
                    .HasComment("Bot Operator")
                    .HasColumnName("operator_partner_id");
                entity.Property(e => e.SourceId)
                    .HasComment("Source")
                    .HasColumnName("source_id");
                entity.Property(e => e.Title)
                    .HasComment("Title")
                    .HasColumnType("jsonb")
                    .HasColumnName("title");
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
                    .HasConstraintName("chatbot_script_create_uid_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.OperatorPartnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("chatbot_script_operator_partner_id_fkey");

                entity.HasOne<UtmSource>().WithMany()
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("chatbot_script_source_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("chatbot_script_write_uid_fkey");
            });
        }
    }
}