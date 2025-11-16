using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventLeadRule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventLeadRule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_lead_rule_pkey");

                        entity.ToTable("event_lead_rule");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.EventRegistrationFilter).HasColumnName("event_registration_filter");
                        entity.Property(e => e.LeadCreationBasis).HasColumnName("lead_creation_basis");
                        entity.Property(e => e.LeadCreationTrigger).HasColumnName("lead_creation_trigger");
                        entity.Property(e => e.LeadSalesTeamId).HasColumnName("lead_sales_team_id");
                        entity.Property(e => e.LeadType).HasColumnName("lead_type");
                        entity.Property(e => e.LeadUserId).HasColumnName("lead_user_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.EventLeadRule) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_lead_rule_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_lead_rule_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.EventLeadRuleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_lead_rule_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_lead_rule_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.EventLeadRule)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_lead_rule_event_id_fkey");

                        entity.HasOne(d => d.LeadSalesTeam).WithMany(p => p.EventLeadRule)
                            .HasForeignKey(d => d.LeadSalesTeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_lead_rule_lead_sales_team_id_fkey");

                        // entity.HasOne(d => d.LeadUser).WithMany(p => p.EventLeadRuleLeadUser) .HasForeignKey(d => d.LeadUserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_lead_rule_lead_user_id_fkey");
                        entity.HasOne(d => d.LeadUser).WithMany()
                            .HasForeignKey(d => d.LeadUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_lead_rule_lead_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.EventLeadRuleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("event_lead_rule_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("event_lead_rule_write_uid_fkey");

                        // entity.HasMany(d => d.CrmTag).WithMany(p => p.EventLeadRule)
                        entity.HasMany(d => d.CrmTag).WithMany(p => p.EventLeadRule)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmTagEventLeadRuleRel",
                                r => r.HasOne<CrmTag>().WithMany()
                                    .HasForeignKey("CrmTagId")
                                    .HasConstraintName("crm_tag_event_lead_rule_rel_crm_tag_id_fkey"),
                                l => l.HasOne<EventLeadRule>().WithMany()
                                    .HasForeignKey("EventLeadRuleId")
                                    .HasConstraintName("crm_tag_event_lead_rule_rel_event_lead_rule_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EventLeadRuleId", "CrmTagId").HasName("crm_tag_event_lead_rule_rel_pkey");
                                    j.ToTable("crm_tag_event_lead_rule_rel");
                                    j.HasIndex(new[] { "CrmTagId", "EventLeadRuleId" }, "crm_tag_event_lead_rule_rel_crm_tag_id_event_lead_rule_id_idx");
                                    j.IndexerProperty<Guid>("EventLeadRuleId").HasColumnName("event_lead_rule_id");
                                    j.IndexerProperty<Guid>("CrmTagId").HasColumnName("crm_tag_id");
                                });

                        // entity.HasMany(d => d.EventType).WithMany(p => p.EventLeadRule)
                        entity.HasMany(d => d.EventType).WithMany(p => p.EventLeadRule)
                            .UsingEntity<Dictionary<string, object>>(
                                "EventLeadRuleEventTypeRel",
                                r => r.HasOne<EventType>().WithMany()
                                    .HasForeignKey("EventTypeId")
                                    .HasConstraintName("event_lead_rule_event_type_rel_event_type_id_fkey"),
                                l => l.HasOne<EventLeadRule>().WithMany()
                                    .HasForeignKey("EventLeadRuleId")
                                    .HasConstraintName("event_lead_rule_event_type_rel_event_lead_rule_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EventLeadRuleId", "EventTypeId").HasName("event_lead_rule_event_type_rel_pkey");
                                    j.ToTable("event_lead_rule_event_type_rel");
                                    j.HasIndex(new[] { "EventTypeId", "EventLeadRuleId" }, "event_lead_rule_event_type_re_event_type_id_event_lead_rule_idx");
                                    j.IndexerProperty<Guid>("EventLeadRuleId").HasColumnName("event_lead_rule_id");
                                    j.IndexerProperty<Guid>("EventTypeId").HasColumnName("event_type_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}