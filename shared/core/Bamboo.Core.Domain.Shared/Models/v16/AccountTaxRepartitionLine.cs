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

[Table("account_tax_repartition_line")]
public partial class AccountTaxRepartitionLine: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("invoice_tax_id")]
    public Guid? InvoiceTaxId { get; set; }

    [Column("refund_tax_id")]
    public Guid? RefundTaxId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("repartition_type")]
    public string? RepartitionType { get; set; }

    [Column("use_in_tax_closing")]
    public bool? UseInTaxClosing { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("factor_percent")]
    public double? FactorPercent { get; set; }

    // [Many2one]
    [ForeignKey("AccountId")]
    // [InverseProperty("AccountTaxRepartitionLine")] //Many2one
    public virtual AccountAccount? Account { get; set; }

    // [One2many]
    [ForeignKey("TaxRepartitionLineId")]
    [InverseProperty("TaxRepartitionLine")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountTaxRepartitionLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountTaxRepartitionLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("InvoiceTaxId")]
    // [InverseProperty("AccountTaxRepartitionLineInvoiceTax")] //Many2one
    public virtual AccountTax? InvoiceTax { get; set; }

    // [Many2one]
    [ForeignKey("RefundTaxId")]
    // [InverseProperty("AccountTaxRepartitionLineRefundTax")] //Many2one
    public virtual AccountTax? RefundTax { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountTaxRepartitionLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountTaxRepartitionLineId")] //Many2many
    // [InverseProperty("AccountTaxRepartitionLine")] //Many2many
    public virtual ICollection<AccountAccountTag> AccountAccountTag { get; set; }
}
