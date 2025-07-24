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

[Table("onboarding_progress")]
public partial class OnboardingProgress: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("onboarding_id")]
    public Guid? OnboardingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("onboarding_state")]
    public string? OnboardingState { get; set; }

    [Column("is_onboarding_closed")]
    public bool? IsOnboardingClosed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("OnboardingProgresses")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("OnboardingProgressCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("OnboardingId")]
    //[InverseProperty("OnboardingProgresses")]
    [NotMapped]
    public virtual OnboardingOnboarding? Onboarding { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("OnboardingProgressWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("OnboardingProgressId")]
    //[InverseProperty("OnboardingProgresses")]
    [NotMapped]
    public virtual ICollection<OnboardingProgressStep> OnboardingProgressSteps { get; set; } = new List<OnboardingProgressStep>();
}
