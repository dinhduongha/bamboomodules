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

[Table("gamification_karma_tracking")]
//[Index("TrackingDate", Name = "gamification_karma_tracking__tracking_date_index")]
//[Index("UserId", Name = "gamification_karma_tracking__user_id_index")]
public partial class GamificationKarmaTracking: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("old_value")]
    public long? OldValue { get; set; }

    [Column("new_value")]
    public long? NewValue { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("origin_ref")]
    public string? OriginRef { get; set; }

    [Column("origin_ref_model_name")]
    public string? OriginRefModelName { get; set; }

    [Column("reason")]
    public string? Reason { get; set; }

    [Column("consolidated")]
    public bool? Consolidated { get; set; }

    [Column("tracking_date", TypeName = "timestamp without time zone")]
    public DateTime? TrackingDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationKarmaTrackingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("GamificationKarmaTrackingUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationKarmaTrackingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
