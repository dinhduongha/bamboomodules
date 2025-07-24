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

[Table("gamification_goal")]
//[Index("ChallengeId", Name = "gamification_goal__challenge_id_index")]
public partial class GamificationGoal: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("definition_id")]
    public Guid? DefinitionId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("line_id")]
    public Guid? LineId { get; set; }

    [Column("challenge_id")]
    public Guid? ChallengeId { get; set; }

    [Column("remind_update_delay")]
    public long? RemindUpdateDelay { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("start_date")]
    public DateTime? StartDate { get; set; }

    [Column("end_date")]
    public DateTime? EndDate { get; set; }

    [Column("last_update")]
    public DateTime? LastUpdate { get; set; }

    [Column("to_update")]
    public bool? ToUpdate { get; set; }

    [Column("closed")]
    public bool? Closed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("target_goal")]
    public double? TargetGoal { get; set; }

    [Column("current")]
    public double? Current { get; set; }

    [ForeignKey("ChallengeId")]
    //[InverseProperty("GamificationGoals")]
    [NotMapped]
    public virtual GamificationChallenge? Challenge { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationGoalCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DefinitionId")]
    //[InverseProperty("GamificationGoals")]
    [NotMapped]
    public virtual GamificationGoalDefinition? Definition { get; set; }

    //[InverseProperty("Goal")]
    [NotMapped]
    public virtual ICollection<GamificationGoalWizard> GamificationGoalWizards { get; set; } = new List<GamificationGoalWizard>();

    [ForeignKey("LineId")]
    //[InverseProperty("GamificationGoals")]
    [NotMapped]
    public virtual GamificationChallengeLine? Line { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("GamificationGoalUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationGoalWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
