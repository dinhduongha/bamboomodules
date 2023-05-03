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

[Table("payment_token")]
//[Index("TenantId", Name = "payment_token_company_id_index")]
public partial class PaymentToken: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("provider_id")]
    public Guid? ProviderId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("payment_details")]
    public string? PaymentDetails { get; set; }

    [Column("provider_ref")]
    public string? ProviderRef { get; set; }

    [Column("verified")]
    public bool? Verified { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("PaymentTokens")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PaymentTokenCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("PaymentTokens")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("ProviderId")]
    //[InverseProperty("PaymentTokens")]
    [NotMapped]
    public virtual PaymentProvider? Provider { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PaymentTokenWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("PaymentToken")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; } = new List<AccountPaymentRegister>();

    //[InverseProperty("PaymentToken")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; } = new List<AccountPayment>();

    //[InverseProperty("Token")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; } = new List<PaymentTransaction>();

}
