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
public partial class OnboardingOnboardingStep: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("StepId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Step")] // One2many
    public virtual ICollection<OnboardingProgressStep> OnboardingProgressStep { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("OnboardingOnboardingStepId")] //Many2many // Hidden
    // [InverseProperty("OnboardingOnboardingStep")] //Many2many // Hidden
    public virtual ICollection<OnboardingOnboarding> OnboardingOnboarding { get; set; }
}
