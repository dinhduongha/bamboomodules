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
        public static void ConfigureCrmLead(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrmLead>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("crm_lead_pkey");

                entity.ToTable("crm_lead");

                entity.HasIndex(e => e.TenantId, "crm_lead_company_id_index");

                entity.HasIndex(e => new { e.CreationTime, e.TeamId }, "crm_lead_create_date_team_id_idx");

                entity.HasIndex(e => e.DateLastStageUpdate, "crm_lead_date_last_stage_update_index");

                entity.HasIndex(e => e.EmailFrom, "crm_lead_email_from_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.LeadMiningRequestId, "crm_lead_lead_mining_request_id_index").HasFilter("(lead_mining_request_id IS NOT NULL)");

                entity.HasIndex(e => e.LostReasonId, "crm_lead_lost_reason_id_index");

                entity.HasIndex(e => e.Name, "crm_lead_name_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.PartnerId, "crm_lead_partner_id_index");

                entity.HasIndex(e => e.Priority, "crm_lead_priority_index");

                entity.HasIndex(e => e.StageId, "crm_lead_stage_id_index");

                entity.HasIndex(e => e.TeamId, "crm_lead_team_id_index");

                entity.HasIndex(e => e.Type, "crm_lead_type_index");

                entity.HasIndex(e => e.UserId, "crm_lead_user_id_index");

                entity.HasIndex(e => new { e.UserId, e.TeamId, e.Type }, "crm_lead_user_id_team_id_type_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AutomatedProbability).HasColumnName("automated_probability");
                entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                entity.Property(e => e.City).HasColumnName("city");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ContactName).HasColumnName("contact_name");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateActionLast)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_action_last");
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
                entity.Property(e => e.DayClose).HasColumnName("day_close");
                entity.Property(e => e.DayOpen).HasColumnName("day_open");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.EmailCc).HasColumnName("email_cc");
                entity.Property(e => e.EmailFrom).HasColumnName("email_from");
                entity.Property(e => e.EmailNormalized).HasColumnName("email_normalized");
                entity.Property(e => e.EmailState).HasColumnName("email_state");
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
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Mobile).HasColumnName("mobile");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
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
                entity.Property(e => e.Referred).HasColumnName("referred");
                entity.Property(e => e.RevealId).HasColumnName("reveal_id");
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

                entity.HasOne(d => d.Campaign).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_campaign_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_company_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_create_uid_fkey");

                entity.HasOne(d => d.Lang).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.LangId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_lang_id_fkey");

                entity.HasOne(d => d.LeadMiningRequest).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.LeadMiningRequestId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_lead_mining_request_id_fkey");

                entity.HasOne(d => d.LostReason).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.LostReasonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("crm_lead_lost_reason_id_fkey");

                entity.HasOne(d => d.Medium).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.MediumId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_medium_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_message_main_attachment_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_partner_id_fkey");

                entity.HasOne(d => d.RecurringPlanNavigation).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.RecurringPlan)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_recurring_plan_fkey");

                entity.HasOne(d => d.Source).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_source_id_fkey");

                entity.HasOne(d => d.Stage).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("crm_lead_stage_id_fkey");

                entity.HasOne(d => d.State).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_state_id_fkey");

                entity.HasOne(d => d.Team).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_team_id_fkey");

                entity.HasOne(d => d.TitleNavigation).WithMany(p => p.CrmLeads)
                    .HasForeignKey(d => d.Title)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_title_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_write_uid_fkey");

                //entity.HasMany(d => d.Tags).WithMany(p => p.Leads)
                entity.HasMany<CrmTag>().WithMany()
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
                        });

                //entity.HasMany(d => d.WebsiteVisitors).WithMany(p => p.CrmLeads)
                entity.HasMany<WebsiteVisitor>().WithMany()
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
                        });
            });
        }
    }
}