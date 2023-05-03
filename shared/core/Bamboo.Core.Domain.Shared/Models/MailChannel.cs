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

[Table("mail_channel")]
//[Index("Uuid", Name = "mail_channel_uuid_unique", IsUnique = true)]
public partial class MailChannel: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("group_public_id")]
    public Guid? GroupPublicId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("channel_type")]
    public string? ChannelType { get; set; }

    [Column("default_display_mode")]
    public string? DefaultDisplayMode { get; set; }

    [Column("uuid")]
    public string? Uuid { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailChannelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("GroupPublicId")]
    //[InverseProperty("MailChannels")]
    [NotMapped]
    public virtual ResGroup? GroupPublic { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("MailChannels")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailChannelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("VideocallChannel")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; } = new List<CalendarEvent>();

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMembers { get; } = new List<MailChannelMember>();

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<MailChannelRtcSession> MailChannelRtcSessions { get; } = new List<MailChannelRtcSession>();

    [ForeignKey("MailChannelId")]
    //[InverseProperty("MailChannels")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartments { get; } = new List<HrDepartment>();

    [ForeignKey("MailChannelId")]
    //[InverseProperty("MailChannelsNavigation")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroups { get; } = new List<ResGroup>();
}
