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
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.ProcessedRegistrationId).HasColumnName("processed_registration_id");

                        entity.HasOne(d => d.Event).WithOne(p => p.EventLeadRequest)
                            .HasForeignKey<EventLeadRequest>(d => d.EventId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("event_lead_request_event_id_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}