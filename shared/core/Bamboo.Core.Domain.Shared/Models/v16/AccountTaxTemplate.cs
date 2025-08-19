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

[Table("account_tax_template")]
//[Index("Name", "TypeTaxUse", "TaxScope", "ChartTemplateId", Name = "account_tax_template_name_company_uniq", IsUnique = true)]
public partial class AccountTaxTemplate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("tax_group_id")]
    public Guid? TaxGroupId { get; set; }

    [Column("cash_basis_transition_account_id")]
    public Guid? CashBasisTransitionAccountId { get; set; }

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

    // [One2many]
    [ForeignKey("TaxDestId")]
    [InverseProperty("TaxDest")]
    public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateTaxDest { get; set; }

    // [One2many]
    [ForeignKey("TaxSrcId")]
    [InverseProperty("TaxSrc")]
    public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateTaxSrc { get; set; }

    // [One2many]
    [ForeignKey("InvoiceTaxId")]
    [InverseProperty("InvoiceTax")]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateInvoiceTax { get; set; }

    // [One2many]
    [ForeignKey("RefundTaxId")]
    [InverseProperty("RefundTax")]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateRefundTax { get; set; }

    // [Many2one]
    [ForeignKey("CashBasisTransitionAccountId")]
    // [InverseProperty("AccountTaxTemplate")] //Many2one
    public virtual AccountAccountTemplate? CashBasisTransitionAccount { get; set; }

    // [Many2one]
    [ForeignKey("ChartTemplateId")]
    // [InverseProperty("AccountTaxTemplate")] //Many2one
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountTaxTemplateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("TaxGroupId")]
    // [InverseProperty("AccountTaxTemplate")] //Many2one
    public virtual AccountTaxGroup? TaxGroup { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountTaxTemplateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TaxId")]
    // [InverseProperty("Tax")]
    public virtual ICollection<AccountAccountTemplate> Account { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountTaxTemplateId")]
    // [InverseProperty("AccountTaxTemplate")]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplate { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ParentTax")] //Many2many
    // [InverseProperty("ParentTax")] //Many2many
    public virtual ICollection<AccountTaxTemplate> ChildTax { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ChildTax")] //Many2many
    // [InverseProperty("ChildTax")] //Many2many
    public virtual ICollection<AccountTaxTemplate> ParentTax { get; set; }
}
