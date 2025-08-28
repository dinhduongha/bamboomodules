using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmLeadScoringFrequency(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmLeadScoringFrequency>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_lead_scoring_frequency_pkey");

                        entity.ToTable("crm_lead_scoring_frequency");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Variable, "crm_lead_scoring_frequency__variable_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LostCount).HasColumnName("lost_count");
                        entity.Property(e => e.TeamId).HasColumnName("team_id");
                        entity.Property(e => e.Value).HasColumnName("value");
                        entity.Property(e => e.Variable).HasColumnName("variable");
                        entity.Property(e => e.WonCount).HasColumnName("won_count");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmLeadScoringFrequencyCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_scoring_frequency_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_scoring_frequency_create_uid_fkey");

                        entity.HasOne(d => d.Team).WithMany(p => p.CrmLeadScoringFrequency)
                            .HasForeignKey(d => d.TeamId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("crm_lead_scoring_frequency_team_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmLeadScoringFrequencyWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_scoring_frequency_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_scoring_frequency_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}