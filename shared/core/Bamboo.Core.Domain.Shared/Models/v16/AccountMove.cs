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

[Table("account_move")]
//[Index("CompanyId", Name = "account_move__company_id_index")]
//[Index("Date", Name = "account_move__date_index")]
//[Index("InvoiceDateDue", Name = "account_move__invoice_date_due_index")]
//[Index("InvoiceDate", Name = "account_move__invoice_date_index")]
//[Index("MoveType", Name = "account_move__move_type_index")]
//[Index("PartnerId", Name = "account_move__partner_id_index")]
//[Index("SecureSequenceNumber", Name = "account_move__secure_sequence_number_index")]
//[Index("JournalId", "State", "PaymentState", "MoveType", "Date", Name = "account_move_payment_idx")]
//[Index("JournalId", "SequencePrefix", "SequenceNumber", "Name", Name = "account_move_sequence_index", IsDescending = new[] { false, true, true, false })]
//[Index("JournalId", "Id", "SequencePrefix", Name = "account_move_sequence_index2", IsDescending = new[] { false, true, false })]
public partial class AccountMove: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence_number")]
    public long? SequenceNumber { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("origin_payment_id")]
    public Guid? OriginPaymentId { get; set; }

    [Column("payment_id")]
    public Guid? PaymentId { get; set; }

    [Column("statement_line_id")]
    public Guid? StatementLineId { get; set; }

    [Column("tax_cash_basis_rec_id")]
    public Guid? TaxCashBasisRecId { get; set; }

    [Column("tax_cash_basis_origin_move_id")]
    public Guid? TaxCashBasisOriginMoveId { get; set; }

    [Column("auto_post_origin_id")]
    public Guid? AutoPostOriginId { get; set; }

    [Column("secure_sequence_number")]
    public long? SecureSequenceNumber { get; set; }

    [Column("invoice_payment_term_id")]
    public Guid? InvoicePaymentTermId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("commercial_partner_id")]
    public Guid? CommercialPartnerId { get; set; }

    [Column("partner_shipping_id")]
    public Guid? PartnerShippingId { get; set; }

    [Column("partner_bank_id")]
    public Guid? PartnerBankId { get; set; }

    [Column("fiscal_position_id")]
    public Guid? FiscalPositionId { get; set; }

    [Column("preferred_payment_method_line_id")]
    public Guid? PreferredPaymentMethodLineId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("reversed_entry_id")]
    public Guid? ReversedEntryId { get; set; }

    [Column("invoice_user_id")]
    public Guid? InvoiceUserId { get; set; }

    [Column("invoice_incoterm_id")]
    public Guid? InvoiceIncotermId { get; set; }

    [Column("invoice_cash_rounding_id")]
    public Guid? InvoiceCashRoundingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("sequence_prefix")]
    public string? SequencePrefix { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("ref")]
    public string? Ref { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("move_type")]
    public string? MoveType { get; set; }

    [Column("auto_post")]
    public string? AutoPost { get; set; }

    [Column("inalterable_hash")]
    public string? InalterableHash { get; set; }

    [Column("payment_reference")]
    public string? PaymentReference { get; set; }

    [Column("qr_code_method")]
    public string? QrCodeMethod { get; set; }

    [Column("payment_state")]
    public string? PaymentState { get; set; }

    [Column("invoice_source_email")]
    public string? InvoiceSourceEmail { get; set; }

    [Column("invoice_partner_display_name")]
    public string? InvoicePartnerDisplayName { get; set; }

    [Column("invoice_origin")]
    public string? InvoiceOrigin { get; set; }

    [Column("incoterm_location")]
    public string? IncotermLocation { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("auto_post_until")]
    public DateTime? AutoPostUntil { get; set; }

    [Column("invoice_date")]
    public DateTime? InvoiceDate { get; set; }

    [Column("invoice_date_due")]
    public DateTime? InvoiceDateDue { get; set; }

    [Column("delivery_date")]
    public DateTime? DeliveryDate { get; set; }

    [JsonField]
    [Column("sending_data", TypeName = "jsonb")]
    public string? SendingData { get; set; }

    [Column("narration")]
    public string? Narration { get; set; }

    [Column("invoice_currency_rate")]
    public decimal? InvoiceCurrencyRate { get; set; }

    [Column("amount_untaxed")]
    public decimal? AmountUntaxed { get; set; }

    [Column("amount_tax")]
    public decimal? AmountTax { get; set; }

    [Column("amount_total")]
    public decimal? AmountTotal { get; set; }

    [Column("amount_residual")]
    public decimal? AmountResidual { get; set; }

    [Column("amount_untaxed_signed")]
    public decimal? AmountUntaxedSigned { get; set; }

    [Column("amount_untaxed_in_currency_signed")]
    public decimal? AmountUntaxedInCurrencySigned { get; set; }

    [Column("amount_tax_signed")]
    public decimal? AmountTaxSigned { get; set; }

    [Column("amount_total_signed")]
    public decimal? AmountTotalSigned { get; set; }

    [Column("amount_total_in_currency_signed")]
    public decimal? AmountTotalInCurrencySigned { get; set; }

    [Column("amount_residual_signed")]
    public decimal? AmountResidualSigned { get; set; }

    [Column("quick_edit_total_amount")]
    public decimal? QuickEditTotalAmount { get; set; }

    [Column("is_storno")]
    public bool? IsStorno { get; set; }

    [Column("always_tax_exigible")]
    public bool? AlwaysTaxExigible { get; set; }

    [Column("checked")]
    public bool? Checked { get; set; }

    [Column("to_check")]
    public bool? ToCheck { get; set; }

    [Column("posted_before")]
    public bool? PostedBefore { get; set; }

    [Column("made_sequence_gap")]
    public bool? MadeSequenceGap { get; set; }

    [Column("is_manually_modified")]
    public bool? IsManuallyModified { get; set; }

    [Column("is_move_sent")]
    public bool? IsMoveSent { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("l10n_vn_e_invoice_number")]
    public string? L10nVnEInvoiceNumber { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("stock_move_id")]
    public Guid? StockMoveId { get; set; }

    [Column("reversed_pos_order_id")]
    public Guid? ReversedPosOrderId { get; set; }

    [Column("expense_sheet_id")]
    public Guid? ExpenseSheetId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("edi_state")]
    public string? EdiState { get; set; }

    [Column("debit_origin_id")]
    public Guid? DebitOriginId { get; set; }

    [Column("peppol_message_uuid")]
    public string? PeppolMessageUuid { get; set; }

    [Column("peppol_move_state")]
    public string? PeppolMoveState { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TimesheetInvoiceId")]
    [InverseProperty("TimesheetInvoice")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many]
    [ForeignKey("InvoiceId")]
    [InverseProperty("Invoice")]
    public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<AccountAssetDepreciationLine> AccountAssetDepreciationLine { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<AccountEdiDocument> AccountEdiDocument { get; set; }

    // [One2many]
    [ForeignKey("ExchangeMoveId")]
    [InverseProperty("ExchangeMove")]
    public virtual ICollection<AccountFullReconcile> AccountFullReconcile { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizard { get; set; }

    // [One2many]
    [ForeignKey("ExchangeMoveId")]
    [InverseProperty("ExchangeMove")]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcile { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [Many2one]
    [ForeignKey("AutoPostOriginId")]
    // [InverseProperty("InverseAutoPostOrigin")] //Many2one
    public virtual AccountMove? AutoPostOrigin { get; set; }

    // [Many2one]
    [ForeignKey("CampaignId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [ForeignKey("CommercialPartnerId")]
    // [InverseProperty("AccountMoveCommercialPartner")] //Many2one
    public virtual ResPartner? CommercialPartner { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountMoveCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DebitOriginId")]
    // [InverseProperty("InverseDebitOrigin")] //Many2one
    public virtual AccountMove? DebitOrigin { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseSheetId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual HrExpenseSheet? ExpenseSheet { get; set; }

    // [Many2one]
    [ForeignKey("FiscalPositionId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountFiscalPosition? FiscalPosition { get; set; }

    // v16-Compat
    // [One2many]
    [NotMapped] // [One2many]
    [ForeignKey("AccountMoveId")]
    [InverseProperty("AccountMove")]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<HrPayslip> HrPayslip { get; set; }

    // [One2many]
    [ForeignKey("AutoPostOriginId")]
    [InverseProperty("AutoPostOrigin")]
    public virtual ICollection<AccountMove> InverseAutoPostOrigin { get; set; }

    // [One2many]
    [ForeignKey("DebitOriginId")]
    [InverseProperty("DebitOrigin")]
    public virtual ICollection<AccountMove> InverseDebitOrigin { get; set; }

    // [One2many]
    [ForeignKey("ReversedEntryId")]
    [InverseProperty("ReversedEntry")]
    public virtual ICollection<AccountMove> InverseReversedEntry { get; set; }

    // [One2many]
    [ForeignKey("TaxCashBasisOriginMoveId")]
    [InverseProperty("TaxCashBasisOriginMove")]
    public virtual ICollection<AccountMove> InverseTaxCashBasisOriginMove { get; set; }

    // [Many2one]
    [ForeignKey("InvoiceCashRoundingId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountCashRounding? InvoiceCashRounding { get; set; }

    // [Many2one]
    [ForeignKey("InvoiceIncotermId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountIncoterms? InvoiceIncoterm { get; set; }

    // [Many2one]
    [ForeignKey("InvoicePaymentTermId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountPaymentTerm? InvoicePaymentTerm { get; set; }

    // [Many2one]
    [ForeignKey("InvoiceUserId")]
    // [InverseProperty("AccountMoveInvoiceUser")] //Many2one
    public virtual ResUsers? InvoiceUser { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("MediumId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual UtmMedium? Medium { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("OriginPaymentId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountPayment? OriginPayment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("AccountMovePartner")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PartnerBankId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual ResPartnerBank? PartnerBank { get; set; }

    // [Many2one]
    [ForeignKey("PartnerShippingId")]
    // [InverseProperty("AccountMovePartnerShipping")] //Many2one
    public virtual ResPartner? PartnerShipping { get; set; }

    // v16-Compat
    // [Many2one]
    [ForeignKey("PaymentId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountPayment? Payment { get; set; }

    // [One2many]
    [ForeignKey("AccountMove")]
    [InverseProperty("AccountMove1")]
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // v16-Compat
    // [One2many]
    // [ForeignKey("AccountMove")]
    // [InverseProperty("AccountMoveNavigation")]
    // public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [ForeignKey("AccountMoveId")]
    [InverseProperty("AccountMove")]
    public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [One2many]
    [ForeignKey("MoveId")]
    [InverseProperty("Move")]
    public virtual ICollection<PosSession> PosSession { get; set; }

    // [One2many]
    [ForeignKey("InvoiceId")]
    [InverseProperty("Invoice")]
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [Many2one]
    [ForeignKey("PreferredPaymentMethodLineId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountPaymentMethodLine? PreferredPaymentMethodLine { get; set; }

    // [One2many]
    [ForeignKey("AccountOpeningMoveId")]
    [InverseProperty("AccountOpeningMove")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [ForeignKey("ReversedEntryId")]
    // [InverseProperty("InverseReversedEntry")] //Many2one
    public virtual AccountMove? ReversedEntry { get; set; }

    // [Many2one]
    [ForeignKey("ReversedPosOrderId")]
    // [InverseProperty("AccountMoveNavigation")] //Many2one
    public virtual PosOrder? ReversedPosOrder { get; set; }

    // [Many2one]
    [ForeignKey("SourceId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual UtmSource? Source { get; set; }

    // [Many2one]
    [ForeignKey("StatementLineId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountBankStatementLine? StatementLine { get; set; }

    // [One2many]
    [ForeignKey("AccountMoveId")]
    [InverseProperty("AccountMove")]
    public virtual ICollection<StockLandedCost> StockLandedCostAccountMove { get; set; }

    // [One2many]
    [ForeignKey("VendorBillId")]
    [InverseProperty("VendorBill")]
    public virtual ICollection<StockLandedCost> StockLandedCostVendorBill { get; set; }

    // [Many2one]
    [ForeignKey("StockMoveId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual StockMove? StockMove { get; set; }

    // [One2many]
    [ForeignKey("AccountMoveId")]
    [InverseProperty("AccountMove")]
    public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [Many2one]
    [ForeignKey("TaxCashBasisOriginMoveId")]
    // [InverseProperty("InverseTaxCashBasisOriginMove")] //Many2one
    public virtual AccountMove? TaxCashBasisOriginMove { get; set; }

    // [Many2one]
    [ForeignKey("TaxCashBasisRecId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual AccountPartialReconcile? TaxCashBasisRec { get; set; }

    // [Many2one]
    [ForeignKey("TeamId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual CrmTeam? Team { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("AccountMove")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountMoveWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountMoveId")]
    // [InverseProperty("AccountMove")]
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSend { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountMoveId")]
    // [InverseProperty("AccountMove")]
    public virtual ICollection<AccountMoveSendBatchWizard> AccountMoveSendBatchWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountMoveId")]
    // [InverseProperty("AccountMove")]
    public virtual ICollection<AccountResequenceWizard> AccountResequenceWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MoveId")]
    // [InverseProperty("Move")]
    public virtual ICollection<AccountDebitNote> Debit { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountMoveId")] //Many2many
    // [InverseProperty("AccountMove")] //Many2many
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("RefundAccountMove")] //Many2many
    // [InverseProperty("RefundAccountMove")] //Many2many
    public virtual ICollection<AccountMove> OriginalAccountMove { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("InvoiceId")] //Many2many
    // [InverseProperty("Invoice")] //Many2many
    public virtual ICollection<AccountPayment> Payments { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountMoveId")]
    // [InverseProperty("AccountMove")]
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("OriginalAccountMove")] //Many2many
    // [InverseProperty("OriginalAccountMove")] //Many2many
    public virtual ICollection<AccountMove> RefundAccountMove { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MoveId")]
    // [InverseProperty("Move")]
    public virtual ICollection<AccountMoveReversal> Reversal { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("NewMoveId")]
    // [InverseProperty("NewMove")]
    public virtual ICollection<AccountMoveReversal> ReversalNavigation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("InvoiceId")] //Many2many
    // [InverseProperty("Invoice")] //Many2many
    public virtual ICollection<PaymentTransaction> Transaction { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountMoveId")]
    // [InverseProperty("AccountMove")]
    public virtual ICollection<ValidateAccountMove> ValidateAccountMove { get; set; }
}
