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

[Table("gamification_badge")]
//[Index("IsPublished", Name = "gamification_badge_is_published_index")]
public partial class GamificationBadge: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("rule_max_number")]
    public long? RuleMaxNumber { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("level")]
    public string? Level { get; set; }

    [Column("rule_auth")]
    public string? RuleAuth { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("rule_max")]
    public bool? RuleMax { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("GamificationBadgeCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("BadgeId")]
    [InverseProperty("Badge")]
    public virtual ICollection<GamificationBadgeUser> GamificationBadgeUser { get; set; }

    // [One2many]
    [ForeignKey("BadgeId")]
    [InverseProperty("Badge")]
    public virtual ICollection<GamificationBadgeUserWizard> GamificationBadgeUserWizard { get; set; }

    // [One2many]
    [ForeignKey("RewardId")]
    [InverseProperty("Reward")]
    public virtual ICollection<GamificationChallenge> GamificationChallengeReward { get; set; }

    // [One2many]
    [ForeignKey("RewardFirstId")]
    [InverseProperty("RewardFirst")]
    public virtual ICollection<GamificationChallenge> GamificationChallengeRewardFirst { get; set; }

    // [One2many]
    [ForeignKey("RewardSecondId")]
    [InverseProperty("RewardSecond")]
    public virtual ICollection<GamificationChallenge> GamificationChallengeRewardSecond { get; set; }

    // [One2many]
    [ForeignKey("RewardThirdId")]
    [InverseProperty("RewardThird")]
    public virtual ICollection<GamificationChallenge> GamificationChallengeRewardThird { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("GamificationBadge")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("SurveyId")]
    // [InverseProperty("GamificationBadge")] //Many2one
    public virtual SurveySurvey? Survey { get; set; }

    // [Many2one]
    // [InverseProperty("CertificationBadge")] //Many2one
    public virtual SurveySurvey? SurveySurvey { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("GamificationBadgeWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("Badge2Id")] //Many2many
    // [InverseProperty("Badge2")] //Many2many
    public virtual ICollection<GamificationBadge> Badge1 { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("Badge1Id")] //Many2many
    // [InverseProperty("Badge1")] //Many2many
    public virtual ICollection<GamificationBadge> Badge2 { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("GamificationBadgeId")] //Many2many
    // [InverseProperty("GamificationBadge")] //Many2many
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinition { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("GamificationBadgeId")] //Many2many
    // [InverseProperty("GamificationBadge")] //Many2many
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
