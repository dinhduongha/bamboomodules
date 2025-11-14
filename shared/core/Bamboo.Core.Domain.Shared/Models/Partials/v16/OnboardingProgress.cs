using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("onboarding_progress")]
//[Index("OnboardingId", "CompanyId", Name = "onboarding_progress_onboarding_company_uniq", IsUnique = true)]
public partial class OnboardingProgress
{
    // v16-Compat
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProgressId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Progress")] // One2many
    // public virtual ICollection<OnboardingProgressStep> OnboardingProgressStep { get; set; }
}
