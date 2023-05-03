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

[Table("mail_channel_rtc_session")]
//[Index("ChannelMemberId", Name = "mail_channel_rtc_session_channel_member_unique", IsUnique = true)]
//[Index("LastModificationTime", Name = "mail_channel_rtc_session_write_date_index")]
public partial class MailChannelRtcSession: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("channel_member_id")]
    public Guid? ChannelMemberId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("is_screen_sharing_on")]
    public bool? IsScreenSharingOn { get; set; }

    [Column("is_camera_on")]
    public bool? IsCameraOn { get; set; }

    [Column("is_muted")]
    public bool? IsMuted { get; set; }

    [Column("is_deaf")]
    public bool? IsDeaf { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("MailChannelRtcSessions")]
    [NotMapped]
    public virtual MailChannel? Channel { get; set; }

    [ForeignKey("ChannelMemberId")]
    //[InverseProperty("MailChannelRtcSession")]
    [NotMapped]
    public virtual MailChannelMember? ChannelMember { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailChannelRtcSessionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailChannelRtcSessionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("RtcInvitingSession")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMembers { get; } = new List<MailChannelMember>();

}
