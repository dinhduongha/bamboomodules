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

[Table("res_users_settings")]
//[Index("MuteUntilDt", Name = "res_users_settings__mute_until_dt_index")]
//[Index("UserId", Name = "res_users_settings_unique_user_id", IsUnique = true)]
public partial class ResUsersSettings: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("voice_active_duration")]
    public long? VoiceActiveDuration { get; set; }

    [Column("push_to_talk_key")]
    public string? PushToTalkKey { get; set; }

    [Column("channel_notifications")]
    public string? ChannelNotifications { get; set; }

    [Column("is_discuss_sidebar_category_channel_open")]
    public bool? IsDiscussSidebarCategoryChannelOpen { get; set; }

    [Column("is_discuss_sidebar_category_chat_open")]
    public bool? IsDiscussSidebarCategoryChatOpen { get; set; }

    [Column("use_push_to_talk")]
    public bool? UsePushToTalk { get; set; }

    [Column("mute_until_dt", TypeName = "timestamp without time zone")]
    public DateTime? MuteUntilDt { get; set; }

    [Column("calendar_default_privacy")]
    public string? CalendarDefaultPrivacy { get; set; }

    [Column("livechat_username")]
    public string? LivechatUsername { get; set; }

    [Column("google_calendar_rtoken")]
    public string? GoogleCalendarRtoken { get; set; }

    [Column("google_calendar_token")]
    public string? GoogleCalendarToken { get; set; }

    [Column("google_calendar_sync_token")]
    public string? GoogleCalendarSyncToken { get; set; }

    [Column("google_calendar_cal_id")]
    public string? GoogleCalendarCalId { get; set; }

    [Column("google_synchronization_stopped")]
    public bool? GoogleSynchronizationStopped { get; set; }

    [Column("google_calendar_token_validity", TypeName = "timestamp without time zone")]
    public DateTime? GoogleCalendarTokenValidity { get; set; }

    [Column("microsoft_calendar_sync_token")]
    public string? MicrosoftCalendarSyncToken { get; set; }

    [Column("microsoft_synchronization_stopped")]
    public bool? MicrosoftSynchronizationStopped { get; set; }

    [Column("microsoft_last_sync_date", TypeName = "timestamp without time zone")]
    public DateTime? MicrosoftLastSyncDate { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("UserSettingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("UserSetting")] // One2many
    public virtual ICollection<ResUsersSettingsVolumes> ResUsersSettingsVolumes { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ResUsersSettingsId")] // Many2many // Normal
    // [InverseProperty("ResUsersSettings")] // Many2many // Normal
    public virtual ICollection<ResLang> ResLang { get; set; }
}
