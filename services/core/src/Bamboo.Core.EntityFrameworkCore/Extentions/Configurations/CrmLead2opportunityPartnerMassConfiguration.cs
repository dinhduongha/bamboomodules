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
        public static void ConfigureCrmLead2opportunityPartnerMass(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrmLead2opportunityPartnerMass>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("crm_lead2opportunity_partner_mass_pkey");

                entity.ToTable("crm_lead2opportunity_partner_mass");

                entity.HasIndex(e => e.TenantId, "crm_lead2opportunity_partner_mass_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Action).HasColumnName("action");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead2opportunity_partner_mass_create_uid_fkey");

                entity.HasOne(d => d.Lead).WithMany(p => p.CrmLead2opportunityPartnerMassesNavigation)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead2opportunity_partner_mass_lead_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead2opportunity_partner_mass_partner_id_fkey");

                entity.HasOne(d => d.Team).WithMany(p => p.CrmLead2opportunityPartnerMasses)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead2opportunity_partner_mass_team_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead2opportunity_partner_mass_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead2opportunity_partner_mass_write_uid_fkey");
                /// TODO: 
                //entity.HasMany(d => d.CrmLeads).WithMany(p => p.CrmLead2opportunityPartnerMasses)
                entity.HasMany<CrmLead>().WithMany()
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
                        });

                /// TODO: 
                //entity.HasMany(d => d.CrmLeadsNavigation).WithMany(p => p.CrmLead2opportunityPartnerMasses1)
                entity.HasMany<CrmLead>().WithMany()
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
                        });

                //entity.HasMany(d => d.ResUsers).WithMany(p => p.CrmLead2opportunityPartnerMasses)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "CrmLead2opportunityPartnerMassResUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
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
                        });
            });
        }
    }
}