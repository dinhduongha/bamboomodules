using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResConfigSettings(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResConfigSettings>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_config_settings_pkey");

                        entity.ToTable("res_config_settings");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AuthOauthGoogleClientId).HasColumnName("auth_oauth_google_client_id");
                        entity.Property(e => e.AuthOauthGoogleEnabled).HasColumnName("auth_oauth_google_enabled");
                        entity.Property(e => e.AuthSignupResetPassword).HasColumnName("auth_signup_reset_password");
                        entity.Property(e => e.AuthSignupTemplateUserId).HasColumnName("auth_signup_template_user_id");
                        entity.Property(e => e.AuthSignupUninvited).HasColumnName("auth_signup_uninvited");
                        entity.Property(e => e.AuthTotpEnforce).HasColumnName("auth_totp_enforce");
                        entity.Property(e => e.AuthTotpPolicy).HasColumnName("auth_totp_policy");
                        entity.Property(e => e.AutomaticInvoice).HasColumnName("automatic_invoice");
                        entity.Property(e => e.BarcodeSeparator).HasColumnName("barcode_separator");
                        entity.Property(e => e.CalClientId).HasColumnName("cal_client_id");
                        entity.Property(e => e.CalClientSecret).HasColumnName("cal_client_secret");
                        entity.Property(e => e.CalMicrosoftClientId).HasColumnName("cal_microsoft_client_id");
                        entity.Property(e => e.CalMicrosoftClientSecret).HasColumnName("cal_microsoft_client_secret");
                        entity.Property(e => e.CalMicrosoftSyncPaused).HasColumnName("cal_microsoft_sync_paused");
                        entity.Property(e => e.CalSyncPaused).HasColumnName("cal_sync_paused");
                        entity.Property(e => e.ChartTemplate).HasColumnName("chart_template");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CrmAutoAssignmentAction).HasColumnName("crm_auto_assignment_action");
                        entity.Property(e => e.CrmAutoAssignmentIntervalNumber).HasColumnName("crm_auto_assignment_interval_number");
                        entity.Property(e => e.CrmAutoAssignmentIntervalType).HasColumnName("crm_auto_assignment_interval_type");
                        entity.Property(e => e.CrmAutoAssignmentRunDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("crm_auto_assignment_run_datetime");
                        entity.Property(e => e.CrmUseAutoAssignment).HasColumnName("crm_use_auto_assignment");
                        entity.Property(e => e.DefaultAllowOutOfStockOrder).HasColumnName("default_allow_out_of_stock_order");
                        entity.Property(e => e.DefaultAvailableThreshold).HasColumnName("default_available_threshold");
                        entity.Property(e => e.DefaultInvoicePolicy).HasColumnName("default_invoice_policy");
                        entity.Property(e => e.DefaultPickingPolicy).HasColumnName("default_picking_policy");
                        entity.Property(e => e.DefaultShowAvailability).HasColumnName("default_show_availability");
                        entity.Property(e => e.DelayAlertContract).HasColumnName("delay_alert_contract");
                        entity.Property(e => e.DigestEmails).HasColumnName("digest_emails");
                        entity.Property(e => e.DigestId).HasColumnName("digest_id");
                        entity.Property(e => e.EnableRecaptcha).HasColumnName("enable_recaptcha");
                        entity.Property(e => e.ExternalEmailServerDefault).HasColumnName("external_email_server_default");
                        entity.Property(e => e.GeolocProviderGooglemapKey).HasColumnName("geoloc_provider_googlemap_key");
                        entity.Property(e => e.GeolocProviderId).HasColumnName("geoloc_provider_id");
                        entity.Property(e => e.GoogleGmailClientIdentifier).HasColumnName("google_gmail_client_identifier");
                        entity.Property(e => e.GoogleGmailClientSecret).HasColumnName("google_gmail_client_secret");
                        entity.Property(e => e.GoogleMapsStaticApiKey).HasColumnName("google_maps_static_api_key");
                        entity.Property(e => e.GoogleMapsStaticApiSecret).HasColumnName("google_maps_static_api_secret");
                        entity.Property(e => e.GooglePlacesApiKey).HasColumnName("google_places_api_key");
                        entity.Property(e => e.GoogleTranslateApiKey).HasColumnName("google_translate_api_key");
                        entity.Property(e => e.GroupAnalyticAccounting).HasColumnName("group_analytic_accounting");
                        entity.Property(e => e.GroupAutoDoneSetting).HasColumnName("group_auto_done_setting");
                        entity.Property(e => e.GroupCashRounding).HasColumnName("group_cash_rounding");
                        entity.Property(e => e.GroupDiscountPerSoLine).HasColumnName("group_discount_per_so_line");
                        entity.Property(e => e.GroupExpiryDateOnDeliverySlip).HasColumnName("group_expiry_date_on_delivery_slip");
                        entity.Property(e => e.GroupFiscalYear).HasColumnName("group_fiscal_year");
                        entity.Property(e => e.GroupLotOnDeliverySlip).HasColumnName("group_lot_on_delivery_slip");
                        entity.Property(e => e.GroupLotOnInvoice).HasColumnName("group_lot_on_invoice");
                        entity.Property(e => e.GroupMassMailingCampaign).HasColumnName("group_mass_mailing_campaign");
                        entity.Property(e => e.GroupMrpByproducts).HasColumnName("group_mrp_byproducts");
                        entity.Property(e => e.GroupMrpReceptionReport).HasColumnName("group_mrp_reception_report");
                        entity.Property(e => e.GroupMrpRoutings).HasColumnName("group_mrp_routings");
                        entity.Property(e => e.GroupMrpWorkorderDependencies).HasColumnName("group_mrp_workorder_dependencies");
                        entity.Property(e => e.GroupMultiCurrency).HasColumnName("group_multi_currency");
                        entity.Property(e => e.GroupMultiWebsite).HasColumnName("group_multi_website");
                        entity.Property(e => e.GroupPosPreset).HasColumnName("group_pos_preset");
                        entity.Property(e => e.GroupProductPriceComparison).HasColumnName("group_product_price_comparison");
                        entity.Property(e => e.GroupProductPricelist).HasColumnName("group_product_pricelist");
                        entity.Property(e => e.GroupProductVariant).HasColumnName("group_product_variant");
                        entity.Property(e => e.GroupProformaSales).HasColumnName("group_proforma_sales");
                        entity.Property(e => e.GroupProjectStages).HasColumnName("group_project_stages");
                        entity.Property(e => e.GroupPurchaseAlternatives).HasColumnName("group_purchase_alternatives");
                        entity.Property(e => e.GroupSaleDeliveryAddress).HasColumnName("group_sale_delivery_address");
                        entity.Property(e => e.GroupSaleOrderTemplate).HasColumnName("group_sale_order_template");
                        entity.Property(e => e.GroupSendReminder).HasColumnName("group_send_reminder");
                        entity.Property(e => e.GroupShowUomPrice).HasColumnName("group_show_uom_price");
                        entity.Property(e => e.GroupStockAdvLocation).HasColumnName("group_stock_adv_location");
                        entity.Property(e => e.GroupStockLotPrintGs1).HasColumnName("group_stock_lot_print_gs1");
                        entity.Property(e => e.GroupStockMultiLocations).HasColumnName("group_stock_multi_locations");
                        entity.Property(e => e.GroupStockProductionLot).HasColumnName("group_stock_production_lot");
                        entity.Property(e => e.GroupStockReceptionReport).HasColumnName("group_stock_reception_report");
                        entity.Property(e => e.GroupStockSignDelivery).HasColumnName("group_stock_sign_delivery");
                        entity.Property(e => e.GroupStockTrackingLot).HasColumnName("group_stock_tracking_lot");
                        entity.Property(e => e.GroupStockTrackingOwner).HasColumnName("group_stock_tracking_owner");
                        entity.Property(e => e.GroupUnlockedByDefault).HasColumnName("group_unlocked_by_default");
                        entity.Property(e => e.GroupUom).HasColumnName("group_uom");
                        entity.Property(e => e.GroupUseLead).HasColumnName("group_use_lead");
                        entity.Property(e => e.GroupUseRecurringRevenues).HasColumnName("group_use_recurring_revenues");
                        entity.Property(e => e.GroupWarningPurchase).HasColumnName("group_warning_purchase");
                        entity.Property(e => e.GroupWarningSale).HasColumnName("group_warning_sale");
                        entity.Property(e => e.GroupWarningStock).HasColumnName("group_warning_stock");
                        entity.Property(e => e.HrExpenseAliasPrefix).HasColumnName("hr_expense_alias_prefix");
                        entity.Property(e => e.HrExpenseUseMailgateway).HasColumnName("hr_expense_use_mailgateway");
                        entity.Property(e => e.InvoiceMailTemplateId).HasColumnName("invoice_mail_template_id");
                        entity.Property(e => e.InvoicePolicy).HasColumnName("invoice_policy");
                        entity.Property(e => e.IsInstalledSale).HasColumnName("is_installed_sale");
                        entity.Property(e => e.IsKioskMode).HasColumnName("is_kiosk_mode");
                        entity.Property(e => e.IsMembershipMulti).HasColumnName("is_membership_multi");
                        entity.Property(e => e.IsNewsletterEnabled).HasColumnName("is_newsletter_enabled");
                        entity.Property(e => e.LeadEnrichAuto).HasColumnName("lead_enrich_auto");
                        entity.Property(e => e.LeadMiningInPipeline).HasColumnName("lead_mining_in_pipeline");
                        entity.Property(e => e.LockConfirmedPo).HasColumnName("lock_confirmed_po");
                        entity.Property(e => e.MassMailingMailServerId).HasColumnName("mass_mailing_mail_server_id");
                        entity.Property(e => e.MassMailingOutgoingMailServer).HasColumnName("mass_mailing_outgoing_mail_server");
                        entity.Property(e => e.MassMailingReports).HasColumnName("mass_mailing_reports");
                        entity.Property(e => e.MassMailingSplitContactName).HasColumnName("mass_mailing_split_contact_name");
                        entity.Property(e => e.MicrosoftOutlookClientIdentifier).HasColumnName("microsoft_outlook_client_identifier");
                        entity.Property(e => e.MicrosoftOutlookClientSecret).HasColumnName("microsoft_outlook_client_secret");
                        entity.Property(e => e.Minlength).HasColumnName("minlength");
                        entity.Property(e => e.ModuleAccount3wayMatch).HasColumnName("module_account_3way_match");
                        entity.Property(e => e.ModuleAccountAccountant).HasColumnName("module_account_accountant");
                        entity.Property(e => e.ModuleAccountBankStatementExtract).HasColumnName("module_account_bank_statement_extract");
                        entity.Property(e => e.ModuleAccountBankStatementImportQif).HasColumnName("module_account_bank_statement_import_qif");
                        entity.Property(e => e.ModuleAccountBatchPayment).HasColumnName("module_account_batch_payment");
                        entity.Property(e => e.ModuleAccountBudget).HasColumnName("module_account_budget");
                        entity.Property(e => e.ModuleAccountCheckPrinting).HasColumnName("module_account_check_printing");
                        entity.Property(e => e.ModuleAccountExtract).HasColumnName("module_account_extract");
                        entity.Property(e => e.ModuleAccountInterCompanyRules).HasColumnName("module_account_inter_company_rules");
                        entity.Property(e => e.ModuleAccountIntrastat).HasColumnName("module_account_intrastat");
                        entity.Property(e => e.ModuleAccountInvoiceExtract).HasColumnName("module_account_invoice_extract");
                        entity.Property(e => e.ModuleAccountIso20022).HasColumnName("module_account_iso20022");
                        entity.Property(e => e.ModuleAccountPayment).HasColumnName("module_account_payment");
                        entity.Property(e => e.ModuleAccountPeppol).HasColumnName("module_account_peppol");
                        entity.Property(e => e.ModuleAccountReports).HasColumnName("module_account_reports");
                        entity.Property(e => e.ModuleAccountSepaDirectDebit).HasColumnName("module_account_sepa_direct_debit");
                        entity.Property(e => e.ModuleAuthLdap).HasColumnName("module_auth_ldap");
                        entity.Property(e => e.ModuleAuthOauth).HasColumnName("module_auth_oauth");
                        entity.Property(e => e.ModuleBaseGeolocalize).HasColumnName("module_base_geolocalize");
                        entity.Property(e => e.ModuleBaseImport).HasColumnName("module_base_import");
                        entity.Property(e => e.ModuleCrmIapEnrich).HasColumnName("module_crm_iap_enrich");
                        entity.Property(e => e.ModuleCrmIapMine).HasColumnName("module_crm_iap_mine");
                        entity.Property(e => e.ModuleCurrencyRateLive).HasColumnName("module_currency_rate_live");
                        entity.Property(e => e.ModuleDelivery).HasColumnName("module_delivery");
                        entity.Property(e => e.ModuleDeliveryBpost).HasColumnName("module_delivery_bpost");
                        entity.Property(e => e.ModuleDeliveryDhl).HasColumnName("module_delivery_dhl");
                        entity.Property(e => e.ModuleDeliveryEasypost).HasColumnName("module_delivery_easypost");
                        entity.Property(e => e.ModuleDeliveryEnvia).HasColumnName("module_delivery_envia");
                        entity.Property(e => e.ModuleDeliveryFedexRest).HasColumnName("module_delivery_fedex_rest");
                        entity.Property(e => e.ModuleDeliverySendcloud).HasColumnName("module_delivery_sendcloud");
                        entity.Property(e => e.ModuleDeliveryShiprocket).HasColumnName("module_delivery_shiprocket");
                        entity.Property(e => e.ModuleDeliveryStarshipit).HasColumnName("module_delivery_starshipit");
                        entity.Property(e => e.ModuleDeliveryUpsRest).HasColumnName("module_delivery_ups_rest");
                        entity.Property(e => e.ModuleDeliveryUspsRest).HasColumnName("module_delivery_usps_rest");
                        entity.Property(e => e.ModuleEventBooth).HasColumnName("module_event_booth");
                        entity.Property(e => e.ModuleEventSale).HasColumnName("module_event_sale");
                        entity.Property(e => e.ModuleGoogleAddressAutocomplete).HasColumnName("module_google_address_autocomplete");
                        entity.Property(e => e.ModuleGoogleCalendar).HasColumnName("module_google_calendar");
                        entity.Property(e => e.ModuleGoogleGmail).HasColumnName("module_google_gmail");
                        entity.Property(e => e.ModuleGoogleRecaptcha).HasColumnName("module_google_recaptcha");
                        entity.Property(e => e.ModuleHrExpenseExtract).HasColumnName("module_hr_expense_extract");
                        entity.Property(e => e.ModuleHrExpenseStripe).HasColumnName("module_hr_expense_stripe");
                        entity.Property(e => e.ModuleHrPayrollExpense).HasColumnName("module_hr_payroll_expense");
                        entity.Property(e => e.ModuleHrPresence).HasColumnName("module_hr_presence");
                        entity.Property(e => e.ModuleHrRecruitmentExtract).HasColumnName("module_hr_recruitment_extract");
                        entity.Property(e => e.ModuleHrRecruitmentSurvey).HasColumnName("module_hr_recruitment_survey");
                        entity.Property(e => e.ModuleHrSkills).HasColumnName("module_hr_skills");
                        entity.Property(e => e.ModuleHrTimesheet).HasColumnName("module_hr_timesheet");
                        entity.Property(e => e.ModuleLoyalty).HasColumnName("module_loyalty");
                        entity.Property(e => e.ModuleMailPlugin).HasColumnName("module_mail_plugin");
                        entity.Property(e => e.ModuleMaintenanceWorksheet).HasColumnName("module_maintenance_worksheet");
                        entity.Property(e => e.ModuleMassMailingSlides).HasColumnName("module_mass_mailing_slides");
                        entity.Property(e => e.ModuleMicrosoftCalendar).HasColumnName("module_microsoft_calendar");
                        entity.Property(e => e.ModuleMicrosoftOutlook).HasColumnName("module_microsoft_outlook");
                        entity.Property(e => e.ModuleMrpMps).HasColumnName("module_mrp_mps");
                        entity.Property(e => e.ModuleMrpPlm).HasColumnName("module_mrp_plm");
                        entity.Property(e => e.ModuleMrpSubcontracting).HasColumnName("module_mrp_subcontracting");
                        entity.Property(e => e.ModulePartnerAutocomplete).HasColumnName("module_partner_autocomplete");
                        entity.Property(e => e.ModulePartnership).HasColumnName("module_partnership");
                        entity.Property(e => e.ModulePosAdyen).HasColumnName("module_pos_adyen");
                        entity.Property(e => e.ModulePosEvent).HasColumnName("module_pos_event");
                        entity.Property(e => e.ModulePosMercadoPago).HasColumnName("module_pos_mercado_pago");
                        entity.Property(e => e.ModulePosPineLabs).HasColumnName("module_pos_pine_labs");
                        entity.Property(e => e.ModulePosPricer).HasColumnName("module_pos_pricer");
                        entity.Property(e => e.ModulePosQfpay).HasColumnName("module_pos_qfpay");
                        entity.Property(e => e.ModulePosRazorpay).HasColumnName("module_pos_razorpay");
                        entity.Property(e => e.ModulePosStripe).HasColumnName("module_pos_stripe");
                        entity.Property(e => e.ModulePosVivaCom).HasColumnName("module_pos_viva_com");
                        entity.Property(e => e.ModuleProductEmailTemplate).HasColumnName("module_product_email_template");
                        entity.Property(e => e.ModuleProductExpiry).HasColumnName("module_product_expiry");
                        entity.Property(e => e.ModuleProductMargin).HasColumnName("module_product_margin");
                        entity.Property(e => e.ModuleProjectTimesheetHolidays).HasColumnName("module_project_timesheet_holidays");
                        entity.Property(e => e.ModulePurchaseProductMatrix).HasColumnName("module_purchase_product_matrix");
                        entity.Property(e => e.ModulePurchaseRequisition).HasColumnName("module_purchase_requisition");
                        entity.Property(e => e.ModuleQualityControl).HasColumnName("module_quality_control");
                        entity.Property(e => e.ModuleQualityControlWorksheet).HasColumnName("module_quality_control_worksheet");
                        entity.Property(e => e.ModuleSaleAmazon).HasColumnName("module_sale_amazon");
                        entity.Property(e => e.ModuleSaleCommission).HasColumnName("module_sale_commission");
                        entity.Property(e => e.ModuleSaleGelato).HasColumnName("module_sale_gelato");
                        entity.Property(e => e.ModuleSaleLoyalty).HasColumnName("module_sale_loyalty");
                        entity.Property(e => e.ModuleSaleMargin).HasColumnName("module_sale_margin");
                        entity.Property(e => e.ModuleSalePdfQuoteBuilder).HasColumnName("module_sale_pdf_quote_builder");
                        entity.Property(e => e.ModuleSaleProductMatrix).HasColumnName("module_sale_product_matrix");
                        entity.Property(e => e.ModuleSaleShopee).HasColumnName("module_sale_shopee");
                        entity.Property(e => e.ModuleSms).HasColumnName("module_sms");
                        entity.Property(e => e.ModuleSnailmailAccount).HasColumnName("module_snailmail_account");
                        entity.Property(e => e.ModuleStockBarcode).HasColumnName("module_stock_barcode");
                        entity.Property(e => e.ModuleStockBarcodeBarcodelookup).HasColumnName("module_stock_barcode_barcodelookup");
                        entity.Property(e => e.ModuleStockDropshipping).HasColumnName("module_stock_dropshipping");
                        entity.Property(e => e.ModuleStockFleet).HasColumnName("module_stock_fleet");
                        entity.Property(e => e.ModuleStockLandedCosts).HasColumnName("module_stock_landed_costs");
                        entity.Property(e => e.ModuleStockPickingBatch).HasColumnName("module_stock_picking_batch");
                        entity.Property(e => e.ModuleStockSms).HasColumnName("module_stock_sms");
                        entity.Property(e => e.ModuleVoip).HasColumnName("module_voip");
                        entity.Property(e => e.ModuleWebUnsplash).HasColumnName("module_web_unsplash");
                        entity.Property(e => e.ModuleWebsiteCfTurnstile).HasColumnName("module_website_cf_turnstile");
                        entity.Property(e => e.ModuleWebsiteCrmIapReveal).HasColumnName("module_website_crm_iap_reveal");
                        entity.Property(e => e.ModuleWebsiteEventExhibitor).HasColumnName("module_website_event_exhibitor");
                        entity.Property(e => e.ModuleWebsiteEventSale).HasColumnName("module_website_event_sale");
                        entity.Property(e => e.ModuleWebsiteEventTrack).HasColumnName("module_website_event_track");
                        entity.Property(e => e.ModuleWebsiteEventTrackLive).HasColumnName("module_website_event_track_live");
                        entity.Property(e => e.ModuleWebsiteEventTrackQuiz).HasColumnName("module_website_event_track_quiz");
                        entity.Property(e => e.ModuleWebsiteHrRecruitment).HasColumnName("module_website_hr_recruitment");
                        entity.Property(e => e.ModuleWebsiteLivechat).HasColumnName("module_website_livechat");
                        entity.Property(e => e.ModuleWebsiteSaleAutocomplete).HasColumnName("module_website_sale_autocomplete");
                        entity.Property(e => e.ModuleWebsiteSaleCollect).HasColumnName("module_website_sale_collect");
                        entity.Property(e => e.ModuleWebsiteSaleSlides).HasColumnName("module_website_sale_slides");
                        entity.Property(e => e.ModuleWebsiteSlidesForum).HasColumnName("module_website_slides_forum");
                        entity.Property(e => e.ModuleWebsiteSlidesSurvey).HasColumnName("module_website_slides_survey");
                        entity.Property(e => e.OvertimeCompanyThreshold).HasColumnName("overtime_company_threshold");
                        entity.Property(e => e.OvertimeEmployeeThreshold).HasColumnName("overtime_employee_threshold");
                        entity.Property(e => e.PayInvoicesOnline).HasColumnName("pay_invoices_online");
                        entity.Property(e => e.PoOrderApproval).HasColumnName("po_order_approval");
                        entity.Property(e => e.PosConfigId).HasColumnName("pos_config_id");
                        entity.Property(e => e.PosDefaultFiscalPositionId).HasColumnName("pos_default_fiscal_position_id");
                        entity.Property(e => e.PosDiscountProductId).HasColumnName("pos_discount_product_id");
                        entity.Property(e => e.PosIfaceCashdrawer).HasColumnName("pos_iface_cashdrawer");
                        entity.Property(e => e.PosIfaceElectronicScale).HasColumnName("pos_iface_electronic_scale");
                        entity.Property(e => e.PosIfacePrintViaProxy).HasColumnName("pos_iface_print_via_proxy");
                        entity.Property(e => e.PosIfacePrintbill).HasColumnName("pos_iface_printbill");
                        entity.Property(e => e.PosIfaceScanViaProxy).HasColumnName("pos_iface_scan_via_proxy");
                        entity.Property(e => e.PosIfaceSplitbill).HasColumnName("pos_iface_splitbill");
                        entity.Property(e => e.PosIsOrderPrinter).HasColumnName("pos_is_order_printer");
                        entity.Property(e => e.PosPricelistId).HasColumnName("pos_pricelist_id");
                        entity.Property(e => e.PosReceiptFooter).HasColumnName("pos_receipt_footer");
                        entity.Property(e => e.PosReceiptHeader).HasColumnName("pos_receipt_header");
                        entity.Property(e => e.PosSetTipAfterPayment).HasColumnName("pos_set_tip_after_payment");
                        entity.Property(e => e.PosTipProductId).HasColumnName("pos_tip_product_id");
                        entity.Property(e => e.PredictiveLeadScoringFieldsStr).HasColumnName("predictive_lead_scoring_fields_str");
                        entity.Property(e => e.PredictiveLeadScoringStartDateStr).HasColumnName("predictive_lead_scoring_start_date_str");
                        entity.Property(e => e.ProductVolumeVolumeInCubicFeet).HasColumnName("product_volume_volume_in_cubic_feet");
                        entity.Property(e => e.ProductWeightInLbs).HasColumnName("product_weight_in_lbs");
                        entity.Property(e => e.ProfilingEnabledUntil)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("profiling_enabled_until");
                        entity.Property(e => e.RecaptchaMinScore).HasColumnName("recaptcha_min_score");
                        entity.Property(e => e.RecaptchaPrivateKey).HasColumnName("recaptcha_private_key");
                        entity.Property(e => e.RecaptchaPublicKey).HasColumnName("recaptcha_public_key");
                        entity.Property(e => e.ReminderAllow).HasColumnName("reminder_allow");
                        entity.Property(e => e.ReminderUserAllow).HasColumnName("reminder_user_allow");
                        entity.Property(e => e.RestrictTemplateRendering).HasColumnName("restrict_template_rendering");
                        entity.Property(e => e.ServerUriGoogle).HasColumnName("server_uri_google");
                        entity.Property(e => e.SfuServerKey).HasColumnName("sfu_server_key");
                        entity.Property(e => e.SfuServerUrl).HasColumnName("sfu_server_url");
                        entity.Property(e => e.ShowBlacklistButtons).HasColumnName("show_blacklist_buttons");
                        entity.Property(e => e.ShowEffect).HasColumnName("show_effect");
                        entity.Property(e => e.ShowSaleReceipts).HasColumnName("show_sale_receipts");
                        entity.Property(e => e.TenorApiKey).HasColumnName("tenor_api_key");
                        entity.Property(e => e.TurnstileSecretKey).HasColumnName("turnstile_secret_key");
                        entity.Property(e => e.TurnstileSiteKey).HasColumnName("turnstile_site_key");
                        entity.Property(e => e.TwilioAccountSid).HasColumnName("twilio_account_sid");
                        entity.Property(e => e.TwilioAccountToken).HasColumnName("twilio_account_token");
                        entity.Property(e => e.UnsplashAccessKey).HasColumnName("unsplash_access_key");
                        entity.Property(e => e.UnsplashAppId).HasColumnName("unsplash_app_id");
                        entity.Property(e => e.UseEventBarcode).HasColumnName("use_event_barcode");
                        entity.Property(e => e.UseGoogleMapsStaticApi).HasColumnName("use_google_maps_static_api");
                        entity.Property(e => e.UseInvoiceTerms).HasColumnName("use_invoice_terms");
                        entity.Property(e => e.UseSecurityLead).HasColumnName("use_security_lead");
                        entity.Property(e => e.UseSfuServer).HasColumnName("use_sfu_server");
                        entity.Property(e => e.UseTwilioRtcServers).HasColumnName("use_twilio_rtc_servers");
                        entity.Property(e => e.WebAppName).HasColumnName("web_app_name");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.AuthSignupTemplateUser).WithMany(p => p.ResConfigSettingsAuthSignupTemplateUser) .HasForeignKey(d => d.AuthSignupTemplateUserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_config_settings_auth_signup_template_user_id_fkey");
                        entity.HasOne(d => d.AuthSignupTemplateUser).WithMany()
                            .HasForeignKey(d => d.AuthSignupTemplateUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_auth_signup_template_user_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ResConfigSettings) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("res_config_settings_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("res_config_settings_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResConfigSettingsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_config_settings_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_create_uid_fkey");

                        entity.HasOne(d => d.Digest).WithMany(p => p.ResConfigSettings)
                            .HasForeignKey(d => d.DigestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_digest_id_fkey");

                        entity.HasOne(d => d.GeolocProvider).WithMany(p => p.ResConfigSettings)
                            .HasForeignKey(d => d.GeolocProviderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_geoloc_provider_id_fkey");

                        entity.HasOne(d => d.InvoiceMailTemplate).WithMany(p => p.ResConfigSettings)
                            .HasForeignKey(d => d.InvoiceMailTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_invoice_mail_template_id_fkey");

                        entity.HasOne(d => d.MassMailingMailServer).WithMany(p => p.ResConfigSettings)
                            .HasForeignKey(d => d.MassMailingMailServerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_mass_mailing_mail_server_id_fkey");

                        entity.HasOne(d => d.PosConfig).WithMany(p => p.ResConfigSettings)
                            .HasForeignKey(d => d.PosConfigId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_pos_config_id_fkey");

                        entity.HasOne(d => d.PosDefaultFiscalPosition).WithMany(p => p.ResConfigSettingsNavigation)
                            .HasForeignKey(d => d.PosDefaultFiscalPositionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_pos_default_fiscal_position_id_fkey");

                        // entity.HasOne(d => d.PosDiscountProduct).WithMany(p => p.ResConfigSettingsPosDiscountProduct) .HasForeignKey(d => d.PosDiscountProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_config_settings_pos_discount_product_id_fkey");
                        entity.HasOne(d => d.PosDiscountProduct).WithMany()
                            .HasForeignKey(d => d.PosDiscountProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_pos_discount_product_id_fkey");

                        entity.HasOne(d => d.PosPricelist).WithMany(p => p.ResConfigSettingsNavigation)
                            .HasForeignKey(d => d.PosPricelistId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_pos_pricelist_id_fkey");

                        // entity.HasOne(d => d.PosTipProduct).WithMany(p => p.ResConfigSettingsPosTipProduct) .HasForeignKey(d => d.PosTipProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_config_settings_pos_tip_product_id_fkey");
                        entity.HasOne(d => d.PosTipProduct).WithMany()
                            .HasForeignKey(d => d.PosTipProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_pos_tip_product_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.ResConfigSettings) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("res_config_settings_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("res_config_settings_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResConfigSettingsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_config_settings_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_config_settings_write_uid_fkey");

                        // entity.HasMany(d => d.AccountFiscalPosition).WithMany(p => p.ResConfigSettings)
                        entity.HasMany(d => d.AccountFiscalPosition).WithMany(p => p.ResConfigSettings)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountFiscalPositionResConfigSettingsRel",
                                r => r.HasOne<AccountFiscalPosition>().WithMany()
                                    .HasForeignKey("AccountFiscalPositionId")
                                    .HasConstraintName("account_fiscal_position_res_con_account_fiscal_position_id_fkey"),
                                l => l.HasOne<ResConfigSettings>().WithMany()
                                    .HasForeignKey("ResConfigSettingsId")
                                    .HasConstraintName("account_fiscal_position_res_config__res_config_settings_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ResConfigSettingsId", "AccountFiscalPositionId").HasName("account_fiscal_position_res_config_settings_rel_pkey");
                                    j.ToTable("account_fiscal_position_res_config_settings_rel");
                                    j.HasIndex(new[] { "AccountFiscalPositionId", "ResConfigSettingsId" }, "account_fiscal_position_res_c_account_fiscal_position_id_re_idx");
                                    j.IndexerProperty<Guid>("ResConfigSettingsId").HasColumnName("res_config_settings_id");
                                    j.IndexerProperty<Guid>("AccountFiscalPositionId").HasColumnName("account_fiscal_position_id");
                                });

                        // entity.HasMany(d => d.PosCategory).WithMany(p => p.ResConfigSettings)
                        entity.HasMany(d => d.PosCategory).WithMany(p => p.ResConfigSettings)
                            .UsingEntity<Dictionary<string, object>>(
                                "PosCategoryResConfigSettingsRel",
                                r => r.HasOne<PosCategory>().WithMany()
                                    .HasForeignKey("PosCategoryId")
                                    .HasConstraintName("pos_category_res_config_settings_rel_pos_category_id_fkey"),
                                l => l.HasOne<ResConfigSettings>().WithMany()
                                    .HasForeignKey("ResConfigSettingsId")
                                    .HasConstraintName("pos_category_res_config_settings_re_res_config_settings_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ResConfigSettingsId", "PosCategoryId").HasName("pos_category_res_config_settings_rel_pkey");
                                    j.ToTable("pos_category_res_config_settings_rel");
                                    j.HasIndex(new[] { "PosCategoryId", "ResConfigSettingsId" }, "pos_category_res_config_setti_pos_category_id_res_config_se_idx");
                                    j.IndexerProperty<Guid>("ResConfigSettingsId").HasColumnName("res_config_settings_id");
                                    j.IndexerProperty<Guid>("PosCategoryId").HasColumnName("pos_category_id");
                                });

                        // entity.HasMany(d => d.ProductPricelist).WithMany(p => p.ResConfigSettings)
                        entity.HasMany(d => d.ProductPricelist).WithMany(p => p.ResConfigSettings)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductPricelistResConfigSettingsRel",
                                r => r.HasOne<ProductPricelist>().WithMany()
                                    .HasForeignKey("ProductPricelistId")
                                    .HasConstraintName("product_pricelist_res_config_settings_product_pricelist_id_fkey"),
                                l => l.HasOne<ResConfigSettings>().WithMany()
                                    .HasForeignKey("ResConfigSettingsId")
                                    .HasConstraintName("product_pricelist_res_config_settin_res_config_settings_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ResConfigSettingsId", "ProductPricelistId").HasName("product_pricelist_res_config_settings_rel_pkey");
                                    j.ToTable("product_pricelist_res_config_settings_rel");
                                    j.HasIndex(new[] { "ProductPricelistId", "ResConfigSettingsId" }, "product_pricelist_res_config__product_pricelist_id_res_conf_idx");
                                    j.IndexerProperty<Guid>("ResConfigSettingsId").HasColumnName("res_config_settings_id");
                                    j.IndexerProperty<Guid>("ProductPricelistId").HasColumnName("product_pricelist_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}