using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("mail_channel_rtc_session")]
//[Index("ChannelMemberId", Name = "mail_channel_rtc_session_channel_member_unique", IsUnique = true)]
//[Index("WriteDate", Name = "mail_channel_rtc_session_write_date_index")]
public partial class MailChannelRtcSession : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("channel_member_id")]
    public Guid? ChannelMemberId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ChannelId")]
    public virtual MailChannel? Channel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ChannelMemberId")]
    public virtual MailChannelMember? ChannelMember { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RtcInvitingSessionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RtcInvitingSession")] // One2many
    public virtual ICollection<MailChannelMember> MailChannelMember { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
