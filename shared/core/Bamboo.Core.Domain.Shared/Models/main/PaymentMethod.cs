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

[Table("payment_method")]
public partial class PaymentMethod : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PrimaryPaymentMethodId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PrimaryPaymentMethod")] // One2many
    public virtual ICollection<PaymentMethod> InversePrimaryPaymentMethod { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentMethodId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentMethod")] // One2many
    public virtual ICollection<PaymentToken> PaymentToken { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentMethodId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentMethod")] // One2many
    public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PrimaryPaymentMethodId")]
    public virtual PaymentMethod? PrimaryPaymentMethod { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PaymentMethodId")] // Many2many // Normal
    // [InverseProperty("PaymentMethod")] // Many2many // Normal
    public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCountry) is commented out
    // [ForeignKey("PaymentMethodId")] // Many2many // Normal
    // [InverseProperty("PaymentMethod")] // Many2many // Normal
    public virtual ICollection<ResCountry> ResCountry { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCurrency) is commented out
    // [ForeignKey("PaymentMethodId")] // Many2many // Normal
    // [InverseProperty("PaymentMethod")] // Many2many // Normal
    public virtual ICollection<ResCurrency> ResCurrency { get; set; }
}
