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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("VideocallChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("VideocallChannel")] // One2many
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ChatbotCurrentStepId")]
    public virtual ChatbotScriptStep? ChatbotCurrentStep { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DiscussChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DiscussChannel")] // One2many
    public virtual ICollection<ChatbotMessage> ChatbotMessage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<DiscussChannelMember> DiscussChannelMember { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<DiscussChannelRtcSession> DiscussChannelRtcSession { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FromMessageId")]
    public virtual MailMessage? FromMessage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ReportMessageGroupId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ReportMessageGroup")] // One2many
    public virtual ICollection<GamificationChallenge> GamificationChallenge { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GroupPublicId")]
    public virtual ResGroups? GroupPublic { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ParentChannel")] // One2many
    public virtual ICollection<DiscussChannel> InverseParentChannel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LivechatChannelId")]
    public virtual ImLivechatChannel? LivechatChannel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LivechatOperatorId")]
    public virtual ResPartner? LivechatOperator { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LivechatVisitorId")]
    public virtual WebsiteVisitor? LivechatVisitor { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentChannelId")]
    public virtual DiscussChannel? ParentChannel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DiscussChannelId")] // Many2many // Normal
    // [InverseProperty("DiscussChannel")] // Many2many // Normal
    public virtual ICollection<HrDepartment> HrDepartment { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DiscussChannelId")] // Many2many // Normal
    // [InverseProperty("DiscussChannelNavigation")] // Many2many // Normal
    public virtual ICollection<ResGroups> ResGroups { get; set; }
}
