using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("chatbot_script");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.OperatorPartnerId).HasColumnName("operator_partner_id");
                        entity.Property(e => e.SourceId).HasColumnName("source_id");
                        entity.Property(e => e.Title)
                            .HasColumnType("jsonb")
                            .HasColumnName("title");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ChatbotScriptCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("chatbot_script_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_script_create_uid_fkey");

                        // entity.HasOne(d => d.OperatorPartner).WithMany(p => p.ChatbotScript) .HasForeignKey(d => d.OperatorPartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("chatbot_script_operator_partner_id_fkey");
                        entity.HasOne(d => d.OperatorPartner).WithMany()
                            .HasForeignKey(d => d.OperatorPartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("chatbot_script_operator_partner_id_fkey");

                        entity.HasOne(d => d.Source).WithMany(p => p.ChatbotScript)
                            .HasForeignKey(d => d.SourceId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("chatbot_script_source_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ChatbotScriptWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("chatbot_script_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("chatbot_script_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}