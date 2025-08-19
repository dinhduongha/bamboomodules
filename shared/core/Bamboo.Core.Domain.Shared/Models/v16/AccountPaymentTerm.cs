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

[Table("account_payment_term")]
public partial class AccountPaymentTerm: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("discount_days")]
    public long? DiscountDays { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("early_pay_discount_computation")]
    public string? EarlyPayDiscountComputation { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("note", TypeName = "jsonb")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("display_on_invoice")]
    public bool? DisplayOnInvoice { get; set; }

    [Column("early_discount")]
    public bool? EarlyDiscount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("discount_percentage")]
    public double? DiscountPercentage { get; set; }

    // [One2many]
    [ForeignKey("InvoicePaymentTermId")]
    [InverseProperty("InvoicePaymentTerm")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    [ForeignKey("PaymentId")]
    [InverseProperty("Payment")]
    public virtual ICollection<AccountPaymentTermLine> AccountPaymentTermLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountPaymentTerm")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountPaymentTermCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("PaymentTermId")]
    [InverseProperty("PaymentTerm")]
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many]
    [ForeignKey("PaymentTermId")]
    [InverseProperty("PaymentTerm")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountPaymentTermWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
