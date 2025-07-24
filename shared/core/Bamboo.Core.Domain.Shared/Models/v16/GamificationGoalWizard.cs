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

[Table("gamification_goal_wizard")]
public partial class GamificationGoalWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("goal_id")]
    public Guid? GoalId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("current")]
    public double? Current { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationGoalWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("GoalId")]
    //[InverseProperty("GamificationGoalWizards")]
    [NotMapped]
    public virtual GamificationGoal? Goal { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationGoalWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
