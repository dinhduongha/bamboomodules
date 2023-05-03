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

[Table("account_move_line")]
//[Index("AccountId", Name = "account_move_line_account_id_index")]
//[Index("TenantId", Name = "account_move_line_company_id_index")]
//[Index("DateMaturity", Name = "account_move_line_date_maturity_index")]
//[Index("Date", "MoveName", "Id", Name = "account_move_line_date_name_id_idx", IsDescending = new[] { true, true, false })]
//[Index("JournalId", Name = "account_move_line_journal_id_index")]
//[Index("MoveId", Name = "account_move_line_move_id_index")]
//[Index("MoveName", Name = "account_move_line_move_name_index")]
//[Index("PartnerId", "Ref", Name = "account_move_line_partner_id_ref_idx")]
public partial class AccountMoveLine: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("company_currency_id")]
    public long? CompanyCurrencyId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("reconcile_model_id")]
    public Guid? ReconcileModelId { get; set; }

    [Column("payment_id")]
    public Guid? PaymentId { get; set; }

    [Column("statement_line_id")]
    public Guid? StatementLineId { get; set; }

    [Column("statement_id")]
    public Guid? StatementId { get; set; }

    [Column("group_tax_id")]
    public Guid? GroupTaxId { get; set; }

    [Column("tax_line_id")]
    public Guid? TaxLineId { get; set; }

    [Column("tax_group_id")]
    public Guid? TaxGroupId { get; set; }

    [Column("tax_repartition_line_id")]
    public Guid? TaxRepartitionLineId { get; set; }

    [Column("full_reconcile_id")]
    public Guid? FullReconcileId { get; set; }

    [Column("account_root_id")]
    public Guid? AccountRootId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("move_name")]
    public string? MoveName { get; set; }

    [Column("parent_state")]
    public string? ParentState { get; set; }

    [Column("ref")]
    public string? Ref { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("tax_audit")]
    public string? TaxAudit { get; set; }

    [Column("matching_number")]
    public string? MatchingNumber { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("date_maturity")]
    public DateTime? DateMaturity { get; set; }

    [Column("discount_date")]
    public DateTime? DiscountDate { get; set; }

    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    [Column("debit")]
    public decimal? Debit { get; set; }

    [Column("credit")]
    public decimal? Credit { get; set; }

    [Column("balance")]
    public decimal? Balance { get; set; }

    [Column("amount_currency")]
    public decimal? AmountCurrency { get; set; }

    [Column("tax_base_amount")]
    public decimal? TaxBaseAmount { get; set; }

    [Column("amount_residual")]
    public decimal? AmountResidual { get; set; }

    [Column("amount_residual_currency")]
    public decimal? AmountResidualCurrency { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("price_subtotal")]
    public decimal? PriceSubtotal { get; set; }

    [Column("price_total")]
    public decimal? PriceTotal { get; set; }

    [Column("discount")]
    public decimal? Discount { get; set; }

    [Column("discount_amount_currency")]
    public decimal? DiscountAmountCurrency { get; set; }

    [Column("discount_balance")]
    public decimal? DiscountBalance { get; set; }

    [Column("tax_tag_invert")]
    public bool? TaxTagInvert { get; set; }

    [Column("reconciled")]
    public bool? Reconciled { get; set; }

    [Column("blocked")]
    public bool? Blocked { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("discount_percentage")]
    public double? DiscountPercentage { get; set; }

    [Column("is_downpayment")]
    public bool? IsDownpayment { get; set; }

    [Column("purchase_line_id")]
    public Guid? PurchaseLineId { get; set; }

    [Column("asset_category_id")]
    public Guid? AssetCategoryId { get; set; }

    [Column("asset_start_date")]
    public DateTime? AssetStartDate { get; set; }

    [Column("asset_end_date")]
    public DateTime? AssetEndDate { get; set; }

    [Column("asset_mrr")]
    public double? AssetMrr { get; set; }

    [Column("followup_line_id")]
    public Guid? FollowupLineId { get; set; }

    [Column("followup_date")]
    public DateTime? FollowupDate { get; set; }

    [Column("expense_id")]
    public Guid? ExpenseId { get; set; }

    [Column("vehicle_id")]
    public Guid? VehicleId { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountAccount? Account { get; set; }

    [ForeignKey("AssetCategoryId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountAssetCategory? AssetCategory { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CompanyCurrencyId")]
    //[InverseProperty("AccountMoveLineCompanyCurrencies")]
    [NotMapped]
    public virtual ResCurrency? CompanyCurrency { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountMoveLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountMoveLineCurrencies")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("ExpenseId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual HrExpense? Expense { get; set; }

    [ForeignKey("FollowupLineId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual FollowupLine? FollowupLine { get; set; }

    [ForeignKey("FullReconcileId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountFullReconcile? FullReconcile { get; set; }

    [ForeignKey("GroupTaxId")]
    //[InverseProperty("AccountMoveLineGroupTaxes")]
    [NotMapped]
    public virtual AccountTax? GroupTax { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountMove? Move { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PaymentId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountPayment? Payment { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("PurchaseLineId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual PurchaseOrderLine? PurchaseLine { get; set; }

    [ForeignKey("ReconcileModelId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountReconcileModel? ReconcileModel { get; set; }

    [ForeignKey("StatementId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountBankStatement? Statement { get; set; }

    [ForeignKey("StatementLineId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountBankStatementLine? StatementLine { get; set; }

    [ForeignKey("TaxGroupId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountTaxGroup? TaxGroup { get; set; }

    [ForeignKey("TaxLineId")]
    //[InverseProperty("AccountMoveLineTaxLines")]
    [NotMapped]
    public virtual AccountTax? TaxLine { get; set; }

    [ForeignKey("TaxRepartitionLineId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual AccountTaxRepartitionLine? TaxRepartitionLine { get; set; }

    [ForeignKey("VehicleId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual FleetVehicle? Vehicle { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountMoveLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("MoveLine")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; } = new List<AccountAnalyticLine>();

    //[InverseProperty("CreditMove")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreditMoves { get; } = new List<AccountPartialReconcile>();

    //[InverseProperty("DebitMove")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileDebitMoves { get; } = new List<AccountPartialReconcile>();

    //[InverseProperty("InvoiceLine")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFees { get; } = new List<RepairFee>();

    //[InverseProperty("InvoiceLine")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLines { get; } = new List<RepairLine>();

    //[InverseProperty("AccountMoveLine")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayers { get; } = new List<StockValuationLayer>();

    [ForeignKey("AccountMoveLineId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTags { get; } = new List<AccountAccountTag>();

    [ForeignKey("AccountMoveLineId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizards { get; } = new List<AccountAutomaticEntryWizard>();

    [ForeignKey("AccountMoveLineId")]
    //[InverseProperty("AccountMoveLines")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; } = new List<AccountTax>();

    [ForeignKey("InvoiceLineId")]
    //[InverseProperty("InvoiceLines")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> OrderLines { get; } = new List<SaleOrderLine>();

    [ForeignKey("LineId")]
    //[InverseProperty("Lines")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> Wizards { get; } = new List<AccountPaymentRegister>();
}
