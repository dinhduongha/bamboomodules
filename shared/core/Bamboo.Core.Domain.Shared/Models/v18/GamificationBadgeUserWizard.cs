using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("gamification_badge_user_wizard")]
public partial class GamificationBadgeUserWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("badge_id")]
    public Guid? BadgeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [ForeignKey("BadgeId")]
    //[InverseProperty("GamificationBadgeUserWizards")]
    [NotMapped]
    public virtual GamificationBadge? Badge { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationBadgeUserWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("GamificationBadgeUserWizards")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("GamificationBadgeUserWizardUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationBadgeUserWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
