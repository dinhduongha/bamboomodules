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

[Table("gamification_challenge_line")]
public partial class GamificationChallengeLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("challenge_id")]
    public Guid? ChallengeId { get; set; }

    [Column("definition_id")]
    public Guid? DefinitionId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("target_goal")]
    public double? TargetGoal { get; set; }

    [ForeignKey("ChallengeId")]
    //[InverseProperty("GamificationChallengeLines")]
    [NotMapped]
    public virtual GamificationChallenge? Challenge { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationChallengeLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DefinitionId")]
    //[InverseProperty("GamificationChallengeLines")]
    [NotMapped]
    public virtual GamificationGoalDefinition? Definition { get; set; }

    //[InverseProperty("Line")]
    [NotMapped]
    public virtual ICollection<GamificationGoal> GamificationGoals { get; set; } = new List<GamificationGoal>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationChallengeLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
