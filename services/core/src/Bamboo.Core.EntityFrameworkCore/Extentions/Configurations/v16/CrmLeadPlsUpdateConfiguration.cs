using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmLeadPlsUpdate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmLeadPlsUpdate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_lead_pls_update_pkey");

                        entity.ToTable("crm_lead_pls_update");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.PlsStartDate).HasColumnName("pls_start_date");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmLeadPlsUpdateCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_pls_update_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_pls_update_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmLeadPlsUpdateWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_pls_update_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_pls_update_write_uid_fkey");

                        // entity.HasMany(d => d.CrmLeadScoringFrequencyField).WithMany(p => p.CrmLeadPlsUpdate)
                        entity.HasMany(d => d.CrmLeadScoringFrequencyField).WithMany(p => p.CrmLeadPlsUpdate)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmLeadPlsUpdateCrmLeadScoringFrequencyFieldRel",
                                r => r.HasOne<CrmLeadScoringFrequencyField>().WithMany()
                                    .HasForeignKey("CrmLeadScoringFrequencyFieldId")
                                    .HasConstraintName("crm_lead_pls_update_crm_lead__crm_lead_scoring_frequency_f_fkey"),
                                l => l.HasOne<CrmLeadPlsUpdate>().WithMany()
                                    .HasForeignKey("CrmLeadPlsUpdateId")
                                    .HasConstraintName("crm_lead_pls_update_crm_lead_scorin_crm_lead_pls_update_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmLeadPlsUpdateId", "CrmLeadScoringFrequencyFieldId").HasName("crm_lead_pls_update_crm_lead_scoring_frequency_field_rel_pkey");
                                    j.ToTable("crm_lead_pls_update_crm_lead_scoring_frequency_field_rel");
                                    j.HasIndex(new[] { "CrmLeadScoringFrequencyFieldId", "CrmLeadPlsUpdateId" }, "crm_lead_pls_update_crm_lead__crm_lead_scoring_frequency_fi_idx");
                                    j.IndexerProperty<Guid>("CrmLeadPlsUpdateId").HasColumnName("crm_lead_pls_update_id");
                                    j.IndexerProperty<Guid>("CrmLeadScoringFrequencyFieldId").HasColumnName("crm_lead_scoring_frequency_field_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}