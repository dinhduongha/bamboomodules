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
//[Index("BadgeId", Name = "gamification_badge_user_badge_id_index")]
//[Index("EmployeeId", Name = "gamification_badge_user_employee_id_index")]
//[Index("UserId", Name = "gamification_badge_user_user_id_index")]
public partial class GamificationBadgeUser: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("sender_id")]
    public Guid? SenderId { get; set; }

    [Column("badge_id")]
    public Guid? BadgeId { get; set; }

    [Column("challenge_id")]
    public Guid? ChallengeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("level")]
    public string? Level { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    // [Many2one]
    [ForeignKey("BadgeId")]
    // [InverseProperty("GamificationBadgeUser")] //Many2one
    public virtual GamificationBadge? Badge { get; set; }

    // [Many2one]
    [ForeignKey("ChallengeId")]
    // [InverseProperty("GamificationBadgeUser")] //Many2one
    public virtual GamificationChallenge? Challenge { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("GamificationBadgeUserCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("GamificationBadgeUser")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("SenderId")]
    // [InverseProperty("GamificationBadgeUserSender")] //Many2one
    public virtual ResUsers? Sender { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("GamificationBadgeUserUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("GamificationBadgeUserWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
