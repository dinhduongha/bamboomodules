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

[Table("res_company")]
//[Index("ParentId", Name = "res_company__parent_id_index")]
//[Index("ParentPath", Name = "res_company__parent_path_index")]
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

    [Column("font")]
    public string? Font { get; set; }

    [Column("primary_color")]
    public string? PrimaryColor { get; set; }

    [Column("secondary_color")]
    public string? SecondaryColor { get; set; }

    [Column("layout_background")]
    public string? LayoutBackground { get; set; }

    [JsonField] // ReportHeader
    [Column("report_header", TypeName = "jsonb")]
    public JsonElement? ReportHeader { get; set; }

    [JsonField] // ReportFooter
    [Column("report_footer", TypeName = "jsonb")]
    public JsonElement? ReportFooter { get; set; }

    [JsonField] // CompanyDetails
    [Column("company_details", TypeName = "jsonb")]
    public JsonElement? CompanyDetails { get; set; }

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

    [Column("payment_onboarding_payment_method")]
    public string? PaymentOnboardingPaymentMethod { get; set; }

    [Column("fiscalyear_last_day")]
    public long? FiscalyearLastDay { get; set; }

    [Column("transfer_account_id")]
    public Guid? TransferAccountId { get; set; }

    [Column("default_cash_difference_income_account_id")]
    public Guid? DefaultCashDifferenceIncomeAccountId { get; set; }

    [Column("default_cash_difference_expense_account_id")]
    public Guid? DefaultCashDifferenceExpenseAccountId { get; set; }

    [Column("account_journal_suspense_account_id")]
    public Guid? AccountJournalSuspenseAccountId { get; set; }

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

    [Column("transfer_account_code_prefix")]
    public string? TransferAccountCodePrefix { get; set; }

    [Column("tax_calculation_rounding_method")]
    public string? TaxCalculationRoundingMethod { get; set; }

    [Column("terms_type")]
    public string? TermsType { get; set; }

    [Column("quick_edit_mode")]
    public string? QuickEditMode { get; set; }

    [Column("account_price_include")]
    public string? AccountPriceInclude { get; set; }

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

    [JsonField] // InvoiceTerms
    [Column("invoice_terms", TypeName = "jsonb")]
    public JsonElement? InvoiceTerms { get; set; }

    [JsonField] // InvoiceTermsHtml
    [Column("invoice_terms_html", TypeName = "jsonb")]
    public JsonElement? InvoiceTermsHtml { get; set; }

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

    [Column("account_use_credit_limit")]
    public bool? AccountUseCreditLimit { get; set; }

    [Column("tax_exigibility")]
    public bool? TaxExigibility { get; set; }

    [Column("account_storno")]
    public bool? AccountStorno { get; set; }

    [Column("check_account_audit_trail")]
    public bool? CheckAccountAuditTrail { get; set; }

    [Column("autopost_bills")]
    public bool? AutopostBills { get; set; }

    [Column("quotation_validity_days")]
    public long? QuotationValidityDays { get; set; }

    [Column("sale_discount_product_id")]
    public Guid? SaleDiscountProductId { get; set; }

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

    [Column("hr_presence_control_email_amount")]
    public long? HrPresenceControlEmailAmount { get; set; }

    [Column("hr_presence_control_ip_list")]
    public string? HrPresenceControlIpList { get; set; }

    [JsonField] // EmployeePropertiesDefinition
    [Column("employee_properties_definition", TypeName = "jsonb")]
    public JsonElement? EmployeePropertiesDefinition { get; set; }

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

    [JsonField] // CandidatePropertiesDefinition
    [Column("candidate_properties_definition", TypeName = "jsonb")]
    public JsonElement? CandidatePropertiesDefinition { get; set; }

    [JsonField] // JobPropertiesDefinition
    [Column("job_properties_definition", TypeName = "jsonb")]
    public JsonElement? JobPropertiesDefinition { get; set; }

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

    [JsonField(IsSparse = false)] // LunchNotifyMessage
    [Column("lunch_notify_message", TypeName = "jsonb")]
    public StringDictionary? LunchNotifyMessage { get; set; }

    [Column("lunch_minimum_threshold")]
    public double? LunchMinimumThreshold { get; set; }

    [Column("manufacturing_lead")]
    public double? ManufacturingLead { get; set; }

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

    [Column("vat_check_vies")]
    public bool? VatCheckVies { get; set; }

    [Column("peppol_purchase_journal_id")]
    public Guid? PeppolPurchaseJournalId { get; set; }

    [Column("account_peppol_contact_email")]
    public string? AccountPeppolContactEmail { get; set; }

    [JsonIgnore]
    [Column("account_peppol_migration_key")]
    public string? AccountPeppolMigrationKey { get; set; }

    [Column("account_peppol_phone_number")]
    public string? AccountPeppolPhoneNumber { get; set; }

    [Column("account_peppol_proxy_state")]
    public string? AccountPeppolProxyState { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAccruedOrdersWizard) is commented out
    // public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAgedTrialBalance) is commented out
    // public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalance { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAnalyticAccount) is commented out
    // public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAnalyticApplicability) is commented out
    // public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicability { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAnalyticDistributionModel) is commented out
    // public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAnalyticLine) is commented out
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAssetAsset) is commented out
    // public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAssetCategory) is commented out
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAutomaticEntryWizard) is commented out
    // public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountBalanceReport) is commented out
    // public virtual ICollection<AccountBalanceReport> AccountBalanceReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountBankStatement) is commented out
    // public virtual ICollection<AccountBankStatement> AccountBankStatement { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountBankStatementLine) is commented out
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountBudgetPost) is commented out
    // public virtual ICollection<AccountBudgetPost> AccountBudgetPost { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountCashBasisBaseAccountId")]
    public virtual AccountAccount? AccountCashBasisBaseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountCommonAccountReport) is commented out
    // public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountCommonJournalReport) is commented out
    // public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountCommonPartnerReport) is commented out
    // public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountCommonReport) is commented out
    // public virtual ICollection<AccountCommonReport> AccountCommonReport { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountDefaultPosReceivableAccountId")]
    public virtual AccountAccount? AccountDefaultPosReceivableAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountDiscountExpenseAllocationId")]
    public virtual AccountAccount? AccountDiscountExpenseAllocation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountDiscountIncomeAllocationId")]
    public virtual AccountAccount? AccountDiscountIncomeAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountEdiProxyClientUser) is commented out
    // public virtual ICollection<AccountEdiProxyClientUser> AccountEdiProxyClientUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountFinancialYearOp) is commented out
    // public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOp { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountFiscalCountryId")]
    public virtual ResCountry? AccountFiscalCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountFiscalPosition) is commented out
    // public virtual ICollection<AccountFiscalPosition> AccountFiscalPosition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountFiscalPositionAccount) is commented out
    // public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountFiscalPositionTax) is commented out
    // public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountFiscalYear) is commented out
    // public virtual ICollection<AccountFiscalYear> AccountFiscalYear { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountGroup) is commented out
    // public virtual ICollection<AccountGroup> AccountGroup { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountJournal) is commented out
    // public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    public virtual AccountAccount? AccountJournalEarlyPayDiscountGainAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    public virtual AccountAccount? AccountJournalEarlyPayDiscountLossAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountJournalGroup) is commented out
    // public virtual ICollection<AccountJournalGroup> AccountJournalGroup { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountJournalSuspenseAccountId")]
    public virtual AccountAccount? AccountJournalSuspenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountLockException) is commented out
    // public virtual ICollection<AccountLockException> AccountLockException { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountMove) is commented out
    // public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountMoveLine) is commented out
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountMoveReversal) is commented out
    // public virtual ICollection<AccountMoveReversal> AccountMoveReversal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountOpeningMoveId")]
    public virtual AccountMove? AccountOpeningMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountPartialReconcile) is commented out
    // public virtual ICollection<AccountPartialReconcile> AccountPartialReconcile { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountPayment) is commented out
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountPaymentRegister) is commented out
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountPaymentTerm) is commented out
    // public virtual ICollection<AccountPaymentTerm> AccountPaymentTerm { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountPrintJournal) is commented out
    // public virtual ICollection<AccountPrintJournal> AccountPrintJournal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountProductionWipAccountId")]
    public virtual AccountAccount? AccountProductionWipAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountProductionWipOverheadAccountId")]
    public virtual AccountAccount? AccountProductionWipOverheadAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountPurchaseTaxId")]
    public virtual AccountTax? AccountPurchaseTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountReconcileModel) is commented out
    // public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountReconcileModelLine) is commented out
    // public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountRecurringTemplate) is commented out
    // public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountReportExternalValue) is commented out
    // public virtual ICollection<AccountReportExternalValue> AccountReportExternalValue { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountReportGeneralLedger) is commented out
    // public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedger { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountReportPartnerLedger) is commented out
    // public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedger { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountSaleTaxId")]
    public virtual AccountTax? AccountSaleTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountSecureEntriesWizard) is commented out
    // public virtual ICollection<AccountSecureEntriesWizard> AccountSecureEntriesWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountTax) is commented out
    // public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountTaxGroup) is commented out
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroup { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountTaxRepartitionLine) is commented out
    // public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountTaxReportWizard) is commented out
    // public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountUpdateTaxTagsWizard) is commented out
    // public virtual ICollection<AccountUpdateTaxTagsWizard> AccountUpdateTaxTagsWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountingReport) is commented out
    // public virtual ICollection<AccountingReport> AccountingReport { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AliasDomainId")]
    public virtual MailAliasDomain? AliasDomain { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AutomaticEntryDefaultJournalId")]
    public virtual AccountJournal? AutomaticEntryDefaultJournal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (BaseDocumentLayout) is commented out
    // public virtual ICollection<BaseDocumentLayout> BaseDocumentLayout { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BatchPaymentSequenceId")]
    public virtual IrSequence? BatchPaymentSequence { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (CertificateCertificate) is commented out
    // public virtual ICollection<CertificateCertificate> CertificateCertificate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (CertificateKey) is commented out
    // public virtual ICollection<CertificateKey> CertificateKey { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ChangeLockDate) is commented out
    // public virtual ICollection<ChangeLockDate> ChangeLockDate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (CrmLead) is commented out
    // public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (CrmTeam) is commented out
    // public virtual ICollection<CrmTeam> CrmTeam { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (CrossoveredBudget) is commented out
    // public virtual ICollection<CrossoveredBudget> CrossoveredBudget { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (CrossoveredBudgetLines) is commented out
    // public virtual ICollection<CrossoveredBudgetLines> CrossoveredBudgetLines { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyExchangeJournalId")]
    public virtual AccountJournal? CurrencyExchangeJournal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (DataRecycleRecord) is commented out
    // public virtual ICollection<DataRecycleRecord> DataRecycleRecord { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    public virtual AccountAccount? DefaultCashDifferenceExpenseAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    public virtual AccountAccount? DefaultCashDifferenceIncomeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (DeliveryCarrier) is commented out
    // public virtual ICollection<DeliveryCarrier> DeliveryCarrier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (DigestDigest) is commented out
    // public virtual ICollection<DigestDigest> DigestDigest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DropshipSubcontractorPickTypeId")]
    public virtual StockPickingType? DropshipSubcontractorPickType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (EventEvent) is commented out
    // public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (EventLeadRule) is commented out
    // public virtual ICollection<EventLeadRule> EventLeadRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (EventRegistration) is commented out
    // public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExpenseAccrualAccountId")]
    public virtual AccountAccount? ExpenseAccrualAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    public virtual AccountAccount? ExpenseCurrencyExchangeAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExpenseJournalId")]
    public virtual AccountJournal? ExpenseJournal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExpenseOutstandingAccountId")]
    public virtual AccountAccount? ExpenseOutstandingAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExternalReportLayoutId")]
    public virtual IrUiView? ExternalReportLayout { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (FleetVehicle) is commented out
    // public virtual ICollection<FleetVehicle> FleetVehicle { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (FleetVehicleLogContract) is commented out
    // public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (FleetVehicleLogServices) is commented out
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServices { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual FollowupFollowup? FollowupFollowup { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrApplicant) is commented out
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrCandidate) is commented out
    // public virtual ICollection<HrCandidate> HrCandidate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrContract) is commented out
    // public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrContributionRegister) is commented out
    // public virtual ICollection<HrContributionRegister> HrContributionRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrDepartment) is commented out
    // public virtual ICollection<HrDepartment> HrDepartment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrExpense) is commented out
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrExpenseSheet) is commented out
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrExpenseSplit) is commented out
    // public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrJob) is commented out
    // public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrLeaveAccrualPlan) is commented out
    // public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlan { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("EmployeeCompanyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("EmployeeCompany")] // One2many // Peer relationship (HrLeaveAllocation) is commented out
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrLeaveAllocationGenerateMultiWizard) is commented out
    // public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrLeave) is commented out
    // public virtual ICollection<HrLeave> HrLeaveCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("EmployeeCompanyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("EmployeeCompany")] // One2many // Peer relationship (HrLeave) is commented out
    // public virtual ICollection<HrLeave> HrLeaveEmployeeCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrLeaveGenerateMultiWizard) is commented out
    // public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrLeaveMandatoryDay) is commented out
    // public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDay { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrLeaveType) is commented out
    // public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrPayrollStructure) is commented out
    // public virtual ICollection<HrPayrollStructure> HrPayrollStructure { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrPayslip) is commented out
    // public virtual ICollection<HrPayslip> HrPayslip { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrPayslipLine) is commented out
    // public virtual ICollection<HrPayslipLine> HrPayslipLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrSalaryRule) is commented out
    // public virtual ICollection<HrSalaryRule> HrSalaryRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrSalaryRuleCategory) is commented out
    // public virtual ICollection<HrSalaryRuleCategory> HrSalaryRuleCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrWorkEntry) is commented out
    // public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrWorkLocation) is commented out
    // public virtual ICollection<HrWorkLocation> HrWorkLocation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("IncomeCurrencyExchangeAccountId")]
    public virtual AccountAccount? IncomeCurrencyExchangeAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("IncotermId")]
    public virtual AccountIncoterms? Incoterm { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("InternalProjectId")]
    public virtual ProjectProject? InternalProject { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("InternalTransitLocationId")]
    public virtual StockLocation? InternalTransitLocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Parent")] // One2many
    // public virtual ICollection<ResCompany> InverseParent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many
    // public virtual ICollection<IrAttachment> IrAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (IrDefault) is commented out
    // public virtual ICollection<IrDefault> IrDefault { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (IrSequence) is commented out
    // public virtual ICollection<IrSequence> IrSequence { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LcJournalId")]
    public virtual AccountJournal? LcJournal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LeaveTimesheetTaskId")]
    public virtual ProjectTask? LeaveTimesheetTask { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LoyaltyCard) is commented out
    // public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LoyaltyProgram) is commented out
    // public virtual ICollection<LoyaltyProgram> LoyaltyProgram { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LoyaltyReward) is commented out
    // public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LoyaltyRule) is commented out
    // public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LunchLocation) is commented out
    // public virtual ICollection<LunchLocation> LunchLocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LunchOrder) is commented out
    // public virtual ICollection<LunchOrder> LunchOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LunchProduct) is commented out
    // public virtual ICollection<LunchProduct> LunchProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LunchProductCategory) is commented out
    // public virtual ICollection<LunchProductCategory> LunchProductCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LunchSupplier) is commented out
    // public virtual ICollection<LunchSupplier> LunchSupplier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (LunchTopping) is commented out
    // public virtual ICollection<LunchTopping> LunchTopping { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MailActivityPlan) is commented out
    // public virtual ICollection<MailActivityPlan> MailActivityPlan { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("RecordCompanyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("RecordCompany")] // One2many // Peer relationship (MailComposeMessage) is commented out
    // public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("RecordCompanyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("RecordCompany")] // One2many // Peer relationship (MailMessage) is commented out
    // public virtual ICollection<MailMessage> MailMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MaintenanceEquipment) is commented out
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MaintenanceEquipmentCategory) is commented out
    // public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MaintenanceRequest) is commented out
    // public virtual ICollection<MaintenanceRequest> MaintenanceRequest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MaintenanceTeam) is commented out
    // public virtual ICollection<MaintenanceTeam> MaintenanceTeam { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MembershipMembershipLine) is commented out
    // public virtual ICollection<MembershipMembershipLine> MembershipMembershipLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MrpBom) is commented out
    // public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MrpBomByproduct) is commented out
    // public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MrpBomLine) is commented out
    // public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MrpProduction) is commented out
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MrpUnbuild) is commented out
    // public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MrpWorkcenter) is commented out
    // public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (MrpWorkcenterProductivity) is commented out
    // public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivity { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("NomenclatureId")]
    public virtual BarcodeNomenclature? Nomenclature { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (OnboardingProgress) is commented out
    // public virtual ICollection<OnboardingProgress> OnboardingProgress { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (OnboardingProgressStep) is commented out
    // public virtual ICollection<OnboardingProgressStep> OnboardingProgressStep { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaperformatId")]
    public virtual ReportPaperformat? Paperformat { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual ResCompany? Parent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PaymentProvider) is commented out
    // public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PaymentToken) is commented out
    // public virtual ICollection<PaymentToken> PaymentToken { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PaymentTransaction) is commented out
    // public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PeppolPurchaseJournalId")]
    public virtual AccountJournal? PeppolPurchaseJournal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PeppolRegistration) is commented out
    // public virtual ICollection<PeppolRegistration> PeppolRegistration { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PosConfig) is commented out
    // public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PosOrder) is commented out
    // public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PosOrderLine) is commented out
    // public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PosPayment) is commented out
    // public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PosPaymentMethod) is commented out
    // public virtual ICollection<PosPaymentMethod> PosPaymentMethod { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PosPrinter) is commented out
    // public virtual ICollection<PosPrinter> PosPrinter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductCombo) is commented out
    // public virtual ICollection<ProductCombo> ProductCombo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductComboItem) is commented out
    // public virtual ICollection<ProductComboItem> ProductComboItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductPackaging) is commented out
    // public virtual ICollection<ProductPackaging> ProductPackaging { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductPricelist) is commented out
    // public virtual ICollection<ProductPricelist> ProductPricelist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductPricelistItem) is commented out
    // public virtual ICollection<ProductPricelistItem> ProductPricelistItem { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductReplenish) is commented out
    // public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductSupplierinfo) is commented out
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductTemplate) is commented out
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProjectProject) is commented out
    // public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProjectProjectStage) is commented out
    // public virtual ICollection<ProjectProjectStage> ProjectProjectStage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProjectTask) is commented out
    // public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProjectTimeModeId")]
    public virtual UomUom? ProjectTimeMode { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PurchaseOrder) is commented out
    // public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PurchaseOrderLine) is commented out
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PurchaseRequisition) is commented out
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PurchaseRequisitionLine) is commented out
    // public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (RecurringPayment) is commented out
    // public virtual ICollection<RecurringPayment> RecurringPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (RecurringPaymentLine) is commented out
    // public virtual ICollection<RecurringPaymentLine> RecurringPaymentLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (RepairOrder) is commented out
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ResConfigSettings) is commented out
    // public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ResCurrencyRate) is commented out
    // public virtual ICollection<ResCurrencyRate> ResCurrencyRate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many
    // public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ResPartnerBank) is commented out
    // public virtual ICollection<ResPartnerBank> ResPartnerBank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many
    // public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResourceCalendarId")]
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ResourceCalendarLeaves) is commented out
    // public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeaves { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ResourceCalendar) is commented out
    // public virtual ICollection<ResourceCalendar> ResourceCalendarNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ResourceResource) is commented out
    // public virtual ICollection<ResourceResource> ResourceResource { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RevenueAccrualAccountId")]
    public virtual AccountAccount? RevenueAccrualAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SaleAdvancePaymentInv) is commented out
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleDiscountProductId")]
    public virtual ProductProduct? SaleDiscountProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SaleOrder) is commented out
    // public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SaleOrderLine) is commented out
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderTemplateId")]
    public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SaleOrderTemplateLine) is commented out
    // public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SaleOrderTemplate) is commented out
    // public virtual ICollection<SaleOrderTemplate> SaleOrderTemplateNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SaleOrderTemplateOption) is commented out
    // public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SnailmailLetter) is commented out
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SpreadsheetDashboard) is commented out
    // public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockLandedCost) is commented out
    // public virtual ICollection<StockLandedCost> StockLandedCost { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockLocation) is commented out
    // public virtual ICollection<StockLocation> StockLocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockLot) is commented out
    // public virtual ICollection<StockLot> StockLot { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StockMailConfirmationTemplateId")]
    public virtual MailTemplate? StockMailConfirmationTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockMove) is commented out
    // public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockMoveLine) is commented out
    // public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockPackageLevel) is commented out
    // public virtual ICollection<StockPackageLevel> StockPackageLevel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockPackageType) is commented out
    // public virtual ICollection<StockPackageType> StockPackageType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockPicking) is commented out
    // public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockPickingBatch) is commented out
    // public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockPickingType) is commented out
    // public virtual ICollection<StockPickingType> StockPickingType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockPutawayRule) is commented out
    // public virtual ICollection<StockPutawayRule> StockPutawayRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockQuant) is commented out
    // public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockQuantPackage) is commented out
    // public virtual ICollection<StockQuantPackage> StockQuantPackage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockRoute) is commented out
    // public virtual ICollection<StockRoute> StockRoute { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockRule) is commented out
    // public virtual ICollection<StockRule> StockRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockScrap) is commented out
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StockSmsConfirmationTemplateId")]
    public virtual SmsTemplate? StockSmsConfirmationTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockStorageCategory) is commented out
    // public virtual ICollection<StockStorageCategory> StockStorageCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockValuationLayer) is commented out
    // public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockValuationLayerRevaluation) is commented out
    // public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockWarehouse) is commented out
    // public virtual ICollection<StockWarehouse> StockWarehouse { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockWarehouseOrderpoint) is commented out
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SubcontractingLocationId")]
    public virtual StockLocation? SubcontractingLocation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TaxCashBasisJournalId")]
    public virtual AccountJournal? TaxCashBasisJournal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TimesheetEncodeUomId")]
    public virtual UomUom? TimesheetEncodeUom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TransferAccountId")]
    public virtual AccountAccount? TransferAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (UtmCampaign) is commented out
    // public virtual ICollection<UtmCampaign> UtmCampaign { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many
    // public virtual ICollection<Website> WebsiteNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    [NotMapped] //Many2many // Hidden // Peer relationship (AccountAccount) is commented out
    // [ForeignKey("ResCompanyId")] //Many2many // Hidden
    // [InverseProperty("ResCompany")] //Many2many // Hidden
    public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ResCompanyId")] // Many2many // Normal
    // [InverseProperty("ResCompany")] // Many2many // Normal
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCompanyId")] //Many2many // Hidden
    // [InverseProperty("ResCompany")] //Many2many // Hidden
    public virtual ICollection<IapAccount> IapAccount { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("Cid")] // Many2many // Normal
    // [InverseProperty("Cid")] // Many2many // Normal
    public virtual ICollection<ResUsers> User { get; set; }
}
