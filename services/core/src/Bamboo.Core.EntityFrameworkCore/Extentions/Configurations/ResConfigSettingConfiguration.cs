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
        public static void ConfigureResConfigSetting(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResConfigSetting>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_config_settings_pkey");

                entity.ToTable("res_config_settings");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AliasDomain).HasColumnName("alias_domain");
                entity.Property(e => e.AllowOutOfStockOrder).HasColumnName("allow_out_of_stock_order");
                entity.Property(e => e.AuthSignupResetPassword).HasColumnName("auth_signup_reset_password");
                entity.Property(e => e.AuthSignupTemplateUserId).HasColumnName("auth_signup_template_user_id");
                entity.Property(e => e.AuthSignupUninvited).HasColumnName("auth_signup_uninvited");
                entity.Property(e => e.AutomaticInvoice).HasColumnName("automatic_invoice");
                entity.Property(e => e.AvailableThreshold).HasColumnName("available_threshold");
                entity.Property(e => e.ChartTemplateId).HasColumnName("chart_template_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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
                entity.Property(e => e.DefaultInvoicePolicy).HasColumnName("default_invoice_policy");
                entity.Property(e => e.DefaultPickingPolicy).HasColumnName("default_picking_policy");
                entity.Property(e => e.DefaultPurchaseMethod).HasColumnName("default_purchase_method");
                entity.Property(e => e.DelayAlertContract).HasColumnName("delay_alert_contract");
                entity.Property(e => e.DepositDefaultProductId).HasColumnName("deposit_default_product_id");
                entity.Property(e => e.DigestEmails).HasColumnName("digest_emails");
                entity.Property(e => e.DigestId).HasColumnName("digest_id");
                entity.Property(e => e.EnabledBuyNowButton).HasColumnName("enabled_buy_now_button");
                entity.Property(e => e.EnabledExtraCheckoutStep).HasColumnName("enabled_extra_checkout_step");
                entity.Property(e => e.ExpenseAliasPrefix).HasColumnName("expense_alias_prefix");
                entity.Property(e => e.ExternalEmailServerDefault).HasColumnName("external_email_server_default");
                entity.Property(e => e.GoogleGmailClientIdentifier).HasColumnName("google_gmail_client_identifier");
                entity.Property(e => e.GoogleGmailClientSecret).HasColumnName("google_gmail_client_secret");
                entity.Property(e => e.GroupAnalyticAccounting).HasColumnName("group_analytic_accounting");
                entity.Property(e => e.GroupApplicantCvDisplay).HasColumnName("group_applicant_cv_display");
                entity.Property(e => e.GroupAttendanceUsePin).HasColumnName("group_attendance_use_pin");
                entity.Property(e => e.GroupAutoDoneSetting).HasColumnName("group_auto_done_setting");
                entity.Property(e => e.GroupCashRounding).HasColumnName("group_cash_rounding");
                entity.Property(e => e.GroupDeliveryInvoiceAddress).HasColumnName("group_delivery_invoice_address");
                entity.Property(e => e.GroupDiscountPerSoLine).HasColumnName("group_discount_per_so_line");
                entity.Property(e => e.GroupDisplayIncoterm).HasColumnName("group_display_incoterm");
                entity.Property(e => e.GroupFiscalYear).HasColumnName("group_fiscal_year");
                entity.Property(e => e.GroupLotOnDeliverySlip).HasColumnName("group_lot_on_delivery_slip");
                entity.Property(e => e.GroupLotOnInvoice).HasColumnName("group_lot_on_invoice");
                entity.Property(e => e.GroupMrpByproducts).HasColumnName("group_mrp_byproducts");
                entity.Property(e => e.GroupMrpReceptionReport).HasColumnName("group_mrp_reception_report");
                entity.Property(e => e.GroupMrpRoutings).HasColumnName("group_mrp_routings");
                entity.Property(e => e.GroupMrpWorkorderDependencies).HasColumnName("group_mrp_workorder_dependencies");
                entity.Property(e => e.GroupMultiCurrency).HasColumnName("group_multi_currency");
                entity.Property(e => e.GroupMultiWebsite).HasColumnName("group_multi_website");
                entity.Property(e => e.GroupProductPriceComparison).HasColumnName("group_product_price_comparison");
                entity.Property(e => e.GroupProductPricelist).HasColumnName("group_product_pricelist");
                entity.Property(e => e.GroupProductVariant).HasColumnName("group_product_variant");
                entity.Property(e => e.GroupProformaSales).HasColumnName("group_proforma_sales");
                entity.Property(e => e.GroupProjectMilestone).HasColumnName("group_project_milestone");
                entity.Property(e => e.GroupProjectRating).HasColumnName("group_project_rating");
                entity.Property(e => e.GroupProjectRecurringTasks).HasColumnName("group_project_recurring_tasks");
                entity.Property(e => e.GroupProjectStages).HasColumnName("group_project_stages");
                entity.Property(e => e.GroupProjectTaskDependencies).HasColumnName("group_project_task_dependencies");
                entity.Property(e => e.GroupSaleDeliveryAddress).HasColumnName("group_sale_delivery_address");
                entity.Property(e => e.GroupSaleOrderTemplate).HasColumnName("group_sale_order_template");
                entity.Property(e => e.GroupSalePricelist).HasColumnName("group_sale_pricelist");
                entity.Property(e => e.GroupSendReminder).HasColumnName("group_send_reminder");
                entity.Property(e => e.GroupShowLineSubtotalsTaxExcluded).HasColumnName("group_show_line_subtotals_tax_excluded");
                entity.Property(e => e.GroupShowLineSubtotalsTaxIncluded).HasColumnName("group_show_line_subtotals_tax_included");
                entity.Property(e => e.GroupShowPurchaseReceipts).HasColumnName("group_show_purchase_receipts");
                entity.Property(e => e.GroupShowSaleReceipts).HasColumnName("group_show_sale_receipts");
                entity.Property(e => e.GroupShowUomPrice).HasColumnName("group_show_uom_price");
                entity.Property(e => e.GroupStockAdvLocation).HasColumnName("group_stock_adv_location");
                entity.Property(e => e.GroupStockLotPrintGs1).HasColumnName("group_stock_lot_print_gs1");
                entity.Property(e => e.GroupStockMultiLocations).HasColumnName("group_stock_multi_locations");
                entity.Property(e => e.GroupStockPackaging).HasColumnName("group_stock_packaging");
                entity.Property(e => e.GroupStockPickingWave).HasColumnName("group_stock_picking_wave");
                entity.Property(e => e.GroupStockProductionLot).HasColumnName("group_stock_production_lot");
                entity.Property(e => e.GroupStockReceptionReport).HasColumnName("group_stock_reception_report");
                entity.Property(e => e.GroupStockSignDelivery).HasColumnName("group_stock_sign_delivery");
                entity.Property(e => e.GroupStockStorageCategories).HasColumnName("group_stock_storage_categories");
                entity.Property(e => e.GroupStockTrackingLot).HasColumnName("group_stock_tracking_lot");
                entity.Property(e => e.GroupStockTrackingOwner).HasColumnName("group_stock_tracking_owner");
                entity.Property(e => e.GroupSubtaskProject).HasColumnName("group_subtask_project");
                entity.Property(e => e.GroupUnlockedByDefault).HasColumnName("group_unlocked_by_default");
                entity.Property(e => e.GroupUom).HasColumnName("group_uom");
                entity.Property(e => e.GroupUseLead).HasColumnName("group_use_lead");
                entity.Property(e => e.GroupUseRecurringRevenues).HasColumnName("group_use_recurring_revenues");
                entity.Property(e => e.GroupWarningAccount).HasColumnName("group_warning_account");
                entity.Property(e => e.GroupWarningPurchase).HasColumnName("group_warning_purchase");
                entity.Property(e => e.GroupWarningSale).HasColumnName("group_warning_sale");
                entity.Property(e => e.GroupWarningStock).HasColumnName("group_warning_stock");
                entity.Property(e => e.HrAttendanceOvertime).HasColumnName("hr_attendance_overtime");
                entity.Property(e => e.HrEmployeeSelfEdit).HasColumnName("hr_employee_self_edit");
                entity.Property(e => e.HrPresenceControlEmail).HasColumnName("hr_presence_control_email");
                entity.Property(e => e.HrPresenceControlIp).HasColumnName("hr_presence_control_ip");
                entity.Property(e => e.HrPresenceControlLogin).HasColumnName("hr_presence_control_login");
                entity.Property(e => e.InvoiceMailTemplateId).HasColumnName("invoice_mail_template_id");
                entity.Property(e => e.IsInstalledSale).HasColumnName("is_installed_sale");
                entity.Property(e => e.IsMembershipMulti).HasColumnName("is_membership_multi");
                entity.Property(e => e.LeadEnrichAuto).HasColumnName("lead_enrich_auto");
                entity.Property(e => e.LeadMiningInPipeline).HasColumnName("lead_mining_in_pipeline");
                entity.Property(e => e.LockConfirmedPo).HasColumnName("lock_confirmed_po");
                entity.Property(e => e.ModuleAccount).HasColumnName("module_account");
                entity.Property(e => e.ModuleAccount3wayMatch).HasColumnName("module_account_3way_match");
                entity.Property(e => e.ModuleAccountAccountant).HasColumnName("module_account_accountant");
                entity.Property(e => e.ModuleAccountBankStatementImportCamt).HasColumnName("module_account_bank_statement_import_camt");
                entity.Property(e => e.ModuleAccountBankStatementImportCsv).HasColumnName("module_account_bank_statement_import_csv");
                entity.Property(e => e.ModuleAccountBankStatementImportOfx).HasColumnName("module_account_bank_statement_import_ofx");
                entity.Property(e => e.ModuleAccountBankStatementImportQif).HasColumnName("module_account_bank_statement_import_qif");
                entity.Property(e => e.ModuleAccountBatchPayment).HasColumnName("module_account_batch_payment");
                entity.Property(e => e.ModuleAccountBudget).HasColumnName("module_account_budget");
                entity.Property(e => e.ModuleAccountCheckPrinting).HasColumnName("module_account_check_printing");
                entity.Property(e => e.ModuleAccountInterCompanyRules).HasColumnName("module_account_inter_company_rules");
                entity.Property(e => e.ModuleAccountIntrastat).HasColumnName("module_account_intrastat");
                entity.Property(e => e.ModuleAccountInvoiceExtract).HasColumnName("module_account_invoice_extract");
                entity.Property(e => e.ModuleAccountPayment).HasColumnName("module_account_payment");
                entity.Property(e => e.ModuleAccountReports).HasColumnName("module_account_reports");
                entity.Property(e => e.ModuleAccountSepa).HasColumnName("module_account_sepa");
                entity.Property(e => e.ModuleAccountSepaDirectDebit).HasColumnName("module_account_sepa_direct_debit");
                entity.Property(e => e.ModuleAccountTaxcloud).HasColumnName("module_account_taxcloud");
                entity.Property(e => e.ModuleAuthLdap).HasColumnName("module_auth_ldap");
                entity.Property(e => e.ModuleAuthOauth).HasColumnName("module_auth_oauth");
                entity.Property(e => e.ModuleBaseGengo).HasColumnName("module_base_gengo");
                entity.Property(e => e.ModuleBaseGeolocalize).HasColumnName("module_base_geolocalize");
                entity.Property(e => e.ModuleBaseImport).HasColumnName("module_base_import");
                entity.Property(e => e.ModuleCrmIapEnrich).HasColumnName("module_crm_iap_enrich");
                entity.Property(e => e.ModuleCrmIapMine).HasColumnName("module_crm_iap_mine");
                entity.Property(e => e.ModuleCurrencyRateLive).HasColumnName("module_currency_rate_live");
                entity.Property(e => e.ModuleDelivery).HasColumnName("module_delivery");
                entity.Property(e => e.ModuleDeliveryBpost).HasColumnName("module_delivery_bpost");
                entity.Property(e => e.ModuleDeliveryDhl).HasColumnName("module_delivery_dhl");
                entity.Property(e => e.ModuleDeliveryEasypost).HasColumnName("module_delivery_easypost");
                entity.Property(e => e.ModuleDeliveryFedex).HasColumnName("module_delivery_fedex");
                entity.Property(e => e.ModuleDeliveryMondialrelay).HasColumnName("module_delivery_mondialrelay");
                entity.Property(e => e.ModuleDeliverySendcloud).HasColumnName("module_delivery_sendcloud");
                entity.Property(e => e.ModuleDeliveryUps).HasColumnName("module_delivery_ups");
                entity.Property(e => e.ModuleDeliveryUsps).HasColumnName("module_delivery_usps");
                entity.Property(e => e.ModuleGoogleCalendar).HasColumnName("module_google_calendar");
                entity.Property(e => e.ModuleGoogleGmail).HasColumnName("module_google_gmail");
                entity.Property(e => e.ModuleGoogleRecaptcha).HasColumnName("module_google_recaptcha");
                entity.Property(e => e.ModuleHrAttendance).HasColumnName("module_hr_attendance");
                entity.Property(e => e.ModuleHrExpenseExtract).HasColumnName("module_hr_expense_extract");
                entity.Property(e => e.ModuleHrHomeworking).HasColumnName("module_hr_homeworking");
                entity.Property(e => e.ModuleHrPayrollExpense).HasColumnName("module_hr_payroll_expense");
                entity.Property(e => e.ModuleHrPresence).HasColumnName("module_hr_presence");
                entity.Property(e => e.ModuleHrRecruitmentExtract).HasColumnName("module_hr_recruitment_extract");
                entity.Property(e => e.ModuleHrRecruitmentSurvey).HasColumnName("module_hr_recruitment_survey");
                entity.Property(e => e.ModuleHrSkills).HasColumnName("module_hr_skills");
                entity.Property(e => e.ModuleHrTimesheet).HasColumnName("module_hr_timesheet");
                entity.Property(e => e.ModuleL10nEuOss).HasColumnName("module_l10n_eu_oss");
                entity.Property(e => e.ModuleLoyalty).HasColumnName("module_loyalty");
                entity.Property(e => e.ModuleMailPlugin).HasColumnName("module_mail_plugin");
                entity.Property(e => e.ModuleMarketingAutomation).HasColumnName("module_marketing_automation");
                entity.Property(e => e.ModuleMicrosoftCalendar).HasColumnName("module_microsoft_calendar");
                entity.Property(e => e.ModuleMicrosoftOutlook).HasColumnName("module_microsoft_outlook");
                entity.Property(e => e.ModuleMrpMps).HasColumnName("module_mrp_mps");
                entity.Property(e => e.ModuleMrpPlm).HasColumnName("module_mrp_plm");
                entity.Property(e => e.ModuleMrpSubcontracting).HasColumnName("module_mrp_subcontracting");
                entity.Property(e => e.ModuleMrpWorkorder).HasColumnName("module_mrp_workorder");
                entity.Property(e => e.ModulePartnerAutocomplete).HasColumnName("module_partner_autocomplete");
                entity.Property(e => e.ModulePaymentPaypal).HasColumnName("module_payment_paypal");
                entity.Property(e => e.ModulePosAdyen).HasColumnName("module_pos_adyen");
                entity.Property(e => e.ModulePosMercury).HasColumnName("module_pos_mercury");
                entity.Property(e => e.ModulePosSix).HasColumnName("module_pos_six");
                entity.Property(e => e.ModulePosStripe).HasColumnName("module_pos_stripe");
                entity.Property(e => e.ModuleProductEmailTemplate).HasColumnName("module_product_email_template");
                entity.Property(e => e.ModuleProductExpiry).HasColumnName("module_product_expiry");
                entity.Property(e => e.ModuleProductImages).HasColumnName("module_product_images");
                entity.Property(e => e.ModuleProductMargin).HasColumnName("module_product_margin");
                entity.Property(e => e.ModuleProjectForecast).HasColumnName("module_project_forecast");
                entity.Property(e => e.ModulePurchaseProductMatrix).HasColumnName("module_purchase_product_matrix");
                entity.Property(e => e.ModulePurchaseRequisition).HasColumnName("module_purchase_requisition");
                entity.Property(e => e.ModuleQualityControl).HasColumnName("module_quality_control");
                entity.Property(e => e.ModuleQualityControlWorksheet).HasColumnName("module_quality_control_worksheet");
                entity.Property(e => e.ModuleSaleAmazon).HasColumnName("module_sale_amazon");
                entity.Property(e => e.ModuleSaleLoyalty).HasColumnName("module_sale_loyalty");
                entity.Property(e => e.ModuleSaleMargin).HasColumnName("module_sale_margin");
                entity.Property(e => e.ModuleSaleProductMatrix).HasColumnName("module_sale_product_matrix");
                entity.Property(e => e.ModuleSaleQuotationBuilder).HasColumnName("module_sale_quotation_builder");
                entity.Property(e => e.ModuleSnailmailAccount).HasColumnName("module_snailmail_account");
                entity.Property(e => e.ModuleStockBarcode).HasColumnName("module_stock_barcode");
                entity.Property(e => e.ModuleStockDropshipping).HasColumnName("module_stock_dropshipping");
                entity.Property(e => e.ModuleStockLandedCosts).HasColumnName("module_stock_landed_costs");
                entity.Property(e => e.ModuleStockPickingBatch).HasColumnName("module_stock_picking_batch");
                entity.Property(e => e.ModuleStockSms).HasColumnName("module_stock_sms");
                entity.Property(e => e.ModuleVoip).HasColumnName("module_voip");
                entity.Property(e => e.ModuleWebUnsplash).HasColumnName("module_web_unsplash");
                entity.Property(e => e.ModuleWebsiteCrmIapReveal).HasColumnName("module_website_crm_iap_reveal");
                entity.Property(e => e.ModuleWebsiteHrRecruitment).HasColumnName("module_website_hr_recruitment");
                entity.Property(e => e.ModuleWebsiteLivechat).HasColumnName("module_website_livechat");
                entity.Property(e => e.ModuleWebsiteSaleAutocomplete).HasColumnName("module_website_sale_autocomplete");
                entity.Property(e => e.ModuleWebsiteSaleComparison).HasColumnName("module_website_sale_comparison");
                entity.Property(e => e.ModuleWebsiteSaleDelivery).HasColumnName("module_website_sale_delivery");
                entity.Property(e => e.ModuleWebsiteSaleDigital).HasColumnName("module_website_sale_digital");
                entity.Property(e => e.ModuleWebsiteSalePicking).HasColumnName("module_website_sale_picking");
                entity.Property(e => e.ModuleWebsiteSaleWishlist).HasColumnName("module_website_sale_wishlist");
                entity.Property(e => e.OvertimeCompanyThreshold).HasColumnName("overtime_company_threshold");
                entity.Property(e => e.OvertimeEmployeeThreshold).HasColumnName("overtime_employee_threshold");
                entity.Property(e => e.OvertimeStartDate).HasColumnName("overtime_start_date");
                entity.Property(e => e.PoOrderApproval).HasColumnName("po_order_approval");
                entity.Property(e => e.PosConfigId).HasColumnName("pos_config_id");
                entity.Property(e => e.PosDefaultFiscalPositionId).HasColumnName("pos_default_fiscal_position_id");
                entity.Property(e => e.PosEpsonPrinterIp).HasColumnName("pos_epson_printer_ip");
                entity.Property(e => e.PosIfaceCashdrawer).HasColumnName("pos_iface_cashdrawer");
                entity.Property(e => e.PosIfaceCustomerFacingDisplayViaProxy).HasColumnName("pos_iface_customer_facing_display_via_proxy");
                entity.Property(e => e.PosIfaceElectronicScale).HasColumnName("pos_iface_electronic_scale");
                entity.Property(e => e.PosIfacePrintViaProxy).HasColumnName("pos_iface_print_via_proxy");
                entity.Property(e => e.PosIfaceScanViaProxy).HasColumnName("pos_iface_scan_via_proxy");
                entity.Property(e => e.PosIfaceStartCategId).HasColumnName("pos_iface_start_categ_id");
                entity.Property(e => e.PosPricelistId).HasColumnName("pos_pricelist_id");
                entity.Property(e => e.PosProxyIp).HasColumnName("pos_proxy_ip");
                entity.Property(e => e.PosReceiptFooter).HasColumnName("pos_receipt_footer");
                entity.Property(e => e.PosReceiptHeader).HasColumnName("pos_receipt_header");
                entity.Property(e => e.PosTipProductId).HasColumnName("pos_tip_product_id");
                entity.Property(e => e.PredictiveLeadScoringFieldsStr).HasColumnName("predictive_lead_scoring_fields_str");
                entity.Property(e => e.PredictiveLeadScoringStartDateStr).HasColumnName("predictive_lead_scoring_start_date_str");
                entity.Property(e => e.ProductPricelistSetting).HasColumnName("product_pricelist_setting");
                entity.Property(e => e.ProductVolumeVolumeInCubicFeet).HasColumnName("product_volume_volume_in_cubic_feet");
                entity.Property(e => e.ProductWeightInLbs).HasColumnName("product_weight_in_lbs");
                entity.Property(e => e.ProfilingEnabledUntil)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("profiling_enabled_until");
                entity.Property(e => e.RecaptchaMinScore).HasColumnName("recaptcha_min_score");
                entity.Property(e => e.RecaptchaPrivateKey).HasColumnName("recaptcha_private_key");
                entity.Property(e => e.RecaptchaPublicKey).HasColumnName("recaptcha_public_key");
                entity.Property(e => e.RestrictTemplateRendering).HasColumnName("restrict_template_rendering");
                entity.Property(e => e.SaleDeliverySettings).HasColumnName("sale_delivery_settings");
                entity.Property(e => e.ShowAvailability).HasColumnName("show_availability");
                entity.Property(e => e.ShowEffect).HasColumnName("show_effect");
                entity.Property(e => e.ShowLineSubtotalsTaxSelection).HasColumnName("show_line_subtotals_tax_selection");
                entity.Property(e => e.TwilioAccountSid).HasColumnName("twilio_account_sid");
                entity.Property(e => e.TwilioAccountToken).HasColumnName("twilio_account_token");
                entity.Property(e => e.UnsplashAccessKey).HasColumnName("unsplash_access_key");
                entity.Property(e => e.UnsplashAppId).HasColumnName("unsplash_app_id");
                entity.Property(e => e.UseInvoiceTerms).HasColumnName("use_invoice_terms");
                entity.Property(e => e.UseMailgateway).HasColumnName("use_mailgateway");
                entity.Property(e => e.UseManufacturingLead).HasColumnName("use_manufacturing_lead");
                entity.Property(e => e.UsePoLead).HasColumnName("use_po_lead");
                entity.Property(e => e.UseQuotationValidityDays).HasColumnName("use_quotation_validity_days");
                entity.Property(e => e.UseSecurityLead).HasColumnName("use_security_lead");
                entity.Property(e => e.UseTwilioRtcServers).HasColumnName("use_twilio_rtc_servers");
                entity.Property(e => e.UserDefaultRights).HasColumnName("user_default_rights");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.AuthSignupTemplateUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_auth_signup_template_user_id_fkey");

                // v16-Compat
                // entity.HasOne(d => d.ChartTemplate).WithMany(p => p.ResConfigSettings)
                //     .HasForeignKey(d => d.ChartTemplateId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("res_config_settings_chart_template_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("res_config_settings_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_create_uid_fkey");

                entity.HasOne(d => d.DepositDefaultProduct).WithMany(p => p.ResConfigSettingDepositDefaultProducts)
                    .HasForeignKey(d => d.DepositDefaultProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_deposit_default_product_id_fkey");

                entity.HasOne(d => d.Digest).WithMany(p => p.ResConfigSettings)
                    .HasForeignKey(d => d.DigestId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_digest_id_fkey");

                entity.HasOne(d => d.InvoiceMailTemplate).WithMany(p => p.ResConfigSettings)
                    .HasForeignKey(d => d.InvoiceMailTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_invoice_mail_template_id_fkey");

                entity.HasOne(d => d.PosConfig).WithMany(p => p.ResConfigSettings)
                    .HasForeignKey(d => d.PosConfigId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_pos_config_id_fkey");

                entity.HasOne(d => d.PosDefaultFiscalPosition).WithMany(p => p.ResConfigSettingsNavigation)
                    .HasForeignKey(d => d.PosDefaultFiscalPositionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_pos_default_fiscal_position_id_fkey");

                entity.HasOne(d => d.PosIfaceStartCateg).WithMany(p => p.ResConfigSettingsNavigation)
                    .HasForeignKey(d => d.PosIfaceStartCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_pos_iface_start_categ_id_fkey");

                entity.HasOne(d => d.PosPricelist).WithMany(p => p.ResConfigSettingsNavigation)
                    .HasForeignKey(d => d.PosPricelistId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_pos_pricelist_id_fkey");

                entity.HasOne(d => d.PosTipProduct).WithMany(p => p.ResConfigSettingPosTipProducts)
                    .HasForeignKey(d => d.PosTipProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_pos_tip_product_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.ResConfigSettings)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("res_config_settings_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_config_settings_write_uid_fkey");

                //entity.HasMany(d => d.AccountFiscalPositions).WithMany(p => p.ResConfigSettings)
                entity.HasMany<AccountFiscalPosition>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountFiscalPositionResConfigSettingsRel",
                        r => r.HasOne<AccountFiscalPosition>().WithMany()
                            .HasForeignKey("AccountFiscalPositionId")
                            .HasConstraintName("account_fiscal_position_res_con_account_fiscal_position_id_fkey"),
                        l => l.HasOne<ResConfigSetting>().WithMany()
                            .HasForeignKey("ResConfigSettingsId")
                            .HasConstraintName("account_fiscal_position_res_config__res_config_settings_id_fkey"),
                        j =>
                        {
                            j.HasKey("ResConfigSettingsId", "AccountFiscalPositionId").HasName("account_fiscal_position_res_config_settings_rel_pkey");
                            j.ToTable("account_fiscal_position_res_config_settings_rel");
                            j.HasIndex(new[] { "AccountFiscalPositionId", "ResConfigSettingsId" }, "account_fiscal_position_res_c_account_fiscal_position_id_re_idx");
                        });

                //entity.HasMany(d => d.PosCategories).WithMany(p => p.ResConfigSettings)
                entity.HasMany<PosCategory>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosCategoryResConfigSettingsRel",
                        r => r.HasOne<PosCategory>().WithMany()
                            .HasForeignKey("PosCategoryId")
                            .HasConstraintName("pos_category_res_config_settings_rel_pos_category_id_fkey"),
                        l => l.HasOne<ResConfigSetting>().WithMany()
                            .HasForeignKey("ResConfigSettingsId")
                            .HasConstraintName("pos_category_res_config_settings_re_res_config_settings_id_fkey"),
                        j =>
                        {
                            j.HasKey("ResConfigSettingsId", "PosCategoryId").HasName("pos_category_res_config_settings_rel_pkey");
                            j.ToTable("pos_category_res_config_settings_rel");
                            j.HasIndex(new[] { "PosCategoryId", "ResConfigSettingsId" }, "pos_category_res_config_setti_pos_category_id_res_config_se_idx");
                        });

                //entity.HasMany(d => d.ProductPricelists).WithMany(p => p.ResConfigSettings)
                entity.HasMany<ProductPricelist>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductPricelistResConfigSettingsRel",
                        r => r.HasOne<ProductPricelist>().WithMany()
                            .HasForeignKey("ProductPricelistId")
                            .HasConstraintName("product_pricelist_res_config_settings_product_pricelist_id_fkey"),
                        l => l.HasOne<ResConfigSetting>().WithMany()
                            .HasForeignKey("ResConfigSettingsId")
                            .HasConstraintName("product_pricelist_res_config_settin_res_config_settings_id_fkey"),
                        j =>
                        {
                            j.HasKey("ResConfigSettingsId", "ProductPricelistId").HasName("product_pricelist_res_config_settings_rel_pkey");
                            j.ToTable("product_pricelist_res_config_settings_rel");
                            j.HasIndex(new[] { "ProductPricelistId", "ResConfigSettingsId" }, "product_pricelist_res_config__product_pricelist_id_res_conf_idx");
                        });
            });
        }
    }
}