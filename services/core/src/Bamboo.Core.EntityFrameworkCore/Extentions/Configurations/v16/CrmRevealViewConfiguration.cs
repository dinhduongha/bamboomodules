using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmRevealView(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmRevealView>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_reveal_view_pkey");

                        entity.ToTable("crm_reveal_view");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CreationTime, "crm_reveal_view__create_date_index");

                        entity.HasIndex(e => e.RevealRuleId, "crm_reveal_view__reveal_rule_id_index").HasFilter("(reveal_rule_id IS NOT NULL)");

                        entity.HasIndex(e => e.RevealState, "crm_reveal_view__reveal_state_index");

                        entity.HasIndex(e => new { e.RevealRuleId, e.RevealIp }, "crm_reveal_view_ip_rule_id").IsUnique();

                        entity.HasIndex(e => new { e.RevealState, e.CreationTime }, "crm_reveal_view_state_create_date");

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
                        entity.Property(e => e.RevealIp).HasColumnName("reveal_ip");
                        entity.Property(e => e.RevealRuleId).HasColumnName("reveal_rule_id");
                        entity.Property(e => e.RevealState).HasColumnName("reveal_state");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmRevealViewCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_reveal_view_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_view_create_uid_fkey");

                        entity.HasOne(d => d.RevealRule).WithMany(p => p.CrmRevealView)
                            .HasForeignKey(d => d.RevealRuleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_view_reveal_rule_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmRevealViewWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_reveal_view_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_view_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}