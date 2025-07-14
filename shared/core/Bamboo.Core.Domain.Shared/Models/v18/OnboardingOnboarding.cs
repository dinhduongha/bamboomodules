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

[Table("onboarding_onboarding")]
//[Index("RouteName", Name = "onboarding_onboarding_route_name_uniq", IsUnique = true)]
public partial class OnboardingOnboarding: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("route_name")]
    public string? RouteName { get; set; }

    [Column("text_completed")]
    public string? TextCompleted { get; set; }

    [Column("panel_close_action_name")]
    public string? PanelCloseActionName { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("OnboardingOnboardingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Onboarding")]
    [NotMapped]
    public virtual ICollection<OnboardingProgress> OnboardingProgresses { get; set; } = new List<OnboardingProgress>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("OnboardingOnboardingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("OnboardingOnboardingId")]
    //[InverseProperty("OnboardingOnboardings")]
    [NotMapped]
    public virtual ICollection<OnboardingOnboardingStep> OnboardingOnboardingSteps { get; set; } = new List<OnboardingOnboardingStep>();
}
