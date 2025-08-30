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

//[Table("onboarding_progress_step")]
//[Index("ProgressId", "StepId", Name = "onboarding_progress_step_progress_step_uniq", IsUnique = true)]
public partial class OnboardingProgressStep
{
    [Column("progress_id")]
    public Guid? ProgressId { get; set; }

    // [Many2one]
    [ForeignKey("ProgressId")]
    public virtual OnboardingProgress? Progress { get; set; }
}
