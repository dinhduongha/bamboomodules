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

[Table("account_move_line")]
//[Index("CompanyId", Name = "account_move_line__company_id_index")]
//[Index("DateMaturity", Name = "account_move_line__date_maturity_index")]
//[Index("JournalId", Name = "account_move_line__journal_id_index")]
//[Index("MatchingNumber", Name = "account_move_line__matching_number_index")]
//[Index("MoveId", Name = "account_move_line__move_id_index")]
//[Index("MoveName", Name = "account_move_line__move_name_index")]
//[Index("AccountId", "Date", Name = "account_move_line_account_id_date_idx")]
//[Index("Date", "MoveName", "Id", Name = "account_move_line_date_name_id_idx", IsDescending = new[] { true, true, false })]
//[Index("PartnerId", "Ref", Name = "account_move_line_partner_id_ref_idx")]
public partial class AccountMoveLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("company_currency_id")]
    public Guid? CompanyCurrencyId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

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

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("move_name")]
    public string? MoveName { get; set; }

    [Column("parent_state")]
    public string? ParentState { get; set; }

    [Column("ref")]
    public string? Ref { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("matching_number")]
    public string? MatchingNumber { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("invoice_date")]
    public DateTime? InvoiceDate { get; set; }

    [Column("date_maturity")]
    public DateTime? DateMaturity { get; set; }

    [Column("discount_date")]
    public DateTime? DiscountDate { get; set; }

    [JsonField] // AnalyticDistribution
    [Column("analytic_distribution", TypeName = "jsonb")]
    public JsonElement? AnalyticDistribution { get; set; }

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

    [Column("is_imported")]
    public bool? IsImported { get; set; }

    [Column("tax_tag_invert")]
    public bool? TaxTagInvert { get; set; }

    [Column("reconciled")]
    public bool? Reconciled { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("is_downpayment")]
    public bool? IsDownpayment { get; set; }

    [Column("cogs_origin_id")]
    public Guid? CogsOriginId { get; set; }

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

    [Column("is_landed_costs_line")]
    public bool? IsLandedCostsLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountId")]
    public virtual AccountAccount? Account { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MoveLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MoveLine")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CreditMoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CreditMove")] // One2many
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreditMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DebitMoveId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DebitMove")] // One2many
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileDebitMove { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AssetCategoryId")]
    public virtual AccountAssetCategory? AssetCategory { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CogsOriginId")]
    public virtual AccountMoveLine? CogsOrigin { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CompanyCurrencyId")]
    public virtual ResCurrency? CompanyCurrency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExpenseId")]
    public virtual HrExpense? Expense { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountMoveLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountMoveLine")] // One2many
    public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServices { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FollowupLineId")]
    public virtual FollowupLine? FollowupLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FullReconcileId")]
    public virtual AccountFullReconcile? FullReconcile { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GroupTaxId")]
    public virtual AccountTax? GroupTax { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CogsOriginId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CogsOrigin")] // One2many
    public virtual ICollection<AccountMoveLine> InverseCogsOrigin { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountInvoiceLine")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountInvoiceLineNavigation")] // One2many
    public virtual ICollection<MembershipMembershipLine> MembershipMembershipLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MoveId")]
    public virtual AccountMove? Move { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountMoveLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountMoveLine")] // One2many
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivity { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentId")]
    public virtual AccountPayment? Payment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUomId")]
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PurchaseLineId")]
    public virtual PurchaseOrderLine? PurchaseLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ReconcileModelId")]
    public virtual AccountReconcileModel? ReconcileModel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StatementId")]
    public virtual AccountBankStatement? Statement { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StatementLineId")]
    public virtual AccountBankStatementLine? StatementLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountMoveLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountMoveLine")] // One2many
    public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TaxGroupId")]
    public virtual AccountTaxGroup? TaxGroup { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TaxLineId")]
    public virtual AccountTax? TaxLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TaxRepartitionLineId")]
    public virtual AccountTaxRepartitionLine? TaxRepartitionLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VehicleId")]
    public virtual FleetVehicle? Vehicle { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountMoveLineId")] // Many2many // Normal
    // [InverseProperty("AccountMoveLine")] // Many2many // Normal
    public virtual ICollection<AccountAccountTag> AccountAccountTag { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountMoveLineId")] //Many2many // Hidden
    // [InverseProperty("AccountMoveLine")] //Many2many // Hidden
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizard { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountMoveLineId")] // Many2many // Normal
    // [InverseProperty("AccountMoveLine")] // Many2many // Normal
    public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("InvoiceLineId")] // Many2many // Normal
    // [InverseProperty("InvoiceLine")] // Many2many // Normal
    public virtual ICollection<SaleOrderLine> OrderLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("LineId")] //Many2many // Hidden
    // [InverseProperty("Line")] //Many2many // Hidden
    public virtual ICollection<AccountPaymentRegister> Wizard { get; set; }
}
