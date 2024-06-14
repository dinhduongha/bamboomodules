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
public partial class AccountTaxTemplate: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("tax_group_id")]
    public Guid? TaxGroupId { get; set; }

    [Column("cash_basis_transition_account_id")]
    public Guid? CashBasisTransitionAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("type_tax_use")]
    public string? TypeTaxUse { get; set; }

    [Column("tax_scope")]
    public string? TaxScope { get; set; }

    [Column("amount_type")]
    public string? AmountType { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CashBasisTransitionAccountId")]
    //[InverseProperty("AccountTaxTemplates")]
    [NotMapped]
    public virtual AccountAccountTemplate? CashBasisTransitionAccount { get; set; }

    [ForeignKey("ChartTemplateId")]
    //[InverseProperty("AccountTaxTemplates")]
    [NotMapped]
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountTaxTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("TaxGroupId")]
    //[InverseProperty("AccountTaxTemplates")]
    [NotMapped]
    public virtual AccountTaxGroup? TaxGroup { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountTaxTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("TaxDest")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateTaxDests { get; } = new List<AccountFiscalPositionTaxTemplate>();

    //[InverseProperty("TaxSrc")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateTaxSrcs { get; } = new List<AccountFiscalPositionTaxTemplate>();

    //[InverseProperty("InvoiceTax")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateInvoiceTaxes { get; } = new List<AccountTaxRepartitionLineTemplate>();

    //[InverseProperty("RefundTax")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateRefundTaxes { get; } = new List<AccountTaxRepartitionLineTemplate>();

    [ForeignKey("AccountTaxTemplateId")]
    //[InverseProperty("AccountTaxTemplates")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplates { get; } = new List<AccountReconcileModelLineTemplate>();

    [ForeignKey("TaxId")]
    //[InverseProperty("Taxes")]
    [NotMapped]
    public virtual ICollection<AccountAccountTemplate> Accounts { get; } = new List<AccountAccountTemplate>();

    [ForeignKey("ParentTax")]
    //[InverseProperty("ParentTaxes")]
    [NotMapped]
    public virtual ICollection<AccountTaxTemplate> ChildTaxes { get; } = new List<AccountTaxTemplate>();

    [ForeignKey("ChildTax")]
    //[InverseProperty("ChildTaxes")]
    [NotMapped]
    public virtual ICollection<AccountTaxTemplate> ParentTaxes { get; } = new List<AccountTaxTemplate>();
}
