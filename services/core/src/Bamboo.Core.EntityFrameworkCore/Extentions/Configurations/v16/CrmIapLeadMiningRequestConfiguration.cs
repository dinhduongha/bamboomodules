using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmIapLeadMiningRequest(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmIapLeadMiningRequest>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_iap_lead_mining_request_pkey");

                        entity.ToTable("crm_iap_lead_mining_request");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CompanySizeMax).HasColumnName("company_size_max");
                        entity.Property(e => e.CompanySizeMin).HasColumnName("company_size_min");
                        entity.Property(e => e.ContactFilterType).HasColumnName("contact_filter_type");
                        entity.Property(e => e.ContactNumber).HasColumnName("contact_number");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ErrorType).HasColumnName("error_type");
                        entity.Property(e => e.FilterOnSize).HasColumnName("filter_on_size");
                        entity.Property(e => e.LeadNumber).HasColumnName("lead_number");
                        entity.Property(e => e.LeadType).HasColumnName("lead_type");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PreferredRoleId).HasColumnName("preferred_role_id");
                        entity.Property(e => e.SearchType).HasColumnName("search_type");
                        entity.Property(e => e.SeniorityId).HasColumnName("seniority_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.TeamId).HasColumnName("team_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmIapLeadMiningRequestCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_iap_lead_mining_request_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_iap_lead_mining_request_create_uid_fkey");

                        entity.HasOne(d => d.PreferredRole).WithMany(p => p.CrmIapLeadMiningRequest)
                            .HasForeignKey(d => d.PreferredRoleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_iap_lead_mining_request_preferred_role_id_fkey");

                        entity.HasOne(d => d.Seniority).WithMany(p => p.CrmIapLeadMiningRequest)
                            .HasForeignKey(d => d.SeniorityId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_iap_lead_mining_request_seniority_id_fkey");

                        entity.HasOne(d => d.Team).WithMany(p => p.CrmIapLeadMiningRequest)
                            .HasForeignKey(d => d.TeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_iap_lead_mining_request_team_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.CrmIapLeadMiningRequestUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_iap_lead_mining_request_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_iap_lead_mining_request_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmIapLeadMiningRequestWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_iap_lead_mining_request_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_iap_lead_mining_request_write_uid_fkey");

                        // entity.HasMany(d => d.CrmIapLeadIndustry).WithMany(p => p.CrmIapLeadMiningRequest)
                        entity.HasMany(d => d.CrmIapLeadIndustry).WithMany(p => p.CrmIapLeadMiningRequest)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmIapLeadIndustryCrmIapLeadMiningRequestRel",
                                r => r.HasOne<CrmIapLeadIndustry>().WithMany()
                                    .HasForeignKey("CrmIapLeadIndustryId")
                                    .HasConstraintName("crm_iap_lead_industry_crm_iap_lea_crm_iap_lead_industry_id_fkey"),
                                l => l.HasOne<CrmIapLeadMiningRequest>().WithMany()
                                    .HasForeignKey("CrmIapLeadMiningRequestId")
                                    .HasConstraintName("crm_iap_lead_industry_crm_iap_crm_iap_lead_mining_request__fkey"),
                                j =>
                                {
                                    j.HasKey("CrmIapLeadMiningRequestId", "CrmIapLeadIndustryId").HasName("crm_iap_lead_industry_crm_iap_lead_mining_request_rel_pkey");
                                    j.ToTable("crm_iap_lead_industry_crm_iap_lead_mining_request_rel");
                                    j.HasIndex(new[] { "CrmIapLeadIndustryId", "CrmIapLeadMiningRequestId" }, "crm_iap_lead_industry_crm_iap_crm_iap_lead_industry_id_crm__idx");
                                    j.IndexerProperty<Guid>("CrmIapLeadMiningRequestId").HasColumnName("crm_iap_lead_mining_request_id");
                                    j.IndexerProperty<Guid>("CrmIapLeadIndustryId").HasColumnName("crm_iap_lead_industry_id");
                                });

                        // entity.HasMany(d => d.CrmIapLeadRole).WithMany(p => p.CrmIapLeadMiningRequestNavigation)
                        entity.HasMany(d => d.CrmIapLeadRole).WithMany(p => p.CrmIapLeadMiningRequestNavigation)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmIapLeadMiningRequestCrmIapLeadRoleRel",
                                r => r.HasOne<CrmIapLeadRole>().WithMany()
                                    .HasForeignKey("CrmIapLeadRoleId")
                                    .HasConstraintName("crm_iap_lead_mining_request_crm_iap_l_crm_iap_lead_role_id_fkey"),
                                l => l.HasOne<CrmIapLeadMiningRequest>().WithMany()
                                    .HasForeignKey("CrmIapLeadMiningRequestId")
                                    .HasConstraintName("crm_iap_lead_mining_request__crm_iap_lead_mining_request__fkey2"),
                                j =>
                                {
                                    j.HasKey("CrmIapLeadMiningRequestId", "CrmIapLeadRoleId").HasName("crm_iap_lead_mining_request_crm_iap_lead_role_rel_pkey");
                                    j.ToTable("crm_iap_lead_mining_request_crm_iap_lead_role_rel");
                                    j.HasIndex(new[] { "CrmIapLeadRoleId", "CrmIapLeadMiningRequestId" }, "crm_iap_lead_mining_request_c_crm_iap_lead_role_id_crm_iap__idx");
                                    j.IndexerProperty<Guid>("CrmIapLeadMiningRequestId").HasColumnName("crm_iap_lead_mining_request_id");
                                    j.IndexerProperty<Guid>("CrmIapLeadRoleId").HasColumnName("crm_iap_lead_role_id");
                                });

                        // entity.HasMany(d => d.CrmTag).WithMany(p => p.CrmIapLeadMiningRequest)
                        entity.HasMany(d => d.CrmTag).WithMany(p => p.CrmIapLeadMiningRequest)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmIapLeadMiningRequestCrmTagRel",
                                r => r.HasOne<CrmTag>().WithMany()
                                    .HasForeignKey("CrmTagId")
                                    .HasConstraintName("crm_iap_lead_mining_request_crm_tag_rel_crm_tag_id_fkey"),
                                l => l.HasOne<CrmIapLeadMiningRequest>().WithMany()
                                    .HasForeignKey("CrmIapLeadMiningRequestId")
                                    .HasConstraintName("crm_iap_lead_mining_request_c_crm_iap_lead_mining_request__fkey"),
                                j =>
                                {
                                    j.HasKey("CrmIapLeadMiningRequestId", "CrmTagId").HasName("crm_iap_lead_mining_request_crm_tag_rel_pkey");
                                    j.ToTable("crm_iap_lead_mining_request_crm_tag_rel");
                                    j.HasIndex(new[] { "CrmTagId", "CrmIapLeadMiningRequestId" }, "crm_iap_lead_mining_request_c_crm_tag_id_crm_iap_lead_minin_idx");
                                    j.IndexerProperty<Guid>("CrmIapLeadMiningRequestId").HasColumnName("crm_iap_lead_mining_request_id");
                                    j.IndexerProperty<Guid>("CrmTagId").HasColumnName("crm_tag_id");
                                });

                        // entity.HasMany(d => d.ResCountry).WithMany(p => p.CrmIapLeadMiningRequest)
                        entity.HasMany(d => d.ResCountry).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmIapLeadMiningRequestResCountryRel",
                                r => r.HasOne<ResCountry>().WithMany()
                                    .HasForeignKey("ResCountryId")
                                    .HasConstraintName("crm_iap_lead_mining_request_res_country_rel_res_country_id_fkey"),
                                l => l.HasOne<CrmIapLeadMiningRequest>().WithMany()
                                    .HasForeignKey("CrmIapLeadMiningRequestId")
                                    .HasConstraintName("crm_iap_lead_mining_request_r_crm_iap_lead_mining_request__fkey"),
                                j =>
                                {
                                    j.HasKey("CrmIapLeadMiningRequestId", "ResCountryId").HasName("crm_iap_lead_mining_request_res_country_rel_pkey");
                                    j.ToTable("crm_iap_lead_mining_request_res_country_rel");
                                    j.HasIndex(new[] { "ResCountryId", "CrmIapLeadMiningRequestId" }, "crm_iap_lead_mining_request_r_res_country_id_crm_iap_lead_m_idx");
                                    j.IndexerProperty<Guid>("CrmIapLeadMiningRequestId").HasColumnName("crm_iap_lead_mining_request_id");
                                    j.IndexerProperty<Guid>("ResCountryId").HasColumnName("res_country_id");
                                });

                        // entity.HasMany(d => d.ResCountryState).WithMany(p => p.CrmIapLeadMiningRequest)
                        entity.HasMany(d => d.ResCountryState).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmIapLeadMiningRequestResCountryStateRel",
                                r => r.HasOne<ResCountryState>().WithMany()
                                    .HasForeignKey("ResCountryStateId")
                                    .HasConstraintName("crm_iap_lead_mining_request_res_count_res_country_state_id_fkey"),
                                l => l.HasOne<CrmIapLeadMiningRequest>().WithMany()
                                    .HasForeignKey("CrmIapLeadMiningRequestId")
                                    .HasConstraintName("crm_iap_lead_mining_request__crm_iap_lead_mining_request__fkey1"),
                                j =>
                                {
                                    j.HasKey("CrmIapLeadMiningRequestId", "ResCountryStateId").HasName("crm_iap_lead_mining_request_res_country_state_rel_pkey");
                                    j.ToTable("crm_iap_lead_mining_request_res_country_state_rel");
                                    j.HasIndex(new[] { "ResCountryStateId", "CrmIapLeadMiningRequestId" }, "crm_iap_lead_mining_request_r_res_country_state_id_crm_iap__idx");
                                    j.IndexerProperty<Guid>("CrmIapLeadMiningRequestId").HasColumnName("crm_iap_lead_mining_request_id");
                                    j.IndexerProperty<Guid>("ResCountryStateId").HasColumnName("res_country_state_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}