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
public partial class DiscussChannel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("parent_channel_id")]
    public Guid? ParentChannelId { get; set; }

    [Column("from_message_id")]
    public Guid? FromMessageId { get; set; }

    [Column("group_public_id")]
    public Guid? GroupPublicId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

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

    // [One2many]
    [ForeignKey("VideocallChannelId")]
    [InverseProperty("VideocallChannel")]
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [ForeignKey("ChatbotCurrentStepId")]
    // [InverseProperty("DiscussChannel")] //Many2one
    public virtual ChatbotScriptStep? ChatbotCurrentStep { get; set; }

    // [One2many]
    [ForeignKey("DiscussChannelId")]
    [InverseProperty("DiscussChannel")]
    public virtual ICollection<ChatbotMessage> ChatbotMessage { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("DiscussChannel")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("DiscussChannelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ChannelId")]
    [InverseProperty("Channel")]
    public virtual ICollection<DiscussChannelMember> DiscussChannelMember { get; set; }

    // [One2many]
    [ForeignKey("ChannelId")]
    [InverseProperty("Channel")]
    public virtual ICollection<DiscussChannelRtcSession> DiscussChannelRtcSession { get; set; }

    // [Many2one]
    [ForeignKey("FromMessageId")]
    // [InverseProperty("DiscussChannel")] //Many2one
    public virtual MailMessage? FromMessage { get; set; }

    // [One2many]
    [ForeignKey("ReportMessageGroupId")]
    [InverseProperty("ReportMessageGroup")]
    public virtual ICollection<GamificationChallenge> GamificationChallenge { get; set; }

    // [Many2one]
    [ForeignKey("GroupPublicId")]
    // [InverseProperty("DiscussChannel")] //Many2one
    public virtual ResGroups? GroupPublic { get; set; }

    // [One2many]
    [ForeignKey("ParentChannelId")]
    [InverseProperty("ParentChannel")]
    public virtual ICollection<DiscussChannel> InverseParentChannel { get; set; }

    // [Many2one]
    [ForeignKey("LivechatChannelId")]
    // [InverseProperty("DiscussChannel")] //Many2one
    public virtual ImLivechatChannel? LivechatChannel { get; set; }

    // [Many2one]
    [ForeignKey("LivechatOperatorId")]
    // [InverseProperty("DiscussChannel")] //Many2one
    public virtual ResPartner? LivechatOperator { get; set; }

    // [Many2one]
    [ForeignKey("LivechatVisitorId")]
    // [InverseProperty("DiscussChannel")] //Many2one
    public virtual WebsiteVisitor? LivechatVisitor { get; set; }

    // [Many2one]
    [ForeignKey("ParentChannelId")]
    // [InverseProperty("InverseParentChannel")] //Many2one
    public virtual DiscussChannel? ParentChannel { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("DiscussChannelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [ForeignKey("DiscussChannelId")] //Many2many
    [InverseProperty("DiscussChannel")] //Many2many
    // [NotMapped] //Many2many // Normal
    public virtual ICollection<HrDepartment> HrDepartment { get; set; }

    // [Many2many] // Normal
    [NotMapped] // [Many2many] // Normal
    // [ForeignKey("DiscussChannelId")] //Many2many
    // [InverseProperty("DiscussChannelNavigation")] //Many2many
    // [NotMapped] //Many2many // Normal
    public virtual ICollection<ResGroups> ResGroups { get; set; }
}
