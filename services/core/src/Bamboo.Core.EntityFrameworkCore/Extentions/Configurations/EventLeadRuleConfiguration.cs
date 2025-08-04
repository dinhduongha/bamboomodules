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
        public static void ConfigureEventLeadRule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLeadRule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("event_lead_rule_pkey");

                entity.ToTable("event_lead_rule", tb => tb.HasComment("Event Lead Rules"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.TenantId)
                    .HasComment("Company")
                    .HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.EventId)
                    .HasComment("Event")
                    .HasColumnName("event_id");
                entity.Property(e => e.EventRegistrationFilter)
                    .HasComment("Registrations Domain")
                    .HasColumnName("event_registration_filter");
                entity.Property(e => e.LeadCreationBasis)
                    .HasComment("Create")
                    .HasColumnType("character varying")
                    .HasColumnName("lead_creation_basis");
                entity.Property(e => e.LeadCreationTrigger)
                    .HasComment("When")
                    .HasColumnType("character varying")
                    .HasColumnName("lead_creation_trigger");
                entity.Property(e => e.LeadSalesTeamId)
                    .HasComment("Sales Team")
                    .HasColumnName("lead_sales_team_id");
                entity.Property(e => e.LeadType)
                    .HasComment("Lead Type")
                    .HasColumnType("character varying")
                    .HasColumnName("lead_type");
                entity.Property(e => e.LeadUserId)
                    .HasComment("Salesperson")
                    .HasColumnName("lead_user_id");
                entity.Property(e => e.Name)
                    .HasComment("Rule Name")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_lead_rule_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_lead_rule_create_uid_fkey");

                entity.HasOne(d => d.Event).WithMany(p => p.EventLeadRules)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_lead_rule_event_id_fkey");

                entity.HasOne(d => d.LeadSalesTeam).WithMany()
                    .HasForeignKey(d => d.LeadSalesTeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_lead_rule_lead_sales_team_id_fkey");

                entity.HasOne(d => d.LeadUser).WithMany()
                    .HasForeignKey(d => d.LeadUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_lead_rule_lead_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_lead_rule_write_uid_fkey");

                entity.HasMany(d => d.CrmTags).WithMany(p => p.EventLeadRules)
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
                            j.ToTable("crm_tag_event_lead_rule_rel", tb => tb.HasComment("RELATION BETWEEN event_lead_rule AND crm_tag"));
                            j.HasIndex(new[] { "CrmTagId", "EventLeadRuleId" }, "crm_tag_event_lead_rule_rel_crm_tag_id_event_lead_rule_id_idx");
                            j.IndexerProperty<Guid>("EventLeadRuleId").HasColumnName("event_lead_rule_id");
                            j.IndexerProperty<Guid>("CrmTagId").HasColumnName("crm_tag_id");
                        });

                entity.HasMany(d => d.EventTypes).WithMany(p => p.EventLeadRules)
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
                            j.ToTable("event_lead_rule_event_type_rel", tb => tb.HasComment("RELATION BETWEEN event_lead_rule AND event_type"));
                            j.HasIndex(new[] { "EventTypeId", "EventLeadRuleId" }, "event_lead_rule_event_type_re_event_type_id_event_lead_rule_idx");
                            j.IndexerProperty<Guid>("EventLeadRuleId").HasColumnName("event_lead_rule_id");
                            j.IndexerProperty<Guid>("EventTypeId").HasColumnName("event_type_id");
                        });
            });
        }
    }
}