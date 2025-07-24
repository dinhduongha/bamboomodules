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

[Table("onboarding_progress_step")]
public partial class OnboardingProgressStep: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("step_id")]
    public Guid? StepId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("step_state")]
    public string? StepState { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("OnboardingProgressSteps")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("OnboardingProgressStepCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("StepId")]
    //[InverseProperty("OnboardingProgressSteps")]
    [NotMapped]
    public virtual OnboardingOnboardingStep? Step { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("OnboardingProgressStepWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("OnboardingProgressStepId")]
    //[InverseProperty("OnboardingProgressSteps")]
    [NotMapped]
    public virtual ICollection<OnboardingProgress> OnboardingProgresses { get; set; } = new List<OnboardingProgress>();
}
