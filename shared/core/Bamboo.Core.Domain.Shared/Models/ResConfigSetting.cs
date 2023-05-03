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
public partial class ResConfigSetting: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_default_rights")]
    public bool? UserDefaultRights { get; set; }

    [Column("external_email_server_default")]
    public bool? ExternalEmailServerDefault { get; set; }

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

    [Column("module_base_gengo")]
    public bool? ModuleBaseGengo { get; set; }

    [Column("module_account_inter_company_rules")]
    public bool? ModuleAccountInterCompanyRules { get; set; }

    [Column("module_voip")]
    public bool? ModuleVoip { get; set; }

    [Column("module_web_unsplash")]
    public bool? ModuleWebUnsplash { get; set; }

    [Column("module_partner_autocomplete")]
    public bool? ModulePartnerAutocomplete { get; set; }

    [Column("module_base_geolocalize")]
    public bool? ModuleBaseGeolocalize { get; set; }

    [Column("module_google_recaptcha")]
    public bool? ModuleGoogleRecaptcha { get; set; }

    [Column("group_multi_currency")]
    public bool? GroupMultiCurrency { get; set; }

    [Column("show_effect")]
    public bool? ShowEffect { get; set; }

    [Column("module_product_images")]
    public bool? ModuleProductImages { get; set; }

    [Column("profiling_enabled_until", TypeName = "timestamp without time zone")]
    public DateTime? ProfilingEnabledUntil { get; set; }

    [Column("alias_domain")]
    public string? AliasDomain { get; set; }

    [Column("twilio_account_sid")]
    public string? TwilioAccountSid { get; set; }

    [Column("twilio_account_token")]
    public string? TwilioAccountToken { get; set; }

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

    [Column("product_pricelist_setting")]
    public string? ProductPricelistSetting { get; set; }

    [Column("product_weight_in_lbs")]
    public string? ProductWeightInLbs { get; set; }

    [Column("product_volume_volume_in_cubic_feet")]
    public string? ProductVolumeVolumeInCubicFeet { get; set; }

    [Column("group_discount_per_so_line")]
    public bool? GroupDiscountPerSoLine { get; set; }

    [Column("group_uom")]
    public bool? GroupUom { get; set; }

    [Column("group_product_variant")]
    public bool? GroupProductVariant { get; set; }

    [Column("module_sale_product_matrix")]
    public bool? ModuleSaleProductMatrix { get; set; }

    [Column("module_loyalty")]
    public bool? ModuleLoyalty { get; set; }

    [Column("group_stock_packaging")]
    public bool? GroupStockPackaging { get; set; }

    [Column("group_product_pricelist")]
    public bool? GroupProductPricelist { get; set; }

    [Column("group_sale_pricelist")]
    public bool? GroupSalePricelist { get; set; }

    [Column("unsplash_access_key")]
    public string? UnsplashAccessKey { get; set; }

    [Column("unsplash_app_id")]
    public string? UnsplashAppId { get; set; }

    [Column("digest_id")]
    public Guid? DigestId { get; set; }

    [Column("digest_emails")]
    public bool? DigestEmails { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("show_line_subtotals_tax_selection")]
    public string? ShowLineSubtotalsTaxSelection { get; set; }

    [Column("module_account_accountant")]
    public bool? ModuleAccountAccountant { get; set; }

    [Column("group_warning_account")]
    public bool? GroupWarningAccount { get; set; }

    [Column("group_cash_rounding")]
    public bool? GroupCashRounding { get; set; }

    [Column("group_show_line_subtotals_tax_excluded")]
    public bool? GroupShowLineSubtotalsTaxExcluded { get; set; }

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

    [Column("module_account_taxcloud")]
    public bool? ModuleAccountTaxcloud { get; set; }

    [Column("module_account_invoice_extract")]
    public bool? ModuleAccountInvoiceExtract { get; set; }

    [Column("module_snailmail_account")]
    public bool? ModuleSnailmailAccount { get; set; }

    [Column("use_invoice_terms")]
    public bool? UseInvoiceTerms { get; set; }

    [Column("group_sale_delivery_address")]
    public bool? GroupSaleDeliveryAddress { get; set; }

    [Column("deposit_default_product_id")]
    public Guid? DepositDefaultProductId { get; set; }

    [Column("invoice_mail_template_id")]
    public Guid? InvoiceMailTemplateId { get; set; }

    [Column("default_invoice_policy")]
    public string? DefaultInvoicePolicy { get; set; }

    [Column("group_auto_done_setting")]
    public bool? GroupAutoDoneSetting { get; set; }

    [Column("group_proforma_sales")]
    public bool? GroupProformaSales { get; set; }

    [Column("group_warning_sale")]
    public bool? GroupWarningSale { get; set; }

    [Column("automatic_invoice")]
    public bool? AutomaticInvoice { get; set; }

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

    [Column("module_delivery_sendcloud")]
    public bool? ModuleDeliverySendcloud { get; set; }

    [Column("module_delivery_fedex")]
    public bool? ModuleDeliveryFedex { get; set; }

    [Column("module_delivery_ups")]
    public bool? ModuleDeliveryUps { get; set; }

    [Column("module_delivery_usps")]
    public bool? ModuleDeliveryUsps { get; set; }

    [Column("module_product_email_template")]
    public bool? ModuleProductEmailTemplate { get; set; }

    [Column("module_sale_amazon")]
    public bool? ModuleSaleAmazon { get; set; }

    [Column("module_sale_loyalty")]
    public bool? ModuleSaleLoyalty { get; set; }

    [Column("module_sale_margin")]
    public bool? ModuleSaleMargin { get; set; }

    [Column("group_sale_order_template")]
    public bool? GroupSaleOrderTemplate { get; set; }

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

    [Column("group_stock_picking_wave")]
    public bool? GroupStockPickingWave { get; set; }

    [Column("module_stock_barcode")]
    public bool? ModuleStockBarcode { get; set; }

    [Column("module_stock_sms")]
    public bool? ModuleStockSms { get; set; }

    [Column("module_quality_control")]
    public bool? ModuleQualityControl { get; set; }

    [Column("module_quality_control_worksheet")]
    public bool? ModuleQualityControlWorksheet { get; set; }

    [Column("group_stock_multi_locations")]
    public bool? GroupStockMultiLocations { get; set; }

    [Column("group_stock_storage_categories")]
    public bool? GroupStockStorageCategories { get; set; }

    [Column("group_stock_reception_report")]
    public bool? GroupStockReceptionReport { get; set; }

    [Column("module_stock_landed_costs")]
    public bool? ModuleStockLandedCosts { get; set; }

    [Column("group_lot_on_invoice")]
    public bool? GroupLotOnInvoice { get; set; }

    [Column("pos_config_id")]
    public Guid? PosConfigId { get; set; }

    [Column("pos_default_fiscal_position_id")]
    public Guid? PosDefaultFiscalPositionId { get; set; }

    [Column("pos_iface_start_categ_id")]
    public long? PosIfaceStartCategId { get; set; }

    [Column("pos_pricelist_id")]
    public Guid? PosPricelistId { get; set; }

    [Column("pos_tip_product_id")]
    public Guid? PosTipProductId { get; set; }

    [Column("pos_proxy_ip")]
    public string? PosProxyIp { get; set; }

    [Column("pos_receipt_footer")]
    public string? PosReceiptFooter { get; set; }

    [Column("pos_receipt_header")]
    public string? PosReceiptHeader { get; set; }

    [Column("module_pos_mercury")]
    public bool? ModulePosMercury { get; set; }

    [Column("module_pos_adyen")]
    public bool? ModulePosAdyen { get; set; }

    [Column("module_pos_stripe")]
    public bool? ModulePosStripe { get; set; }

    [Column("module_pos_six")]
    public bool? ModulePosSix { get; set; }

    [Column("pos_iface_cashdrawer")]
    public bool? PosIfaceCashdrawer { get; set; }

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

    [Column("group_display_incoterm")]
    public bool? GroupDisplayIncoterm { get; set; }

    [Column("use_security_lead")]
    public bool? UseSecurityLead { get; set; }

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

    [Column("module_stock_dropshipping")]
    public bool? ModuleStockDropshipping { get; set; }

    [Column("is_installed_sale")]
    public bool? IsInstalledSale { get; set; }

    [Column("group_fiscal_year")]
    public bool? GroupFiscalYear { get; set; }

    [Column("use_manufacturing_lead")]
    public bool? UseManufacturingLead { get; set; }

    [Column("group_mrp_byproducts")]
    public bool? GroupMrpByproducts { get; set; }

    [Column("module_mrp_mps")]
    public bool? ModuleMrpMps { get; set; }

    [Column("module_mrp_plm")]
    public bool? ModuleMrpPlm { get; set; }

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

    [Column("module_project_forecast")]
    public bool? ModuleProjectForecast { get; set; }

    [Column("module_hr_timesheet")]
    public bool? ModuleHrTimesheet { get; set; }

    [Column("group_subtask_project")]
    public bool? GroupSubtaskProject { get; set; }

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

    [Column("module_hr_presence")]
    public bool? ModuleHrPresence { get; set; }

    [Column("module_hr_skills")]
    public bool? ModuleHrSkills { get; set; }

    [Column("module_hr_homeworking")]
    public bool? ModuleHrHomeworking { get; set; }

    [Column("hr_presence_control_login")]
    public bool? HrPresenceControlLogin { get; set; }

    [Column("hr_presence_control_email")]
    public bool? HrPresenceControlEmail { get; set; }

    [Column("hr_presence_control_ip")]
    public bool? HrPresenceControlIp { get; set; }

    [Column("module_hr_attendance")]
    public bool? ModuleHrAttendance { get; set; }

    [Column("hr_employee_self_edit")]
    public bool? HrEmployeeSelfEdit { get; set; }

    [Column("expense_alias_prefix")]
    public string? ExpenseAliasPrefix { get; set; }

    [Column("use_mailgateway")]
    public bool? UseMailgateway { get; set; }

    [Column("module_hr_payroll_expense")]
    public bool? ModuleHrPayrollExpense { get; set; }

    [Column("module_hr_expense_extract")]
    public bool? ModuleHrExpenseExtract { get; set; }

    [Column("overtime_company_threshold")]
    public long? OvertimeCompanyThreshold { get; set; }

    [Column("overtime_employee_threshold")]
    public long? OvertimeEmployeeThreshold { get; set; }

    [Column("overtime_start_date")]
    public DateTime? OvertimeStartDate { get; set; }

    [Column("group_attendance_use_pin")]
    public bool? GroupAttendanceUsePin { get; set; }

    [Column("hr_attendance_overtime")]
    public bool? HrAttendanceOvertime { get; set; }

    [Column("module_website_hr_recruitment")]
    public bool? ModuleWebsiteHrRecruitment { get; set; }

    [Column("module_hr_recruitment_survey")]
    public bool? ModuleHrRecruitmentSurvey { get; set; }

    [Column("group_applicant_cv_display")]
    public bool? GroupApplicantCvDisplay { get; set; }

    [Column("module_hr_recruitment_extract")]
    public bool? ModuleHrRecruitmentExtract { get; set; }

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

    [Column("module_payment_paypal")]
    public bool? ModulePaymentPaypal { get; set; }

    [Column("sale_delivery_settings")]
    public string? SaleDeliverySettings { get; set; }

    [Column("module_website_sale_delivery")]
    public bool? ModuleWebsiteSaleDelivery { get; set; }

    [Column("group_delivery_invoice_address")]
    public bool? GroupDeliveryInvoiceAddress { get; set; }

    [Column("group_show_uom_price")]
    public bool? GroupShowUomPrice { get; set; }

    [Column("group_product_price_comparison")]
    public bool? GroupProductPriceComparison { get; set; }

    [Column("module_website_sale_digital")]
    public bool? ModuleWebsiteSaleDigital { get; set; }

    [Column("module_website_sale_wishlist")]
    public bool? ModuleWebsiteSaleWishlist { get; set; }

    [Column("module_website_sale_comparison")]
    public bool? ModuleWebsiteSaleComparison { get; set; }

    [Column("module_website_sale_autocomplete")]
    public bool? ModuleWebsiteSaleAutocomplete { get; set; }

    [Column("module_account")]
    public bool? ModuleAccount { get; set; }

    [Column("module_website_sale_picking")]
    public bool? ModuleWebsiteSalePicking { get; set; }

    [Column("module_delivery_mondialrelay")]
    public bool? ModuleDeliveryMondialrelay { get; set; }

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

    [Column("delay_alert_contract")]
    public long? DelayAlertContract { get; set; }

    [ForeignKey("AuthSignupTemplateUserId")]
    //[InverseProperty("ResConfigSettingAuthSignupTemplateUsers")]
    [NotMapped]
    public virtual ResUser? AuthSignupTemplateUser { get; set; }

    [ForeignKey("ChartTemplateId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

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

    [ForeignKey("ResConfigSettingsId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositions { get; } = new List<AccountFiscalPosition>();

    [ForeignKey("ResConfigSettingsId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual ICollection<PosCategory> PosCategories { get; } = new List<PosCategory>();

    [ForeignKey("ResConfigSettingsId")]
    //[InverseProperty("ResConfigSettings")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; } = new List<ProductPricelist>();
}
