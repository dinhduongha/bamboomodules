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
//[Index("CompanyId", Name = "payment_token__company_id_index")]
public partial class PaymentToken: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("provider_id")]
    public Guid? ProviderId { get; set; }

    [Column("payment_method_id")]
    public Guid? PaymentMethodId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("payment_details")]
    public string? PaymentDetails { get; set; }

    [Column("provider_ref")]
    public string? ProviderRef { get; set; }

    [Column("verified")]
    public bool? Verified { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("authorize_profile")]
    public string? AuthorizeProfile { get; set; }

    // [One2many]
    [ForeignKey("PaymentTokenId")]
    [InverseProperty("PaymentToken")]
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many]
    [ForeignKey("PaymentTokenId")]
    [InverseProperty("PaymentToken")]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("PaymentToken")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PaymentTokenCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("PaymentToken")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PaymentMethodId")]
    // [InverseProperty("PaymentToken")] //Many2one
    public virtual PaymentMethod? PaymentMethod { get; set; }

    // [One2many]
    [ForeignKey("TokenId")]
    [InverseProperty("Token")]
    public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [Many2one]
    [ForeignKey("ProviderId")]
    // [InverseProperty("PaymentToken")] //Many2one
    public virtual PaymentProvider? Provider { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PaymentTokenWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
