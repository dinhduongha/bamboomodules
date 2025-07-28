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
public partial class PaymentMethod: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("primary_payment_method_id")]
    public Guid? PrimaryPaymentMethodId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("support_refund")]
    public string? SupportRefund { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("support_tokenization")]
    public bool? SupportTokenization { get; set; }

    [Column("support_express_checkout")]
    public bool? SupportExpressCheckout { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PaymentMethodCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("PrimaryPaymentMethod")]
    [NotMapped]
    public virtual ICollection<PaymentMethod> InversePrimaryPaymentMethod { get; set; } 

    //[InverseProperty("PaymentMethod")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokens { get; set; } 

    //[InverseProperty("PaymentMethod")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } 

    [ForeignKey("PrimaryPaymentMethodId")]
    //[InverseProperty("InversePrimaryPaymentMethod")]
    [NotMapped]
    public virtual PaymentMethod? PrimaryPaymentMethod { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PaymentMethodWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("PaymentMethodId")]
    //[InverseProperty("PaymentMethods")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviders { get; set; } 

    [ForeignKey("PaymentMethodId")]
    //[InverseProperty("PaymentMethods")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountries { get; set; } 

    [ForeignKey("PaymentMethodId")]
    //[InverseProperty("PaymentMethods")]
    [NotMapped]
    public virtual ICollection<ResCurrency> ResCurrencies { get; set; } 
}
