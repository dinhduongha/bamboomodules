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

[Table("sale_payment_provider_onboarding_wizard")]
public partial class SalePaymentProviderOnboardingWizard : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("payment_method")]
    public string? PaymentMethod { get; set; }

    // v16-Compat
    [Column("paypal_user_type")]
    public string? PaypalUserType { get; set; }

    [Column("paypal_email_account")]
    public string? PaypalEmailAccount { get; set; }

    // v16-Compat
    [Column("paypal_seller_account")]
    public string? PaypalSellerAccount { get; set; }

    // v16-Compat
    [Column("paypal_pdt_token")]
    public string? PaypalPdtToken { get; set; }

    [Column("manual_name")]
    public string? ManualName { get; set; }

    [Column("journal_name")]
    public string? JournalName { get; set; }

    [Column("acc_number")]
    public string? AccNumber { get; set; }

    [Column("manual_post_msg")]
    public string? ManualPostMsg { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SalePaymentProviderOnboardingWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SalePaymentProviderOnboardingWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
