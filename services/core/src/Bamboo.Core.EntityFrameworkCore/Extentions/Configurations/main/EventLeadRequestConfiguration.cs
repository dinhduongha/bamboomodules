using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureEventLeadRequest(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EventLeadRequest>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("event_lead_request_pkey");

                        entity.ToTable("event_lead_request");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.EventId, "event_lead_request_uniq_event").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.ProcessedRegistrationId).HasColumnName("processed_registration_id");

                        entity.HasOne(d => d.Event).WithOne(p => p.EventLeadRequest)
                            .HasForeignKey<EventLeadRequest>(d => d.EventId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_lead_request_event_id_fkey");

                        // entity.HasMany(d => d.EventLeadRule).WithMany(p => p.EventLeadRequest)
                        entity.HasMany(d => d.EventLeadRule).WithMany(p => p.EventLeadRequest)
                            .UsingEntity<Dictionary<string, object>>(
                                "EventLeadRequestEventLeadRuleRel",
                                r => r.HasOne<EventLeadRule>().WithMany()
                                    .HasForeignKey("EventLeadRuleId")
                                    .HasConstraintName("event_lead_request_event_lead_rule_rel_event_lead_rule_id_fkey"),
                                l => l.HasOne<EventLeadRequest>().WithMany()
                                    .HasForeignKey("EventLeadRequestId")
                                    .HasConstraintName("event_lead_request_event_lead_rule_r_event_lead_request_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EventLeadRequestId", "EventLeadRuleId").HasName("event_lead_request_event_lead_rule_rel_pkey");
                                    j.ToTable("event_lead_request_event_lead_rule_rel");
                                    j.HasIndex(new[] { "EventLeadRuleId", "EventLeadRequestId" }, "event_lead_request_event_lead_event_lead_rule_id_event_lead_idx");
                                    j.IndexerProperty<Guid>("EventLeadRequestId").HasColumnName("event_lead_request_id");
                                    j.IndexerProperty<Guid>("EventLeadRuleId").HasColumnName("event_lead_rule_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}