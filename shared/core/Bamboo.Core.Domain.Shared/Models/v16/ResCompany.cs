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
//[Index("Name", Name = "res_company_name_uniq", IsUnique = true)]
//[Index("ParentId", Name = "res_company_parent_id_index")]
[Module("base")]
public partial class ResCompany : FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    //[Column("company_id")]
    //public Guid? TenantId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("paperformat_id")]
    public Guid? PaperformatId { get; set; }

    [Column("external_report_layout_id")]
    public Guid? ExternalReportLayoutId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    // v16-Compat
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

    // v16-Compat json
    [JsonField]
    [Column("report_header", TypeName = "jsonb")]
    public string? ReportHeader { get; set; }

    [JsonField]
    [Column("report_footer", TypeName = "jsonb")]
    public string? ReportFooter { get; set; }

    [JsonField]
    [Column("company_details", TypeName = "jsonb")]
    public string? CompanyDetails { get; set; }

    // v16-Compat
    // [Column("report_header")]
    // public string? ReportHeader { get; set; }

    // v16-Compat
    //[Column("company_details")]
    //public string? CompanyDetails { get; set; }

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

    // v16-Compat
    [Column("payment_provider_onboarding_state")]
    public string? PaymentProviderOnboardingState { get; set; }

    [Column("payment_onboarding_payment_method")]
    public string? PaymentOnboardingPaymentMethod { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("fiscalyear_last_day")]
    public long? FiscalyearLastDay { get; set; }

    [Column("transfer_account_id")]
    public Guid? TransferAccountId { get; set; }

    // v16-Compat
    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("default_cash_difference_income_account_id")]
    public Guid? DefaultCashDifferenceIncomeAccountId { get; set; }

    [Column("default_cash_difference_expense_account_id")]
    public Guid? DefaultCashDifferenceExpenseAccountId { get; set; }

    [Column("account_journal_suspense_account_id")]
    public Guid? AccountJournalSuspenseAccountId { get; set; }

    // v16-Compat
    [Column("account_journal_payment_debit_account_id")]
    public Guid? AccountJournalPaymentDebitAccountId { get; set; }

    // v16-Compat
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

    // v16-Compat
    [Column("property_stock_account_input_categ_id")]
    public Guid? PropertyStockAccountInputCategId { get; set; }

    // v16-Compat
    [Column("property_stock_account_output_categ_id")]
    public Guid? PropertyStockAccountOutputCategId { get; set; }

    // v16-Compat
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
    public string? ChartTemplate { get; set; }

    [Column("bank_account_code_prefix")]
    public string? BankAccountCodePrefix { get; set; }

    [Column("cash_account_code_prefix")]
    public string? CashAccountCodePrefix { get; set; }

    // v16-Compat
    [Column("early_pay_discount_computation")]
    public string? EarlyPayDiscountComputation { get; set; }

    [Column("transfer_account_code_prefix")]
    public string? TransferAccountCodePrefix { get; set; }

    [Column("tax_calculation_rounding_method")]
    public string? TaxCalculationRoundingMethod { get; set; }

    // v16-Compat
    [Column("account_setup_bank_data_state")]
    public string? AccountSetupBankDataState { get; set; }

    // v16-Compat
    [Column("account_setup_fy_data_state")]
    public string? AccountSetupFyDataState { get; set; }

    // v16-Compat
    [Column("account_setup_coa_state")]
    public string? AccountSetupCoaState { get; set; }

    // v16-Compat
    [Column("account_setup_taxes_state")]
    public string? AccountSetupTaxesState { get; set; }

    // v16-Compat
    [Column("account_onboarding_invoice_layout_state")]
    public string? AccountOnboardingInvoiceLayoutState { get; set; }

    // v16-Compat
    [Column("account_onboarding_sale_tax_state")]
    public string? AccountOnboardingSaleTaxState { get; set; }

    // v16-Compat
    [Column("account_invoice_onboarding_state")]
    public string? AccountInvoiceOnboardingState { get; set; }

    // v16-Compat
    [Column("account_dashboard_onboarding_state")]
    public string? AccountDashboardOnboardingState { get; set; }

    [Column("terms_type")]
    public string? TermsType { get; set; }

    // v16-Compat
    [Column("account_setup_bill_state")]
    public string? AccountSetupBillState { get; set; }

    [Column("quick_edit_mode")]
    public string? QuickEditMode { get; set; }

    [Column("account_price_include")]
    public string? AccountPriceInclude { get; set; }

    // v16-Compat
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

    // v16-Compat
    [Column("invoice_is_email")]
    public bool? InvoiceIsEmail { get; set; }

    // v16-Compat
    [Column("invoice_is_print")]
    public bool? InvoiceIsPrint { get; set; }

    [Column("account_use_credit_limit")]
    public bool? AccountUseCreditLimit { get; set; }

    // v16-Compat
    [Column("account_onboarding_create_invoice_state_flag")]
    public bool? AccountOnboardingCreateInvoiceStateFlag { get; set; }

    [Column("tax_exigibility")]
    public bool? TaxExigibility { get; set; }

    [Column("account_storno")]
    public bool? AccountStorno { get; set; }

    // v16-Compat
    [Column("invoice_is_snailmail")]
    public bool? InvoiceIsSnailmail { get; set; }

    [Column("check_account_audit_trail")]
    public bool? CheckAccountAuditTrail { get; set; }

    [Column("autopost_bills")]
    public bool? AutopostBills { get; set; }

    [Column("quotation_validity_days")]
    public long? QuotationValidityDays { get; set; }

    [Column("sale_discount_product_id")]
    public Guid? SaleDiscountProductId { get; set; }

    // v16-Compat
    [Column("sale_quotation_onboarding_state")]
    public string? SaleQuotationOnboardingState { get; set; }

    // v16-Compat
    [Column("sale_onboarding_order_confirmation_state")]
    public string? SaleOnboardingOrderConfirmationState { get; set; }

    // v16-Compat
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

    // v16-Compat
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

    // v16-Compat
    // [Column("expense_journal_id")]
    // public Guid? ExpenseJournalId { get; set; }

    // v16-Compat
    [Column("company_expense_journal_id")]
    public Guid? CompanyExpenseJournalId { get; set; }

    [JsonField]
    [Column("employee_properties_definition", TypeName = "jsonb")]
    public string? EmployeePropertiesDefinition { get; set; }

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

    [Column("hr_attendance_display_overtime")]
    public bool? HrAttendanceDisplayOvertime { get; set; }

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

    [Column("expense_journal_id")]
    public Guid? ExpenseJournalId { get; set; }

    [Column("expense_outstanding_account_id")]
    public Guid? ExpenseOutstandingAccountId { get; set; }

    [JsonField]
    [Column("lunch_notify_message", TypeName = "jsonb")]
    public string? LunchNotifyMessage { get; set; }

    [Column("lunch_minimum_threshold")]
    public double? LunchMinimumThreshold { get; set; }

    // v16-Compat
    [Column("overtime_start_date")]
    public DateTime? OvertimeStartDate { get; set; }

    // v16-Compat
    [Column("hr_attendance_overtime")]
    public bool? HrAttendanceOvertime { get; set; }

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

    // v16-Compat
    //[JsonField]
    [Column("lunch_notify_message", TypeName = "jsonb")]
    //public string? LunchNotifyMessage { get; set; }

    // v16-Compat
    //[Column("lunch_minimum_threshold")]
    //public double? LunchMinimumThreshold { get; set; }

    [ForeignKey("AccountCashBasisBaseAccountId")]
    //[InverseProperty("ResCompanyAccountCashBasisBaseAccounts")]
    [NotMapped]
    public virtual AccountAccount? AccountCashBasisBaseAccount { get; set; }

    [ForeignKey("AccountFiscalCountryId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual ResCountry? AccountFiscalCountry { get; set; }

    [ForeignKey("AccountDefaultPosReceivableAccountId")]
    //[InverseProperty("ResCompanyAccountDefaultPosReceivableAccounts")]
    [NotMapped]
    public virtual AccountAccount? AccountDefaultPosReceivableAccount { get; set; }

    [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    //[InverseProperty("ResCompanyAccountJournalEarlyPayDiscountGainAccounts")]
    [NotMapped]
    public virtual AccountAccount? AccountJournalEarlyPayDiscountGainAccount { get; set; }

    [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    //[InverseProperty("ResCompanyAccountJournalEarlyPayDiscountLossAccounts")]
    [NotMapped]
    public virtual AccountAccount? AccountJournalEarlyPayDiscountLossAccount { get; set; }

    [ForeignKey("AccountJournalPaymentCreditAccountId")]
    //[InverseProperty("ResCompanyAccountJournalPaymentCreditAccounts")]
    [NotMapped]
    public virtual AccountAccount? AccountJournalPaymentCreditAccount { get; set; }

    [ForeignKey("AccountJournalPaymentDebitAccountId")]
    //[InverseProperty("ResCompanyAccountJournalPaymentDebitAccounts")]
    [NotMapped]
    public virtual AccountAccount? AccountJournalPaymentDebitAccount { get; set; }

    [ForeignKey("AccountJournalSuspenseAccountId")]
    //[InverseProperty("ResCompanyAccountJournalSuspenseAccounts")]
    [NotMapped]
    public virtual AccountAccount? AccountJournalSuspenseAccount { get; set; }

    [ForeignKey("AccountOpeningMoveId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual AccountMove? AccountOpeningMove { get; set; }

    [ForeignKey("AccountPurchaseTaxId")]
    //[InverseProperty("ResCompanyAccountPurchaseTaxes")]
    [NotMapped]
    public virtual AccountTax? AccountPurchaseTax { get; set; }

    [ForeignKey("AccountSaleTaxId")]
    //[InverseProperty("ResCompanyAccountSaleTaxes")]
    [NotMapped]
    public virtual AccountTax? AccountSaleTax { get; set; }

    [ForeignKey("AutomaticEntryDefaultJournalId")]
    //[InverseProperty("ResCompanyAutomaticEntryDefaultJournals")]
    [NotMapped]
    public virtual AccountJournal? AutomaticEntryDefaultJournal { get; set; }

    // v16-Compat
    // [ForeignKey("ChartTemplateId")]
    // //[InverseProperty("ResCompanies")]
    // [NotMapped]
    // public virtual AccountChartTemplate? ChartTemplateObject { get; set; }

    [ForeignKey("CompanyExpenseJournalId")]
    //[InverseProperty("ResCompanyCompanyExpenseJournals")]
    [NotMapped]
    public virtual AccountJournal? CompanyExpenseJournal { get; set; }

    //[InverseProperty("ResCompanyCreateUs")]
    [ForeignKey("CreatorId")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("CurrencyExchangeJournalId")]
    //[InverseProperty("ResCompanyCurrencyExchangeJournals")]
    [NotMapped]
    public virtual AccountJournal? CurrencyExchangeJournal { get; set; }

    [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    //[InverseProperty("ResCompanyDefaultCashDifferenceExpenseAccounts")]
    [NotMapped]
    public virtual AccountAccount? DefaultCashDifferenceExpenseAccount { get; set; }

    [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    //[InverseProperty("ResCompanyDefaultCashDifferenceIncomeAccounts")]
    [NotMapped]
    public virtual AccountAccount? DefaultCashDifferenceIncomeAccount { get; set; }

    [ForeignKey("ExpenseAccrualAccountId")]
    //[InverseProperty("ResCompanyExpenseAccrualAccounts")]
    [NotMapped]
    public virtual AccountAccount? ExpenseAccrualAccount { get; set; }

    [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    //[InverseProperty("ResCompanyExpenseCurrencyExchangeAccounts")]
    [NotMapped]
    public virtual AccountAccount? ExpenseCurrencyExchangeAccount { get; set; }

    [ForeignKey("ExpenseJournalId")]
    //[InverseProperty("ResCompanyExpenseJournals")]
    [NotMapped]
    public virtual AccountJournal? ExpenseJournal { get; set; }

    [ForeignKey("ExternalReportLayoutId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual IrUiView? ExternalReportLayout { get; set; }

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual FollowupFollowup? FollowupFollowup { get; set; }

    [ForeignKey("IncotermId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual AccountIncoterm? Incoterm { get; set; }

    [ForeignKey("InternalTransitLocationId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual StockLocation? InternalTransitLocation { get; set; }

    [ForeignKey("IncomeCurrencyExchangeAccountId")]
    //[InverseProperty("ResCompanyIncomeCurrencyExchangeAccounts")]
    [NotMapped]
    public virtual AccountAccount? IncomeCurrencyExchangeAccount { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("NomenclatureId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual BarcodeNomenclature? Nomenclature { get; set; }

    [ForeignKey("PaperformatId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual ReportPaperformat? Paperformat { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual ResCompany? Parent { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PropertyStockAccountInputCategId")]
    //[InverseProperty("ResCompanyPropertyStockAccountInputCategs")]
    [NotMapped]
    public virtual AccountAccount? PropertyStockAccountInputCateg { get; set; }

    [ForeignKey("PropertyStockAccountOutputCategId")]
    //[InverseProperty("ResCompanyPropertyStockAccountOutputCategs")]
    [NotMapped]
    public virtual AccountAccount? PropertyStockAccountOutputCateg { get; set; }

    [ForeignKey("PropertyStockValuationAccountId")]
    //[InverseProperty("ResCompanyPropertyStockValuationAccounts")]
    [NotMapped]
    public virtual AccountAccount? PropertyStockValuationAccount { get; set; }

    [ForeignKey("ResourceCalendarId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    [ForeignKey("RevenueAccrualAccountId")]
    //[InverseProperty("ResCompanyRevenueAccrualAccounts")]
    [NotMapped]
    public virtual AccountAccount? RevenueAccrualAccount { get; set; }

    [ForeignKey("SaleOrderTemplateId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    [ForeignKey("StockMailConfirmationTemplateId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual MailTemplate? StockMailConfirmationTemplate { get; set; }

    [ForeignKey("StockSmsConfirmationTemplateId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual SmsTemplate? StockSmsConfirmationTemplate { get; set; }

    [ForeignKey("TaxCashBasisJournalId")]
    //[InverseProperty("ResCompanyTaxCashBasisJournals")]
    [NotMapped]
    public virtual AccountJournal? TaxCashBasisJournal { get; set; }

    [ForeignKey("TransferAccountId")]
    //[InverseProperty("ResCompanyTransferAccounts")]
    [NotMapped]
    public virtual AccountAccount? TransferAccount { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResCompanyWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; set; } 


    [ForeignKey("TenantId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLines { get; set; } 

    [ForeignKey("TenantId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual ICollection<IapAccount> IapAccounts { get; set; } 

    /// TODO: DISABLE INVERSE
    //[InverseProperty("Company")]
    /*
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizards { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalances { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlans { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategories { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizards { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReports { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatements { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountBudgetPost> AccountBudgetPosts { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReports { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReports { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountCommonReport> AccountCommonReports { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOps { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccounts { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxes { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositions { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFiscalYear> AccountFiscalYears { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountGroup> AccountGroups { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountJournalGroup> AccountJournalGroups { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountMoveReversal> AccountMoveReversals { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconciles { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTerm> AccountPaymentTerms { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountPrintJournal> AccountPrintJournals { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplates { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValues { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgers { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizards { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountingReport> AccountingReports { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<BaseDocumentLayout> BaseDocumentLayouts { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ChangeLockDate> ChangeLockDates { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeams { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudgetLine> CrossoveredBudgetLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgets { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<DigestDigest> DigestDigests { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContracts { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServices { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicles { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartments { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; set; } 

    //[InverseProperty("EmployeeCompany")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationEmployeeCompanies { get; set; } 

    //[InverseProperty("ModeCompany")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationModeCompanies { get; set; } 

    //[InverseProperty("EmployeeCompany")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveEmployeeCompanies { get; set; } 

    //[InverseProperty("ModeCompany")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveModeCompanies { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDays { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypes { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypes { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrPlan> HrPlans { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrWorkLocation> HrWorkLocations { get; set; } 

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ResCompany> InverseParent { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachments { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<IrDefault> IrDefaults { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<IrProperty> IrProperties { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<IrSequence> IrSequences { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchLocation> LunchLocations { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrders { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchProductCategory> LunchProductCategories { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchProduct> LunchProducts { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSuppliers { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchTopping> LunchToppings { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategories { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MaintenanceTeam> MaintenanceTeams { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivities { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNotes { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviders { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokens { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethods { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosPayment> PosPayments { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagings { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RecurringPayment> RecurringPayments { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResCurrencyRate> ResCurrencyRates { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeaves { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResourceCalendar> ResourceCalendars { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResources { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplates { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocations { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPackageLevel> StockPackageLevels { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPackageType> StockPackageTypes { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPickingType> StockPickingTypes { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRules { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockQuantPackage> StockQuantPackages { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockRoute> StockRoutes { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRules { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockStorageCategory> StockStorageCategories { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayers { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouses { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<UtmCampaign> UtmCampaigns { get; set; } 

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<Website> Websites { get; set; } 


    [ForeignKey("Cid")]
    //[InverseProperty("Cids")]
    [NotMapped]
    public virtual ICollection<ResUser> Users { get; set; } 
    */
}
