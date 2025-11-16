using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCrmLead(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CrmLead>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("crm_lead_pkey");

                        entity.ToTable("crm_lead");

                        entity.HasIndex(e => e.CampaignId, "crm_lead__campaign_id_index").HasFilter("(campaign_id IS NOT NULL)");

                        entity.HasIndex(e => e.TenantId, "crm_lead__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ContactName, "crm_lead__contact_name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.DateLastStageUpdate, "crm_lead__date_last_stage_update_index");

                        entity.HasIndex(e => e.EmailDomainCriterion, "crm_lead__email_domain_criterion_index").HasFilter("(email_domain_criterion IS NOT NULL)");

                        entity.HasIndex(e => e.EmailFrom, "crm_lead__email_from_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.EmailNormalized, "crm_lead__email_normalized_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.EventId, "crm_lead__event_id_index").HasFilter("(event_id IS NOT NULL)");

                        entity.HasIndex(e => e.LeadMiningRequestId, "crm_lead__lead_mining_request_id_index").HasFilter("(lead_mining_request_id IS NOT NULL)");

                        entity.HasIndex(e => e.LostReasonId, "crm_lead__lost_reason_id_index");

                        entity.HasIndex(e => e.MediumId, "crm_lead__medium_id_index").HasFilter("(medium_id IS NOT NULL)");

                        entity.HasIndex(e => e.Name, "crm_lead__name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.PartnerAssignedId, "crm_lead__partner_assigned_id_index").HasFilter("(partner_assigned_id IS NOT NULL)");

                        entity.HasIndex(e => e.PartnerId, "crm_lead__partner_id_index");

                        entity.HasIndex(e => e.PartnerName, "crm_lead__partner_name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.PhoneSanitized, "crm_lead__phone_sanitized_index").HasFilter("(phone_sanitized IS NOT NULL)");

                        entity.HasIndex(e => e.Priority, "crm_lead__priority_index");

                        entity.HasIndex(e => e.RevealId, "crm_lead__reveal_id_index").HasFilter("(reveal_id IS NOT NULL)");

                        entity.HasIndex(e => e.RevealRuleId, "crm_lead__reveal_rule_id_index").HasFilter("(reveal_rule_id IS NOT NULL)");

                        entity.HasIndex(e => e.SourceId, "crm_lead__source_id_index").HasFilter("(source_id IS NOT NULL)");

                        entity.HasIndex(e => e.StageId, "crm_lead__stage_id_index");

                        entity.HasIndex(e => e.TeamId, "crm_lead__team_id_index");

                        entity.HasIndex(e => e.Type, "crm_lead__type_index");

                        entity.HasIndex(e => e.UserId, "crm_lead__user_id_index");

                        entity.HasIndex(e => new { e.CreationTime, e.TeamId }, "crm_lead_create_date_team_id_idx");

                        entity.HasIndex(e => new { e.UserId, e.TeamId, e.Type }, "crm_lead_user_id_team_id_type_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AutomatedProbability).HasColumnName("automated_probability");
                        entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                        entity.Property(e => e.City).HasColumnName("city");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.ContactName).HasColumnName("contact_name");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateAutomationLast)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_automation_last");
                        entity.Property(e => e.DateClosed)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_closed");
                        entity.Property(e => e.DateConversion)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_conversion");
                        entity.Property(e => e.DateDeadline).HasColumnName("date_deadline");
                        entity.Property(e => e.DateLastStageUpdate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_last_stage_update");
                        entity.Property(e => e.DateOpen)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_open");
                        entity.Property(e => e.DatePartnerAssign).HasColumnName("date_partner_assign");
                        entity.Property(e => e.DayClose).HasColumnName("day_close");
                        entity.Property(e => e.DayOpen).HasColumnName("day_open");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.EmailCc).HasColumnName("email_cc");
                        entity.Property(e => e.EmailDomainCriterion).HasColumnName("email_domain_criterion");
                        entity.Property(e => e.EmailFrom).HasColumnName("email_from");
                        entity.Property(e => e.EmailNormalized).HasColumnName("email_normalized");
                        entity.Property(e => e.EmailState).HasColumnName("email_state");
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.EventLeadRuleId).HasColumnName("event_lead_rule_id");
                        entity.Property(e => e.ExpectedRevenue).HasColumnName("expected_revenue");
                        entity.Property(e => e.Function).HasColumnName("function");
                        entity.Property(e => e.IapEnrichDone).HasColumnName("iap_enrich_done");
                        entity.Property(e => e.LangId).HasColumnName("lang_id");
                        entity.Property(e => e.LeadMiningRequestId).HasColumnName("lead_mining_request_id");
                        entity.Property(e => e.LeadProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("lead_properties");
                        entity.Property(e => e.LostReasonId).HasColumnName("lost_reason_id");
                        entity.Property(e => e.MediumId).HasColumnName("medium_id");
                        entity.Property(e => e.MessageBounce).HasColumnName("message_bounce");
                        entity.Property(e => e.Mobile).HasColumnName("mobile");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PartnerAssignedId).HasColumnName("partner_assigned_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PartnerLatitude).HasColumnName("partner_latitude");
                        entity.Property(e => e.PartnerLongitude).HasColumnName("partner_longitude");
                        entity.Property(e => e.PartnerName).HasColumnName("partner_name");
                        entity.Property(e => e.Phone).HasColumnName("phone");
                        entity.Property(e => e.PhoneSanitized).HasColumnName("phone_sanitized");
                        entity.Property(e => e.PhoneState).HasColumnName("phone_state");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.Probability).HasColumnName("probability");
                        entity.Property(e => e.ProratedRevenue).HasColumnName("prorated_revenue");
                        entity.Property(e => e.RecurringPlan).HasColumnName("recurring_plan");
                        entity.Property(e => e.RecurringRevenue).HasColumnName("recurring_revenue");
                        entity.Property(e => e.RecurringRevenueMonthly).HasColumnName("recurring_revenue_monthly");
                        entity.Property(e => e.RecurringRevenueMonthlyProrated).HasColumnName("recurring_revenue_monthly_prorated");
                        entity.Property(e => e.RecurringRevenueProrated).HasColumnName("recurring_revenue_prorated");
                        entity.Property(e => e.Referred).HasColumnName("referred");
                        entity.Property(e => e.RevealIapCredits).HasColumnName("reveal_iap_credits");
                        entity.Property(e => e.RevealId).HasColumnName("reveal_id");
                        entity.Property(e => e.RevealIp).HasColumnName("reveal_ip");
                        entity.Property(e => e.RevealRuleId).HasColumnName("reveal_rule_id");
                        entity.Property(e => e.SourceId).HasColumnName("source_id");
                        entity.Property(e => e.StageId).HasColumnName("stage_id");
                        entity.Property(e => e.StateId).HasColumnName("state_id");
                        entity.Property(e => e.Street).HasColumnName("street");
                        entity.Property(e => e.Street2).HasColumnName("street2");
                        entity.Property(e => e.TeamId).HasColumnName("team_id");
                        entity.Property(e => e.Title).HasColumnName("title");
                        entity.Property(e => e.Type).HasColumnName("type");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.Website).HasColumnName("website");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.Zip).HasColumnName("zip");

                        entity.HasOne(d => d.Campaign).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.CampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_campaign_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.CrmLead) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_company_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.CrmLead) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CrmLeadCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_event_id_fkey");

                        entity.HasOne(d => d.EventLeadRule).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.EventLeadRuleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_event_lead_rule_id_fkey");

                        entity.HasOne(d => d.Lang).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.LangId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_lang_id_fkey");

                        entity.HasOne(d => d.LeadMiningRequest).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.LeadMiningRequestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_lead_mining_request_id_fkey");

                        entity.HasOne(d => d.LostReason).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.LostReasonId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("crm_lead_lost_reason_id_fkey");

                        entity.HasOne(d => d.Medium).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.MediumId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_medium_id_fkey");

                        // entity.HasOne(d => d.PartnerAssigned).WithMany(p => p.CrmLeadPartnerAssigned) .HasForeignKey(d => d.PartnerAssignedId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_partner_assigned_id_fkey");
                        entity.HasOne(d => d.PartnerAssigned).WithMany()
                            .HasForeignKey(d => d.PartnerAssignedId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_partner_assigned_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.CrmLeadPartner) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_partner_id_fkey");

                        entity.HasOne(d => d.RecurringPlanNavigation).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.RecurringPlan)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_recurring_plan_fkey");

                        entity.HasOne(d => d.RevealRule).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.RevealRuleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_reveal_rule_id_fkey");

                        entity.HasOne(d => d.Source).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.SourceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_source_id_fkey");

                        entity.HasOne(d => d.Stage).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.StageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("crm_lead_stage_id_fkey");

                        // entity.HasOne(d => d.State).WithMany(p => p.CrmLead) .HasForeignKey(d => d.StateId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_state_id_fkey");
                        entity.HasOne(d => d.State).WithMany()
                            .HasForeignKey(d => d.StateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_state_id_fkey");

                        entity.HasOne(d => d.Team).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.TeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_team_id_fkey");

                        entity.HasOne(d => d.TitleNavigation).WithMany(p => p.CrmLead)
                            .HasForeignKey(d => d.Title)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_title_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.CrmLeadUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CrmLeadWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_write_uid_fkey");

                        // entity.HasMany(d => d.EventRegistration).WithMany(p => p.CrmLead)
                        entity.HasMany(d => d.EventRegistration).WithMany(p => p.CrmLead)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmLeadEventRegistrationRel",
                                r => r.HasOne<EventRegistration>().WithMany()
                                    .HasForeignKey("EventRegistrationId")
                                    .HasConstraintName("crm_lead_event_registration_rel_event_registration_id_fkey"),
                                l => l.HasOne<CrmLead>().WithMany()
                                    .HasForeignKey("CrmLeadId")
                                    .HasConstraintName("crm_lead_event_registration_rel_crm_lead_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmLeadId", "EventRegistrationId").HasName("crm_lead_event_registration_rel_pkey");
                                    j.ToTable("crm_lead_event_registration_rel");
                                    j.HasIndex(new[] { "EventRegistrationId", "CrmLeadId" }, "crm_lead_event_registration_r_event_registration_id_crm_lea_idx");
                                    j.IndexerProperty<Guid>("CrmLeadId").HasColumnName("crm_lead_id");
                                    j.IndexerProperty<Guid>("EventRegistrationId").HasColumnName("event_registration_id");
                                });

                        // entity.HasMany(d => d.PartnerNavigation).WithMany(p => p.Lead)
                        entity.HasMany(d => d.PartnerNavigation).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmLeadDeclinedPartner",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("PartnerId")
                                    .HasConstraintName("crm_lead_declined_partner_partner_id_fkey"),
                                l => l.HasOne<CrmLead>().WithMany()
                                    .HasForeignKey("LeadId")
                                    .HasConstraintName("crm_lead_declined_partner_lead_id_fkey"),
                                j =>
                                {
                                    j.HasKey("LeadId", "PartnerId").HasName("crm_lead_declined_partner_pkey");
                                    j.ToTable("crm_lead_declined_partner");
                                    j.HasIndex(new[] { "PartnerId", "LeadId" }, "crm_lead_declined_partner_partner_id_lead_id_idx");
                                    j.IndexerProperty<Guid>("LeadId").HasColumnName("lead_id");
                                    j.IndexerProperty<Guid>("PartnerId").HasColumnName("partner_id");
                                });

                        // entity.HasMany(d => d.Tag).WithMany(p => p.Lead)
                        entity.HasMany(d => d.Tag).WithMany(p => p.Lead)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmTagRel",
                                r => r.HasOne<CrmTag>().WithMany()
                                    .HasForeignKey("TagId")
                                    .HasConstraintName("crm_tag_rel_tag_id_fkey"),
                                l => l.HasOne<CrmLead>().WithMany()
                                    .HasForeignKey("LeadId")
                                    .HasConstraintName("crm_tag_rel_lead_id_fkey"),
                                j =>
                                {
                                    j.HasKey("LeadId", "TagId").HasName("crm_tag_rel_pkey");
                                    j.ToTable("crm_tag_rel");
                                    j.HasIndex(new[] { "TagId", "LeadId" }, "crm_tag_rel_tag_id_lead_id_idx");
                                    j.IndexerProperty<Guid>("LeadId").HasColumnName("lead_id");
                                    j.IndexerProperty<Guid>("TagId").HasColumnName("tag_id");
                                });

                        // entity.HasMany(d => d.WebsiteVisitor).WithMany(p => p.CrmLead)
                        entity.HasMany(d => d.WebsiteVisitor).WithMany(p => p.CrmLead)
                            .UsingEntity<Dictionary<string, object>>(
                                "CrmLeadWebsiteVisitorRel",
                                r => r.HasOne<WebsiteVisitor>().WithMany()
                                    .HasForeignKey("WebsiteVisitorId")
                                    .HasConstraintName("crm_lead_website_visitor_rel_website_visitor_id_fkey"),
                                l => l.HasOne<CrmLead>().WithMany()
                                    .HasForeignKey("CrmLeadId")
                                    .HasConstraintName("crm_lead_website_visitor_rel_crm_lead_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CrmLeadId", "WebsiteVisitorId").HasName("crm_lead_website_visitor_rel_pkey");
                                    j.ToTable("crm_lead_website_visitor_rel");
                                    j.HasIndex(new[] { "WebsiteVisitorId", "CrmLeadId" }, "crm_lead_website_visitor_rel_website_visitor_id_crm_lead_id_idx");
                                    j.IndexerProperty<Guid>("CrmLeadId").HasColumnName("crm_lead_id");
                                    j.IndexerProperty<Guid>("WebsiteVisitorId").HasColumnName("website_visitor_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}