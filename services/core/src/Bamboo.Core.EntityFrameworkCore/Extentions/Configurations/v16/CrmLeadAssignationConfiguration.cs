using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmLeadAssignation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmLeadAssignation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_lead_assignation_pkey");

                        entity.ToTable("crm_lead_assignation");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.ForwardId).HasColumnName("forward_id");
                        entity.Property(e => e.LeadId).HasColumnName("lead_id");
                        entity.Property(e => e.LeadLink).HasColumnName("lead_link");
                        entity.Property(e => e.LeadLocation).HasColumnName("lead_location");
                        entity.Property(e => e.PartnerAssignedId).HasColumnName("partner_assigned_id");
                        entity.Property(e => e.PartnerLocation).HasColumnName("partner_location");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmLeadAssignationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_assignation_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_assignation_create_uid_fkey");

                        entity.HasOne(d => d.Forward).WithMany(p => p.CrmLeadAssignation)
                            .HasForeignKey(d => d.ForwardId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_assignation_forward_id_fkey");

                        entity.HasOne(d => d.Lead).WithMany(p => p.CrmLeadAssignation)
                            .HasForeignKey(d => d.LeadId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_assignation_lead_id_fkey");

                        // entity.HasOne(d => d.PartnerAssigned).WithMany(p => p.CrmLeadAssignation) .HasForeignKey(d => d.PartnerAssignedId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_assignation_partner_assigned_id_fkey");
                        entity.HasOne(d => d.PartnerAssigned).WithMany()
                            .HasForeignKey(d => d.PartnerAssignedId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_assignation_partner_assigned_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmLeadAssignationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_assignation_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_assignation_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}