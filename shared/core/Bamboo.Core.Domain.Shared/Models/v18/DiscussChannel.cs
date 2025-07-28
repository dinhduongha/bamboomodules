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

[Table("discuss_channel")]
//[Index("LastInterestDt", Name = "discuss_channel__last_interest_dt_index")]
//[Index("ParentChannelId", Name = "discuss_channel__parent_channel_id_index")]
//[Index("FromMessageId", Name = "discuss_channel_from_message_id_unique", IsUnique = true)]
//[Index("Uuid", Name = "discuss_channel_uuid_unique", IsUnique = true)]
public partial class DiscussChannel: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("parent_channel_id")]
    public Guid? ParentChannelId { get; set; }

    [Column("from_message_id")]
    public Guid? FromMessageId { get; set; }

    [Column("group_public_id")]
    public Guid? GroupPublicId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("channel_type")]
    public string? ChannelType { get; set; }

    [Column("default_display_mode")]
    public string? DefaultDisplayMode { get; set; }

    [Column("sfu_channel_uuid")]
    public string? SfuChannelUuid { get; set; }

    [Column("sfu_server_url")]
    public string? SfuServerUrl { get; set; }

    [Column("uuid")]
    public string? Uuid { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("allow_public_upload")]
    public bool? AllowPublicUpload { get; set; }

    [Column("last_interest_dt", TypeName = "timestamp without time zone")]
    public DateTime? LastInterestDt { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("livechat_channel_id")]
    public Guid? LivechatChannelId { get; set; }

    [Column("livechat_operator_id")]
    public Guid? LivechatOperatorId { get; set; }

    [Column("chatbot_current_step_id")]
    public Guid? ChatbotCurrentStepId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("anonymous_name")]
    public string? AnonymousName { get; set; }

    [Column("livechat_active")]
    public bool? LivechatActive { get; set; }

    [Column("rating_last_value")]
    public double? RatingLastValue { get; set; }

    [Column("livechat_visitor_id")]
    public Guid? LivechatVisitorId { get; set; }

    //[InverseProperty("VideocallChannel")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } 

    [ForeignKey("ChatbotCurrentStepId")]
    //[InverseProperty("DiscussChannels")]
    [NotMapped]
    public virtual ChatbotScriptStep? ChatbotCurrentStep { get; set; }

    //[InverseProperty("DiscussChannel")]
    [NotMapped]
    public virtual ICollection<ChatbotMessage> ChatbotMessages { get; set; } 

    [ForeignKey("CountryId")]
    //[InverseProperty("DiscussChannels")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("DiscussChannelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<DiscussChannelMember> DiscussChannelMembers { get; set; } 

    //[InverseProperty("Channel")]
    [NotMapped]
    public virtual ICollection<DiscussChannelRtcSession> DiscussChannelRtcSessions { get; set; } 

    [ForeignKey("FromMessageId")]
    //[InverseProperty("DiscussChannel")]
    [NotMapped]
    public virtual MailMessage? FromMessage { get; set; }

    //[InverseProperty("ReportMessageGroup")]
    [NotMapped]
    public virtual ICollection<GamificationChallenge> GamificationChallenges { get; set; } 

    [ForeignKey("GroupPublicId")]
    //[InverseProperty("DiscussChannels")]
    [NotMapped]
    public virtual ResGroup? GroupPublic { get; set; }

    //[InverseProperty("ParentChannel")]
    [NotMapped]
    public virtual ICollection<DiscussChannel> InverseParentChannel { get; set; } 

    [ForeignKey("LivechatChannelId")]
    //[InverseProperty("DiscussChannels")]
    [NotMapped]
    public virtual ImLivechatChannel? LivechatChannel { get; set; }

    [ForeignKey("LivechatOperatorId")]
    //[InverseProperty("DiscussChannels")]
    [NotMapped]
    public virtual ResPartner? LivechatOperator { get; set; }

    [ForeignKey("LivechatVisitorId")]
    //[InverseProperty("DiscussChannels")]
    [NotMapped]
    public virtual WebsiteVisitor? LivechatVisitor { get; set; }

    [ForeignKey("ParentChannelId")]
    //[InverseProperty("InverseParentChannel")]
    [NotMapped]
    public virtual DiscussChannel? ParentChannel { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("DiscussChannelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("DiscussChannelId")]
    //[InverseProperty("DiscussChannels")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartments { get; set; } 

    [ForeignKey("DiscussChannelId")]
    //[InverseProperty("DiscussChannelsNavigation")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroups { get; set; } 
}
