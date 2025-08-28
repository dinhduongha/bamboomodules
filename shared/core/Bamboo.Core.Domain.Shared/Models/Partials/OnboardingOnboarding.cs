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

//[Table("onboarding_onboarding")]
//[Index("RouteName", Name = "onboarding_onboarding_route_name_uniq", IsUnique = true)]
public partial class OnboardingOnboarding
{
    [Column("panel_background_color")]
    public string? PanelBackgroundColor { get; set; }

    [Column("is_per_company")]
    public bool? IsPerCompany { get; set; }

    // v16-Compat
    // [One2many]
    // [One2many] [ForeignKey("OnboardingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Onboarding")] // One2many
    // public virtual ICollection<OnboardingOnboardingStep> OnboardingOnboardingStep { get; set; }
}
