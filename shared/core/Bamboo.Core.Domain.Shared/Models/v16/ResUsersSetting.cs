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

[Module("base")]
[Table("res_users_settings")]
//[Index("MuteUntilDt", Name = "res_users_settings__mute_until_dt_index")]
//[Index("UserId", Name = "res_users_settings_unique_user_id", IsUnique = true)]
public partial class ResUsersSetting: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    /// <summary>
    /// Is category livechat open
    /// </summary>
    [Column("is_discuss_sidebar_category_livechat_open")]
    public bool? IsDiscussSidebarCategoryLivechatOpen { get; set; }


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

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResUsersSettingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("ResUsersSettingUser")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResUsersSettingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("UserSetting")]
    [NotMapped]
    public virtual ICollection<ResUsersSettingsVolume> ResUsersSettingsVolumes { get; set; } 

}
