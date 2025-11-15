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

public partial class ResCompany
{

    [Column("social_discord")]
    public string? SocialDiscord { get; set; }

    // [JsonField(IsSparse = false)] // LunchNotifyMessage
    // [Column("lunch_notify_message", TypeName = "jsonb")]
    // public StringDictionary? LunchNotifyMessage { get; set; }

    [Column("account_purchase_receipt_fiscal_position_id")]
    public Guid? AccountPurchaseReceiptFiscalPositionId { get; set; }

    [Column("domestic_fiscal_position_id")]
    public Guid? DomesticFiscalPositionId { get; set; }

    [Column("income_account_id")]
    public Guid? IncomeAccountId { get; set; }

    [Column("expense_account_id")]
    public Guid? ExpenseAccountId { get; set; }

    [Column("price_difference_account_id")]
    public Guid? PriceDifferenceAccountId { get; set; }

    [Column("link_qr_code")]
    public bool? LinkQrCode { get; set; }

    [Column("restrictive_audit_trail")]
    public bool? RestrictiveAuditTrail { get; set; }

    [Column("stock_confirmation_type")]
    public string? StockConfirmationType { get; set; }

    [Column("stock_text_confirmation")]
    public bool? StockTextConfirmation { get; set; }

    [Column("horizon_days")]
    public double? HorizonDays { get; set; }

    [Column("attendance_device_tracking")]
    public bool? AttendanceDeviceTracking { get; set; }


    // [JsonField] // JobPropertiesDefinition
    // [Column("job_properties_definition", TypeName = "jsonb")]
    // public JsonElement? JobPropertiesDefinition { get; set; }

    [Column("account_stock_journal_id")]
    public Guid? AccountStockJournalId { get; set; }

    [Column("account_stock_valuation_id")]
    public Guid? AccountStockValuationId { get; set; }

    [Column("inventory_period")]
    public string? InventoryPeriod { get; set; }

    [Column("inventory_valuation")]
    public string? InventoryValuation { get; set; }

    [Column("cost_method")]
    public string? CostMethod { get; set; }


    [Column("downpayment_account_id")]
    public Guid? DownpaymentAccountId { get; set; }

    [Column("sms_provider")]
    public string? SmsProvider { get; set; }

    [Column("sms_twilio_account_sid")]
    public string? SmsTwilioAccountSid { get; set; }

    [Column("sms_twilio_auth_token")]
    public string? SmsTwilioAuthToken { get; set; }

    [Column("account_check_printing_layout")]
    public string? AccountCheckPrintingLayout { get; set; }

    [Column("account_check_printing_date_label")]
    public bool? AccountCheckPrintingDateLabel { get; set; }

    [Column("account_check_printing_multi_stub")]
    public bool? AccountCheckPrintingMultiStub { get; set; }

    [Column("account_check_printing_margin_top")]
    public double? AccountCheckPrintingMarginTop { get; set; }

    [Column("account_check_printing_margin_left")]
    public double? AccountCheckPrintingMarginLeft { get; set; }

    [Column("account_check_printing_margin_right")]
    public double? AccountCheckPrintingMarginRight { get; set; }

    [JsonField(IsSparse = false)] // PartnershipLabel
    [Column("partnership_label", TypeName = "jsonb")]
    public StringDictionary? PartnershipLabel { get; set; }

    [Column("withholding_tax_base_account_id")]
    public Guid? WithholdingTaxBaseAccountId { get; set; }

    [Column("peppol_self_billing_reception_journal_id")]
    public Guid? PeppolSelfBillingReceptionJournalId { get; set; }

    [Column("peppol_external_provider")]
    public string? PeppolExternalProvider { get; set; }

    [JsonField] // PeppolMetadata
    [Column("peppol_metadata", TypeName = "jsonb")]
    public JsonElement? PeppolMetadata { get; set; }

    [Column("peppol_activate_self_billing_sending")]
    public bool? PeppolActivateSelfBillingSending { get; set; }

    [Column("peppol_metadata_updated_at", TypeName = "timestamp without time zone")]
    public DateTime? PeppolMetadataUpdatedAt { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountPaymentRegisterWithholdingLine) is commented out
    // public virtual ICollection<AccountPaymentRegisterWithholdingLine> AccountPaymentRegisterWithholdingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountPaymentWithholdingLine) is commented out
    // public virtual ICollection<AccountPaymentWithholdingLine> AccountPaymentWithholdingLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountPurchaseReceiptFiscalPositionId")]
    public virtual AccountFiscalPosition? AccountPurchaseReceiptFiscalPosition { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountStockJournalId")]
    public virtual AccountJournal? AccountStockJournal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountStockValuationId")]
    public virtual AccountAccount? AccountStockValuation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DomesticFiscalPositionId")]
    public virtual AccountFiscalPosition? DomesticFiscalPosition { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DownpaymentAccountId")]
    public virtual AccountAccount? DownpaymentAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExpenseAccountId")]
    public virtual AccountAccount? ExpenseAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (FollowupFollowup) is commented out
    // public virtual ICollection<FollowupFollowup> FollowupFollowup { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrApplicant) is commented out
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrAttendanceOvertimeRuleset) is commented out
    // public virtual ICollection<HrAttendanceOvertimeRuleset> HrAttendanceOvertimeRuleset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrExpensePostWizard) is commented out
    // public virtual ICollection<HrExpensePostWizard> HrExpensePostWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrTalentPool) is commented out
    // public virtual ICollection<HrTalentPool> HrTalentPool { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrVersion) is commented out
    // public virtual ICollection<HrVersion> HrVersion { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("IncomeAccountId")]
    public virtual AccountAccount? IncomeAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (L10nLatamCheck) is commented out
    // public virtual ICollection<L10nLatamCheck> L10nLatamCheck { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (PeppolConfigWizard) is commented out
    // public virtual ICollection<PeppolConfigWizard> PeppolConfigWizard { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PeppolSelfBillingReceptionJournalId")]
    public virtual AccountJournal? PeppolSelfBillingReceptionJournal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PriceDifferenceAccountId")]
    public virtual AccountAccount? PriceDifferenceAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductUom) is commented out
    // public virtual ICollection<ProductUom> ProductUom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ProductValue) is commented out
    // public virtual ICollection<ProductValue> ProductValue { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (ResPartnerGrade) is commented out
    // public virtual ICollection<ResPartnerGrade> ResPartnerGrade { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("RecordCompanyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("RecordCompany")] // One2many // Peer relationship (SmsSms) is commented out
    // public virtual ICollection<SmsSms> SmsSms { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SmsTwilioAccountManage) is commented out
    // public virtual ICollection<SmsTwilioAccountManage> SmsTwilioAccountManage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SmsTwilioNumber) is commented out
    // public virtual ICollection<SmsTwilioNumber> SmsTwilioNumber { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (SnailmailLetter) is commented out
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockPackage) is commented out
    // public virtual ICollection<StockPackage> StockPackage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (StockPackageHistory) is commented out
    // public virtual ICollection<StockPackageHistory> StockPackageHistory { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WithholdingTaxBaseAccountId")]
    public virtual AccountAccount? WithholdingTaxBaseAccount { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCompanyId")] //Many2many // Hidden
    // [InverseProperty("ResCompany")] //Many2many // Hidden
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboard { get; set; }


}