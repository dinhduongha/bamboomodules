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

[Table("account_tax")]
public partial class AccountTax: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("tax_group_id")]
    public Guid? TaxGroupId { get; set; }

    [Column("cash_basis_transition_account_id")]
    public Guid? CashBasisTransitionAccountId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("type_tax_use")]
    public string? TypeTaxUse { get; set; }

    [Column("tax_scope")]
    public string? TaxScope { get; set; }

    [Column("amount_type")]
    public string? AmountType { get; set; }

    [Column("price_include_override")]
    public string? PriceIncludeOverride { get; set; }

    [Column("tax_exigibility")]
    public string? TaxExigibility { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [JsonField]
    [Column("invoice_label", TypeName = "jsonb")]
    public string? InvoiceLabel { get; set; }

    [Column("invoice_legal_notes")]
    public string? InvoiceLegalNotes { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("include_base_amount")]
    public bool? IncludeBaseAmount { get; set; }

    [Column("is_base_affected")]
    public bool? IsBaseAffected { get; set; }

    [Column("analytic")]
    public bool? Analytic { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("formula")]
    public string? Formula { get; set; }

    [Column("ubl_cii_tax_category_code")]
    public string? UblCiiTaxCategoryCode { get; set; }

    [Column("ubl_cii_tax_exemption_reason_code")]
    public string? UblCiiTaxExemptionReasonCode { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TaxDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TaxDest")] // One2many
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxTaxDest { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TaxSrcId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TaxSrc")] // One2many
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxTaxSrc { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("GroupTaxId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("GroupTax")] // One2many
    public virtual ICollection<AccountMoveLine> AccountMoveLineGroupTax { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TaxLineId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TaxLine")] // One2many
    public virtual ICollection<AccountMoveLine> AccountMoveLineTaxLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TaxId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Tax")] // One2many
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLine { get; set; }

    // [Many2one]
    [ForeignKey("CashBasisTransitionAccountId")]
    public virtual AccountAccount? CashBasisTransitionAccount { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AccountTaxId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountTax")] // One2many
    public virtual ICollection<HrPayslipLine> HrPayslipLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AccountTaxId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountTax")] // One2many
    public virtual ICollection<HrSalaryRule> HrSalaryRule { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AccountPurchaseTaxId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("AccountPurchaseTax")] // One2many
    public virtual ICollection<ResCompany> ResCompanyAccountPurchaseTax { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AccountSaleTaxId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("AccountSaleTax")] // One2many
    public virtual ICollection<ResCompany> ResCompanyAccountSaleTax { get; set; }

    // [Many2one]
    [ForeignKey("TaxGroupId")]
    public virtual AccountTaxGroup? TaxGroup { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden

    [NotMapped] //Many2many // Hidden // Peer relationship (AccountAccount) is commented out
    // [ForeignKey("TaxId")] //Many2many // Hidden
    // [InverseProperty("Tax")] //Many2many // Hidden
    public virtual ICollection<AccountAccount> Account { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLine { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ParentTax")] // Many2many // Normal
    // [InverseProperty("ParentTax")] // Many2many // Normal
    public virtual ICollection<AccountTax> ChildTax { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")] //Many2many // Hidden
    // [InverseProperty("Tax")] //Many2many // Hidden
    public virtual ICollection<HrExpense> Expense { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ChildTax")] // Many2many // Normal
    // [InverseProperty("ChildTax")] // Many2many // Normal
    public virtual ICollection<AccountTax> ParentTax { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")] //Many2many // Hidden
    // [InverseProperty("Tax")] //Many2many // Hidden
    public virtual ICollection<ProductTemplate> Prod { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")] //Many2many // Hidden
    // [InverseProperty("TaxNavigation")] //Many2many // Hidden
    public virtual ICollection<ProductTemplate> ProdNavigation { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<SaleOrderDiscount> SaleOrderDiscount { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")] //Many2many // Hidden
    // [InverseProperty("AccountTax")] //Many2many // Hidden
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }
}
