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
//[Index("Name", "TenantId", "TypeTaxUse", "TaxScope", Name = "account_tax_name_company_uniq", IsUnique = true)]
public partial class AccountTax: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("tax_group_id")]
    public Guid? TaxGroupId { get; set; }

    [Column("cash_basis_transition_account_id")]
    public Guid? CashBasisTransitionAccountId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    // v16-Compat
    // [JsonField]
    //[Column("name", TypeName = "jsonb")]
    // public string? Name { get; set; }

    [Column("type_tax_use")]
    public string? TypeTaxUse { get; set; }

    [Column("tax_scope")]
    public string? TaxScope { get; set; }

    [Column("amount_type")]
    public string? AmountType { get; set; }

    [Column("price_include_override")]
    public string? PriceIncludeOverride { get; set; }

    // v16-Compat
    // [JsonField]
    // [Column("description", TypeName = "jsonb")]
    // public string? Description { get; set; }

    [Column("tax_exigibility")]
    public string? TaxExigibility { get; set; }

    // TODO: JSON AS KEY
    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }
    //public string? Name { get; set; }

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

    // v16-Compat
    [Column("price_include")]
    public bool? PriceInclude { get; set; }

    [Column("include_base_amount")]
    public bool? IncludeBaseAmount { get; set; }

    [Column("is_base_affected")]
    public bool? IsBaseAffected { get; set; }

    [Column("analytic")]
    public bool? Analytic { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [Column("real_amount")]
    public double? RealAmount { get; set; }

    //[InverseProperty("TaxDest")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxTaxDests { get; set; } 

    //[InverseProperty("TaxSrc")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxTaxSrcs { get; set; } 

    //[InverseProperty("GroupTax")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineGroupTaxes { get; set; } 

    //[InverseProperty("TaxLine")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineTaxLines { get; set; } 

    //[InverseProperty("Tax")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLines { get; set; } 

    // v16-Compat
    //[InverseProperty("InvoiceTax")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineInvoiceTaxes { get; set; } 

    // v16-Compat
    //[InverseProperty("RefundTax")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineRefundTaxes { get; set; } 


    [ForeignKey("CashBasisTransitionAccountId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual AccountAccount? CashBasisTransitionAccount { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountTaxCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("AccountPurchaseTax")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountPurchaseTaxes { get; set; } 

    //[InverseProperty("AccountSaleTax")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyAccountSaleTaxes { get; set; } 

    [ForeignKey("TaxGroupId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual AccountTaxGroup? TaxGroup { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountTaxWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("AccountTaxId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } 

    [ForeignKey("AccountTaxId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLines { get; set; } 

    [ForeignKey("TaxId")]
    //[InverseProperty("Taxes")]
    [NotMapped]
    public virtual ICollection<AccountAccount> Accounts { get; set; } 

    [ForeignKey("ParentTax")]
    //[InverseProperty("ParentTaxes")]
    [NotMapped]
    public virtual ICollection<AccountTax> ChildTaxes { get; set; } 

    [ForeignKey("TaxId")]
    //[InverseProperty("Taxes")]
    [NotMapped]
    public virtual ICollection<HrExpense> Expenses { get; set; } 

    [ForeignKey("AccountTaxId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; set; } 

    [ForeignKey("ChildTax")]
    //[InverseProperty("ChildTaxes")]
    [NotMapped]
    public virtual ICollection<AccountTax> ParentTaxes { get; set; } 

    [ForeignKey("AccountTaxId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; set; } 

    [ForeignKey("TaxId")]
    //[InverseProperty("Taxes")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> Prods { get; set; } 

    [ForeignKey("TaxId")]
    //[InverseProperty("TaxesNavigation")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProdsNavigation { get; set; } 

    [ForeignKey("AccountTaxId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } 

    [ForeignKey("AccountTaxId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ICollection<SaleOrderDiscount> SaleOrderDiscounts { get; set; } 

    // v16-Compat
    [ForeignKey("TaxId")]
    //[InverseProperty("Taxes")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFeeLines { get; set; } 

    // v16-Compat
    [ForeignKey("TaxId")]
    //[InverseProperty("Taxes")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairOperationLines { get; set; } 

    // v16-Compat
    [ForeignKey("AccountTaxId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; } 

    [ForeignKey("AccountTaxId")]
    //[InverseProperty("AccountTaxes")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } 
}
