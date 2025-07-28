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

[Table("discuss_channel_rtc_session")]
//[Index("WriteDate", Name = "discuss_channel_rtc_session__write_date_index")]
//[Index("ChannelMemberId", Name = "discuss_channel_rtc_session_channel_member_unique", IsUnique = true)]
public partial class DiscussChannelRtcSession: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("channel_member_id")]
    public Guid? ChannelMemberId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("is_screen_sharing_on")]
    public bool? IsScreenSharingOn { get; set; }

    [Column("is_camera_on")]
    public bool? IsCameraOn { get; set; }

    [Column("is_muted")]
    public bool? IsMuted { get; set; }

    [Column("is_deaf")]
    public bool? IsDeaf { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("DiscussChannelRtcSessions")]
    [NotMapped]
    public virtual DiscussChannel? Channel { get; set; }

    [ForeignKey("ChannelMemberId")]
    //[InverseProperty("DiscussChannelRtcSession")]
    [NotMapped]
    public virtual DiscussChannelMember? ChannelMember { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("DiscussChannelRtcSessionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("RtcInvitingSession")]
    [NotMapped]
    public virtual ICollection<DiscussChannelMember> DiscussChannelMembers { get; set; } 

    [ForeignKey("LastModifierId")]
    //[InverseProperty("DiscussChannelRtcSessionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
