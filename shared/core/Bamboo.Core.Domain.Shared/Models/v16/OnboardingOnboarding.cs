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
public partial class OnboardingOnboarding : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }


    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("route_name")]
    public string? RouteName { get; set; }

    [Column("text_completed")]
    public string? TextCompleted { get; set; }

    [Column("panel_background_color")]
    public string? PanelBackgroundColor { get; set; }

    [Column("panel_close_action_name")]
    public string? PanelCloseActionName { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("is_per_company")]
    public bool? IsPerCompany { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("OnboardingOnboardingCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("OnboardingId")]
    [InverseProperty("Onboarding")]
    public virtual ICollection<OnboardingOnboardingStep> OnboardingOnboardingStep { get; set; }

    // [One2many]
    [ForeignKey("OnboardingId")]
    [InverseProperty("Onboarding")]
    public virtual ICollection<OnboardingProgress> OnboardingProgress { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("OnboardingOnboardingWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // INVESIGATE:
    // [Many2many] // Normal
    //[NotMapped] //Many2many // Normal
    // [ForeignKey("OnboardingOnboardingId")] //Many2many
    // [InverseProperty("OnboardingOnboarding")] //Many2many
    //public virtual ICollection<OnboardingOnboardingStep> OnboardingOnboardingStep { get; set; }
}
