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
//[Index("OnboardingId", "CompanyId", Name = "onboarding_progress_onboarding_company_uniq", IsUnique = true)]
public partial class OnboardingProgress: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("onboarding_id")]
    public Guid? OnboardingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("onboarding_state")]
    public string? OnboardingState { get; set; }

    [Column("is_onboarding_closed")]
    public bool? IsOnboardingClosed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("OnboardingProgress")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("OnboardingProgressCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("OnboardingId")]
    // [InverseProperty("OnboardingProgress")] //Many2one
    public virtual OnboardingOnboarding? Onboarding { get; set; }

    // [One2many]
    //[ForeignKey("ProgressId")]
    //[InverseProperty("Progress")]
    //public virtual ICollection<OnboardingProgressStep> OnboardingProgressStep { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("OnboardingProgressWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    //[NotMapped] //Many2many // Normal
    [ForeignKey("OnboardingProgressId")] //Many2many
    [InverseProperty("OnboardingProgress")] //Many2many
    public virtual ICollection<OnboardingProgressStep> OnboardingProgressStep { get; set; }
}
