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

[Table("discuss_channel_member")]
//[Index("GuestId", Name = "discuss_channel_member__guest_id_index")]
//[Index("LastInterestDt", Name = "discuss_channel_member__last_interest_dt_index")]
//[Index("PartnerId", Name = "discuss_channel_member__partner_id_index")]
//[Index("UnpinDt", Name = "discuss_channel_member__unpin_dt_index")]
//[Index("ChannelId", "PartnerId", "SeenMessageId", Name = "discuss_channel_member_seen_message_id_idx")]
public partial class DiscussChannelMember: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("guest_id")]
    public Guid? GuestId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("fetched_message_id")]
    public Guid? FetchedMessageId { get; set; }

    [Column("seen_message_id")]
    public Guid? SeenMessageId { get; set; }

    [Column("new_message_separator")]
    public long? NewMessageSeparator { get; set; }

    [Column("rtc_inviting_session_id")]
    public Guid? RtcInvitingSessionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("custom_channel_name")]
    public string? CustomChannelName { get; set; }

    [Column("fold_state")]
    public string? FoldState { get; set; }

    [Column("custom_notifications")]
    public string? CustomNotifications { get; set; }

    [Column("mute_until_dt", TypeName = "timestamp without time zone")]
    public DateTime? MuteUntilDt { get; set; }

    [Column("unpin_dt", TypeName = "timestamp without time zone")]
    public DateTime? UnpinDt { get; set; }

    [Column("last_interest_dt", TypeName = "timestamp without time zone")]
    public DateTime? LastInterestDt { get; set; }

    [Column("last_seen_dt", TypeName = "timestamp without time zone")]
    public DateTime? LastSeenDt { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ChannelId")]
    public virtual DiscussChannel? Channel { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    public virtual DiscussChannelRtcSession? DiscussChannelRtcSession { get; set; }

    // [Many2one]
    [ForeignKey("FetchedMessageId")]
    public virtual MailMessage? FetchedMessage { get; set; }

    // [Many2one]
    [ForeignKey("GuestId")]
    public virtual MailGuest? Guest { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("RtcInvitingSessionId")]
    public virtual DiscussChannelRtcSession? RtcInvitingSession { get; set; }

    // [Many2one]
    [ForeignKey("SeenMessageId")]
    public virtual MailMessage? SeenMessage { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
