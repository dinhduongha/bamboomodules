using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmRevealRule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmRevealRule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_reveal_rule_pkey");

                        entity.ToTable("crm_reveal_rule");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CompanySizeMax).HasColumnName("company_size_max");
                        entity.Property(e => e.CompanySizeMin).HasColumnName("company_size_min");
                        entity.Property(e => e.ContactFilterType).HasColumnName("contact_filter_type");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ExtraContacts).HasColumnName("extra_contacts");
                        entity.Property(e => e.FilterOnSize).HasColumnName("filter_on_size");
                        entity.Property(e => e.LeadFor).HasColumnName("lead_for");
                        entity.Property(e => e.LeadType).HasColumnName("lead_type");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PreferredRoleId).HasColumnName("preferred_role_id");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.RegexUrl).HasColumnName("regex_url");
                        entity.Property(e => e.SeniorityId).HasColumnName("seniority_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Suffix).HasColumnName("suffix");
                        entity.Property(e => e.TeamId).HasColumnName("team_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmRevealRuleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_reveal_rule_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_rule_create_uid_fkey");

                        entity.HasOne(d => d.PreferredRole).WithMany(p => p.CrmRevealRuleNavigation)
                            .HasForeignKey(d => d.PreferredRoleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_rule_preferred_role_id_fkey");

                        entity.HasOne(d => d.Seniority).WithMany(p => p.CrmRevealRule)
                            .HasForeignKey(d => d.SeniorityId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_rule_seniority_id_fkey");

                        entity.HasOne(d => d.Team).WithMany(p => p.CrmRevealRule)
                            .HasForeignKey(d => d.TeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_rule_team_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.CrmRevealRuleUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_reveal_rule_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_rule_user_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.CrmRevealRule) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_reveal_rule_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_rule_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmRevealRuleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_reveal_rule_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_reveal_rule_write_uid_fkey");

                        // entity.HasMany(d => d.CrmIapLeadIndustry).WithMany(p => p.CrmRevealRule)
                        entity.HasMany(d => d.CrmIapLeadIndustry).WithMany(p => p.CrmRevealRule)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmIapLeadIndustryCrmRevealRuleRel",
                                r => r.HasOne<CrmIapLeadIndustry>().WithMany()
                                    .HasForeignKey("CrmIapLeadIndustryId")
                                    .HasConstraintName("crm_iap_lead_industry_crm_reveal__crm_iap_lead_industry_id_fkey"),
                                l => l.HasOne<CrmRevealRule>().WithMany()
                                    .HasForeignKey("CrmRevealRuleId")
                                    .HasConstraintName("crm_iap_lead_industry_crm_reveal_rule_r_crm_reveal_rule_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmRevealRuleId", "CrmIapLeadIndustryId").HasName("crm_iap_lead_industry_crm_reveal_rule_rel_pkey");
                                    j.ToTable("crm_iap_lead_industry_crm_reveal_rule_rel");
                                    j.HasIndex(new[] { "CrmIapLeadIndustryId", "CrmRevealRuleId" }, "crm_iap_lead_industry_crm_rev_crm_iap_lead_industry_id_crm__idx");
                                    j.IndexerProperty<Guid>("CrmRevealRuleId").HasColumnName("crm_reveal_rule_id");
                                    j.IndexerProperty<Guid>("CrmIapLeadIndustryId").HasColumnName("crm_iap_lead_industry_id");
                                });

                        // entity.HasMany(d => d.CrmIapLeadRole).WithMany(p => p.CrmRevealRule)
                        entity.HasMany(d => d.CrmIapLeadRole).WithMany(p => p.CrmRevealRule)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmIapLeadRoleCrmRevealRuleRel",
                                r => r.HasOne<CrmIapLeadRole>().WithMany()
                                    .HasForeignKey("CrmIapLeadRoleId")
                                    .HasConstraintName("crm_iap_lead_role_crm_reveal_rule_rel_crm_iap_lead_role_id_fkey"),
                                l => l.HasOne<CrmRevealRule>().WithMany()
                                    .HasForeignKey("CrmRevealRuleId")
                                    .HasConstraintName("crm_iap_lead_role_crm_reveal_rule_rel_crm_reveal_rule_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmRevealRuleId", "CrmIapLeadRoleId").HasName("crm_iap_lead_role_crm_reveal_rule_rel_pkey");
                                    j.ToTable("crm_iap_lead_role_crm_reveal_rule_rel");
                                    j.HasIndex(new[] { "CrmIapLeadRoleId", "CrmRevealRuleId" }, "crm_iap_lead_role_crm_reveal__crm_iap_lead_role_id_crm_reve_idx");
                                    j.IndexerProperty<Guid>("CrmRevealRuleId").HasColumnName("crm_reveal_rule_id");
                                    j.IndexerProperty<Guid>("CrmIapLeadRoleId").HasColumnName("crm_iap_lead_role_id");
                                });

                        // entity.HasMany(d => d.CrmTag).WithMany(p => p.CrmRevealRule)
                        entity.HasMany(d => d.CrmTag).WithMany(p => p.CrmRevealRule)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmRevealRuleCrmTagRel",
                                r => r.HasOne<CrmTag>().WithMany()
                                    .HasForeignKey("CrmTagId")
                                    .HasConstraintName("crm_reveal_rule_crm_tag_rel_crm_tag_id_fkey"),
                                l => l.HasOne<CrmRevealRule>().WithMany()
                                    .HasForeignKey("CrmRevealRuleId")
                                    .HasConstraintName("crm_reveal_rule_crm_tag_rel_crm_reveal_rule_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmRevealRuleId", "CrmTagId").HasName("crm_reveal_rule_crm_tag_rel_pkey");
                                    j.ToTable("crm_reveal_rule_crm_tag_rel");
                                    j.HasIndex(new[] { "CrmTagId", "CrmRevealRuleId" }, "crm_reveal_rule_crm_tag_rel_crm_tag_id_crm_reveal_rule_id_idx");
                                    j.IndexerProperty<Guid>("CrmRevealRuleId").HasColumnName("crm_reveal_rule_id");
                                    j.IndexerProperty<Guid>("CrmTagId").HasColumnName("crm_tag_id");
                                });

                        // entity.HasMany(d => d.ResCountry).WithMany(p => p.CrmRevealRule)
                        entity.HasMany(d => d.ResCountry).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmRevealRuleResCountryRel",
                                r => r.HasOne<ResCountry>().WithMany()
                                    .HasForeignKey("ResCountryId")
                                    .HasConstraintName("crm_reveal_rule_res_country_rel_res_country_id_fkey"),
                                l => l.HasOne<CrmRevealRule>().WithMany()
                                    .HasForeignKey("CrmRevealRuleId")
                                    .HasConstraintName("crm_reveal_rule_res_country_rel_crm_reveal_rule_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmRevealRuleId", "ResCountryId").HasName("crm_reveal_rule_res_country_rel_pkey");
                                    j.ToTable("crm_reveal_rule_res_country_rel");
                                    j.HasIndex(new[] { "ResCountryId", "CrmRevealRuleId" }, "crm_reveal_rule_res_country_r_res_country_id_crm_reveal_rul_idx");
                                    j.IndexerProperty<Guid>("CrmRevealRuleId").HasColumnName("crm_reveal_rule_id");
                                    j.IndexerProperty<Guid>("ResCountryId").HasColumnName("res_country_id");
                                });

                        // entity.HasMany(d => d.ResCountryState).WithMany(p => p.CrmRevealRule)
                        entity.HasMany(d => d.ResCountryState).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmRevealRuleResCountryStateRel",
                                r => r.HasOne<ResCountryState>().WithMany()
                                    .HasForeignKey("ResCountryStateId")
                                    .HasConstraintName("crm_reveal_rule_res_country_state_rel_res_country_state_id_fkey"),
                                l => l.HasOne<CrmRevealRule>().WithMany()
                                    .HasForeignKey("CrmRevealRuleId")
                                    .HasConstraintName("crm_reveal_rule_res_country_state_rel_crm_reveal_rule_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmRevealRuleId", "ResCountryStateId").HasName("crm_reveal_rule_res_country_state_rel_pkey");
                                    j.ToTable("crm_reveal_rule_res_country_state_rel");
                                    j.HasIndex(new[] { "ResCountryStateId", "CrmRevealRuleId" }, "crm_reveal_rule_res_country_s_res_country_state_id_crm_reve_idx");
                                    j.IndexerProperty<Guid>("CrmRevealRuleId").HasColumnName("crm_reveal_rule_id");
                                    j.IndexerProperty<Guid>("ResCountryStateId").HasColumnName("res_country_state_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}