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

//[Table("onboarding_onboarding_step")]
public partial class OnboardingOnboardingStep
{
    [Column("onboarding_id")]
    public Guid? OnboardingId { get; set; }

    // [Many2one]
    [ForeignKey("OnboardingId")]
    public virtual OnboardingOnboarding? Onboarding { get; set; }
}
