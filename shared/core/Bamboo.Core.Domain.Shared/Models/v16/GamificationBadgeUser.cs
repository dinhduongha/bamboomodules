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

[Table("gamification_badge_user")]
//[Index("BadgeId", Name = "gamification_badge_user__badge_id_index")]
//[Index("EmployeeId", Name = "gamification_badge_user__employee_id_index")]
//[Index("UserId", Name = "gamification_badge_user__user_id_index")]
public partial class GamificationBadgeUser: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("sender_id")]
    public Guid? SenderId { get; set; }

    [Column("badge_id")]
    public Guid? BadgeId { get; set; }

    [Column("challenge_id")]
    public Guid? ChallengeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("level")]
    public string? Level { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [ForeignKey("BadgeId")]
    //[InverseProperty("GamificationBadgeUsers")]
    [NotMapped]
    public virtual GamificationBadge? Badge { get; set; }

    [ForeignKey("ChallengeId")]
    //[InverseProperty("GamificationBadgeUsers")]
    [NotMapped]
    public virtual GamificationChallenge? Challenge { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationBadgeUserCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("GamificationBadgeUsers")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("SenderId")]
    //[InverseProperty("GamificationBadgeUserSenders")]
    [NotMapped]
    public virtual ResUser? Sender { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("GamificationBadgeUserUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationBadgeUserWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
