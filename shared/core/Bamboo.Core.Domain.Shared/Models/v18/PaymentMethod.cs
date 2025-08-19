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

[Table("payment_method")]
public partial class PaymentMethod: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("primary_payment_method_id")]
    public Guid? PrimaryPaymentMethodId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("support_refund")]
    public string? SupportRefund { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("support_tokenization")]
    public bool? SupportTokenization { get; set; }

    [Column("support_express_checkout")]
    public bool? SupportExpressCheckout { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PaymentMethodCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("PrimaryPaymentMethodId")]
    [InverseProperty("PrimaryPaymentMethod")]
    public virtual ICollection<PaymentMethod> InversePrimaryPaymentMethod { get; set; }

    // [One2many]
    [ForeignKey("PaymentMethodId")]
    [InverseProperty("PaymentMethod")]
    public virtual ICollection<PaymentToken> PaymentToken { get; set; }

    // [One2many]
    [ForeignKey("PaymentMethodId")]
    [InverseProperty("PaymentMethod")]
    public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [Many2one]
    [ForeignKey("PrimaryPaymentMethodId")]
    // [InverseProperty("InversePrimaryPaymentMethod")] //Many2one
    public virtual PaymentMethod? PrimaryPaymentMethod { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PaymentMethodWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [ForeignKey("PaymentMethodId")] //Many2many
    [InverseProperty("PaymentMethod")] //Many2many
    // [NotMapped] //Many2many // Normal
    public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }

    // [Many2many] // Normal
    // [ForeignKey("PaymentMethodId")] //Many2many
    [InverseProperty("PaymentMethod")] //Many2many
    // [NotMapped] //Many2many // Normal
    public virtual ICollection<ResCountry> ResCountry { get; set; }

    // [Many2many] // Normal
    // [ForeignKey("PaymentMethodId")] //Many2many
    [InverseProperty("PaymentMethod")] //Many2many
    // [NotMapped] //Many2many // Normal
    public virtual ICollection<ResCurrency> ResCurrency { get; set; }
}
