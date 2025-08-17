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
//[Index("Name", "CompanyId", "TypeTaxUse", "TaxScope", Name = "account_tax_name_company_uniq", IsUnique = true)]
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

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("type_tax_use")]
    public string? TypeTaxUse { get; set; }

    [Column("tax_scope")]
    public string? TaxScope { get; set; }

    [Column("amount_type")]
    public string? AmountType { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("tax_exigibility")]
    public string? TaxExigibility { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("price_include")]
    public bool? PriceInclude { get; set; }

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

    [Column("real_amount")]
    public double? RealAmount { get; set; }

    // [One2many]
    [ForeignKey("TaxDestId")]
    [InverseProperty("TaxDest")]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxTaxDest { get; set; }

    // [One2many]
    [ForeignKey("TaxSrcId")]
    [InverseProperty("TaxSrc")]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxTaxSrc { get; set; }

    // [One2many]
    [ForeignKey("GroupTaxId")]
    [InverseProperty("GroupTax")]
    public virtual ICollection<AccountMoveLine> AccountMoveLineGroupTax { get; set; }

    // [One2many]
    [ForeignKey("TaxLineId")]
    [InverseProperty("TaxLine")]
    public virtual ICollection<AccountMoveLine> AccountMoveLineTaxLine { get; set; }

    // [One2many]
    [ForeignKey("InvoiceTaxId")]
    [InverseProperty("InvoiceTax")]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineInvoiceTax { get; set; }

    // [One2many]
    [ForeignKey("RefundTaxId")]
    [InverseProperty("RefundTax")]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineRefundTax { get; set; }

    // [Many2one]
    [ForeignKey("CashBasisTransitionAccountId")]
    // [InverseProperty("AccountTax")] //Many2one
    public virtual AccountAccount? CashBasisTransitionAccount { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountTax")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("AccountTax")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountTaxCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("AccountPurchaseTaxId")]
    [InverseProperty("AccountPurchaseTax")]
    public virtual ICollection<ResCompany> ResCompanyAccountPurchaseTax { get; set; }

    // [One2many]
    [ForeignKey("AccountSaleTaxId")]
    [InverseProperty("AccountSaleTax")]
    public virtual ICollection<ResCompany> ResCompanyAccountSaleTax { get; set; }

    // [Many2one]
    [ForeignKey("TaxGroupId")]
    // [InverseProperty("AccountTax")] //Many2one
    public virtual AccountTaxGroup? TaxGroup { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountTaxWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")]
    // [InverseProperty("Tax")]
    // public virtual ICollection<AccountAccount> Account { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")]
    // [InverseProperty("AccountTax")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")]
    // [InverseProperty("AccountTax")]
    // public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLine { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ParentTax")] //Many2many
    // [InverseProperty("ParentTax")] //Many2many
    public virtual ICollection<AccountTax> ChildTax { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")]
    // [InverseProperty("Tax")]
    // public virtual ICollection<HrExpense> Expense { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")]
    // [InverseProperty("AccountTax")]
    // public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ChildTax")] //Many2many
    // [InverseProperty("ChildTax")] //Many2many
    public virtual ICollection<AccountTax> ParentTax { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")]
    // [InverseProperty("AccountTax")]
    // public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")]
    // [InverseProperty("Tax")]
    // public virtual ICollection<ProductTemplate> Prod { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")]
    // [InverseProperty("TaxNavigation")]
    // public virtual ICollection<ProductTemplate> ProdNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")]
    // [InverseProperty("AccountTax")]
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")]
    // [InverseProperty("Tax")]
    // public virtual ICollection<RepairFee> RepairFeeLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")]
    // [InverseProperty("Tax")]
    // public virtual ICollection<RepairLine> RepairOperationLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")]
    // [InverseProperty("AccountTax")]
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInv { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxId")]
    // [InverseProperty("AccountTax")]
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }
}
