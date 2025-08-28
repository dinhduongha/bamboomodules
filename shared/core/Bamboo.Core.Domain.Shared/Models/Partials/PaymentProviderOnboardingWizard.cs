using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("payment_provider_onboarding_wizard")]
public partial class PaymentProviderOnboardingWizard
{
    [Column("paypal_user_type")]
    public string? PaypalUserType { get; set; }

    [Column("paypal_seller_account")]
    public string? PaypalSellerAccount { get; set; }

    [Column("paypal_pdt_token")]
    public string? PaypalPdtToken { get; set; }
}
