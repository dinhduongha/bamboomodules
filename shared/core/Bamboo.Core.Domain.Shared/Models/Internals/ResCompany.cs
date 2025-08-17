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

[Table("res_company")]
//[Index("ParentId", Name = "res_company__parent_id_index")]
//[Index("Name", Name = "res_company_name_uniq", IsUnique = true)]
public partial class ResCompany: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("paperformat_id")]
    public Guid? PaperformatId { get; set; }

    [Column("external_report_layout_id")]
    public Guid? ExternalReportLayoutId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    [Column("base_onboarding_company_state")]
    public string? BaseOnboardingCompanyState { get; set; }

    [Column("font")]
    public string? Font { get; set; }

    [Column("primary_color")]
    public string? PrimaryColor { get; set; }

    [Column("secondary_color")]
    public string? SecondaryColor { get; set; }

    [Column("layout_background")]
    public string? LayoutBackground { get; set; }

    // v16-Compat
    //[Column("report_header")]
    //public string? ReportHeader { get; set; }

    [JsonField]
    [Column("report_header", TypeName = "jsonb")]
    public string? ReportHeader { get; set; }

    [JsonField]
    [Column("report_footer", TypeName = "jsonb")]
    public string? ReportFooter { get; set; }

    // v16-Compat
    //[Column("company_details")]
    //public string? CompanyDetails { get; set; }

    [JsonField]
    [Column("company_details", TypeName = "jsonb")]
    public string? CompanyDetails { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("uses_default_logo")]
    public bool? UsesDefaultLogo { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("logo_web")]
    public byte[]? LogoWeb { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("alias_domain_id")]
    public Guid? AliasDomainId { get; set; }

    [Column("alias_domain_name")]
    public string? AliasDomainName { get; set; }

    [Column("email_primary_color")]
    public string? EmailPrimaryColor { get; set; }

    [Column("email_secondary_color")]
    public string? EmailSecondaryColor { get; set; }

    [Column("partner_gid")]
    public Guid? PartnerGid { get; set; }

    [Column("iap_enrich_auto_done")]
    public bool? IapEnrichAutoDone { get; set; }

    [Column("snailmail_color")]
    public bool? SnailmailColor { get; set; }

    [Column("snailmail_cover")]
    public bool? SnailmailCover { get; set; }

    [Column("snailmail_duplex")]
    public bool? SnailmailDuplex { get; set; }

    [Column("payment_provider_onboarding_state")]
    public string? PaymentProviderOnboardingState { get; set; }

    [Column("payment_onboarding_payment_method")]
    public string? PaymentOnboardingPaymentMethod { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("fiscalyear_last_day")]
    public long? FiscalyearLastDay { get; set; }

    [Column("transfer_account_id")]
    public Guid? TransferAccountId { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("default_cash_difference_income_account_id")]
    public Guid? DefaultCashDifferenceIncomeAccountId { get; set; }

    [Column("default_cash_difference_expense_account_id")]
    public Guid? DefaultCashDifferenceExpenseAccountId { get; set; }

    [Column("account_journal_suspense_account_id")]
    public Guid? AccountJournalSuspenseAccountId { get; set; }

    [Column("account_journal_payment_debit_account_id")]
    public Guid? AccountJournalPaymentDebitAccountId { get; set; }

    [Column("account_journal_payment_credit_account_id")]
    public Guid? AccountJournalPaymentCreditAccountId { get; set; }

    [Column("account_journal_early_pay_discount_gain_account_id")]
    public Guid? AccountJournalEarlyPayDiscountGainAccountId { get; set; }

    [Column("account_journal_early_pay_discount_loss_account_id")]
    public Guid? AccountJournalEarlyPayDiscountLossAccountId { get; set; }

    [Column("account_sale_tax_id")]
    public Guid? AccountSaleTaxId { get; set; }

    [Column("account_purchase_tax_id")]
    public Guid? AccountPurchaseTaxId { get; set; }

    [Column("currency_exchange_journal_id")]
    public Guid? CurrencyExchangeJournalId { get; set; }

    [Column("income_currency_exchange_account_id")]
    public Guid? IncomeCurrencyExchangeAccountId { get; set; }

    [Column("expense_currency_exchange_account_id")]
    public Guid? ExpenseCurrencyExchangeAccountId { get; set; }

    [Column("property_stock_account_input_categ_id")]
    public Guid? PropertyStockAccountInputCategId { get; set; }

    [Column("property_stock_account_output_categ_id")]
    public Guid? PropertyStockAccountOutputCategId { get; set; }

    [Column("property_stock_valuation_account_id")]
    public Guid? PropertyStockValuationAccountId { get; set; }

    [Column("incoterm_id")]
    public Guid? IncotermId { get; set; }

    [Column("batch_payment_sequence_id")]
    public Guid? BatchPaymentSequenceId { get; set; }

    [Column("account_opening_move_id")]
    public Guid? AccountOpeningMoveId { get; set; }

    [Column("account_default_pos_receivable_account_id")]
    public Guid? AccountDefaultPosReceivableAccountId { get; set; }

    [Column("expense_accrual_account_id")]
    public Guid? ExpenseAccrualAccountId { get; set; }

    [Column("revenue_accrual_account_id")]
    public Guid? RevenueAccrualAccountId { get; set; }

    [Column("automatic_entry_default_journal_id")]
    public Guid? AutomaticEntryDefaultJournalId { get; set; }

    [Column("account_fiscal_country_id")]
    public Guid? AccountFiscalCountryId { get; set; }

    [Column("tax_cash_basis_journal_id")]
    public Guid? TaxCashBasisJournalId { get; set; }

    [Column("account_cash_basis_base_account_id")]
    public Guid? AccountCashBasisBaseAccountId { get; set; }

    [Column("account_discount_income_allocation_id")]
    public Guid? AccountDiscountIncomeAllocationId { get; set; }

    [Column("account_discount_expense_allocation_id")]
    public Guid? AccountDiscountExpenseAllocationId { get; set; }

    [Column("fiscalyear_last_month")]
    public string? FiscalyearLastMonth { get; set; }

    [Column("chart_template")]
    public string? ChartTemplateString { get; set; }

    [Column("bank_account_code_prefix")]
    public string? BankAccountCodePrefix { get; set; }

    [Column("cash_account_code_prefix")]
    public string? CashAccountCodePrefix { get; set; }

    [Column("early_pay_discount_computation")]
    public string? EarlyPayDiscountComputation { get; set; }

    [Column("transfer_account_code_prefix")]
    public string? TransferAccountCodePrefix { get; set; }

    [Column("tax_calculation_rounding_method")]
    public string? TaxCalculationRoundingMethod { get; set; }

    [Column("account_setup_bank_data_state")]
    public string? AccountSetupBankDataState { get; set; }

    [Column("account_setup_fy_data_state")]
    public string? AccountSetupFyDataState { get; set; }

    [Column("account_setup_coa_state")]
    public string? AccountSetupCoaState { get; set; }

    [Column("account_setup_taxes_state")]
    public string? AccountSetupTaxesState { get; set; }

    [Column("account_onboarding_invoice_layout_state")]
    public string? AccountOnboardingInvoiceLayoutState { get; set; }

    [Column("account_onboarding_sale_tax_state")]
    public string? AccountOnboardingSaleTaxState { get; set; }

    [Column("account_invoice_onboarding_state")]
    public string? AccountInvoiceOnboardingState { get; set; }

    [Column("account_dashboard_onboarding_state")]
    public string? AccountDashboardOnboardingState { get; set; }

    [Column("terms_type")]
    public string? TermsType { get; set; }

    [Column("account_setup_bill_state")]
    public string? AccountSetupBillState { get; set; }

    [Column("quick_edit_mode")]
    public string? QuickEditMode { get; set; }

    [Column("account_price_include")]
    public string? AccountPriceInclude { get; set; }

    [Column("period_lock_date")]
    public DateTime? PeriodLockDate { get; set; }

    [Column("fiscalyear_lock_date")]
    public DateTime? FiscalyearLockDate { get; set; }

    [Column("tax_lock_date")]
    public DateTime? TaxLockDate { get; set; }

    [Column("sale_lock_date")]
    public DateTime? SaleLockDate { get; set; }

    [Column("purchase_lock_date")]
    public DateTime? PurchaseLockDate { get; set; }

    [Column("hard_lock_date")]
    public DateTime? HardLockDate { get; set; }

    [Column("account_opening_date")]
    public DateTime? AccountOpeningDate { get; set; }

    [JsonField]
    [Column("invoice_terms", TypeName = "jsonb")]
    public string? InvoiceTerms { get; set; }

    [JsonField]
    [Column("invoice_terms_html", TypeName = "jsonb")]
    public string? InvoiceTermsHtml { get; set; }

    [Column("expects_chart_of_accounts")]
    public bool? ExpectsChartOfAccounts { get; set; }

    [Column("anglo_saxon_accounting")]
    public bool? AngloSaxonAccounting { get; set; }

    [Column("qr_code")]
    public bool? QrCode { get; set; }

    [Column("display_invoice_amount_total_words")]
    public bool? DisplayInvoiceAmountTotalWords { get; set; }

    [Column("display_invoice_tax_company_currency")]
    public bool? DisplayInvoiceTaxCompanyCurrency { get; set; }

    [Column("invoice_is_email")]
    public bool? InvoiceIsEmail { get; set; }

    [Column("invoice_is_print")]
    public bool? InvoiceIsPrint { get; set; }

    [Column("account_use_credit_limit")]
    public bool? AccountUseCreditLimit { get; set; }

    [Column("account_onboarding_create_invoice_state_flag")]
    public bool? AccountOnboardingCreateInvoiceStateFlag { get; set; }

    [Column("tax_exigibility")]
    public bool? TaxExigibility { get; set; }

    [Column("account_storno")]
    public bool? AccountStorno { get; set; }

    [Column("check_account_audit_trail")]
    public bool? CheckAccountAuditTrail { get; set; }

    [Column("autopost_bills")]
    public bool? AutopostBills { get; set; }

    [Column("invoice_is_snailmail")]
    public bool? InvoiceIsSnailmail { get; set; }

    [Column("quotation_validity_days")]
    public long? QuotationValidityDays { get; set; }

    [Column("sale_discount_product_id")]
    public Guid? SaleDiscountProductId { get; set; }

    [Column("sale_quotation_onboarding_state")]
    public string? SaleQuotationOnboardingState { get; set; }

    [Column("sale_onboarding_order_confirmation_state")]
    public string? SaleOnboardingOrderConfirmationState { get; set; }

    [Column("sale_onboarding_sample_quotation_state")]
    public string? SaleOnboardingSampleQuotationState { get; set; }

    [Column("sale_onboarding_payment_method")]
    public string? SaleOnboardingPaymentMethod { get; set; }

    [Column("portal_confirmation_sign")]
    public bool? PortalConfirmationSign { get; set; }

    [Column("portal_confirmation_pay")]
    public bool? PortalConfirmationPay { get; set; }

    [Column("prepayment_percent")]
    public double? PrepaymentPercent { get; set; }

    [Column("sale_order_template_id")]
    public Guid? SaleOrderTemplateId { get; set; }

    [Column("vat_check_vies")]
    public bool? VatCheckVies { get; set; }

    [Column("nomenclature_id")]
    public Guid? NomenclatureId { get; set; }

    [Column("internal_transit_location_id")]
    public Guid? InternalTransitLocationId { get; set; }

    [Column("stock_mail_confirmation_template_id")]
    public Guid? StockMailConfirmationTemplateId { get; set; }

    [Column("annual_inventory_day")]
    public long? AnnualInventoryDay { get; set; }

    [Column("annual_inventory_month")]
    public string? AnnualInventoryMonth { get; set; }

    [Column("stock_move_email_validation")]
    public bool? StockMoveEmailValidation { get; set; }

    [Column("account_production_wip_account_id")]
    public Guid? AccountProductionWipAccountId { get; set; }

    [Column("account_production_wip_overhead_account_id")]
    public Guid? AccountProductionWipOverheadAccountId { get; set; }

    [Column("stock_sms_confirmation_template_id")]
    public Guid? StockSmsConfirmationTemplateId { get; set; }

    [Column("stock_move_sms_validation")]
    public bool? StockMoveSmsValidation { get; set; }

    [Column("has_received_warning_stock_sms")]
    public bool? HasReceivedWarningStockSms { get; set; }

    [Column("point_of_sale_update_stock_quantities")]
    public string? PointOfSaleUpdateStockQuantities { get; set; }

    [Column("point_of_sale_ticket_portal_url_display_mode")]
    public string? PointOfSaleTicketPortalUrlDisplayMode { get; set; }

    [Column("point_of_sale_use_ticket_qr_code")]
    public bool? PointOfSaleUseTicketQrCode { get; set; }

    [Column("point_of_sale_ticket_unique_code")]
    public bool? PointOfSaleTicketUniqueCode { get; set; }

    [Column("security_lead")]
    public double? SecurityLead { get; set; }

    [Column("po_lock")]
    public string? PoLock { get; set; }

    [Column("po_double_validation")]
    public string? PoDoubleValidation { get; set; }

    [Column("po_double_validation_amount")]
    public decimal? PoDoubleValidationAmount { get; set; }

    [Column("po_lead")]
    public double? PoLead { get; set; }

    [Column("days_to_purchase")]
    public double? DaysToPurchase { get; set; }

    [Column("manufacturing_lead")]
    public double? ManufacturingLead { get; set; }

    [Column("hr_presence_control_email_amount")]
    public long? HrPresenceControlEmailAmount { get; set; }

    [Column("hr_presence_control_ip_list")]
    public string? HrPresenceControlIpList { get; set; }

    [JsonField]
    [Column("employee_properties_definition", TypeName = "jsonb")]
    public string? EmployeePropertiesDefinition { get; set; }

    [Column("expense_journal_id")]
    public Guid? ExpenseJournalId { get; set; }

    [Column("company_expense_journal_id")]
    public Guid? CompanyExpenseJournalId { get; set; }

    [Column("hr_presence_control_login")]
    public bool? HrPresenceControlLogin { get; set; }

    [Column("hr_presence_control_email")]
    public bool? HrPresenceControlEmail { get; set; }

    [Column("hr_presence_control_ip")]
    public bool? HrPresenceControlIp { get; set; }

    [Column("hr_presence_control_attendance")]
    public bool? HrPresenceControlAttendance { get; set; }

    [Column("contract_expiration_notice_period")]
    public long? ContractExpirationNoticePeriod { get; set; }

    [Column("work_permit_expiration_notice_period")]
    public long? WorkPermitExpirationNoticePeriod { get; set; }

    [JsonField]
    [Column("candidate_properties_definition", TypeName = "jsonb")]
    public string? CandidatePropertiesDefinition { get; set; }

    [JsonField]
    [Column("job_properties_definition", TypeName = "jsonb")]
    public string? JobPropertiesDefinition { get; set; }

    [Column("overtime_company_threshold")]
    public long? OvertimeCompanyThreshold { get; set; }

    [Column("overtime_employee_threshold")]
    public long? OvertimeEmployeeThreshold { get; set; }

    [Column("attendance_kiosk_delay")]
    public long? AttendanceKioskDelay { get; set; }

    [Column("attendance_kiosk_mode")]
    public string? AttendanceKioskMode { get; set; }

    [Column("attendance_barcode_source")]
    public string? AttendanceBarcodeSource { get; set; }

    [Column("attendance_kiosk_key")]
    public string? AttendanceKioskKey { get; set; }

    [Column("attendance_overtime_validation")]
    public string? AttendanceOvertimeValidation { get; set; }

    [Column("overtime_start_date")]
    public DateTime? OvertimeStartDate { get; set; }

    [Column("hr_attendance_display_overtime")]
    public bool? HrAttendanceDisplayOvertime { get; set; }

    [Column("hr_attendance_overtime")]
    public bool? HrAttendanceOvertime { get; set; }

    [Column("attendance_kiosk_use_pin")]
    public bool? AttendanceKioskUsePin { get; set; }

    [Column("attendance_from_systray")]
    public bool? AttendanceFromSystray { get; set; }

    [Column("auto_check_out")]
    public bool? AutoCheckOut { get; set; }

    [Column("absence_management")]
    public bool? AbsenceManagement { get; set; }

    [Column("auto_check_out_tolerance")]
    public double? AutoCheckOutTolerance { get; set; }

    // [Column("expense_journal_id")]
    // public Guid? ExpenseJournalId { get; set; }

    [Column("expense_outstanding_account_id")]
    public Guid? ExpenseOutstandingAccountId { get; set; }

    [JsonField]
    [Column("lunch_notify_message", TypeName = "jsonb")]
    public string? LunchNotifyMessage { get; set; }

    [Column("lunch_minimum_threshold")]
    public double? LunchMinimumThreshold { get; set; }

    // [Column("manufacturing_lead")]
    // public double? ManufacturingLead { get; set; }

    [Column("social_twitter")]
    public string? SocialTwitter { get; set; }

    [Column("social_facebook")]
    public string? SocialFacebook { get; set; }

    [Column("social_github")]
    public string? SocialGithub { get; set; }

    [Column("social_linkedin")]
    public string? SocialLinkedin { get; set; }

    [Column("social_youtube")]
    public string? SocialYoutube { get; set; }

    [Column("social_instagram")]
    public string? SocialInstagram { get; set; }

    [Column("social_tiktok")]
    public string? SocialTiktok { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("website_sale_onboarding_payment_provider_state")]
    public string? WebsiteSaleOnboardingPaymentProviderState { get; set; }

    [Column("lc_journal_id")]
    public Guid? LcJournalId { get; set; }

    [Column("subcontracting_location_id")]
    public Guid? SubcontractingLocationId { get; set; }

    [Column("project_time_mode_id")]
    public Guid? ProjectTimeModeId { get; set; }

    [Column("timesheet_encode_uom_id")]
    public Guid? TimesheetEncodeUomId { get; set; }

    [Column("internal_project_id")]
    public Guid? InternalProjectId { get; set; }

    [Column("leave_timesheet_task_id")]
    public Guid? LeaveTimesheetTaskId { get; set; }

    [Column("hr_presence_last_compute_date", TypeName = "timestamp without time zone")]
    public DateTime? HrPresenceLastComputeDate { get; set; }

    [Column("dropship_subcontractor_pick_type_id")]
    public Guid? DropshipSubcontractorPickTypeId { get; set; }

    // [Column("vat_check_vies")]
    // public bool? VatCheckVies { get; set; }

    [Column("peppol_purchase_journal_id")]
    public Guid? PeppolPurchaseJournalId { get; set; }

    [Column("account_peppol_contact_email")]
    public string? AccountPeppolContactEmail { get; set; }

    [Column("account_peppol_migration_key")]
    public string? AccountPeppolMigrationKey { get; set; }

    [Column("account_peppol_phone_number")]
    public string? AccountPeppolPhoneNumber { get; set; }

    [Column("account_peppol_proxy_state")]
    public string? AccountPeppolProxyState { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalance { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicability { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlan { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountBalanceReport> AccountBalanceReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountBankStatement> AccountBankStatement { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountBudgetPost> AccountBudgetPost { get; set; }

    // [Many2one]
    [ForeignKey("AccountCashBasisBaseAccountId")]
    // [InverseProperty("ResCompanyAccountCashBasisBaseAccount")] //Many2one
    public virtual AccountAccount? AccountCashBasisBaseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountCommonReport> AccountCommonReport { get; set; }

    // [Many2one]
    [ForeignKey("AccountDefaultPosReceivableAccountId")]
    // [InverseProperty("ResCompanyAccountDefaultPosReceivableAccount")] //Many2one
    public virtual AccountAccount? AccountDefaultPosReceivableAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountDiscountExpenseAllocationId")]
    // [InverseProperty("ResCompanyAccountDiscountExpenseAllocation")] //Many2one
    public virtual AccountAccount? AccountDiscountExpenseAllocation { get; set; }

    // [Many2one]
    [ForeignKey("AccountDiscountIncomeAllocationId")]
    // [InverseProperty("ResCompanyAccountDiscountIncomeAllocation")] //Many2one
    public virtual AccountAccount? AccountDiscountIncomeAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountEdiProxyClientUser> AccountEdiProxyClientUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOp { get; set; }

    // [Many2one]
    [ForeignKey("AccountFiscalCountryId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual ResCountry? AccountFiscalCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountFiscalPosition> AccountFiscalPosition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountFiscalYear> AccountFiscalYear { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountGroup> AccountGroup { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    // [InverseProperty("ResCompanyAccountJournalEarlyPayDiscountGainAccount")] //Many2one
    public virtual AccountAccount? AccountJournalEarlyPayDiscountGainAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    // [InverseProperty("ResCompanyAccountJournalEarlyPayDiscountLossAccount")] //Many2one
    public virtual AccountAccount? AccountJournalEarlyPayDiscountLossAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountJournalGroup> AccountJournalGroup { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalPaymentCreditAccountId")]
    // [InverseProperty("ResCompanyAccountJournalPaymentCreditAccount")] //Many2one
    public virtual AccountAccount? AccountJournalPaymentCreditAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalPaymentDebitAccountId")]
    // [InverseProperty("ResCompanyAccountJournalPaymentDebitAccount")] //Many2one
    public virtual AccountAccount? AccountJournalPaymentDebitAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalSuspenseAccountId")]
    // [InverseProperty("ResCompanyAccountJournalSuspenseAccount")] //Many2one
    public virtual AccountAccount? AccountJournalSuspenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountLockException> AccountLockException { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountMoveReversal> AccountMoveReversal { get; set; }

    // [Many2one]
    [ForeignKey("AccountOpeningMoveId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual AccountMove? AccountOpeningMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountPartialReconcile> AccountPartialReconcile { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountPaymentTerm> AccountPaymentTerm { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountPrintJournal> AccountPrintJournal { get; set; }

    // [Many2one]
    [ForeignKey("AccountProductionWipAccountId")]
    // [InverseProperty("ResCompanyAccountProductionWipAccount")] //Many2one
    public virtual AccountAccount? AccountProductionWipAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountProductionWipOverheadAccountId")]
    // [InverseProperty("ResCompanyAccountProductionWipOverheadAccount")] //Many2one
    public virtual AccountAccount? AccountProductionWipOverheadAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountPurchaseTaxId")]
    // [InverseProperty("ResCompanyAccountPurchaseTax")] //Many2one
    public virtual AccountTax? AccountPurchaseTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountReportExternalValue> AccountReportExternalValue { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedger { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedger { get; set; }

    // [Many2one]
    [ForeignKey("AccountSaleTaxId")]
    // [InverseProperty("ResCompanyAccountSaleTax")] //Many2one
    public virtual AccountTax? AccountSaleTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountSecureEntriesWizard> AccountSecureEntriesWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroup { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountUpdateTaxTagsWizard> AccountUpdateTaxTagsWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<AccountingReport> AccountingReport { get; set; }

    // [Many2one]
    [ForeignKey("AliasDomainId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual MailAliasDomain? AliasDomain { get; set; }

    // [Many2one]
    [ForeignKey("AutomaticEntryDefaultJournalId")]
    // [InverseProperty("ResCompanyAutomaticEntryDefaultJournal")] //Many2one
    public virtual AccountJournal? AutomaticEntryDefaultJournal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<BaseDocumentLayout> BaseDocumentLayout { get; set; }

    // [Many2one]
    [ForeignKey("BatchPaymentSequenceId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual IrSequence? BatchPaymentSequence { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<CertificateCertificate> CertificateCertificate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<CertificateKey> CertificateKey { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ChangeLockDate> ChangeLockDate { get; set; }

    // [Many2one]
    [ForeignKey("ChartTemplateId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CompanyExpenseJournalId")]
    // [InverseProperty("ResCompanyCompanyExpenseJournal")] //Many2one
    public virtual AccountJournal? CompanyExpenseJournal { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResCompanyCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<CrmTeam> CrmTeam { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<CrossoveredBudget> CrossoveredBudget { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<CrossoveredBudgetLines> CrossoveredBudgetLines { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyExchangeJournalId")]
    // [InverseProperty("ResCompanyCurrencyExchangeJournal")] //Many2one
    public virtual AccountJournal? CurrencyExchangeJournal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<DataRecycleRecord> DataRecycleRecord { get; set; }

    // [Many2one]
    [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    // [InverseProperty("ResCompanyDefaultCashDifferenceExpenseAccount")] //Many2one
    public virtual AccountAccount? DefaultCashDifferenceExpenseAccount { get; set; }

    // [Many2one]
    [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    // [InverseProperty("ResCompanyDefaultCashDifferenceIncomeAccount")] //Many2one
    public virtual AccountAccount? DefaultCashDifferenceIncomeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<DeliveryCarrier> DeliveryCarrier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<DigestDigest> DigestDigest { get; set; }

    // [Many2one]
    [ForeignKey("DropshipSubcontractorPickTypeId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual StockPickingType? DropshipSubcontractorPickType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<EventLeadRule> EventLeadRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseAccrualAccountId")]
    // [InverseProperty("ResCompanyExpenseAccrualAccount")] //Many2one
    public virtual AccountAccount? ExpenseAccrualAccount { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    // [InverseProperty("ResCompanyExpenseCurrencyExchangeAccount")] //Many2one
    public virtual AccountAccount? ExpenseCurrencyExchangeAccount { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseJournalId")]
    // [InverseProperty("ResCompanyExpenseJournal")] //Many2one
    public virtual AccountJournal? ExpenseJournal { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseOutstandingAccountId")]
    // [InverseProperty("ResCompanyExpenseOutstandingAccount")] //Many2one
    public virtual AccountAccount? ExpenseOutstandingAccount { get; set; }

    // [Many2one]
    [ForeignKey("ExternalReportLayoutId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual IrUiView? ExternalReportLayout { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<FleetVehicle> FleetVehicle { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServices { get; set; }

    // [Many2one]
    // [InverseProperty("Company")] //Many2one
    public virtual FollowupFollowup? FollowupFollowup { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrCandidate> HrCandidate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrContributionRegister> HrContributionRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrDepartment> HrDepartment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlan { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("EmployeeCompanyId")]
    // [InverseProperty("EmployeeCompany")]
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("EmployeeCompanyId")]
    // [InverseProperty("EmployeeCompany")]
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationEmployeeCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("ModeCompanyId")]
    // [InverseProperty("ModeCompany")]
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationModeCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrLeave> HrLeaveCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("EmployeeCompanyId")]
    // [InverseProperty("EmployeeCompany")]
    // public virtual ICollection<HrLeave> HrLeaveEmployeeCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDay { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("ModeCompanyId")]
    // [InverseProperty("ModeCompany")]
    // public virtual ICollection<HrLeave> HrLeaveModeCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrLeaveStressDay> HrLeaveStressDay { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrPayrollStructure> HrPayrollStructure { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrPayslip> HrPayslip { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrPayslipLine> HrPayslipLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrPlan> HrPlan { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrPlanActivityType> HrPlanActivityType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrSalaryRule> HrSalaryRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrSalaryRuleCategory> HrSalaryRuleCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<HrWorkLocation> HrWorkLocation { get; set; }

    // [Many2one]
    [ForeignKey("IncomeCurrencyExchangeAccountId")]
    // [InverseProperty("ResCompanyIncomeCurrencyExchangeAccount")] //Many2one
    public virtual AccountAccount? IncomeCurrencyExchangeAccount { get; set; }

    // [Many2one]
    [ForeignKey("IncotermId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual AccountIncoterms? Incoterm { get; set; }

    // [Many2one]
    [ForeignKey("InternalProjectId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual ProjectProject? InternalProject { get; set; }

    // [Many2one]
    [ForeignKey("InternalTransitLocationId")]
    // [InverseProperty("ResCompanyInternalTransitLocation")] //Many2one
    public virtual StockLocation? InternalTransitLocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("ParentId")]
    // [InverseProperty("Parent")]
    // public virtual ICollection<ResCompany> InverseParent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<IrAttachment> IrAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<IrDefault> IrDefault { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<IrProperty> IrProperty { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<IrSequence> IrSequence { get; set; }

    // [Many2one]
    [ForeignKey("LcJournalId")]
    // [InverseProperty("ResCompanyLcJournal")] //Many2one
    public virtual AccountJournal? LcJournal { get; set; }

    // [Many2one]
    [ForeignKey("LeaveTimesheetTaskId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual ProjectTask? LeaveTimesheetTask { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LoyaltyProgram> LoyaltyProgram { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LunchLocation> LunchLocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LunchOrder> LunchOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LunchProduct> LunchProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LunchProductCategory> LunchProductCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LunchSupplier> LunchSupplier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<LunchTopping> LunchTopping { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MailActivityPlan> MailActivityPlan { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("RecordCompanyId")]
    // [InverseProperty("RecordCompany")]
    // public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("RecordCompanyId")]
    // [InverseProperty("RecordCompany")]
    // public virtual ICollection<MailMessage> MailMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MaintenanceRequest> MaintenanceRequest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MaintenanceTeam> MaintenanceTeam { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MembershipMembershipLine> MembershipMembershipLine { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivity { get; set; }

    // [Many2one]
    [ForeignKey("NomenclatureId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual BarcodeNomenclature? Nomenclature { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<NoteNote> NoteNote { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<OnboardingProgress> OnboardingProgress { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<OnboardingProgressStep> OnboardingProgressStep { get; set; }

    // [Many2one]
    [ForeignKey("PaperformatId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual ReportPaperformat? Paperformat { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual ResCompany? Parent { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PaymentToken> PaymentToken { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [Many2one]
    [ForeignKey("PeppolPurchaseJournalId")]
    // [InverseProperty("ResCompanyPeppolPurchaseJournal")] //Many2one
    public virtual AccountJournal? PeppolPurchaseJournal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PeppolRegistration> PeppolRegistration { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PosPaymentMethod> PosPaymentMethod { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PosPrinter> PosPrinter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProductCombo> ProductCombo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProductComboItem> ProductComboItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProductPackaging> ProductPackaging { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProductPricelist> ProductPricelist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProductPricelistItem> ProductPricelistItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProjectProjectStage> ProjectProjectStage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [Many2one]
    [ForeignKey("ProjectTimeModeId")]
    // [InverseProperty("ResCompanyProjectTimeMode")] //Many2one
    public virtual UomUom? ProjectTimeMode { get; set; }

    // [Many2one]
    [ForeignKey("PropertyStockAccountInputCategId")]
    // [InverseProperty("ResCompanyPropertyStockAccountInputCateg")] //Many2one
    public virtual AccountAccount? PropertyStockAccountInputCateg { get; set; }

    // [Many2one]
    [ForeignKey("PropertyStockAccountOutputCategId")]
    // [InverseProperty("ResCompanyPropertyStockAccountOutputCateg")] //Many2one
    public virtual AccountAccount? PropertyStockAccountOutputCateg { get; set; }

    // [Many2one]
    [ForeignKey("PropertyStockValuationAccountId")]
    // [InverseProperty("ResCompanyPropertyStockValuationAccount")] //Many2one
    public virtual AccountAccount? PropertyStockValuationAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<RecurringPayment> RecurringPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<RecurringPaymentLine> RecurringPaymentLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<RepairFee> RepairFee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<RepairLine> RepairLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ResCurrencyRate> ResCurrencyRate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ResPartnerBank> ResPartnerBank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [Many2one]
    [ForeignKey("ResourceCalendarId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeaves { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ResourceCalendar> ResourceCalendarNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<ResourceResource> ResourceResource { get; set; }

    // [Many2one]
    [ForeignKey("RevenueAccrualAccountId")]
    // [InverseProperty("ResCompanyRevenueAccrualAccount")] //Many2one
    public virtual AccountAccount? RevenueAccrualAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [Many2one]
    [ForeignKey("SaleDiscountProductId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual ProductProduct? SaleDiscountProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderTemplateId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<SaleOrderTemplate> SaleOrderTemplateNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockLandedCost> StockLandedCost { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockLocation> StockLocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockLot> StockLot { get; set; }

    // [Many2one]
    [ForeignKey("StockMailConfirmationTemplateId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual MailTemplate? StockMailConfirmationTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockPackageLevel> StockPackageLevel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockPackageType> StockPackageType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockPickingType> StockPickingType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockPutawayRule> StockPutawayRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockQuantPackage> StockQuantPackage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockRoute> StockRoute { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockRule> StockRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [ForeignKey("StockSmsConfirmationTemplateId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual SmsTemplate? StockSmsConfirmationTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockStorageCategory> StockStorageCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockWarehouse> StockWarehouse { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [ForeignKey("SubcontractingLocationId")]
    // [InverseProperty("ResCompanySubcontractingLocation")] //Many2one
    public virtual StockLocation? SubcontractingLocation { get; set; }

    // [Many2one]
    [ForeignKey("TaxCashBasisJournalId")]
    // [InverseProperty("ResCompanyTaxCashBasisJournal")] //Many2one
    public virtual AccountJournal? TaxCashBasisJournal { get; set; }

    // [Many2one]
    [ForeignKey("TimesheetEncodeUomId")]
    // [InverseProperty("ResCompanyTimesheetEncodeUom")] //Many2one
    public virtual UomUom? TimesheetEncodeUom { get; set; }

    // [Many2one]
    [ForeignKey("TransferAccountId")]
    // [InverseProperty("ResCompanyTransferAccount")] //Many2one
    public virtual AccountAccount? TransferAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<UtmCampaign> UtmCampaign { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("ResCompany")] //Many2one
    public virtual Website? Website { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [ForeignKey("TenantId")]
    // [InverseProperty("Company")]
    // public virtual ICollection<Website> WebsiteNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResCompanyWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCompanyId")]
    // [InverseProperty("ResCompany")]
    // public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ResCompanyId")] //Many2many
    // [InverseProperty("ResCompany")] //Many2many
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCompanyId")]
    // [InverseProperty("ResCompany")]
    // public virtual ICollection<IapAccount> IapAccount { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("Cid")] //Many2many
    // [InverseProperty("Cid")] //Many2many
    public virtual ICollection<ResUsers> User { get; set; }
}
