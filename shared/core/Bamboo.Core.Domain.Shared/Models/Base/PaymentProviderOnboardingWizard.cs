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

[Table("payment_provider_onboarding_wizard")]
public partial class PaymentProviderOnboardingWizard: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("payment_method")]
    public string? PaymentMethod { get; set; }

    [Column("paypal_user_type")]
    public string? PaypalUserType { get; set; }

    [Column("paypal_email_account")]
    public string? PaypalEmailAccount { get; set; }

    [Column("paypal_seller_account")]
    public string? PaypalSellerAccount { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PaymentProviderOnboardingWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PaymentProviderOnboardingWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
