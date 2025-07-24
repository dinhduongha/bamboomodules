using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("res_config_settings")]
public partial class ResConfigSetting: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("web_app_name")]
    public string? WebAppName { get; set; }

    [Column("user_default_rights")]
    public bool? UserDefaultRights { get; set; }

    // v16-Compat
    //[Column("external_email_server_default")]
    //public bool? ExternalEmailServerDefault { get; set; }

    [Column("module_base_import")]
    public bool? ModuleBaseImport { get; set; }

    [Column("module_google_calendar")]
    public bool? ModuleGoogleCalendar { get; set; }

    [Column("module_microsoft_calendar")]
    public bool? ModuleMicrosoftCalendar { get; set; }

    [Column("module_mail_plugin")]
    public bool? ModuleMailPlugin { get; set; }

    [Column("module_auth_oauth")]
    public bool? ModuleAuthOauth { get; set; }

    [Column("module_auth_ldap")]
    public bool? ModuleAuthLdap { get; set; }

    // v16-Compat
    [Column("module_base_gengo")]
    public bool? ModuleBaseGengo { get; set; }

    [Column("module_account_inter_company_rules")]
    public bool? ModuleAccountInterCompanyRules { get; set; }

    [Column("module_voip")]
    public bool? ModuleVoip { get; set; }

    [Column("module_web_unsplash")]
    public bool? ModuleWebUnsplash { get; set; }

    [Column("module_sms")]
    public bool? ModuleSms { get; set; }

    [Column("module_partner_autocomplete")]
    public bool? ModulePartnerAutocomplete { get; set; }

    [Column("module_base_geolocalize")]
    public bool? ModuleBaseGeolocalize { get; set; }

    [Column("module_google_recaptcha")]
    public bool? ModuleGoogleRecaptcha { get; set; }

    [Column("module_website_cf_turnstile")]
    public bool? ModuleWebsiteCfTurnstile { get; set; }

    [Column("group_multi_currency")]
    public bool? GroupMultiCurrency { get; set; }

    [Column("show_effect")]
    public bool? ShowEffect { get; set; }

    [Column("module_product_images")]
    public bool? ModuleProductImages { get; set; }

    [Column("profiling_enabled_until", TypeName = "timestamp without time zone")]
    public DateTime? ProfilingEnabledUntil { get; set; }

    [Column("unsplash_access_key")]
    public string? UnsplashAccessKey { get; set; }

    [Column("unsplash_app_id")]
    public string? UnsplashAppId { get; set; }

    [Column("tenor_gif_limit")]
    public long? TenorGifLimit { get; set; }

    // v16-Compat
    [Column("alias_domain")]
    public string? AliasDomain { get; set; }

    [Column("twilio_account_sid")]
    public string? TwilioAccountSid { get; set; }

    [Column("twilio_account_token")]
    public string? TwilioAccountToken { get; set; }

    [Column("sfu_server_url")]
    public string? SfuServerUrl { get; set; }

    [Column("sfu_server_key")]
    public string? SfuServerKey { get; set; }

    [Column("tenor_api_key")]
    public string? TenorApiKey { get; set; }

    [Column("tenor_content_filter")]
    public string? TenorContentFilter { get; set; }

    [Column("google_translate_api_key")]
    public string? GoogleTranslateApiKey { get; set; }

    [Column("external_email_server_default")]
    public bool? ExternalEmailServerDefault { get; set; }

    [Column("module_google_gmail")]
    public bool? ModuleGoogleGmail { get; set; }

    [Column("module_microsoft_outlook")]
    public bool? ModuleMicrosoftOutlook { get; set; }

    [Column("restrict_template_rendering")]
    public bool? RestrictTemplateRendering { get; set; }

    [Column("use_twilio_rtc_servers")]
    public bool? UseTwilioRtcServers { get; set; }

    [Column("group_analytic_accounting")]
    public bool? GroupAnalyticAccounting { get; set; }

    [Column("auth_signup_template_user_id")]
    public Guid? AuthSignupTemplateUserId { get; set; }

    [Column("auth_signup_uninvited")]
    public string? AuthSignupUninvited { get; set; }

    [Column("auth_signup_reset_password")]
    public bool? AuthSignupResetPassword { get; set; }

    [Column("google_gmail_client_identifier")]
    public string? GoogleGmailClientIdentifier { get; set; }

    [Column("google_gmail_client_secret")]
    public string? GoogleGmailClientSecret { get; set; }

    // v16-Compat
    [Column("product_pricelist_setting")]
    public string? ProductPricelistSetting { get; set; }

    [Column("product_weight_in_lbs")]
    public string? ProductWeightInLbs { get; set; }

    [Column("product_volume_volume_in_cubic_feet")]
    public string? ProductVolumeVolumeInCubicFeet { get; set; }

    // v16-Compat
    //[Column("group_discount_per_so_line")]
    //public bool? GroupDiscountPerSoLine { get; set; }

    [Column("group_uom")]
    public bool? GroupUom { get; set; }

    [Column("group_product_variant")]
    public bool? GroupProductVariant { get; set; }

    // v16-Compat
    //[Column("module_sale_product_matrix")]
    //public bool? ModuleSaleProductMatrix { get; set; }

    [Column("module_loyalty")]
    public bool? ModuleLoyalty { get; set; }

    [Column("group_stock_packaging")]
    public bool? GroupStockPackaging { get; set; }

    [Column("group_product_pricelist")]
    public bool? GroupProductPricelist { get; set; }

    // v16-Compat
    [Column("group_sale_pricelist")]
    public bool? GroupSalePricelist { get; set; }

    // v16-Compat
    //[Column("unsplash_access_key")]
    //public string? UnsplashAccessKey { get; set; }

    // v16-Compat
    //[Column("unsplash_app_id")]
    //public string? UnsplashAppId { get; set; }

    [Column("digest_id")]
    public Guid? DigestId { get; set; }

    [Column("digest_emails")]
    public bool? DigestEmails { get; set; }

    [Column("chart_template")]
    public string? ChartTemplate { get; set; }

    // v16-Compat
    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    // v16-Compat
    [Column("show_line_subtotals_tax_selection")]
    public string? ShowLineSubtotalsTaxSelection { get; set; }

    [Column("module_account_accountant")]
    public bool? ModuleAccountAccountant { get; set; }

    [Column("group_warning_account")]
    public bool? GroupWarningAccount { get; set; }

    [Column("group_cash_rounding")]
    public bool? GroupCashRounding { get; set; }

    // v16-Compat
    [Column("group_show_line_subtotals_tax_excluded")]
    public bool? GroupShowLineSubtotalsTaxExcluded { get; set; }

    // v16-Compat
    [Column("group_show_line_subtotals_tax_included")]
    public bool? GroupShowLineSubtotalsTaxIncluded { get; set; }

    [Column("group_show_sale_receipts")]
    public bool? GroupShowSaleReceipts { get; set; }

    [Column("group_show_purchase_receipts")]
    public bool? GroupShowPurchaseReceipts { get; set; }

    [Column("module_account_budget")]
    public bool? ModuleAccountBudget { get; set; }

    [Column("module_account_payment")]
    public bool? ModuleAccountPayment { get; set; }

    [Column("module_account_reports")]
    public bool? ModuleAccountReports { get; set; }

    [Column("module_account_check_printing")]
    public bool? ModuleAccountCheckPrinting { get; set; }

    [Column("module_account_batch_payment")]
    public bool? ModuleAccountBatchPayment { get; set; }

    [Column("module_account_iso20022")]
    public bool? ModuleAccountIso20022 { get; set; }

    // v16-Compat
    [Column("module_account_sepa")]
    public bool? ModuleAccountSepa { get; set; }

    [Column("module_account_sepa_direct_debit")]
    public bool? ModuleAccountSepaDirectDebit { get; set; }

    [Column("module_account_bank_statement_import_qif")]
    public bool? ModuleAccountBankStatementImportQif { get; set; }

    [Column("module_account_bank_statement_import_ofx")]
    public bool? ModuleAccountBankStatementImportOfx { get; set; }

    [Column("module_account_bank_statement_import_csv")]
    public bool? ModuleAccountBankStatementImportCsv { get; set; }

    [Column("module_account_bank_statement_import_camt")]
    public bool? ModuleAccountBankStatementImportCamt { get; set; }

    [Column("module_currency_rate_live")]
    public bool? ModuleCurrencyRateLive { get; set; }

    [Column("module_account_intrastat")]
    public bool? ModuleAccountIntrastat { get; set; }

    [Column("module_product_margin")]
    public bool? ModuleProductMargin { get; set; }

    [Column("module_l10n_eu_oss")]
    public bool? ModuleL10nEuOss { get; set; }

    [Column("module_account_extract")]
    public bool? ModuleAccountExtract { get; set; }

    // v16-Compat
    [Column("module_account_taxcloud")]
    public bool? ModuleAccountTaxcloud { get; set; }

    [Column("module_account_invoice_extract")]
    public bool? ModuleAccountInvoiceExtract { get; set; }

    [Column("module_account_bank_statement_extract")]
    public bool? ModuleAccountBankStatementExtract { get; set; }

    [Column("module_snailmail_account")]
    public bool? ModuleSnailmailAccount { get; set; }

    [Column("module_account_peppol")]
    public bool? ModuleAccountPeppol { get; set; }

    [Column("use_invoice_terms")]
    public bool? UseInvoiceTerms { get; set; }

    [Column("group_sale_delivery_address")]
    public bool? GroupSaleDeliveryAddress { get; set; }

    // v16-Compat
    [Column("deposit_default_product_id")]
    public Guid? DepositDefaultProductId { get; set; }

    [Column("pay_invoices_online")]
    public bool? PayInvoicesOnline { get; set; }

    [Column("group_fiscal_year")]
    public bool? GroupFiscalYear { get; set; }

    [Column("crm_auto_assignment_interval_number")]
    public long? CrmAutoAssignmentIntervalNumber { get; set; }

    [Column("crm_auto_assignment_action")]
    public string? CrmAutoAssignmentAction { get; set; }

    [Column("crm_auto_assignment_interval_type")]
    public string? CrmAutoAssignmentIntervalType { get; set; }

    [Column("lead_enrich_auto")]
    public string? LeadEnrichAuto { get; set; }

    [Column("predictive_lead_scoring_start_date_str")]
    public string? PredictiveLeadScoringStartDateStr { get; set; }

    [Column("predictive_lead_scoring_fields_str")]
    public string? PredictiveLeadScoringFieldsStr { get; set; }

    [Column("group_use_lead")]
    public bool? GroupUseLead { get; set; }

    [Column("group_use_recurring_revenues")]
    public bool? GroupUseRecurringRevenues { get; set; }

    [Column("is_membership_multi")]
    public bool? IsMembershipMulti { get; set; }

    [Column("crm_use_auto_assignment")]
    public bool? CrmUseAutoAssignment { get; set; }

    [Column("module_crm_iap_mine")]
    public bool? ModuleCrmIapMine { get; set; }

    [Column("module_crm_iap_enrich")]
    public bool? ModuleCrmIapEnrich { get; set; }

    [Column("module_website_crm_iap_reveal")]
    public bool? ModuleWebsiteCrmIapReveal { get; set; }

    [Column("lead_mining_in_pipeline")]
    public bool? LeadMiningInPipeline { get; set; }

    [Column("crm_auto_assignment_run_datetime", TypeName = "timestamp without time zone")]
    public DateTime? CrmAutoAssignmentRunDatetime { get; set; }

    [Column("invoice_mail_template_id")]
    public Guid? InvoiceMailTemplateId { get; set; }

    [Column("default_invoice_policy")]
    public string? DefaultInvoicePolicy { get; set; }

    [Column("group_auto_done_setting")]
    public bool? GroupAutoDoneSetting { get; set; }

    [Column("group_discount_per_so_line")]
    public bool? GroupDiscountPerSoLine { get; set; }

    [Column("group_proforma_sales")]
    public bool? GroupProformaSales { get; set; }

    [Column("group_warning_sale")]
    public bool? GroupWarningSale { get; set; }

    [Column("automatic_invoice")]
    public bool? AutomaticInvoice { get; set; }

    // v16-Compat
    [Column("use_quotation_validity_days")]
    public bool? UseQuotationValidityDays { get; set; }

    [Column("module_delivery")]
    public bool? ModuleDelivery { get; set; }

    [Column("module_delivery_bpost")]
    public bool? ModuleDeliveryBpost { get; set; }

    [Column("module_delivery_dhl")]
    public bool? ModuleDeliveryDhl { get; set; }

    [Column("module_delivery_easypost")]
    public bool? ModuleDeliveryEasypost { get; set; }

    [Column("module_delivery_fedex")]
    public bool? ModuleDeliveryFedex { get; set; }

    [Column("module_delivery_sendcloud")]
    public bool? ModuleDeliverySendcloud { get; set; }

    [Column("module_delivery_shiprocket")]
    public bool? ModuleDeliveryShiprocket { get; set; }

    // v16-Compat
    //[Column("module_delivery_fedex")]
    //public bool? ModuleDeliveryFedex { get; set; }

    [Column("module_delivery_ups")]
    public bool? ModuleDeliveryUps { get; set; }

    [Column("module_delivery_usps")]
    public bool? ModuleDeliveryUsps { get; set; }

    [Column("module_delivery_starshipit")]
    public bool? ModuleDeliveryStarshipit { get; set; }

    [Column("module_product_email_template")]
    public bool? ModuleProductEmailTemplate { get; set; }

    [Column("module_sale_amazon")]
    public bool? ModuleSaleAmazon { get; set; }

    [Column("module_sale_loyalty")]
    public bool? ModuleSaleLoyalty { get; set; }

    [Column("module_sale_margin")]
    public bool? ModuleSaleMargin { get; set; }

    [Column("module_sale_product_matrix")]
    public bool? ModuleSaleProductMatrix { get; set; }

    [Column("module_sale_pdf_quote_builder")]
    public bool? ModuleSalePdfQuoteBuilder { get; set; }

    [Column("module_sale_commission")]
    public bool? ModuleSaleCommission { get; set; }

    [Column("group_sale_order_template")]
    public bool? GroupSaleOrderTemplate { get; set; }

    [Column("barcode_separator")]
    public string? BarcodeSeparator { get; set; }

    // v16-Compat
    [Column("module_sale_quotation_builder")]
    public bool? ModuleSaleQuotationBuilder { get; set; }

    [Column("module_product_expiry")]
    public bool? ModuleProductExpiry { get; set; }

    [Column("group_stock_production_lot")]
    public bool? GroupStockProductionLot { get; set; }

    [Column("group_stock_lot_print_gs1")]
    public bool? GroupStockLotPrintGs1 { get; set; }

    [Column("group_lot_on_delivery_slip")]
    public bool? GroupLotOnDeliverySlip { get; set; }

    [Column("group_stock_tracking_lot")]
    public bool? GroupStockTrackingLot { get; set; }

    [Column("group_stock_tracking_owner")]
    public bool? GroupStockTrackingOwner { get; set; }

    [Column("group_stock_adv_location")]
    public bool? GroupStockAdvLocation { get; set; }

    [Column("group_warning_stock")]
    public bool? GroupWarningStock { get; set; }

    [Column("group_stock_sign_delivery")]
    public bool? GroupStockSignDelivery { get; set; }

    [Column("module_stock_picking_batch")]
    public bool? ModuleStockPickingBatch { get; set; }

    // v16-Compat
    [Column("group_stock_picking_wave")]
    public bool? GroupStockPickingWave { get; set; }

    [Column("module_stock_barcode")]
    public bool? ModuleStockBarcode { get; set; }

    [Column("module_stock_barcode_barcodelookup")]
    public bool? ModuleStockBarcodeBarcodelookup { get; set; }

    [Column("module_stock_sms")]
    public bool? ModuleStockSms { get; set; }

    [Column("module_quality_control")]
    public bool? ModuleQualityControl { get; set; }

    [Column("module_quality_control_worksheet")]
    public bool? ModuleQualityControlWorksheet { get; set; }

    [Column("group_stock_multi_locations")]
    public bool? GroupStockMultiLocations { get; set; }

    // v16-Compat
    [Column("group_stock_storage_categories")]
    public bool? GroupStockStorageCategories { get; set; }

    [Column("group_stock_reception_report")]
    public bool? GroupStockReceptionReport { get; set; }

    [Column("module_stock_dropshipping")]
    public bool? ModuleStockDropshipping { get; set; }

    [Column("module_stock_fleet")]
    public bool? ModuleStockFleet { get; set; }

    [Column("module_stock_landed_costs")]
    public bool? ModuleStockLandedCosts { get; set; }

    [Column("group_lot_on_invoice")]
    public bool? GroupLotOnInvoice { get; set; }

    [Column("group_stock_accounting_automatic")]
    public bool? GroupStockAccountingAutomatic { get; set; }

    [Column("pos_config_id")]
    public Guid? PosConfigId { get; set; }

    [Column("pos_default_fiscal_position_id")]
    public Guid? PosDefaultFiscalPositionId { get; set; }

    // v16-Compat
    [Column("pos_iface_start_categ_id")]
    public Guid? PosIfaceStartCategId { get; set; }

    [Column("pos_pricelist_id")]
    public Guid? PosPricelistId { get; set; }

    [Column("pos_tip_product_id")]
    public Guid? PosTipProductId { get; set; }

    // v16-Compat
    [Column("pos_proxy_ip")]
    public string? PosProxyIp { get; set; }

    [Column("pos_receipt_footer")]
    public string? PosReceiptFooter { get; set; }

    [Column("pos_receipt_header")]
    public string? PosReceiptHeader { get; set; }

    // v16-Compat
    [Column("module_pos_mercury")]
    public bool? ModulePosMercury { get; set; }

    [Column("module_pos_adyen")]
    public bool? ModulePosAdyen { get; set; }

    [Column("module_pos_stripe")]
    public bool? ModulePosStripe { get; set; }

    [Column("module_pos_six")]
    public bool? ModulePosSix { get; set; }

    [Column("module_pos_viva_wallet")]
    public bool? ModulePosVivaWallet { get; set; }

    [Column("module_pos_paytm")]
    public bool? ModulePosPaytm { get; set; }

    [Column("module_pos_razorpay")]
    public bool? ModulePosRazorpay { get; set; }

    [Column("module_pos_mercado_pago")]
    public bool? ModulePosMercadoPago { get; set; }

    [Column("module_pos_preparation_display")]
    public bool? ModulePosPreparationDisplay { get; set; }

    [Column("module_pos_pricer")]
    public bool? ModulePosPricer { get; set; }

    [Column("is_kiosk_mode")]
    public bool? IsKioskMode { get; set; }

    [Column("pos_is_order_printer")]
    public bool? PosIsOrderPrinter { get; set; }

    [Column("pos_iface_cashdrawer")]
    public bool? PosIfaceCashdrawer { get; set; }

    // v16-Compat
    [Column("pos_iface_customer_facing_display_via_proxy")]
    public bool? PosIfaceCustomerFacingDisplayViaProxy { get; set; }

    [Column("pos_iface_electronic_scale")]
    public bool? PosIfaceElectronicScale { get; set; }

    [Column("pos_iface_print_via_proxy")]
    public bool? PosIfacePrintViaProxy { get; set; }

    [Column("pos_iface_scan_via_proxy")]
    public bool? PosIfaceScanViaProxy { get; set; }

    [Column("pos_epson_printer_ip")]
    public string? PosEpsonPrinterIp { get; set; }

    [Column("default_picking_policy")]
    public string? DefaultPickingPolicy { get; set; }

    // v16-Compat
    [Column("group_display_incoterm")]
    public bool? GroupDisplayIncoterm { get; set; }

    [Column("use_security_lead")]
    public bool? UseSecurityLead { get; set; }

    [Column("pos_iface_printbill")]
    public bool? PosIfacePrintbill { get; set; }

    [Column("pos_iface_splitbill")]
    public bool? PosIfaceSplitbill { get; set; }

    [Column("pos_set_tip_after_payment")]
    public bool? PosSetTipAfterPayment { get; set; }

    [Column("module_hr_timesheet")]
    public bool? ModuleHrTimesheet { get; set; }

    [Column("group_project_rating")]
    public bool? GroupProjectRating { get; set; }

    [Column("group_project_stages")]
    public bool? GroupProjectStages { get; set; }

    [Column("group_project_recurring_tasks")]
    public bool? GroupProjectRecurringTasks { get; set; }

    [Column("group_project_task_dependencies")]
    public bool? GroupProjectTaskDependencies { get; set; }

    [Column("group_project_milestone")]
    public bool? GroupProjectMilestone { get; set; }

    [Column("default_purchase_method")]
    public string? DefaultPurchaseMethod { get; set; }

    [Column("lock_confirmed_po")]
    public bool? LockConfirmedPo { get; set; }

    [Column("po_order_approval")]
    public bool? PoOrderApproval { get; set; }

    [Column("group_warning_purchase")]
    public bool? GroupWarningPurchase { get; set; }

    [Column("module_account_3way_match")]
    public bool? ModuleAccount3wayMatch { get; set; }

    [Column("module_purchase_requisition")]
    public bool? ModulePurchaseRequisition { get; set; }

    [Column("module_purchase_product_matrix")]
    public bool? ModulePurchaseProductMatrix { get; set; }

    [Column("use_po_lead")]
    public bool? UsePoLead { get; set; }

    [Column("group_send_reminder")]
    public bool? GroupSendReminder { get; set; }

    // v16-Compat
    //[Column("module_stock_dropshipping")]
    //public bool? ModuleStockDropshipping { get; set; }

    [Column("is_installed_sale")]
    public bool? IsInstalledSale { get; set; }

    // v16-Compat
    //[Column("group_fiscal_year")]
    //public bool? GroupFiscalYear { get; set; }

    [Column("use_manufacturing_lead")]
    public bool? UseManufacturingLead { get; set; }

    [Column("group_mrp_byproducts")]
    public bool? GroupMrpByproducts { get; set; }

    [Column("module_mrp_mps")]
    public bool? ModuleMrpMps { get; set; }

    [Column("module_mrp_plm")]
    public bool? ModuleMrpPlm { get; set; }

    // v16-Compat
    [Column("module_mrp_workorder")]
    public bool? ModuleMrpWorkorder { get; set; }

    [Column("module_mrp_subcontracting")]
    public bool? ModuleMrpSubcontracting { get; set; }

    [Column("group_mrp_routings")]
    public bool? GroupMrpRoutings { get; set; }

    [Column("group_unlocked_by_default")]
    public bool? GroupUnlockedByDefault { get; set; }

    [Column("group_mrp_reception_report")]
    public bool? GroupMrpReceptionReport { get; set; }

    [Column("group_mrp_workorder_dependencies")]
    public bool? GroupMrpWorkorderDependencies { get; set; }

    [Column("module_maintenance_worksheet")]
    public bool? ModuleMaintenanceWorksheet { get; set; }

    // v16-Compat
    //[Column("crm_auto_assignment_interval_number")]
    //public long? CrmAutoAssignmentIntervalNumber { get; set; }

    // v16-Compat
    //[Column("crm_auto_assignment_action")]
    //public string? CrmAutoAssignmentAction { get; set; }

    // v16-Compat
    //[Column("crm_auto_assignment_interval_type")]
    //public string? CrmAutoAssignmentIntervalType { get; set; }

    // v16-Compat
    //[Column("lead_enrich_auto")]
    //public string? LeadEnrichAuto { get; set; }

    // v16-Compat
    //[Column("predictive_lead_scoring_start_date_str")]
    //public string? PredictiveLeadScoringStartDateStr { get; set; }

    // v16-Compat
    //[Column("predictive_lead_scoring_fields_str")]
    //public string? PredictiveLeadScoringFieldsStr { get; set; }

    // v16-Compat
    //[Column("group_use_lead")]
    //public bool? GroupUseLead { get; set; }

    // v16-Compat
    //[Column("group_use_recurring_revenues")]
    //public bool? GroupUseRecurringRevenues { get; set; }

    // v16-Compat
    //[Column("is_membership_multi")]
    //public bool? IsMembershipMulti { get; set; }

    // v16-Compat
    //[Column("crm_use_auto_assignment")]
    //public bool? CrmUseAutoAssignment { get; set; }

    // v16-Compat
    //[Column("module_crm_iap_mine")]
    //public bool? ModuleCrmIapMine { get; set; }

    // v16-Compat
    //[Column("module_crm_iap_enrich")]
    //public bool? ModuleCrmIapEnrich { get; set; }

    // v16-Compat
    //[Column("module_website_crm_iap_reveal")]
    //public bool? ModuleWebsiteCrmIapReveal { get; set; }

    // v16-Compat
    //[Column("lead_mining_in_pipeline")]
    //public bool? LeadMiningInPipeline { get; set; }

    // v16-Compat
    //[Column("crm_auto_assignment_run_datetime", TypeName = "timestamp without time zone")]
    //public DateTime? CrmAutoAssignmentRunDatetime { get; set; }

    // v16-Compat
    [Column("module_project_forecast")]
    public bool? ModuleProjectForecast { get; set; }

    // v16-Compat
    //[Column("module_hr_timesheet")]
    //public bool? ModuleHrTimesheet { get; set; }

    // v16-Compat
    [Column("group_subtask_project")]
    public bool? GroupSubtaskProject { get; set; }

    // v16-Compat
    //[Column("group_project_rating")]
    //public bool? GroupProjectRating { get; set; }

    // v16-Compat
    //[Column("group_project_stages")]
    //public bool? GroupProjectStages { get; set; }

    // v16-Compat
    //[Column("group_project_recurring_tasks")]
    //public bool? GroupProjectRecurringTasks { get; set; }

    // v16-Compat
    //[Column("group_project_task_dependencies")]
    //public bool? GroupProjectTaskDependencies { get; set; }

    // v16-Compat
    //[Column("group_project_milestone")]
    //public bool? GroupProjectMilestone { get; set; }

    [Column("module_hr_presence")]
    public bool? ModuleHrPresence { get; set; }

    [Column("module_hr_skills")]
    public bool? ModuleHrSkills { get; set; }

    [Column("module_hr_homeworking")]
    public bool? ModuleHrHomeworking { get; set; }

    // v16-Compat
    [Column("hr_presence_control_login")]
    public bool? HrPresenceControlLogin { get; set; }

    // v16-Compat
    [Column("hr_presence_control_email")]
    public bool? HrPresenceControlEmail { get; set; }

    // v16-Compat
    [Column("hr_presence_control_ip")]
    public bool? HrPresenceControlIp { get; set; }

    // v16-Compat
    [Column("module_hr_attendance")]
    public bool? ModuleHrAttendance { get; set; }

    [Column("hr_employee_self_edit")]
    public bool? HrEmployeeSelfEdit { get; set; }

    // v16-Compat
    [Column("expense_alias_prefix")]
    public string? ExpenseAliasPrefix { get; set; }

    // v16-Compat
    [Column("use_mailgateway")]
    public bool? UseMailgateway { get; set; }

    // v16-Compat
    //[Column("module_hr_payroll_expense")]
    //public bool? ModuleHrPayrollExpense { get; set; }

    // v16-Compat
    //[Column("module_hr_expense_extract")]
    //public bool? ModuleHrExpenseExtract { get; set; }

    [Column("module_website_hr_recruitment")]
    public bool? ModuleWebsiteHrRecruitment { get; set; }

    [Column("module_hr_recruitment_survey")]
    public bool? ModuleHrRecruitmentSurvey { get; set; }

    [Column("group_applicant_cv_display")]
    public bool? GroupApplicantCvDisplay { get; set; }

    [Column("module_hr_recruitment_extract")]
    public bool? ModuleHrRecruitmentExtract { get; set; }

    [Column("overtime_company_threshold")]
    public long? OvertimeCompanyThreshold { get; set; }

    [Column("overtime_employee_threshold")]
    public long? OvertimeEmployeeThreshold { get; set; }

    // v16-Compat
    [Column("overtime_start_date")]
    public DateTime? OvertimeStartDate { get; set; }

    // v16-Compat
    [Column("group_attendance_use_pin")]
    public bool? GroupAttendanceUsePin { get; set; }

    // v16-Compat
    [Column("hr_attendance_overtime")]
    public bool? HrAttendanceOvertime { get; set; }

    // v16-Compat
    //[Column("module_website_hr_recruitment")]
    //public bool? ModuleWebsiteHrRecruitment { get; set; }

    // v16-Compat
    //[Column("module_hr_recruitment_survey")]
    //public bool? ModuleHrRecruitmentSurvey { get; set; }

    // v16-Compat
    //[Column("group_applicant_cv_display")]
    //public bool? GroupApplicantCvDisplay { get; set; }

    // v16-Compat
    //[Column("module_hr_recruitment_extract")]
    //public bool? ModuleHrRecruitmentExtract { get; set; }

    [Column("hr_expense_alias_prefix")]
    public string? HrExpenseAliasPrefix { get; set; }

    [Column("hr_expense_use_mailgateway")]
    public bool? HrExpenseUseMailgateway { get; set; }

    [Column("module_hr_payroll_expense")]
    public bool? ModuleHrPayrollExpense { get; set; }

    [Column("module_hr_expense_extract")]
    public bool? ModuleHrExpenseExtract { get; set; }

    [Column("delay_alert_contract")]
    public long? DelayAlertContract { get; set; }

    [Column("recaptcha_public_key")]
    public string? RecaptchaPublicKey { get; set; }

    [Column("recaptcha_private_key")]
    public string? RecaptchaPrivateKey { get; set; }

    [Column("recaptcha_min_score")]
    public double? RecaptchaMinScore { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("group_multi_website")]
    public bool? GroupMultiWebsite { get; set; }

    [Column("module_website_livechat")]
    public bool? ModuleWebsiteLivechat { get; set; }

    [Column("module_marketing_automation")]
    public bool? ModuleMarketingAutomation { get; set; }

    // v16-Compat
    [Column("module_payment_paypal")]
    public bool? ModulePaymentPaypal { get; set; }

    // v16-Compat
    [Column("sale_delivery_settings")]
    public string? SaleDeliverySettings { get; set; }

    // v16-Compat
    [Column("module_website_sale_delivery")]
    public bool? ModuleWebsiteSaleDelivery { get; set; }

    [Column("group_delivery_invoice_address")]
    public bool? GroupDeliveryInvoiceAddress { get; set; }

    [Column("group_show_uom_price")]
    public bool? GroupShowUomPrice { get; set; }

    [Column("group_product_price_comparison")]
    public bool? GroupProductPriceComparison { get; set; }

    [Column("module_account")]
    public bool? ModuleAccount { get; set; }

    [Column("module_delivery_mondialrelay")]
    public bool? ModuleDeliveryMondialrelay { get; set; }

    [Column("module_website_sale_autocomplete")]
    public bool? ModuleWebsiteSaleAutocomplete { get; set; }

    // v16-Compat
    [Column("module_website_sale_digital")]
    public bool? ModuleWebsiteSaleDigital { get; set; }

    // v16-Compat
    //[Column("module_website_sale_wishlist")]
    //public bool? ModuleWebsiteSaleWishlist { get; set; }

    [Column("module_website_sale_comparison")]
    public bool? ModuleWebsiteSaleComparison { get; set; }

    [Column("module_website_sale_collect")]
    public bool? ModuleWebsiteSaleCollect { get; set; }

    [Column("module_website_sale_wishlist")]
    public bool? ModuleWebsiteSaleWishlist { get; set; }

    // v16-Compat
    //[Column("module_website_sale_autocomplete")]
    //public bool? ModuleWebsiteSaleAutocomplete { get; set; }

    // v16-Compat
    //[Column("module_account")]
    //public bool? ModuleAccount { get; set; }

    // v16-Compat
    [Column("module_website_sale_picking")]
    public bool? ModuleWebsiteSalePicking { get; set; }

    // v16-Compat
    //[Column("module_delivery_mondialrelay")]
    //public bool? ModuleDeliveryMondialrelay { get; set; }

    [Column("enabled_extra_checkout_step")]
    public bool? EnabledExtraCheckoutStep { get; set; }

    [Column("enabled_buy_now_button")]
    public bool? EnabledBuyNowButton { get; set; }

    [Column("allow_out_of_stock_order")]
    public bool? AllowOutOfStockOrder { get; set; }

    [Column("show_availability")]
    public bool? ShowAvailability { get; set; }

    [Column("available_threshold")]
    public double? AvailableThreshold { get; set; }

    [Column("module_website_sale_slides")]
    public bool? ModuleWebsiteSaleSlides { get; set; }

    [Column("module_website_slides_forum")]
    public bool? ModuleWebsiteSlidesForum { get; set; }

    [Column("module_website_slides_survey")]
    public bool? ModuleWebsiteSlidesSurvey { get; set; }

    [Column("module_mass_mailing_slides")]
    public bool? ModuleMassMailingSlides { get; set; }

    [Column("mass_mailing_mail_server_id")]
    public Guid? MassMailingMailServerId { get; set; }

    [Column("group_mass_mailing_campaign")]
    public bool? GroupMassMailingCampaign { get; set; }

    [Column("mass_mailing_outgoing_mail_server")]
    public bool? MassMailingOutgoingMailServer { get; set; }

    [Column("show_blacklist_buttons")]
    public bool? ShowBlacklistButtons { get; set; }

    [Column("mass_mailing_reports")]
    public bool? MassMailingReports { get; set; }

    [Column("mass_mailing_split_contact_name")]
    public bool? MassMailingSplitContactName { get; set; }

    [Column("is_newsletter_enabled")]
    public bool? IsNewsletterEnabled { get; set; }

    [Column("google_maps_static_api_key")]
    public string? GoogleMapsStaticApiKey { get; set; }

    [Column("google_maps_static_api_secret")]
    public string? GoogleMapsStaticApiSecret { get; set; }

    [Column("module_event_sale")]
    public bool? ModuleEventSale { get; set; }

    [Column("module_pos_event")]
    public bool? ModulePosEvent { get; set; }

    [Column("module_website_event_meet")]
    public bool? ModuleWebsiteEventMeet { get; set; }

    [Column("module_website_event_track")]
    public bool? ModuleWebsiteEventTrack { get; set; }

    [Column("module_website_event_track_live")]
    public bool? ModuleWebsiteEventTrackLive { get; set; }

    [Column("module_website_event_track_quiz")]
    public bool? ModuleWebsiteEventTrackQuiz { get; set; }

    [Column("module_website_event_exhibitor")]
    public bool? ModuleWebsiteEventExhibitor { get; set; }

    /// <summary>
    /// Registration Survey
    /// </summary>
    [Column("module_website_event_questions")]
    public bool? ModuleWebsiteEventQuestions { get; set; }
 
    /// <summary>
    /// Barcode
    /// </summary>
    [Column("module_event_barcode")]
    public bool? ModuleEventBarcode { get; set; }

    [Column("use_event_barcode")]
    public bool? UseEventBarcode { get; set; }

    [Column("module_website_event_sale")]
    public bool? ModuleWebsiteEventSale { get; set; }

    [Column("module_event_booth")]
    public bool? ModuleEventBooth { get; set; }

    [Column("use_google_maps_static_api")]
    public bool? UseGoogleMapsStaticApi { get; set; }
    
    // v16-Compat
    //[Column("delay_alert_contract")]
    //public long? DelayAlertContract { get; set; }

    [ForeignKey("AuthSignupTemplateUserId")]
    //[InverseProperty("ResConfigSettingAuthSignupTemplateUsers")]
    [NotMapped]
    public virtual ResUser? AuthSignupTemplateUser { get; set; }

    //[ForeignKey("ChartTemplateId")]
    ////[InverseProperty("ResConfigSettings")]
    //[NotMapped]
    //public virtual AccountChartTemplate? ChartTemplate { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResConfigSettingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepositDefaultProductId")]
    //[InverseProperty("ResConfigSettingDepositDefaultProducts")]
    [NotMapped]
    public virtual ProductProduct? DepositDefaultProduct { get; set; }

    [ForeignKey("DigestId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual DigestDigest? Digest { get; set; }

    [ForeignKey("InvoiceMailTemplateId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual MailTemplate? InvoiceMailTemplate { get; set; }

    [ForeignKey("PosConfigId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual PosConfig? PosConfig { get; set; }

    [ForeignKey("PosDefaultFiscalPositionId")]
    //[InverseProperty("ResConfigSettingsNavigation")]
    [NotMapped]
    public virtual AccountFiscalPosition? PosDefaultFiscalPosition { get; set; }

    [ForeignKey("PosIfaceStartCategId")]
    //[InverseProperty("ResConfigSettingsNavigation")]
    [NotMapped]
    public virtual PosCategory? PosIfaceStartCateg { get; set; }

    [ForeignKey("PosPricelistId")]
    //[InverseProperty("ResConfigSettingsNavigation")]
    [NotMapped]
    public virtual ProductPricelist? PosPricelist { get; set; }

    [ForeignKey("PosTipProductId")]
    //[InverseProperty("ResConfigSettingPosTipProducts")]
    [NotMapped]
    public virtual ProductProduct? PosTipProduct { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResConfigSettingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE COLLECTIONS
    [ForeignKey("ResConfigSettingsId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositions { get; set; } = new List<AccountFiscalPosition>();

    [ForeignKey("ResConfigSettingsId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual ICollection<PosCategory> PosCategories { get; set; } = new List<PosCategory>();

    [ForeignKey("ResConfigSettingsId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; set; } = new List<ProductPricelist>();
    
}
