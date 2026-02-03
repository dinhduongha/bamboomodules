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

// Tenant -> Branch -> Organization -> Warehouse -> Location
// Tenant: ResCompany có hệ thống Warehouse / Stock / Chart of Accounting riêng. Trường ParentId null.
// Branch: ResCompany có hệ thống Warehouse / Stock / Chart of Accounting riêng. Trường ParentId khác null.
// Organization: ResOrganization có hệ thống Warehouse / Stock Location riêng, nhưng dùng chung chart of Accounting với Tenant/Branch.
// Map từ AbpOrganizationUnit
[Table("res_organization")]
//[Index("CompanyId", Name = "res_organization__company_id_index")]
//[Index("ParentId", Name = "res_organization__parent_id_index")]
//[Index("ParentPath", Name = "res_organization__parent_path_index")]
//[Index("CompleteName", Name = "res_organization__complete_name_index")]
//[Index("IsPublished", Name = "res_organization__is_published_index")]
//[Index("Name", Name = "res_organization__name_index")]
//[Index("WebsiteId", Name = "res_organization__website_id_index")]
//[Index("Sequence", Name = "res_organization__sequence_index")]
public partial class ResOrganization : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("origin_organization_unit_id")]
    public Guid? OriginOrganizationUnitId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; } // Quản lý khu vực

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("target_sales_amount")]
    public decimal? TargetSalesAmount { get; set; }

    [Column("target_team_count")]
    public int? TargetTeamCount { get; set; }

    [Column("region_type")]
    public string RegionType { get; set; } = "area"; // area, region, province, city...

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("description")]
    public string? Description { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

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
    [Column("organization_details", TypeName = "jsonb")]
    public JsonElement? OrganizationDetails { get; set; }

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

    [Column("snailmail_color")]
    public bool? SnailmailColor { get; set; }

    [Column("snailmail_cover")]
    public bool? SnailmailCover { get; set; }

    [Column("snailmail_duplex")]
    public bool? SnailmailDuplex { get; set; }

    [Column("payment_onboarding_payment_method")]
    public string? PaymentOnboardingPaymentMethod { get; set; }

    [Column("transfer_account_id")]
    public Guid? TransferAccountId { get; set; }

    // [Column("default_cash_difference_income_account_id")]
    // public Guid? DefaultCashDifferenceIncomeAccountId { get; set; }

    // [Column("default_cash_difference_expense_account_id")]
    // public Guid? DefaultCashDifferenceExpenseAccountId { get; set; }

    // [Column("account_journal_suspense_account_id")]
    // public Guid? AccountJournalSuspenseAccountId { get; set; }

    // [Column("account_journal_early_pay_discount_gain_account_id")]
    // public Guid? AccountJournalEarlyPayDiscountGainAccountId { get; set; }

    // [Column("account_journal_early_pay_discount_loss_account_id")]
    // public Guid? AccountJournalEarlyPayDiscountLossAccountId { get; set; }

    // [Column("account_sale_tax_id")]
    // public Guid? AccountSaleTaxId { get; set; }

    // [Column("account_purchase_tax_id")]
    // public Guid? AccountPurchaseTaxId { get; set; }

    // [Column("currency_exchange_journal_id")]
    // public Guid? CurrencyExchangeJournalId { get; set; }

    // [Column("income_currency_exchange_account_id")]
    // public Guid? IncomeCurrencyExchangeAccountId { get; set; }

    // [Column("expense_currency_exchange_account_id")]
    // public Guid? ExpenseCurrencyExchangeAccountId { get; set; }

    [Column("incoterm_id")]
    public Guid? IncotermId { get; set; }

    // [Column("batch_payment_sequence_id")]
    // public Guid? BatchPaymentSequenceId { get; set; }

    // [Column("account_opening_move_id")]
    // public Guid? AccountOpeningMoveId { get; set; }

    // [Column("account_default_pos_receivable_account_id")]
    // public Guid? AccountDefaultPosReceivableAccountId { get; set; }

    // [Column("expense_accrual_account_id")]
    // public Guid? ExpenseAccrualAccountId { get; set; }

    // [Column("revenue_accrual_account_id")]
    // public Guid? RevenueAccrualAccountId { get; set; }

    // [Column("automatic_entry_default_journal_id")]
    // public Guid? AutomaticEntryDefaultJournalId { get; set; }

    // [Column("account_fiscal_country_id")]
    // public Guid? AccountFiscalCountryId { get; set; }

    // [Column("tax_cash_basis_journal_id")]
    // public Guid? TaxCashBasisJournalId { get; set; }

    // [Column("account_cash_basis_base_account_id")]
    // public Guid? AccountCashBasisBaseAccountId { get; set; }

    // [Column("account_discount_income_allocation_id")]
    // public Guid? AccountDiscountIncomeAllocationId { get; set; }

    // [Column("account_discount_expense_allocation_id")]
    // public Guid? AccountDiscountExpenseAllocationId { get; set; }

    // [Column("fiscalyear_last_month")]
    // public string? FiscalyearLastMonth { get; set; }

    [Column("chart_template")]
    public string? ChartTemplate { get; set; }

    [Column("bank_account_code_prefix")]
    public string? BankAccountCodePrefix { get; set; }

    [Column("cash_account_code_prefix")]
    public string? CashAccountCodePrefix { get; set; }

    [Column("transfer_account_code_prefix")]
    public string? TransferAccountCodePrefix { get; set; }

    // [Column("tax_calculation_rounding_method")]
    // public string? TaxCalculationRoundingMethod { get; set; }

    [Column("terms_type")]
    public string? TermsType { get; set; }

    [Column("quick_edit_mode")]
    public string? QuickEditMode { get; set; }

    // [Column("account_price_include")]
    // public string? AccountPriceInclude { get; set; }

    // [Column("fiscalyear_lock_date")]
    // public DateTime? FiscalyearLockDate { get; set; }

    // [Column("tax_lock_date")]
    // public DateTime? TaxLockDate { get; set; }

    // [Column("sale_lock_date")]
    // public DateTime? SaleLockDate { get; set; }

    // [Column("purchase_lock_date")]
    // public DateTime? PurchaseLockDate { get; set; }

    // [Column("hard_lock_date")]
    // public DateTime? HardLockDate { get; set; }

    // [Column("account_opening_date")]
    // public DateTime? AccountOpeningDate { get; set; }

    // [JsonField] // InvoiceTerms
    // [Column("invoice_terms", TypeName = "jsonb")]
    // public JsonElement? InvoiceTerms { get; set; }

    // [JsonField] // InvoiceTermsHtml
    // [Column("invoice_terms_html", TypeName = "jsonb")]
    // public JsonElement? InvoiceTermsHtml { get; set; }

    // [Column("expects_chart_of_accounts")]
    // public bool? ExpectsChartOfAccounts { get; set; }

    // [Column("anglo_saxon_accounting")]
    // public bool? AngloSaxonAccounting { get; set; }

    [Column("qr_code")]
    public bool? QrCode { get; set; }

    // [Column("display_invoice_amount_total_words")]
    // public bool? DisplayInvoiceAmountTotalWords { get; set; }

    // [Column("display_invoice_tax_company_currency")]
    // public bool? DisplayInvoiceTaxCompanyCurrency { get; set; }

    // [Column("account_use_credit_limit")]
    // public bool? AccountUseCreditLimit { get; set; }

    // [Column("tax_exigibility")]
    // public bool? TaxExigibility { get; set; }

    // [Column("account_storno")]
    // public bool? AccountStorno { get; set; }

    // [Column("check_account_audit_trail")]
    // public bool? CheckAccountAuditTrail { get; set; }

    // [Column("autopost_bills")]
    // public bool? AutopostBills { get; set; }

    // [Column("quotation_validity_days")]
    // public long? QuotationValidityDays { get; set; }

    // [Column("sale_discount_product_id")]
    // public Guid? SaleDiscountProductId { get; set; }

    // [Column("sale_onboarding_payment_method")]
    // public string? SaleOnboardingPaymentMethod { get; set; }

    // [Column("portal_confirmation_sign")]
    // public bool? PortalConfirmationSign { get; set; }

    // [Column("portal_confirmation_pay")]
    // public bool? PortalConfirmationPay { get; set; }

    // [Column("prepayment_percent")]
    // public double? PrepaymentPercent { get; set; }

    // [Column("sale_order_template_id")]
    // public Guid? SaleOrderTemplateId { get; set; }

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

    // [Column("hr_presence_control_email_amount")]
    // public long? HrPresenceControlEmailAmount { get; set; }

    // [Column("hr_presence_control_ip_list")]
    // public string? HrPresenceControlIpList { get; set; }

    // [JsonField] // EmployeePropertiesDefinition
    // [Column("employee_properties_definition", TypeName = "jsonb")]
    // public JsonElement? EmployeePropertiesDefinition { get; set; }

    // [Column("hr_presence_control_login")]
    // public bool? HrPresenceControlLogin { get; set; }

    // [Column("hr_presence_control_email")]
    // public bool? HrPresenceControlEmail { get; set; }

    // [Column("hr_presence_control_ip")]
    // public bool? HrPresenceControlIp { get; set; }

    // [Column("hr_presence_control_attendance")]
    // public bool? HrPresenceControlAttendance { get; set; }

    // [Column("contract_expiration_notice_period")]
    // public long? ContractExpirationNoticePeriod { get; set; }

    // [Column("work_permit_expiration_notice_period")]
    // public long? WorkPermitExpirationNoticePeriod { get; set; }

    // [JsonField] // CandidatePropertiesDefinition
    // [Column("candidate_properties_definition", TypeName = "jsonb")]
    // public JsonElement? CandidatePropertiesDefinition { get; set; }

    // [JsonField] // JobPropertiesDefinition
    // [Column("job_properties_definition", TypeName = "jsonb")]
    // public JsonElement? JobPropertiesDefinition { get; set; }

    // [Column("overtime_company_threshold")]
    // public long? OvertimeCompanyThreshold { get; set; }

    // [Column("overtime_employee_threshold")]
    // public long? OvertimeEmployeeThreshold { get; set; }

    // [Column("attendance_kiosk_delay")]
    // public long? AttendanceKioskDelay { get; set; }

    // [Column("attendance_kiosk_mode")]
    // public string? AttendanceKioskMode { get; set; }

    // [Column("attendance_barcode_source")]
    // public string? AttendanceBarcodeSource { get; set; }

    // [Column("attendance_kiosk_key")]
    // public string? AttendanceKioskKey { get; set; }

    // [Column("attendance_overtime_validation")]
    // public string? AttendanceOvertimeValidation { get; set; }

    // [Column("hr_attendance_display_overtime")]
    // public bool? HrAttendanceDisplayOvertime { get; set; }

    // [Column("attendance_kiosk_use_pin")]
    // public bool? AttendanceKioskUsePin { get; set; }

    // [Column("attendance_from_systray")]
    // public bool? AttendanceFromSystray { get; set; }

    // [Column("auto_check_out")]
    // public bool? AutoCheckOut { get; set; }

    // [Column("absence_management")]
    // public bool? AbsenceManagement { get; set; }

    // [Column("auto_check_out_tolerance")]
    // public double? AutoCheckOutTolerance { get; set; }

    // [Column("expense_journal_id")]
    // public Guid? ExpenseJournalId { get; set; }

    // [Column("expense_outstanding_account_id")]
    // public Guid? ExpenseOutstandingAccountId { get; set; }

    // [JsonField(IsSparse = false)] // LunchNotifyMessage
    // [Column("lunch_notify_message", TypeName = "jsonb")]
    // public StringDictionary? LunchNotifyMessage { get; set; }

    // [Column("lunch_minimum_threshold")]
    // public double? LunchMinimumThreshold { get; set; }

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

    // [Column("lc_journal_id")]
    // public Guid? LcJournalId { get; set; }

    // [Column("subcontracting_location_id")]
    // public Guid? SubcontractingLocationId { get; set; }

    // [Column("project_time_mode_id")]
    // public Guid? ProjectTimeModeId { get; set; }

    // [Column("timesheet_encode_uom_id")]
    // public Guid? TimesheetEncodeUomId { get; set; }

    // [Column("internal_project_id")]
    // public Guid? InternalProjectId { get; set; }

    // [Column("leave_timesheet_task_id")]
    // public Guid? LeaveTimesheetTaskId { get; set; }

    // [Column("hr_presence_last_compute_date", TypeName = "timestamp without time zone")]
    // public DateTime? HrPresenceLastComputeDate { get; set; }

    // [Column("dropship_subcontractor_pick_type_id")]
    // public Guid? DropshipSubcontractorPickTypeId { get; set; }

    // [Column("vat_check_vies")]
    // public bool? VatCheckVies { get; set; }

    // [Column("peppol_purchase_journal_id")]
    // public Guid? PeppolPurchaseJournalId { get; set; }

    // [Column("account_peppol_contact_email")]
    // public string? AccountPeppolContactEmail { get; set; }

    // [JsonIgnore]
    // [Column("account_peppol_migration_key")]
    // public string? AccountPeppolMigrationKey { get; set; }

    // [Column("account_peppol_phone_number")]
    // public string? AccountPeppolPhoneNumber { get; set; }

    // [Column("account_peppol_proxy_state")]
    // public string? AccountPeppolProxyState { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }


    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountCashBasisBaseAccountId")]
    // public virtual AccountAccount? AccountCashBasisBaseAccount { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountDefaultPosReceivableAccountId")]
    // public virtual AccountAccount? AccountDefaultPosReceivableAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountDiscountExpenseAllocationId")]
    // public virtual AccountAccount? AccountDiscountExpenseAllocation { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountDiscountIncomeAllocationId")]
    // public virtual AccountAccount? AccountDiscountIncomeAllocation { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountFiscalCountryId")]
    // public virtual ResCountry? AccountFiscalCountry { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountJournalEarlyPayDiscountGainAccountId")]
    // public virtual AccountAccount? AccountJournalEarlyPayDiscountGainAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountJournalEarlyPayDiscountLossAccountId")]
    // public virtual AccountAccount? AccountJournalEarlyPayDiscountLossAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountJournalSuspenseAccountId")]
    // public virtual AccountAccount? AccountJournalSuspenseAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountOpeningMoveId")]
    // public virtual AccountMove? AccountOpeningMove { get; set; }


    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountProductionWipAccountId")]
    // public virtual AccountAccount? AccountProductionWipAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountProductionWipOverheadAccountId")]
    // public virtual AccountAccount? AccountProductionWipOverheadAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountPurchaseTaxId")]
    // public virtual AccountTax? AccountPurchaseTax { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AccountSaleTaxId")]
    // public virtual AccountTax? AccountSaleTax { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AliasDomainId")]
    // public virtual MailAliasDomain? AliasDomain { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("AutomaticEntryDefaultJournalId")]
    // public virtual AccountJournal? AutomaticEntryDefaultJournal { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("BatchPaymentSequenceId")]
    // public virtual IrSequence? BatchPaymentSequence { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("CurrencyId")]
    // public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("CurrencyExchangeJournalId")]
    // public virtual AccountJournal? CurrencyExchangeJournal { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("DefaultCashDifferenceExpenseAccountId")]
    // public virtual AccountAccount? DefaultCashDifferenceExpenseAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("DefaultCashDifferenceIncomeAccountId")]
    // public virtual AccountAccount? DefaultCashDifferenceIncomeAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("DropshipSubcontractorPickTypeId")]
    // public virtual StockPickingType? DropshipSubcontractorPickType { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("ExpenseAccrualAccountId")]
    // public virtual AccountAccount? ExpenseAccrualAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("ExpenseCurrencyExchangeAccountId")]
    // public virtual AccountAccount? ExpenseCurrencyExchangeAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("ExpenseJournalId")]
    // public virtual AccountJournal? ExpenseJournal { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("ExpenseOutstandingAccountId")]
    // public virtual AccountAccount? ExpenseOutstandingAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("ExternalReportLayoutId")]
    // public virtual IrUiView? ExternalReportLayout { get; set; }


    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // public virtual FollowupFollowup? FollowupFollowup { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("IncomeCurrencyExchangeAccountId")]
    // public virtual AccountAccount? IncomeCurrencyExchangeAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("IncotermId")]
    // public virtual AccountIncoterms? Incoterm { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("InternalProjectId")]
    // public virtual ProjectProject? InternalProject { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("InternalTransitLocationId")]
    // public virtual StockLocation? InternalTransitLocation { get; set; }


    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("LcJournalId")]
    // public virtual AccountJournal? LcJournal { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("LeaveTimesheetTaskId")]
    // public virtual ProjectTask? LeaveTimesheetTask { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("NomenclatureId")]
    // public virtual BarcodeNomenclature? Nomenclature { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaperformatId")]
    public virtual ReportPaperformat? Paperformat { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual ResOrganization? Parent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("PeppolPurchaseJournalId")]
    // public virtual AccountJournal? PeppolPurchaseJournal { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("ProjectTimeModeId")]
    // public virtual UomUom? ProjectTimeMode { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("ResourceCalendarId")]
    // public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("RevenueAccrualAccountId")]
    // public virtual AccountAccount? RevenueAccrualAccount { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("SaleDiscountProductId")]
    // public virtual ProductProduct? SaleDiscountProduct { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("SaleOrderTemplateId")]
    // public virtual SaleOrderTemplate? SaleOrderTemplate { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("StockMailConfirmationTemplateId")]
    // public virtual MailTemplate? StockMailConfirmationTemplate { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("StockSmsConfirmationTemplateId")]
    // public virtual SmsTemplate? StockSmsConfirmationTemplate { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("SubcontractingLocationId")]
    // public virtual StockLocation? SubcontractingLocation { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("TaxCashBasisJournalId")]
    // public virtual AccountJournal? TaxCashBasisJournal { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("TimesheetEncodeUomId")]
    // public virtual UomUom? TimesheetEncodeUom { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("TransferAccountId")]
    // public virtual AccountAccount? TransferAccount { get; set; }

    // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("WebsiteId")]
    // public virtual Website? Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    // [NotMapped] //Many2many // Hidden // Peer relationship (AccountAccount) is commented out
    // // [ForeignKey("ResCompanyId")] //Many2many // Hidden
    // // [InverseProperty("ResCompany")] //Many2many // Hidden
    // public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [NotMapped] // Many2many // Normal
    // // [ForeignKey("ResCompanyId")] // Many2many // Normal
    // // [InverseProperty("ResCompany")] // Many2many // Normal
    // public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLine { get; set; }

    // // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // // [ForeignKey("Cid")] // Many2many // Normal
    // // [InverseProperty("Cid")] // Many2many // Normal
    // public virtual ICollection<ResUsers> User { get; set; }

    // Navigation
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("ParentId")]
    // public virtual ResOrganization? ParentOrganization { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ManagerId")]
    public virtual ResUsers? Manager { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual ICollection<ResOrganization> Children { get; set; } = new List<ResOrganization>();

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual ICollection<ResTeam> Teams { get; set; } = new List<ResTeam>();
}
