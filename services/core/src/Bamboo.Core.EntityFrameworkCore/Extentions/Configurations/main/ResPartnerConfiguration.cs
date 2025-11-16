using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.Activation, "res_partner__activation_index").HasFilter("(activation IS NOT NULL)");

                        entity.HasIndex(e => e.CommercialPartnerId, "res_partner__commercial_partner_id_index");

                        entity.HasIndex(e => e.TenantId, "res_partner__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CompleteName, "res_partner__complete_name_index");

                        entity.HasIndex(e => e.IsPublished, "res_partner__is_published_index");

                        entity.HasIndex(e => e.Name, "res_partner__name_index");

                        entity.HasIndex(e => e.ParentId, "res_partner__parent_id_index");

                        entity.HasIndex(e => e.Ref, "res_partner__ref_index");

                        entity.HasIndex(e => e.Vat, "res_partner__vat_index");

                        entity.HasIndex(e => e.WebsiteId, "res_partner__website_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Activation).HasColumnName("activation");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AdditionalInfo).HasColumnName("additional_info");
                        entity.Property(e => e.AssignedPartnerId).HasColumnName("assigned_partner_id");
                        entity.Property(e => e.AssociateMember).HasColumnName("associate_member");
                        entity.Property(e => e.AutopostBills).HasColumnName("autopost_bills");
                        entity.Property(e => e.Barcode)
                            .HasColumnType("jsonb")
                            .HasColumnName("barcode");
                        entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
                        entity.Property(e => e.CalendarLastNotifAck)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("calendar_last_notif_ack");
                        entity.Property(e => e.City).HasColumnName("city");
                        entity.Property(e => e.CityId).HasColumnName("city_id");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.Comment).HasColumnName("comment");
                        entity.Property(e => e.CommercialCompanyName).HasColumnName("commercial_company_name");
                        entity.Property(e => e.CommercialPartnerId).HasColumnName("commercial_partner_id");

                        entity.Property(e => e.CompanyName).HasColumnName("company_name");
                        entity.Property(e => e.CompanyRegistry).HasColumnName("company_registry");
                        entity.Property(e => e.CompleteName).HasColumnName("complete_name");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CreditLimit)
                            .HasColumnType("jsonb")
                            .HasColumnName("credit_limit");
                        entity.Property(e => e.CustomerRank).HasColumnName("customer_rank");
                        entity.Property(e => e.DateLocalization).HasColumnName("date_localization");
                        entity.Property(e => e.DatePartnership).HasColumnName("date_partnership");
                        entity.Property(e => e.DateReview).HasColumnName("date_review");
                        entity.Property(e => e.DateReviewNext).HasColumnName("date_review_next");
                        entity.Property(e => e.DebitLimit).HasColumnName("debit_limit");
                        entity.Property(e => e.Email).HasColumnName("email");
                        entity.Property(e => e.EmailNormalized).HasColumnName("email_normalized");
                        entity.Property(e => e.Employee).HasColumnName("employee");
                        entity.Property(e => e.FreeMember).HasColumnName("free_member");
                        entity.Property(e => e.Function).HasColumnName("function");
                        entity.Property(e => e.GradeId).HasColumnName("grade_id");
                        entity.Property(e => e.GradeSequence).HasColumnName("grade_sequence");
                        entity.Property(e => e.IgnoreAbnormalInvoiceAmount)
                            .HasColumnType("jsonb")
                            .HasColumnName("ignore_abnormal_invoice_amount");
                        entity.Property(e => e.IgnoreAbnormalInvoiceDate)
                            .HasColumnType("jsonb")
                            .HasColumnName("ignore_abnormal_invoice_date");
                        entity.Property(e => e.ImplementedPartnerCount).HasColumnName("implemented_partner_count");
                        entity.Property(e => e.IndustryId).HasColumnName("industry_id");
                        entity.Property(e => e.InvoiceEdiFormatStore)
                            .HasColumnType("jsonb")
                            .HasColumnName("invoice_edi_format_store");
                        entity.Property(e => e.InvoiceSendingMethod)
                            .HasColumnType("jsonb")
                            .HasColumnName("invoice_sending_method");
                        entity.Property(e => e.InvoiceTemplatePdfReportId).HasColumnName("invoice_template_pdf_report_id");
                        entity.Property(e => e.InvoiceWarn).HasColumnName("invoice_warn");
                        entity.Property(e => e.InvoiceWarnMsg).HasColumnName("invoice_warn_msg");
                        entity.Property(e => e.IsCompany).HasColumnName("is_company");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.LatestFollowupSequence).HasColumnName("latest_followup_sequence");
                        entity.Property(e => e.MembershipAmount).HasColumnName("membership_amount");
                        entity.Property(e => e.MembershipCancel).HasColumnName("membership_cancel");
                        entity.Property(e => e.MembershipStart).HasColumnName("membership_start");
                        entity.Property(e => e.MembershipState).HasColumnName("membership_state");
                        entity.Property(e => e.MembershipStop).HasColumnName("membership_stop");
                        entity.Property(e => e.MessageBounce).HasColumnName("message_bounce");
                        entity.Property(e => e.Mobile).HasColumnName("mobile");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.PartnerGid).HasColumnName("partner_gid");
                        entity.Property(e => e.PartnerLatitude).HasColumnName("partner_latitude");
                        entity.Property(e => e.PartnerLongitude).HasColumnName("partner_longitude");
                        entity.Property(e => e.PartnerShare).HasColumnName("partner_share");
                        entity.Property(e => e.PartnerWeight).HasColumnName("partner_weight");
                        entity.Property(e => e.PaymentNextAction).HasColumnName("payment_next_action");
                        entity.Property(e => e.PaymentNextActionDate).HasColumnName("payment_next_action_date");
                        entity.Property(e => e.PaymentNote).HasColumnName("payment_note");
                        entity.Property(e => e.PaymentResponsibleId).HasColumnName("payment_responsible_id");
                        entity.Property(e => e.PeppolEas).HasColumnName("peppol_eas");
                        entity.Property(e => e.PeppolEndpoint).HasColumnName("peppol_endpoint");
                        entity.Property(e => e.PeppolVerificationState)
                            .HasColumnType("jsonb")
                            .HasColumnName("peppol_verification_state");
                        entity.Property(e => e.Phone).HasColumnName("phone");
                        entity.Property(e => e.PhoneSanitized).HasColumnName("phone_sanitized");
                        entity.Property(e => e.PickingWarn).HasColumnName("picking_warn");
                        entity.Property(e => e.PickingWarnMsg).HasColumnName("picking_warn_msg");
                        entity.Property(e => e.PlanToChangeBike).HasColumnName("plan_to_change_bike");
                        entity.Property(e => e.PlanToChangeCar).HasColumnName("plan_to_change_car");
                        entity.Property(e => e.PropertyAccountPayableId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_payable_id");
                        entity.Property(e => e.PropertyAccountPositionId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_position_id");
                        entity.Property(e => e.PropertyAccountReceivableId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_receivable_id");
                        entity.Property(e => e.PropertyDeliveryCarrierId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_delivery_carrier_id");
                        entity.Property(e => e.PropertyInboundPaymentMethodLineId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_inbound_payment_method_line_id");
                        entity.Property(e => e.PropertyOutboundPaymentMethodLineId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_outbound_payment_method_line_id");
                        entity.Property(e => e.PropertyPaymentTermId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_payment_term_id");
                        entity.Property(e => e.PropertyPurchaseCurrencyId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_purchase_currency_id");
                        entity.Property(e => e.PropertyStockCustomer)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_customer");
                        entity.Property(e => e.PropertyStockSubcontractor)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_subcontractor");
                        entity.Property(e => e.PropertyStockSupplier)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_supplier");
                        entity.Property(e => e.PropertySupplierPaymentTermId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_supplier_payment_term_id");
                        entity.Property(e => e.PurchaseWarn).HasColumnName("purchase_warn");
                        entity.Property(e => e.PurchaseWarnMsg).HasColumnName("purchase_warn_msg");
                        entity.Property(e => e.ReceiptReminderEmail)
                            .HasColumnType("jsonb")
                            .HasColumnName("receipt_reminder_email");
                        entity.Property(e => e.Ref).HasColumnName("ref");
                        entity.Property(e => e.ReminderDateBeforeReceipt)
                            .HasColumnType("jsonb")
                            .HasColumnName("reminder_date_before_receipt");
                        entity.Property(e => e.SaleWarn).HasColumnName("sale_warn");
                        entity.Property(e => e.SaleWarnMsg).HasColumnName("sale_warn_msg");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.SignupType).HasColumnName("signup_type");
                        entity.Property(e => e.SpecificPropertyProductPricelist)
                            .HasColumnType("jsonb")
                            .HasColumnName("specific_property_product_pricelist");
                        entity.Property(e => e.StateId).HasColumnName("state_id");
                        entity.Property(e => e.Street).HasColumnName("street");
                        entity.Property(e => e.Street2).HasColumnName("street2");
                        entity.Property(e => e.StreetName).HasColumnName("street_name");
                        entity.Property(e => e.StreetNumber).HasColumnName("street_number");
                        entity.Property(e => e.StreetNumber2).HasColumnName("street_number2");
                        entity.Property(e => e.SupplierRank).HasColumnName("supplier_rank");
                        entity.Property(e => e.Title).HasColumnName("title");
                        entity.Property(e => e.Trust)
                            .HasColumnType("jsonb")
                            .HasColumnName("trust");
                        entity.Property(e => e.Type).HasColumnName("type");
                        entity.Property(e => e.Tz).HasColumnName("tz");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.Vat).HasColumnName("vat");
                        entity.Property(e => e.ViesValid).HasColumnName("vies_valid");
                        entity.Property(e => e.Website).HasColumnName("website");
                        entity.Property(e => e.WebsiteDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_description");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.WebsiteMetaDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_description");
                        entity.Property(e => e.WebsiteMetaKeywords)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_keywords");
                        entity.Property(e => e.WebsiteMetaOgImg).HasColumnName("website_meta_og_img");
                        entity.Property(e => e.WebsiteMetaTitle)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_title");
                        entity.Property(e => e.WebsiteShortDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_short_description");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.Zip).HasColumnName("zip");

                        entity.HasOne(d => d.ActivationNavigation).WithMany(p => p.ResPartner)
                            .HasForeignKey(d => d.Activation)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_activation_fkey");

                        // entity.HasOne(d => d.AssignedPartner).WithMany(p => p.InverseAssignedPartner) .HasForeignKey(d => d.AssignedPartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_assigned_partner_id_fkey");
                        entity.HasOne(d => d.AssignedPartner).WithMany()
                            .HasForeignKey(d => d.AssignedPartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_assigned_partner_id_fkey");

                        // entity.HasOne(d => d.AssociateMemberNavigation).WithMany(p => p.InverseAssociateMemberNavigation) .HasForeignKey(d => d.AssociateMember) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_associate_member_fkey");
                        entity.HasOne(d => d.AssociateMemberNavigation).WithMany()
                            .HasForeignKey(d => d.AssociateMember)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_associate_member_fkey");

                        // entity.HasOne(d => d.Buyer).WithMany(p => p.ResPartnerBuyer) .HasForeignKey(d => d.BuyerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_buyer_id_fkey");
                        entity.HasOne(d => d.Buyer).WithMany()
                            .HasForeignKey(d => d.BuyerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_buyer_id_fkey");

                        entity.HasOne(d => d.CityNavigation).WithMany(p => p.ResPartner)
                            .HasForeignKey(d => d.CityId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_city_id_fkey");

                        // entity.HasOne(d => d.CommercialPartner).WithMany(p => p.InverseCommercialPartner) .HasForeignKey(d => d.CommercialPartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_commercial_partner_id_fkey");
                        entity.HasOne(d => d.CommercialPartner).WithMany()
                            .HasForeignKey(d => d.CommercialPartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_commercial_partner_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ResPartner) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_company_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.ResPartner) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("res_partner_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("res_partner_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResPartnerCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_create_uid_fkey");

                        entity.HasOne(d => d.Grade).WithMany(p => p.ResPartner)
                            .HasForeignKey(d => d.GradeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_grade_id_fkey");

                        entity.HasOne(d => d.Industry).WithMany(p => p.ResPartner)
                            .HasForeignKey(d => d.IndustryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_industry_id_fkey");

                        entity.HasOne(d => d.InvoiceTemplatePdfReport).WithMany(p => p.ResPartner)
                            .HasForeignKey(d => d.InvoiceTemplatePdfReportId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_invoice_template_pdf_report_id_fkey");

                        // entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent) .HasForeignKey(d => d.ParentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_parent_id_fkey");
                        entity.HasOne(d => d.Parent).WithMany()
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_parent_id_fkey");

                        // entity.HasOne(d => d.PaymentResponsible).WithMany(p => p.ResPartnerPaymentResponsible) .HasForeignKey(d => d.PaymentResponsibleId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_payment_responsible_id_fkey");
                        entity.HasOne(d => d.PaymentResponsible).WithMany()
                            .HasForeignKey(d => d.PaymentResponsibleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_payment_responsible_id_fkey");

                        // entity.HasOne(d => d.State).WithMany(p => p.ResPartner) .HasForeignKey(d => d.StateId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("res_partner_state_id_fkey");
                        entity.HasOne(d => d.State).WithMany()
                            .HasForeignKey(d => d.StateId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("res_partner_state_id_fkey");

                        entity.HasOne(d => d.TitleNavigation).WithMany(p => p.ResPartner)
                            .HasForeignKey(d => d.Title)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_title_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.ResPartnerUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_user_id_fkey");

                        // entity.HasOne(d => d.WebsiteNavigation).WithMany(p => p.ResPartner) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("res_partner_website_id_fkey");
                        entity.HasOne(d => d.WebsiteNavigation).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("res_partner_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResPartnerWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_write_uid_fkey");

                        // entity.HasMany(d => d.CalendarEvent).WithMany(p => p.ResPartner)
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
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                    j.IndexerProperty<Guid>("CalendarEventId").HasColumnName("calendar_event_id");
                                });

                        // entity.HasMany(d => d.Tag).WithMany(p => p.Partner)
                        entity.HasMany<ResPartnerTag>().WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ResPartnerResPartnerTagRel",
                                r => r.HasOne<ResPartnerTag>().WithMany()
                                    .HasForeignKey("TagId")
                                    .HasConstraintName("res_partner_res_partner_tag_rel_tag_id_fkey"),
                                l => l.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("PartnerId")
                                    .HasConstraintName("res_partner_res_partner_tag_rel_partner_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PartnerId", "TagId").HasName("res_partner_res_partner_tag_rel_pkey");
                                    j.ToTable("res_partner_res_partner_tag_rel");
                                    j.HasIndex(new[] { "TagId", "PartnerId" }, "res_partner_res_partner_tag_rel_tag_id_partner_id_idx");
                                    j.IndexerProperty<Guid>("PartnerId").HasColumnName("partner_id");
                                    j.IndexerProperty<Guid>("TagId").HasColumnName("tag_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}