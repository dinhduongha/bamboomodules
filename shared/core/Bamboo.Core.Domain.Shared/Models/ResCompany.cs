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
public partial class ResCompany: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("paperformat_id")]
    public long? PaperformatId { get; set; }

    [Column("external_report_layout_id")]
    public Guid? ExternalReportLayoutId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }    
    
    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("report_footer", TypeName = "jsonb")]
    public string? ReportFooter { get; set; }

    [Column("report_header")]
    public string? ReportHeader { get; set; }

    [Column("company_details")]
    public string? CompanyDetails { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("logo_web")]
    public byte[]? LogoWeb { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

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
    public long? AccountFiscalCountryId { get; set; }

    [Column("tax_cash_basis_journal_id")]
    public Guid? TaxCashBasisJournalId { get; set; }

    [Column("account_cash_basis_base_account_id")]
    public Guid? AccountCashBasisBaseAccountId { get; set; }

    [Column("fiscalyear_last_month")]
    public string? FiscalyearLastMonth { get; set; }

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

    [Column("period_lock_date")]
    public DateTime? PeriodLockDate { get; set; }

    [Column("fiscalyear_lock_date")]
    public DateTime? FiscalyearLockDate { get; set; }

    [Column("tax_lock_date")]
    public DateTime? TaxLockDate { get; set; }

    [Column("account_opening_date")]
    public DateTime? AccountOpeningDate { get; set; }

    [Column("invoice_terms", TypeName = "jsonb")]
    public string? InvoiceTerms { get; set; }

    [Column("invoice_terms_html", TypeName = "jsonb")]
    public string? InvoiceTermsHtml { get; set; }

    [Column("expects_chart_of_accounts")]
    public bool? ExpectsChartOfAccounts { get; set; }

    [Column("anglo_saxon_accounting")]
    public bool? AngloSaxonAccounting { get; set; }

    [Column("qr_code")]
    public bool? QrCode { get; set; }

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

    [Column("invoice_is_snailmail")]
    public bool? InvoiceIsSnailmail { get; set; }

    [Column("quotation_validity_days")]
    public long? QuotationValidityDays { get; set; }

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

    [Column("sale_order_template_id")]
    public Guid? SaleOrderTemplateId { get; set; }

    [Column("vat_check_vies")]
    public bool? VatCheckVies { get; set; }

    [Column("nomenclature_id")]
    public long? NomenclatureId { get; set; }

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

    [Column("stock_sms_confirmation_template_id")]
    public Guid? StockSmsConfirmationTemplateId { get; set; }

    [Column("stock_move_sms_validation")]
    public bool? StockMoveSmsValidation { get; set; }

    [Column("has_received_warning_stock_sms")]
    public bool? HasReceivedWarningStockSms { get; set; }

    [Column("point_of_sale_update_stock_quantities")]
    public string? PointOfSaleUpdateStockQuantities { get; set; }

    [Column("point_of_sale_use_ticket_qr_code")]
    public bool? PointOfSaleUseTicketQrCode { get; set; }

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

    [Column("expense_journal_id")]
    public Guid? ExpenseJournalId { get; set; }

    [Column("company_expense_journal_id")]
    public Guid? CompanyExpenseJournalId { get; set; }

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

    [Column("overtime_start_date")]
    public DateTime? OvertimeStartDate { get; set; }

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

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("website_sale_onboarding_payment_provider_state")]
    public string? WebsiteSaleOnboardingPaymentProviderState { get; set; }

    [Column("lunch_notify_message", TypeName = "jsonb")]
    public string? LunchNotifyMessage { get; set; }

    [Column("lunch_minimum_threshold")]
    public double? LunchMinimumThreshold { get; set; }

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

    [ForeignKey("ChartTemplateId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

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
    /// TODO: DISABLE INVERSE
    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; } = new List<AccountAccount>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizards { get; } = new List<AccountAccruedOrdersWizard>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalances { get; } = new List<AccountAgedTrialBalance>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; } = new List<AccountAnalyticAccount>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; } = new List<AccountAnalyticDistributionModel>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; } = new List<AccountAnalyticLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlans { get; } = new List<AccountAnalyticPlan>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; } = new List<AccountAssetAsset>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategories { get; } = new List<AccountAssetCategory>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizards { get; } = new List<AccountAutomaticEntryWizard>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReports { get; } = new List<AccountBalanceReport>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatements { get; } = new List<AccountBankStatement>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountBudgetPost> AccountBudgetPosts { get; } = new List<AccountBudgetPost>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; } = new List<AccountCommonAccountReport>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReports { get; } = new List<AccountCommonJournalReport>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReports { get; } = new List<AccountCommonPartnerReport>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountCommonReport> AccountCommonReports { get; } = new List<AccountCommonReport>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOps { get; } = new List<AccountFinancialYearOp>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccounts { get; } = new List<AccountFiscalPositionAccount>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxes { get; } = new List<AccountFiscalPositionTax>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositions { get; } = new List<AccountFiscalPosition>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountFiscalYear> AccountFiscalYears { get; } = new List<AccountFiscalYear>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountGroup> AccountGroups { get; } = new List<AccountGroup>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountJournalGroup> AccountJournalGroups { get; } = new List<AccountJournalGroup>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountMoveReversal> AccountMoveReversals { get; } = new List<AccountMoveReversal>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconciles { get; } = new List<AccountPartialReconcile>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; } = new List<AccountPaymentRegister>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTerm> AccountPaymentTerms { get; } = new List<AccountPaymentTerm>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountPrintJournal> AccountPrintJournals { get; } = new List<AccountPrintJournal>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLines { get; } = new List<AccountReconcileModelLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; } = new List<AccountReconcileModel>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplates { get; } = new List<AccountRecurringTemplate>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValues { get; } = new List<AccountReportExternalValue>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; } = new List<AccountReportGeneralLedger>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgers { get; } = new List<AccountReportPartnerLedger>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLines { get; } = new List<AccountTaxRepartitionLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizards { get; } = new List<AccountTaxReportWizard>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; } = new List<AccountTax>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<AccountingReport> AccountingReports { get; } = new List<AccountingReport>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<BaseDocumentLayout> BaseDocumentLayouts { get; } = new List<BaseDocumentLayout>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ChangeLockDate> ChangeLockDates { get; } = new List<ChangeLockDate>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeams { get; } = new List<CrmTeam>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudgetLine> CrossoveredBudgetLines { get; } = new List<CrossoveredBudgetLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgets { get; } = new List<CrossoveredBudget>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<DigestDigest> DigestDigests { get; } = new List<DigestDigest>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContracts { get; } = new List<FleetVehicleLogContract>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServices { get; } = new List<FleetVehicleLogService>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicles { get; } = new List<FleetVehicle>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; } = new List<HrApplicant>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; } = new List<HrContract>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartments { get; } = new List<HrDepartment>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; } = new List<HrExpenseSheet>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; } = new List<HrExpenseSplit>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; } = new List<HrExpense>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; } = new List<HrJob>();

    //[InverseProperty("EmployeeCompany")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationEmployeeCompanies { get; } = new List<HrLeaveAllocation>();

    //[InverseProperty("ModeCompany")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationModeCompanies { get; } = new List<HrLeaveAllocation>();

    //[InverseProperty("EmployeeCompany")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveEmployeeCompanies { get; } = new List<HrLeave>();

    //[InverseProperty("ModeCompany")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveModeCompanies { get; } = new List<HrLeave>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDays { get; } = new List<HrLeaveStressDay>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypes { get; } = new List<HrLeaveType>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypes { get; } = new List<HrPlanActivityType>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrPlan> HrPlans { get; } = new List<HrPlan>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<HrWorkLocation> HrWorkLocations { get; } = new List<HrWorkLocation>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ResCompany> InverseParent { get; } = new List<ResCompany>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachments { get; } = new List<IrAttachment>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<IrDefault> IrDefaults { get; } = new List<IrDefault>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<IrProperty> IrProperties { get; } = new List<IrProperty>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<IrSequence> IrSequences { get; } = new List<IrSequence>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchLocation> LunchLocations { get; } = new List<LunchLocation>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrders { get; } = new List<LunchOrder>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchProductCategory> LunchProductCategories { get; } = new List<LunchProductCategory>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchProduct> LunchProducts { get; } = new List<LunchProduct>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSuppliers { get; } = new List<LunchSupplier>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<LunchTopping> LunchToppings { get; } = new List<LunchTopping>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategories { get; } = new List<MaintenanceEquipmentCategory>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; } = new List<MaintenanceEquipment>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MaintenanceTeam> MaintenanceTeams { get; } = new List<MaintenanceTeam>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproducts { get; } = new List<MrpBomByproduct>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLines { get; } = new List<MrpBomLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; } = new List<MrpBom>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; } = new List<MrpProduction>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; } = new List<MrpUnbuild>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivities { get; } = new List<MrpWorkcenterProductivity>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; } = new List<MrpWorkcenter>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNotes { get; } = new List<NoteNote>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviders { get; } = new List<PaymentProvider>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokens { get; } = new List<PaymentToken>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; } = new List<PaymentTransaction>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; } = new List<PosConfig>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; } = new List<PosOrderLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; } = new List<PosOrder>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethods { get; } = new List<PosPaymentMethod>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PosPayment> PosPayments { get; } = new List<PosPayment>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagings { get; } = new List<ProductPackaging>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItems { get; } = new List<ProductPricelistItem>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; } = new List<ProductPricelist>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishes { get; } = new List<ProductReplenish>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; } = new List<ProductSupplierinfo>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; } = new List<ProductTemplate>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; } = new List<ProjectProject>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; } = new List<ProjectTask>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLines { get; } = new List<RecurringPaymentLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RecurringPayment> RecurringPayments { get; } = new List<RecurringPayment>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; } = new List<RepairFee>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; } = new List<RepairLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; } = new List<RepairOrder>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; } = new List<ResConfigSetting>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResCurrencyRate> ResCurrencyRates { get; } = new List<ResCurrencyRate>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; } = new List<ResPartnerBank>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; } = new List<ResUser>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeaves { get; } = new List<ResourceCalendarLeaf>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResourceCalendar> ResourceCalendars { get; } = new List<ResourceCalendar>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResources { get; } = new List<ResourceResource>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; } = new List<SaleAdvancePaymentInv>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLines { get; } = new List<SaleOrderTemplateLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; } = new List<SaleOrderTemplateOption>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplates { get; } = new List<SaleOrderTemplate>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; } = new List<SnailmailLetter>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocations { get; } = new List<StockLocation>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; } = new List<StockLot>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; } = new List<StockMoveLine>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPackageLevel> StockPackageLevels { get; } = new List<StockPackageLevel>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPackageType> StockPackageTypes { get; } = new List<StockPackageType>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPickingType> StockPickingTypes { get; } = new List<StockPickingType>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; } = new List<StockPicking>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRules { get; } = new List<StockPutawayRule>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockQuantPackage> StockQuantPackages { get; } = new List<StockQuantPackage>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; } = new List<StockQuant>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockRoute> StockRoutes { get; } = new List<StockRoute>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRules { get; } = new List<StockRule>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; } = new List<StockScrap>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockStorageCategory> StockStorageCategories { get; } = new List<StockStorageCategory>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; } = new List<StockValuationLayerRevaluation>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayers { get; } = new List<StockValuationLayer>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; } = new List<StockWarehouseOrderpoint>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouses { get; } = new List<StockWarehouse>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<UtmCampaign> UtmCampaigns { get; } = new List<UtmCampaign>();

    //[InverseProperty("Company")]
    [NotMapped]
    public virtual ICollection<Website> Websites { get; } = new List<Website>();

    [ForeignKey("ResCompanyId")]
    //[InverseProperty("ResCompanies")]
    [NotMapped]
    public virtual ICollection<IapAccount> IapAccounts { get; } = new List<IapAccount>();

    [ForeignKey("Cid")]
    //[InverseProperty("Cids")]
    [NotMapped]
    public virtual ICollection<ResUser> Users { get; } = new List<ResUser>();

}
