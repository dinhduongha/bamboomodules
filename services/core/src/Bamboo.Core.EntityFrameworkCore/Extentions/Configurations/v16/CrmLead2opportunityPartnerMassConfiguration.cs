using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmLead2opportunityPartnerMass(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmLead2opportunityPartnerMass>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_lead2opportunity_partner_mass_pkey");

                        entity.ToTable("crm_lead2opportunity_partner_mass");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Action).HasColumnName("action");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Deduplicate).HasColumnName("deduplicate");
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

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmLead2opportunityPartnerMassCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead2opportunity_partner_mass_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_mass_create_uid_fkey");

                        entity.HasOne(d => d.Lead).WithMany(p => p.CrmLead2opportunityPartnerMassNavigation)
                            .HasForeignKey(d => d.LeadId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_mass_lead_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.CrmLead2opportunityPartnerMass) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead2opportunity_partner_mass_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_mass_partner_id_fkey");

                        entity.HasOne(d => d.Team).WithMany(p => p.CrmLead2opportunityPartnerMass)
                            .HasForeignKey(d => d.TeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_mass_team_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.CrmLead2opportunityPartnerMassUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead2opportunity_partner_mass_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_mass_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmLead2opportunityPartnerMassWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead2opportunity_partner_mass_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead2opportunity_partner_mass_write_uid_fkey");

                        // entity.HasMany(d => d.CrmLead).WithMany(p => p.CrmLead2opportunityPartnerMass)
                        entity.HasMany(d => d.CrmLead).WithMany(p => p.CrmLead2opportunityPartnerMass)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmConvertLeadMassLeadRel",
                                r => r.HasOne<CrmLead>().WithMany()
                                    .HasForeignKey("CrmLeadId")
                                    .HasConstraintName("crm_convert_lead_mass_lead_rel_crm_lead_id_fkey"),
                                l => l.HasOne<CrmLead2opportunityPartnerMass>().WithMany()
                                    .HasForeignKey("CrmLead2opportunityPartnerMassId")
                                    .HasConstraintName("crm_convert_lead_mass_lead_re_crm_lead2opportunity_partner_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmLead2opportunityPartnerMassId", "CrmLeadId").HasName("crm_convert_lead_mass_lead_rel_pkey");
                                    j.ToTable("crm_convert_lead_mass_lead_rel");
                                    j.HasIndex(new[] { "CrmLeadId", "CrmLead2opportunityPartnerMassId" }, "crm_convert_lead_mass_lead_re_crm_lead_id_crm_lead2opportun_idx");
                                    j.IndexerProperty<Guid>("CrmLead2opportunityPartnerMassId").HasColumnName("crm_lead2opportunity_partner_mass_id");
                                    j.IndexerProperty<Guid>("CrmLeadId").HasColumnName("crm_lead_id");
                                });

                        // entity.HasMany(d => d.CrmLeadNavigation).WithMany(p => p.CrmLead2opportunityPartnerMass1)
                        entity.HasMany(d => d.CrmLeadNavigation).WithMany(p => p.CrmLead2opportunityPartnerMass1)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmLeadCrmLead2opportunityPartnerMassRel",
                                r => r.HasOne<CrmLead>().WithMany()
                                    .HasForeignKey("CrmLeadId")
                                    .HasConstraintName("crm_lead_crm_lead2opportunity_partner_mass_rel_crm_lead_id_fkey"),
                                l => l.HasOne<CrmLead2opportunityPartnerMass>().WithMany()
                                    .HasForeignKey("CrmLead2opportunityPartnerMassId")
                                    .HasConstraintName("crm_lead_crm_lead2opportunit_crm_lead2opportunity_partner_fkey1"),
                                j =>
                                {
                                    j.HasKey("CrmLead2opportunityPartnerMassId", "CrmLeadId").HasName("crm_lead_crm_lead2opportunity_partner_mass_rel_pkey");
                                    j.ToTable("crm_lead_crm_lead2opportunity_partner_mass_rel");
                                    j.HasIndex(new[] { "CrmLeadId", "CrmLead2opportunityPartnerMassId" }, "crm_lead_crm_lead2opportunity_crm_lead_id_crm_lead2opportu_idx1");
                                    j.IndexerProperty<Guid>("CrmLead2opportunityPartnerMassId").HasColumnName("crm_lead2opportunity_partner_mass_id");
                                    j.IndexerProperty<Guid>("CrmLeadId").HasColumnName("crm_lead_id");
                                });

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.CrmLead2opportunityPartnerMass)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmLead2opportunityPartnerMassResUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("crm_lead2opportunity_partner_mass_res_users_r_res_users_id_fkey"),
                                l => l.HasOne<CrmLead2opportunityPartnerMass>().WithMany()
                                    .HasForeignKey("CrmLead2opportunityPartnerMassId")
                                    .HasConstraintName("crm_lead2opportunity_partner__crm_lead2opportunity_partner_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmLead2opportunityPartnerMassId", "ResUsersId").HasName("crm_lead2opportunity_partner_mass_res_users_rel_pkey");
                                    j.ToTable("crm_lead2opportunity_partner_mass_res_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "CrmLead2opportunityPartnerMassId" }, "crm_lead2opportunity_partner__res_users_id_crm_lead2opportu_idx");
                                    j.IndexerProperty<Guid>("CrmLead2opportunityPartnerMassId").HasColumnName("crm_lead2opportunity_partner_mass_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}