using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmLead2opportunityPartner(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmLead2opportunityPartner>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_lead2opportunity_partner_pkey");

                        entity.ToTable("crm_lead2opportunity_partner");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Action).HasColumnName("action");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ForceAssignment).HasColumnName("force_assignment");
                        entity.Property(e => e.LeadId).HasColumnName("lead_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.TeamId).HasColumnName("team_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmLead2opportunityPartnerCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead2opportunity_partner_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_create_uid_fkey");

                        entity.HasOne(d => d.Lead).WithMany(p => p.CrmLead2opportunityPartner)
                            .HasForeignKey(d => d.LeadId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("crm_lead2opportunity_partner_lead_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.CrmLead2opportunityPartner) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead2opportunity_partner_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_partner_id_fkey");

                        entity.HasOne(d => d.Team).WithMany(p => p.CrmLead2opportunityPartner)
                            .HasForeignKey(d => d.TeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_team_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.CrmLead2opportunityPartnerUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead2opportunity_partner_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmLead2opportunityPartnerWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead2opportunity_partner_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_write_uid_fkey");

                        // entity.HasMany(d => d.CrmLead).WithMany(p => p.CrmLead2opportunityPartnerNavigation)
                        entity.HasMany(d => d.CrmLead).WithMany(p => p.CrmLead2opportunityPartnerNavigation)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmLeadCrmLead2opportunityPartnerRel",
                                r => r.HasOne<CrmLead>().WithMany()
                                    .HasForeignKey("CrmLeadId")
                                    .HasConstraintName("crm_lead_crm_lead2opportunity_partner_rel_crm_lead_id_fkey"),
                                l => l.HasOne<CrmLead2opportunityPartner>().WithMany()
                                    .HasForeignKey("CrmLead2opportunityPartnerId")
                                    .HasConstraintName("crm_lead_crm_lead2opportunity_crm_lead2opportunity_partner_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmLead2opportunityPartnerId", "CrmLeadId").HasName("crm_lead_crm_lead2opportunity_partner_rel_pkey");
                                    j.ToTable("crm_lead_crm_lead2opportunity_partner_rel");
                                    j.HasIndex(new[] { "CrmLeadId", "CrmLead2opportunityPartnerId" }, "crm_lead_crm_lead2opportunity_crm_lead_id_crm_lead2opportun_idx");
                                    j.IndexerProperty<Guid>("CrmLead2opportunityPartnerId").HasColumnName("crm_lead2opportunity_partner_id");
                                    j.IndexerProperty<Guid>("CrmLeadId").HasColumnName("crm_lead_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}