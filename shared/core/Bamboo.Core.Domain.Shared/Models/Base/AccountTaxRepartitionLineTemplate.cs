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

[Table("account_tax_repartition_line_template")]
public partial class AccountTaxRepartitionLineTemplate: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("invoice_tax_id")]
    public Guid? InvoiceTaxId { get; set; }

    [Column("refund_tax_id")]
    public Guid? RefundTaxId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("repartition_type")]
    public string? RepartitionType { get; set; }

    [Column("use_in_tax_closing")]
    public bool? UseInTaxClosing { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("factor_percent")]
    public double? FactorPercent { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("AccountTaxRepartitionLineTemplates")]
    [NotMapped]
    public virtual AccountAccountTemplate? Account { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountTaxRepartitionLineTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("InvoiceTaxId")]
    //[InverseProperty("AccountTaxRepartitionLineTemplateInvoiceTaxes")]
    [NotMapped]
    public virtual AccountTaxTemplate? InvoiceTax { get; set; }

    [ForeignKey("RefundTaxId")]
    //[InverseProperty("AccountTaxRepartitionLineTemplateRefundTaxes")]
    [NotMapped]
    public virtual AccountTaxTemplate? RefundTax { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountTaxRepartitionLineTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("AccountTaxRepartitionLineTemplateId")]
    //[InverseProperty("AccountTaxRepartitionLineTemplates")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTags { get; } = new List<AccountAccountTag>();

    [ForeignKey("AccountTaxRepartitionLineTemplateId")]
    //[InverseProperty("AccountTaxRepartitionLineTemplates")]
    [NotMapped]
    public virtual ICollection<AccountReportExpression> AccountReportExpressions { get; } = new List<AccountReportExpression>();

    //[ForeignKey("AccountTaxRepartitionLineTemplateId")]
    //[InverseProperty("AccountTaxRepartitionLineTemplatesNavigation")]
    [NotMapped]
    public virtual ICollection<AccountReportExpression> AccountReportExpressionsNavigation { get; } = new List<AccountReportExpression>();
}
