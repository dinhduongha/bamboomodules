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
public partial class MailChannel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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

    [Column("uuid")]
    public string? Uuid { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

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
    // [One2many] [ForeignKey("VideocallChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("VideocallChannel")] // One2many
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [ForeignKey("ChatbotCurrentStepId")]
    public virtual ChatbotScriptStep? ChatbotCurrentStep { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailChannel")] // One2many
    public virtual ICollection<ChatbotMessage> ChatbotMessage { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ReportMessageGroupId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ReportMessageGroup")] // One2many
    public virtual ICollection<GamificationChallenge> GamificationChallenge { get; set; }

    // [Many2one]
    [ForeignKey("GroupPublicId")]
    public virtual ResGroups? GroupPublic { get; set; }

    // [Many2one]
    [ForeignKey("LivechatChannelId")]
    public virtual ImLivechatChannel? LivechatChannel { get; set; }

    // [Many2one]
    [ForeignKey("LivechatOperatorId")]
    public virtual ResPartner? LivechatOperator { get; set; }

    // [Many2one]
    [ForeignKey("LivechatVisitorId")]
    public virtual WebsiteVisitor? LivechatVisitor { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<MailChannelMember> MailChannelMember { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<MailChannelRtcSession> MailChannelRtcSession { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MailChannelId")] // Many2many // Normal
    // [InverseProperty("MailChannel")] // Many2many // Normal
    public virtual ICollection<HrDepartment> HrDepartment { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MailChannelId")] // Many2many // Normal
    // [InverseProperty("MailChannelNavigation")] // Many2many // Normal
    public virtual ICollection<ResGroups> ResGroups { get; set; }
}
