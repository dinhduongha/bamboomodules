using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("gamification_challenge")]
public partial class GamificationChallenge: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateOnly? StartDate { get; set; }

    [Column("end_date")]
    public DateOnly? EndDate { get; set; }

    [Column("last_report_date")]
    public DateOnly? LastReportDate { get; set; }

    [Column("next_report_date")]
    public DateOnly? NextReportDate { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("reward_failure")]
    public bool? RewardFailure { get; set; }

    [Column("reward_realtime")]
    public bool? RewardRealtime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationChallengeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Challenge")]
    [NotMapped]
    public virtual ICollection<GamificationBadgeUser> GamificationBadgeUsers { get; set; } = new List<GamificationBadgeUser>();

    //[InverseProperty("Challenge")]
    [NotMapped]
    public virtual ICollection<GamificationChallengeLine> GamificationChallengeLines { get; set; } = new List<GamificationChallengeLine>();

    //[InverseProperty("Challenge")]
    [NotMapped]
    public virtual ICollection<GamificationGoal> GamificationGoals { get; set; } = new List<GamificationGoal>();

    [ForeignKey("ManagerId")]
    //[InverseProperty("GamificationChallengeManagers")]
    [NotMapped]
    public virtual ResUser? Manager { get; set; }

    [ForeignKey("ReportMessageGroupId")]
    //[InverseProperty("GamificationChallenges")]
    [NotMapped]
    public virtual DiscussChannel? ReportMessageGroup { get; set; }

    [ForeignKey("ReportTemplateId")]
    //[InverseProperty("GamificationChallenges")]
    [NotMapped]
    public virtual MailTemplate? ReportTemplate { get; set; }

    [ForeignKey("RewardId")]
    //[InverseProperty("GamificationChallengeRewards")]
    [NotMapped]
    public virtual GamificationBadge? Reward { get; set; }

    [ForeignKey("RewardFirstId")]
    //[InverseProperty("GamificationChallengeRewardFirsts")]
    [NotMapped]
    public virtual GamificationBadge? RewardFirst { get; set; }

    [ForeignKey("RewardSecondId")]
    //[InverseProperty("GamificationChallengeRewardSeconds")]
    [NotMapped]
    public virtual GamificationBadge? RewardSecond { get; set; }

    [ForeignKey("RewardThirdId")]
    //[InverseProperty("GamificationChallengeRewardThirds")]
    [NotMapped]
    public virtual GamificationBadge? RewardThird { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationChallengeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("GamificationChallengeId")]
    //[InverseProperty("GamificationChallenges")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; set; } = new List<ResUser>();

    [ForeignKey("GamificationChallengeId")]
    //[InverseProperty("GamificationChallengesNavigation")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsersNavigation { get; set; } = new List<ResUser>();
}
