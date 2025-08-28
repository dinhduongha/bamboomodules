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

[Table("gamification_challenge")]
public partial class GamificationChallenge: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("reward_id")]
    public Guid? RewardId { get; set; }

    [Column("reward_first_id")]
    public Guid? RewardFirstId { get; set; }

    [Column("reward_second_id")]
    public Guid? RewardSecondId { get; set; }

    [Column("reward_third_id")]
    public Guid? RewardThirdId { get; set; }

    [Column("report_message_group_id")]
    public Guid? ReportMessageGroupId { get; set; }

    [Column("report_template_id")]
    public Guid? ReportTemplateId { get; set; }

    [Column("remind_update_delay")]
    public long? RemindUpdateDelay { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("user_domain")]
    public string? UserDomain { get; set; }

    [Column("period")]
    public string? Period { get; set; }

    [Column("visibility_mode")]
    public string? VisibilityMode { get; set; }

    [Column("report_message_frequency")]
    public string? ReportMessageFrequency { get; set; }

    [Column("challenge_category")]
    public string? ChallengeCategory { get; set; }

    [Column("start_date")]
    public DateTime? StartDate { get; set; }

    [Column("end_date")]
    public DateTime? EndDate { get; set; }

    [Column("last_report_date")]
    public DateTime? LastReportDate { get; set; }

    [Column("next_report_date")]
    public DateTime? NextReportDate { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("reward_failure")]
    public bool? RewardFailure { get; set; }

    [Column("reward_realtime")]
    public bool? RewardRealtime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ChallengeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Challenge")] // One2many
    public virtual ICollection<GamificationBadgeUser> GamificationBadgeUser { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ChallengeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Challenge")] // One2many
    public virtual ICollection<GamificationChallengeLine> GamificationChallengeLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ChallengeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Challenge")] // One2many
    public virtual ICollection<GamificationGoal> GamificationGoal { get; set; }

    // [Many2one]
    [ForeignKey("ManagerId")]
    public virtual ResUsers? Manager { get; set; }

    // [Many2one]
    [ForeignKey("ReportMessageGroupId")]
    public virtual DiscussChannel? ReportMessageGroup { get; set; }

    // [Many2one]
    [ForeignKey("ReportTemplateId")]
    public virtual MailTemplate? ReportTemplate { get; set; }

    // [Many2one]
    [ForeignKey("RewardId")]
    public virtual GamificationBadge? Reward { get; set; }

    // [Many2one]
    [ForeignKey("RewardFirstId")]
    public virtual GamificationBadge? RewardFirst { get; set; }

    // [Many2one]
    [ForeignKey("RewardSecondId")]
    public virtual GamificationBadge? RewardSecond { get; set; }

    // [Many2one]
    [ForeignKey("RewardThirdId")]
    public virtual GamificationBadge? RewardThird { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("GamificationChallengeId")] // Many2many // Normal
    // [InverseProperty("GamificationChallenge")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("GamificationChallengeId")] // Many2many // Normal
    // [InverseProperty("GamificationChallengeNavigation")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsersNavigation { get; set; }
}
