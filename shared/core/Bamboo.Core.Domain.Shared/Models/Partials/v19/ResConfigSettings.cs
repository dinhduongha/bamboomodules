using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class ResBank
{
    [Column("module_google_address_autocomplete")]
    public bool? ModuleGoogleAddressAutocomplete { get; set; }

    [JsonIgnore]
    [Column("google_places_api_key")]
    public string? GooglePlacesApiKey { get; set; }

    [Column("geoloc_provider_id")]
    public Guid? GeolocProviderId { get; set; }

    [JsonIgnore]
    [Column("geoloc_provider_googlemap_key")]
    public string? GeolocProviderGooglemapKey { get; set; }

    [Column("recaptcha_public_key")]
    public string? RecaptchaPublicKey { get; set; }

    [JsonIgnore]
    [Column("recaptcha_private_key")]
    public string? RecaptchaPrivateKey { get; set; }

    [Column("enable_recaptcha")]
    public bool? EnableRecaptcha { get; set; }

    [Column("recaptcha_min_score")]
    public double? RecaptchaMinScore { get; set; }

    [Column("use_sfu_server")]
    public bool? UseSfuServer { get; set; }

    [Column("auth_totp_policy")]
    public string? AuthTotpPolicy { get; set; }

    [Column("auth_totp_enforce")]
    public bool? AuthTotpEnforce { get; set; }

    [Column("delay_alert_contract")]
    public long? DelayAlertContract { get; set; }

    [Column("module_maintenance_worksheet")]
    public bool? ModuleMaintenanceWorksheet { get; set; }

    [Column("microsoft_outlook_client_identifier")]
    public string? MicrosoftOutlookClientIdentifier { get; set; }

    [JsonIgnore]
    [Column("microsoft_outlook_client_secret")]
    public string? MicrosoftOutlookClientSecret { get; set; }

    [JsonIgnore]
    [Column("google_maps_static_api_key")]
    public string? GoogleMapsStaticApiKey { get; set; }

    [JsonIgnore]
    [Column("google_maps_static_api_secret")]
    public string? GoogleMapsStaticApiSecret { get; set; }

    [Column("module_event_sale")]
    public bool? ModuleEventSale { get; set; }

    [Column("module_pos_event")]
    public bool? ModulePosEvent { get; set; }

    [Column("module_website_event_track")]
    public bool? ModuleWebsiteEventTrack { get; set; }

    [Column("module_website_event_track_live")]
    public bool? ModuleWebsiteEventTrackLive { get; set; }

    [Column("module_website_event_track_quiz")]
    public bool? ModuleWebsiteEventTrackQuiz { get; set; }

    [Column("module_website_event_exhibitor")]
    public bool? ModuleWebsiteEventExhibitor { get; set; }

    [Column("use_event_barcode")]
    public bool? UseEventBarcode { get; set; }

    [Column("module_website_event_sale")]
    public bool? ModuleWebsiteEventSale { get; set; }

    [Column("module_event_booth")]
    public bool? ModuleEventBooth { get; set; }

    [Column("use_google_maps_static_api")]
    public bool? UseGoogleMapsStaticApi { get; set; }

    [Column("show_sale_receipts")]
    public bool? ShowSaleReceipts { get; set; }

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

    [Column("module_partnership")]
    public bool? ModulePartnership { get; set; }

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

    [Column("module_hr_presence")]
    public bool? ModuleHrPresence { get; set; }

    [Column("module_hr_skills")]
    public bool? ModuleHrSkills { get; set; }

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

    [Column("module_hr_timesheet")]
    public bool? ModuleHrTimesheet { get; set; }

    [Column("group_project_stages")]
    public bool? GroupProjectStages { get; set; }

    [Column("module_delivery")]
    public bool? ModuleDelivery { get; set; }

    [Column("module_delivery_dhl")]
    public bool? ModuleDeliveryDhl { get; set; }

    [Column("module_delivery_fedex_rest")]
    public bool? ModuleDeliveryFedexRest { get; set; }

    [Column("module_delivery_ups_rest")]
    public bool? ModuleDeliveryUpsRest { get; set; }

    [Column("module_delivery_usps_rest")]
    public bool? ModuleDeliveryUspsRest { get; set; }

    [Column("module_delivery_bpost")]
    public bool? ModuleDeliveryBpost { get; set; }

    [Column("module_delivery_easypost")]
    public bool? ModuleDeliveryEasypost { get; set; }

    [Column("module_delivery_sendcloud")]
    public bool? ModuleDeliverySendcloud { get; set; }

    [Column("module_delivery_shiprocket")]
    public bool? ModuleDeliveryShiprocket { get; set; }

    [Column("module_delivery_starshipit")]
    public bool? ModuleDeliveryStarshipit { get; set; }

    [Column("module_delivery_envia")]
    public bool? ModuleDeliveryEnvia { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("group_multi_website")]
    public bool? GroupMultiWebsite { get; set; }

    [Column("module_website_livechat")]
    public bool? ModuleWebsiteLivechat { get; set; }

    [Column("pay_invoices_online")]
    public bool? PayInvoicesOnline { get; set; }

    [Column("module_hr_expense_stripe")]
    public bool? ModuleHrExpenseStripe { get; set; }

    [Column("module_website_hr_recruitment")]
    public bool? ModuleWebsiteHrRecruitment { get; set; }

    [Column("module_hr_recruitment_survey")]
    public bool? ModuleHrRecruitmentSurvey { get; set; }

    [Column("module_hr_recruitment_extract")]
    public bool? ModuleHrRecruitmentExtract { get; set; }

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

    [Column("group_send_reminder")]
    public bool? GroupSendReminder { get; set; }

    [Column("module_stock_landed_costs")]
    public bool? ModuleStockLandedCosts { get; set; }

    [Column("group_lot_on_invoice")]
    public bool? GroupLotOnInvoice { get; set; }

    [Column("is_installed_sale")]
    public bool? IsInstalledSale { get; set; }

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

    [Column("module_product_email_template")]
    public bool? ModuleProductEmailTemplate { get; set; }

    [Column("module_sale_amazon")]
    public bool? ModuleSaleAmazon { get; set; }

    [Column("module_sale_commission")]
    public bool? ModuleSaleCommission { get; set; }

    [Column("module_sale_gelato")]
    public bool? ModuleSaleGelato { get; set; }

    [Column("module_sale_loyalty")]
    public bool? ModuleSaleLoyalty { get; set; }

    [Column("module_sale_margin")]
    public bool? ModuleSaleMargin { get; set; }

    [Column("module_sale_pdf_quote_builder")]
    public bool? ModuleSalePdfQuoteBuilder { get; set; }

    [Column("module_sale_product_matrix")]
    public bool? ModuleSaleProductMatrix { get; set; }

    [Column("module_sale_shopee")]
    public bool? ModuleSaleShopee { get; set; }

    [Column("group_sale_order_template")]
    public bool? GroupSaleOrderTemplate { get; set; }

    [Column("default_picking_policy")]
    public string? DefaultPickingPolicy { get; set; }

    [Column("use_security_lead")]
    public bool? UseSecurityLead { get; set; }

    [Column("group_show_uom_price")]
    public bool? GroupShowUomPrice { get; set; }

    [Column("group_product_price_comparison")]
    public bool? GroupProductPriceComparison { get; set; }

    [Column("module_website_sale_autocomplete")]
    public bool? ModuleWebsiteSaleAutocomplete { get; set; }

    [Column("module_website_sale_collect")]
    public bool? ModuleWebsiteSaleCollect { get; set; }


    [Column("default_allow_out_of_stock_order")]
    public bool? DefaultAllowOutOfStockOrder { get; set; }

    [Column("default_show_availability")]
    public bool? DefaultShowAvailability { get; set; }

    [Column("default_available_threshold")]
    public double? DefaultAvailableThreshold { get; set; }

    [Column("pos_config_id")]
    public Guid? PosConfigId { get; set; }

    [Column("pos_default_fiscal_position_id")]
    public Guid? PosDefaultFiscalPositionId { get; set; }

    [Column("pos_pricelist_id")]
    public Guid? PosPricelistId { get; set; }

    [Column("pos_tip_product_id")]
    public Guid? PosTipProductId { get; set; }

    [Column("pos_receipt_footer")]
    public string? PosReceiptFooter { get; set; }

    [Column("pos_receipt_header")]
    public string? PosReceiptHeader { get; set; }

    [Column("module_pos_adyen")]
    public bool? ModulePosAdyen { get; set; }

    [Column("module_pos_stripe")]
    public bool? ModulePosStripe { get; set; }

    [Column("module_pos_viva_com")]
    public bool? ModulePosVivaCom { get; set; }

    [Column("module_pos_razorpay")]
    public bool? ModulePosRazorpay { get; set; }

    [Column("module_pos_mercado_pago")]
    public bool? ModulePosMercadoPago { get; set; }

    [Column("module_pos_pine_labs")]
    public bool? ModulePosPineLabs { get; set; }

    [Column("module_pos_qfpay")]
    public bool? ModulePosQfpay { get; set; }

    [Column("module_pos_pricer")]
    public bool? ModulePosPricer { get; set; }

    [Column("is_kiosk_mode")]
    public bool? IsKioskMode { get; set; }

    [Column("pos_is_order_printer")]
    public bool? PosIsOrderPrinter { get; set; }

    [Column("pos_iface_cashdrawer")]
    public bool? PosIfaceCashdrawer { get; set; }

    [Column("pos_iface_electronic_scale")]
    public bool? PosIfaceElectronicScale { get; set; }

    [Column("pos_iface_print_via_proxy")]
    public bool? PosIfacePrintViaProxy { get; set; }

    [Column("pos_iface_scan_via_proxy")]
    public bool? PosIfaceScanViaProxy { get; set; }

    [Column("group_pos_preset")]
    public bool? GroupPosPreset { get; set; }

    [Column("minlength")]
    public long? Minlength { get; set; }

    [Column("group_fiscal_year")]
    public bool? GroupFiscalYear { get; set; }

    [Column("group_expiry_date_on_delivery_slip")]
    public bool? GroupExpiryDateOnDeliverySlip { get; set; }

    [Column("turnstile_site_key")]
    public string? TurnstileSiteKey { get; set; }

    [Column("turnstile_secret_key")]
    public string? TurnstileSecretKey { get; set; }

    [Column("module_project_timesheet_holidays")]
    public bool? ModuleProjectTimesheetHolidays { get; set; }

    [Column("reminder_user_allow")]
    public bool? ReminderUserAllow { get; set; }

    [Column("reminder_allow")]
    public bool? ReminderAllow { get; set; }

    [Column("group_purchase_alternatives")]
    public bool? GroupPurchaseAlternatives { get; set; }

    [Column("pos_discount_product_id")]
    public Guid? PosDiscountProductId { get; set; }

    [Column("pos_iface_printbill")]
    public bool? PosIfacePrintbill { get; set; }

    [Column("pos_iface_splitbill")]
    public bool? PosIfaceSplitbill { get; set; }

    [Column("pos_set_tip_after_payment")]
    public bool? PosSetTipAfterPayment { get; set; }

    [Column("invoice_policy")]
    public bool? InvoicePolicy { get; set; }
}