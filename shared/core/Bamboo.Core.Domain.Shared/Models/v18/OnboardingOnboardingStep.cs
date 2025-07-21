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

[Table("onboarding_onboarding_step")]
public partial class OnboardingOnboardingStep: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("done_icon")]
    public string? DoneIcon { get; set; }

    [Column("step_image_filename")]
    public string? StepImageFilename { get; set; }

    [Column("panel_step_open_action_name")]
    public string? PanelStepOpenActionName { get; set; }

    [JsonField]
    [Column("title", TypeName = "jsonb")]
    public string? Title { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [JsonField]
    [Column("button_text", TypeName = "jsonb")]
    public string? ButtonText { get; set; }

    [JsonField]
    [Column("done_text", TypeName = "jsonb")]
    public string? DoneText { get; set; }

    [JsonField]
    [Column("step_image_alt", TypeName = "jsonb")]
    public string? StepImageAlt { get; set; }

    [Column("is_per_company")]
    public bool? IsPerCompany { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("OnboardingOnboardingStepCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Step")]
    [NotMapped]
    public virtual ICollection<OnboardingProgressStep> OnboardingProgressSteps { get; set; } = new List<OnboardingProgressStep>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("OnboardingOnboardingStepWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("OnboardingOnboardingStepId")]
    //[InverseProperty("OnboardingOnboardingSteps")]
    [NotMapped]
    public virtual ICollection<OnboardingOnboarding> OnboardingOnboardings { get; set; } = new List<OnboardingOnboarding>();
}
