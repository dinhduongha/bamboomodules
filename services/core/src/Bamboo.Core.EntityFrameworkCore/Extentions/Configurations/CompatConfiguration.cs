using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCompat(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrApplicantSkill>(entity =>
            {
                // v16-Compat
                /*                
                //entity.HasOne(d => d.Skill).WithMany(p => p.HrApplicantSkill)
                entity.HasOne(d => d.Skill).WithMany()
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_applicant_skill_skill_id_fkey");

                //entity.HasOne(d => d.SkillLevel).WithMany(p => p.HrApplicantSkill)
                entity.HasOne(d => d.SkillLevel).WithMany()
                    .HasForeignKey(d => d.SkillLevelId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_applicant_skill_skill_level_id_fkey");

                //entity.HasOne(d => d.SkillType).WithMany(p => p.HrApplicantSkill)
                entity.HasOne(d => d.SkillType).WithMany()                
                    .HasForeignKey(d => d.SkillTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_applicant_skill_skill_type_id_fkey");
                */

            });
            modelBuilder.Entity<MailChannel>(entity =>
            {
                // v16-Compat
                /*
                //entity.HasOne(d => d.ChatbotCurrentStep).WithMany(p => p.MailChannel)
                entity.HasOne(d => d.ChatbotCurrentStep).WithMany()
                    .HasForeignKey(d => d.ChatbotCurrentStepId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_channel_chatbot_current_step_id_fkey");

                //entity.HasOne(d => d.LivechatChannel).WithMany(p => p.MailChannel)                
                entity.HasOne(d => d.LivechatChannel).WithMany()
                    .HasForeignKey(d => d.LivechatChannelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_channel_livechat_channel_id_fkey");

                //entity.HasOne(d => d.LivechatVisitor).WithMany(p => p.MailChannel)
                entity.HasOne(d => d.LivechatVisitor).WithMany()
                    .HasForeignKey(d => d.LivechatVisitorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_channel_livechat_visitor_id_fkey");
                */
            });
            modelBuilder.Entity<MailChannelMember>(entity =>
            {
                //entity.HasOne(d => d.Guest).WithMany(p => p.MailChannelMember)
                entity.HasOne(d => d.Guest).WithMany()
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mail_channel_member_guest_id_fkey");

            });
            modelBuilder.Entity<RestaurantPrinter>(entity =>
            {
                // v16-Compat
                /*
                // entity.HasMany(d => d.Category).WithMany(p => p.Printer)
                entity.HasMany(d => d.Category).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RestaurantPrinterCategoryRel",
                    r => r.HasOne<PosCategory>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("restaurant_printer_category_rel_category_id_fkey"),
                    l => l.HasOne<RestaurantPrinter>().WithMany()
                        .HasForeignKey("PrinterId")
                        .HasConstraintName("restaurant_printer_category_rel_printer_id_fkey"),
                    j =>
                    {
                        j.HasKey("PrinterId", "CategoryId").HasName("restaurant_printer_category_rel_pkey");
                        j.ToTable("restaurant_printer_category_rel");
                        j.HasIndex(new[] { "CategoryId", "PrinterId" }, "printer_category_rel_category_id_printer_id_idx");
                        j.IndexerProperty<Guid>("PrinterId").HasColumnName("printer_id");
                        j.IndexerProperty<Guid>("CategoryId").HasColumnName("category_id");
                    });
                */
            });

            modelBuilder.Entity<AccountAccount>(entity =>
            {
                // entity.HasOne(d => d.Company).WithMany(p => p.AccountAccount) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_account_company_id_fkey");
                entity.HasOne(d => d.Company).WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_account_company_id_fkey");

                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountAccount) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_account_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_account_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<AccountAnalyticAccount>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountAnalyticAccount) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_analytic_account_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_analytic_account_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<AccountAssetAsset>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountAssetAsset) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_asset_asset_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_asset_asset_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<AccountAssetCategory>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountAssetCategory) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_asset_category_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_asset_category_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<AccountJournal>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountJournal) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_journal_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<AccountReconcileModel>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountReconcileModel) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_reconcile_model_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_reconcile_model_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<AccountTaxRepartitionLine>(entity =>
            {
                // v16-Compat
                entity.HasOne(d => d.InvoiceTax).WithMany(p => p.AccountTaxRepartitionLineInvoiceTax)
                    .HasForeignKey(d => d.InvoiceTaxId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_tax_repartition_line_invoice_tax_id_fkey");

                // v16-Compat
                entity.HasOne(d => d.RefundTax).WithMany(p => p.AccountTaxRepartitionLineRefundTax)
                    .HasForeignKey(d => d.RefundTaxId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_tax_repartition_line_refund_tax_id_fkey");
            });

            modelBuilder.Entity<BlogBlog>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.BlogBlog) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("blog_blog_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("blog_blog_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<BlogPost>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.BlogPost) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("blog_post_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("blog_post_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<BusPresence>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            });

            modelBuilder.Entity<CalendarEvent>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CalendarEvent) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("calendar_event_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<CrmLead>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrmLead) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_lead_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<CrmTeam>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrmTeam) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_team_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_team_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<CrmTeamMember>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrmTeamMember) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crm_team_member_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_team_member_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<CrossoveredBudget>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<EventBooth>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_booth_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<EventEvent>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_event_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<EventRegistration>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_registration_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<EventSponsor>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_sponsor_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<EventTrack>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_track_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<FleetVehicle>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<FleetVehicleLogContract>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_log_contract_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<FleetVehicleLogServices>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_log_services_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ForumForum>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("forum_forum_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ForumPost>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("forum_post_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ForumTag>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("forum_tag_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<GamificationBadge>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<GamificationChallenge>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<HrContract>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_contract_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<HrDepartment>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_department_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<HrJob>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_job_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<HrLeaveAllocation>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_allocation_mode_company_id_fkey");

            });

            modelBuilder.Entity<LoyaltyCard>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("loyalty_card_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<LunchSupplier>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_supplier_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MailBlacklist>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mail_blacklist_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MailingContact>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_contact_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MailingMailing>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mailing_mailing_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MaintenanceEquipmentCategory>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_category_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MaintenanceEquipment>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_equipment_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MaintenanceRequest>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("maintenance_request_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MrpBom>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_bom_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MrpProduction>(entity =>
            {
                // v16-Compat
                entity.HasOne(d => d.AnalyticAccount).WithMany()
                    .HasForeignKey(d => d.AnalyticAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_analytic_account_id_fkey");

                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.MrpProduction) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_production_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MrpUnbuild>(entity =>
            {
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.CrossoveredBudget) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("crossovered_budget_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_unbuild_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<MrpWorkcenter>(entity =>
            {
                // v16-Compat
                entity.HasOne(d => d.CostsHourAccount).WithMany()
                    .HasForeignKey(d => d.CostsHourAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_workcenter_costs_hour_account_id_fkey");
            });

            modelBuilder.Entity<OnboardingOnboardingStep>(entity =>
            {
                // v16-Compat
                entity.HasOne(d => d.Onboarding).WithMany()
                    .HasForeignKey(d => d.OnboardingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("onboarding_onboarding_step_onboarding_id_fkey");
            });

            modelBuilder.Entity<OnboardingProgressStep>(entity =>
            {
                // v16-Compat
                entity.HasOne(d => d.Progress).WithMany()
                    .HasForeignKey(d => d.ProgressId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("onboarding_progress_step_progress_id_fkey");

            });

            modelBuilder.Entity<PhoneBlacklist>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.PhoneBlacklist) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<PosSession>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.PosSession) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_session_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ProductProduct>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProductProduct) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_product_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ProductTemplate>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProductTemplate) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ProjectMilestone>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProjectMilestone) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_milestone_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ProjectProject>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProjectProject) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_project_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ProjectTask>(entity =>
            {
                // v16-Compat
                entity.HasOne(d => d.AnalyticAccount).WithMany(p => p.ProjectTask)
                    .HasForeignKey(d => d.AnalyticAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_analytic_account_id_fkey");

                // v16-Compat
                entity.HasOne(d => d.Ancestor).WithMany()
                    .HasForeignKey(d => d.AncestorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_ancestor_id_fkey");

                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProjectTask) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_task_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<ProjectUpdate>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ProjectUpdate) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("project_update_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.PurchaseOrder) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("phone_blacklist_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<PurchaseRequisition>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.PurchaseRequisition) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<RepairOrder>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.RepairOrder) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ResCompany>(entity =>
            {
                // entity.HasOne(d => d.AccountJournalPaymentCreditAccount).WithMany(p => p.ResCompanyAccountJournalPaymentCreditAccount) .HasForeignKey(d => d.AccountJournalPaymentCreditAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_company_account_journal_payment_credit_account_id_fkey");
                entity.HasOne(d => d.AccountJournalPaymentCreditAccount).WithMany()
                    .HasForeignKey(d => d.AccountJournalPaymentCreditAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_journal_payment_credit_account_id_fkey");

                // entity.HasOne(d => d.AccountJournalPaymentDebitAccount).WithMany(p => p.ResCompanyAccountJournalPaymentDebitAccount) .HasForeignKey(d => d.AccountJournalPaymentDebitAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_company_account_journal_payment_debit_account_id_fkey");
                entity.HasOne(d => d.AccountJournalPaymentDebitAccount).WithMany()
                    .HasForeignKey(d => d.AccountJournalPaymentDebitAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_journal_payment_debit_account_id_fkey");

                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ResCompany) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_message_main_attachment_id_fkey");

                // entity.HasOne(d => d.PropertyStockAccountInputCateg).WithMany(p => p.ResCompanyPropertyStockAccountInputCateg) .HasForeignKey(d => d.PropertyStockAccountInputCategId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_company_property_stock_account_input_categ_id_fkey");
                entity.HasOne(d => d.PropertyStockAccountInputCateg).WithMany()
                    .HasForeignKey(d => d.PropertyStockAccountInputCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_property_stock_account_input_categ_id_fkey");

                // entity.HasOne(d => d.PropertyStockAccountOutputCateg).WithMany(p => p.ResCompanyPropertyStockAccountOutputCateg) .HasForeignKey(d => d.PropertyStockAccountOutputCategId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_company_property_stock_account_output_categ_id_fkey");
                entity.HasOne(d => d.PropertyStockAccountOutputCateg).WithMany()
                    .HasForeignKey(d => d.PropertyStockAccountOutputCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_property_stock_account_output_categ_id_fkey");

                // entity.HasOne(d => d.PropertyStockValuationAccount).WithMany(p => p.ResCompanyPropertyStockValuationAccount) .HasForeignKey(d => d.PropertyStockValuationAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_company_property_stock_valuation_account_id_fkey");
                entity.HasOne(d => d.PropertyStockValuationAccount).WithMany()
                    .HasForeignKey(d => d.PropertyStockValuationAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_property_stock_valuation_account_id_fkey");

            });

            modelBuilder.Entity<ResPartner>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ResPartner) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<ResPartnerBank>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ResPartnerBank) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_bank_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<SaleOrder>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.SaleOrder) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<SlideChannel>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.SlideChannel) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_channel_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<SlideSlide>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.SlideSlide) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("slide_slide_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<StockLandedCost>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.StockLandedCost) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_landed_cost_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<StockLot>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.StockLot) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_lot_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<StockPickingBatch>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.StockPickingBatch) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_batch_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<StockPicking>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.StockPicking) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<StockReturnPicking>(entity =>
            {
                // v16-Compat
                entity.HasOne(d => d.Location).WithMany(p => p.StockReturnPickingLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_return_picking_location_id_fkey");

                // v16-Compat
                entity.HasOne(d => d.OriginalLocation).WithMany(p => p.StockReturnPickingOriginalLocation)
                    .HasForeignKey(d => d.OriginalLocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_return_picking_original_location_id_fkey");

                // v16-Compat
                entity.HasOne(d => d.ParentLocation).WithMany(p => p.StockReturnPickingParentLocation)
                    .HasForeignKey(d => d.ParentLocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_return_picking_parent_location_id_fkey");
            });

            modelBuilder.Entity<StockScrap>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.StockScrap) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_requisition_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_message_main_attachment_id_fkey");

            });

            modelBuilder.Entity<SurveyQuestion>(entity =>
            {
                // v16-Compat
                entity.HasOne(d => d.TriggeringAnswer).WithMany()
                    .HasForeignKey(d => d.TriggeringAnswerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_question_triggering_answer_id_fkey");

                // v16-Compat
                entity.HasOne(d => d.TriggeringQuestion).WithMany(p => p.InverseTriggeringQuestion)
                    .HasForeignKey(d => d.TriggeringQuestionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_question_triggering_question_id_fkey");

            });

            modelBuilder.Entity<SurveySurvey>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.SurveySurvey) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_survey_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_survey_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<SurveyUserInput>(entity =>
            {
                // v16-Compat
                // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.SurveyUserInput) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("survey_survey_message_main_attachment_id_fkey");
                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("survey_user_input_message_main_attachment_id_fkey");
            });

            modelBuilder.Entity<IrModelInherit>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            });

            modelBuilder.Entity<IrModuleModuleDependency>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            });

            modelBuilder.Entity<WebsiteTrack>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            });

            modelBuilder.Entity<MailFollowers>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            });
            modelBuilder.Entity<MailNotification>(entity =>
            {
                entity.Property(e => e.CreationTime)
                    .HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            });

            modelBuilder.Entity<PartnerStatRel>(entity =>
            {
                entity.HasKey(e => new { e.OsvMemoryId, e.PartnerId }).HasName("partner_stat_rel_pkey");

                entity.ToTable("partner_stat_rel");

                entity.HasIndex(e => new { e.PartnerId, e.OsvMemoryId }, "partner_stat_rel_partner_id_osv_memory_id_idx");

                entity.Property(e => e.OsvMemoryId).HasColumnName("osv_memory_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");

                entity.HasOne(d => d.OsvMemory).WithMany(p => p.PartnerStatRel)
                    .HasForeignKey(d => d.OsvMemoryId)
                    .HasConstraintName("partner_stat_rel_osv_memory_id_fkey");
            });
            /*
            modelBuilder.Entity<ResourceCalendar>(entity =>
            {
                entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("resource_calendar_company_id_fkey");

            });
            modelBuilder.Entity<Website>(entity =>
            {
                entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("website_company_id_fkey");

            });
            */
        }
    }
}