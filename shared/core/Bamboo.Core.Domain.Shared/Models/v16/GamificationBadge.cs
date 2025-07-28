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
//[Index("IsPublished", Name = "gamification_badge__is_published_index")]
public partial class GamificationBadge: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("rule_max_number")]
    public long? RuleMaxNumber { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("level")]
    public string? Level { get; set; }

    [Column("rule_auth")]
    public string? RuleAuth { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("rule_max")]
    public bool? RuleMax { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("survey_id")]
    public Guid? SurveyId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationBadgeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("...")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    //[InverseProperty("Badge")]
    [NotMapped]
    public virtual ICollection<GamificationBadgeUserWizard> GamificationBadgeUserWizards { get; set; } 

    //[InverseProperty("Badge")]
    [NotMapped]
    public virtual ICollection<GamificationBadgeUser> GamificationBadgeUsers { get; set; } 

    //[InverseProperty("RewardFirst")]
    [NotMapped]
    public virtual ICollection<GamificationChallenge> GamificationChallengeRewardFirsts { get; set; } 

    //[InverseProperty("RewardSecond")]
    [NotMapped]
    public virtual ICollection<GamificationChallenge> GamificationChallengeRewardSeconds { get; set; } 

    //[InverseProperty("RewardThird")]
    [NotMapped]
    public virtual ICollection<GamificationChallenge> GamificationChallengeRewardThirds { get; set; } 

    //[InverseProperty("Reward")]
    [NotMapped]
    public virtual ICollection<GamificationChallenge> GamificationChallengeRewards { get; set; } 

    [ForeignKey("SurveyId")]
    //[InverseProperty("GamificationBadges")]
    [NotMapped]
    public virtual SurveySurvey? Survey { get; set; }

    //[InverseProperty("CertificationBadge")]
    [NotMapped]
    public virtual SurveySurvey? SurveySurvey { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationBadgeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("Badge2Id")]
    //[InverseProperty("Badge2s")]
    [NotMapped]
    public virtual ICollection<GamificationBadge> Badge1s { get; set; } 

    [ForeignKey("Badge1Id")]
    //[InverseProperty("Badge1s")]
    [NotMapped]
    public virtual ICollection<GamificationBadge> Badge2s { get; set; } 

    [ForeignKey("GamificationBadgeId")]
    //[InverseProperty("GamificationBadges")]
    [NotMapped]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitions { get; set; } 

    [ForeignKey("GamificationBadgeId")]
    //[InverseProperty("GamificationBadges")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; set; } 
}
