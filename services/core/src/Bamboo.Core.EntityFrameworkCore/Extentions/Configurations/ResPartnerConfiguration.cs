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
        public static void ConfigureResPartner(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResPartner>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_partner_pkey");

                entity.ToTable("res_partner");

                entity.HasIndex(e => e.CommercialPartnerId, "res_partner_commercial_partner_id_index");

                entity.HasIndex(e => e.TenantId, "res_partner_company_id_index");

                entity.HasIndex(e => e.Date, "res_partner_date_index");

                entity.HasIndex(e => e.DisplayName, "res_partner_display_name_index");

                entity.HasIndex(e => e.IsPublished, "res_partner_is_published_index");

                entity.HasIndex(e => e.Name, "res_partner_name_index");

                entity.HasIndex(e => e.ParentId, "res_partner_parent_id_index");

                entity.HasIndex(e => e.Ref, "res_partner_ref_index");

                entity.HasIndex(e => e.Vat, "res_partner_vat_index");

                entity.HasIndex(e => e.WebsiteId, "res_partner_website_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AdditionalInfo).HasColumnName("additional_info");
                entity.Property(e => e.CalendarLastNotifAck)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("calendar_last_notif_ack");
                entity.Property(e => e.City).HasColumnName("city");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.Comment).HasColumnName("comment");
                entity.Property(e => e.CommercialCompanyName).HasColumnName("commercial_company_name");
                entity.Property(e => e.CommercialPartnerId).HasColumnName("commercial_partner_id");
                entity.Property(e => e.CompanyName).HasColumnName("company_name");
                entity.Property(e => e.CompanyRegistry).HasColumnName("company_registry");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CustomerRank).HasColumnName("customer_rank");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.DebitLimit).HasColumnName("debit_limit");
                entity.Property(e => e.DisplayName).HasColumnName("display_name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.EmailNormalized).HasColumnName("email_normalized");
                entity.Property(e => e.Employee).HasColumnName("employee");
                entity.Property(e => e.Function).HasColumnName("function");
                entity.Property(e => e.IndustryId).HasColumnName("industry_id");
                entity.Property(e => e.InvoiceWarn).HasColumnName("invoice_warn");
                entity.Property(e => e.InvoiceWarnMsg).HasColumnName("invoice_warn_msg");
                entity.Property(e => e.IsCompany).HasColumnName("is_company");
                entity.Property(e => e.IsPublished).HasColumnName("is_published");
                entity.Property(e => e.Lang).HasColumnName("lang");
                entity.Property(e => e.LastTimeEntriesChecked)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_time_entries_checked");
                entity.Property(e => e.LatestFollowupLevelIdWithoutLit).HasColumnName("latest_followup_level_id_without_lit");
                entity.Property(e => e.LatestFollowupSequence).HasColumnName("latest_followup_sequence");
                entity.Property(e => e.MessageBounce).HasColumnName("message_bounce");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Mobile).HasColumnName("mobile");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.PartnerGid).HasColumnName("partner_gid");
                entity.Property(e => e.PartnerLatitude).HasColumnName("partner_latitude");
                entity.Property(e => e.PartnerLongitude).HasColumnName("partner_longitude");
                entity.Property(e => e.PartnerShare).HasColumnName("partner_share");
                entity.Property(e => e.PaymentNextAction).HasColumnName("payment_next_action");
                entity.Property(e => e.PaymentNextActionDate).HasColumnName("payment_next_action_date");
                entity.Property(e => e.PaymentNote).HasColumnName("payment_note");
                entity.Property(e => e.PaymentResponsibleId).HasColumnName("payment_responsible_id");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.PhoneSanitized).HasColumnName("phone_sanitized");
                entity.Property(e => e.PickingWarn).HasColumnName("picking_warn");
                entity.Property(e => e.PickingWarnMsg).HasColumnName("picking_warn_msg");
                entity.Property(e => e.PlanToChangeBike).HasColumnName("plan_to_change_bike");
                entity.Property(e => e.PlanToChangeCar).HasColumnName("plan_to_change_car");
                entity.Property(e => e.PurchaseWarn).HasColumnName("purchase_warn");
                entity.Property(e => e.PurchaseWarnMsg).HasColumnName("purchase_warn_msg");
                entity.Property(e => e.Ref).HasColumnName("ref");
                entity.Property(e => e.SaleWarn).HasColumnName("sale_warn");
                entity.Property(e => e.SaleWarnMsg).HasColumnName("sale_warn_msg");
                entity.Property(e => e.SignupExpiration)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("signup_expiration");
                entity.Property(e => e.SignupToken).HasColumnName("signup_token");
                entity.Property(e => e.SignupType).HasColumnName("signup_type");
                entity.Property(e => e.StateId).HasColumnName("state_id");
                entity.Property(e => e.Street).HasColumnName("street");
                entity.Property(e => e.Street2).HasColumnName("street2");
                entity.Property(e => e.SupplierRank).HasColumnName("supplier_rank");
                entity.Property(e => e.TeamId).HasColumnName("team_id");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.Tz).HasColumnName("tz");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Vat).HasColumnName("vat");
                entity.Property(e => e.Website).HasColumnName("website");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                entity.Property(e => e.Zip).HasColumnName("zip");

                entity.HasOne(d => d.CommercialPartner).WithMany(p => p.InverseCommercialPartner)
                    .HasForeignKey(d => d.CommercialPartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_commercial_partner_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_company_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("res_partner_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_create_uid_fkey");

                entity.HasOne(d => d.Industry).WithMany(p => p.ResPartners)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_industry_id_fkey");

                entity.HasOne(d => d.LatestFollowupLevelIdWithoutLitNavigation).WithMany(p => p.ResPartners)
                    .HasForeignKey(d => d.LatestFollowupLevelIdWithoutLit)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_latest_followup_level_id_without_lit_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ResPartners)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_parent_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.PaymentResponsibleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_payment_responsible_id_fkey");

                entity.HasOne(d => d.State).WithMany(p => p.ResPartners)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("res_partner_state_id_fkey");

                entity.HasOne(d => d.Team).WithMany(p => p.ResPartners)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_team_id_fkey");

                entity.HasOne(d => d.TitleNavigation).WithMany(p => p.ResPartners)
                    .HasForeignKey(d => d.Title)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_title_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_user_id_fkey");

                entity.HasOne(d => d.WebsiteNavigation).WithMany(p => p.ResPartners)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("res_partner_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_write_uid_fkey");

                //entity.HasMany(d => d.CalendarEvents).WithMany(p => p.ResPartners)
                entity.HasMany<CalendarEvent>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "CalendarEventResPartnerRel",
                        r => r.HasOne<CalendarEvent>().WithMany()
                            .HasForeignKey("CalendarEventId")
                            .HasConstraintName("calendar_event_res_partner_rel_calendar_event_id_fkey"),
                        l => l.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("ResPartnerId")
                            .HasConstraintName("calendar_event_res_partner_rel_res_partner_id_fkey"),
                        j =>
                        {
                            j.HasKey("ResPartnerId", "CalendarEventId").HasName("calendar_event_res_partner_rel_pkey");
                            j.ToTable("calendar_event_res_partner_rel");
                            j.HasIndex(new[] { "CalendarEventId", "ResPartnerId" }, "calendar_event_res_partner_re_calendar_event_id_res_partner_idx");
                        });
            });
        }
    }
}