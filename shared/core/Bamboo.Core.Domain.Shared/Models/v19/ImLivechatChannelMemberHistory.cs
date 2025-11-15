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

[Table("im_livechat_channel_member_history")]
//[Index("ChannelId", Name = "im_livechat_channel_member_history__channel_id_index")]
//[Index("MemberId", Name = "im_livechat_channel_member_history_member_id_unique", IsUnique = true)]
public partial class ImLivechatChannelMemberHistory : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("member_id")]
    public Guid? MemberId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("guest_id")]
    public Guid? GuestId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("chatbot_script_id")]
    public Guid? ChatbotScriptId { get; set; }

    [Column("rating_id")]
    public Guid? RatingId { get; set; }

    [Column("message_count")]
    public long? MessageCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("livechat_member_type")]
    public string? LivechatMemberType { get; set; }

    [Column("help_status")]
    public string? HelpStatus { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("session_duration_hour")]
    public double? SessionDurationHour { get; set; }

    [Column("has_call")]
    public double? HasCall { get; set; }

    [Column("call_duration_hour")]
    public double? CallDurationHour { get; set; }

    [Column("response_time_hour")]
    public double? ResponseTimeHour { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ChannelId")]
    public virtual DiscussChannel? Channel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ChatbotScriptId")]
    public virtual ChatbotScript? ChatbotScript { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LivechatAgentProvidingHelpHistory")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LivechatAgentProvidingHelpHistoryNavigation")] // One2many
    public virtual ICollection<DiscussChannel> DiscussChannelLivechatAgentProvidingHelpHistoryNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LivechatAgentRequestingHelpHistory")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LivechatAgentRequestingHelpHistoryNavigation")] // One2many
    public virtual ICollection<DiscussChannel> DiscussChannelLivechatAgentRequestingHelpHistoryNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GuestId")]
    public virtual MailGuest? Guest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MemberId")]
    public virtual DiscussChannelMember? Member { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RatingId")]
    public virtual RatingRating? Rating { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ImLivechatChannelMemberHistoryId")] //Many2many // Hidden
    // [InverseProperty("ImLivechatChannelMemberHistory")] //Many2many // Hidden
    public virtual ICollection<DiscussCallHistory> DiscussCallHistory { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ImLivechatChannelMemberHistoryId")] // Many2many // Normal
    // [InverseProperty("ImLivechatChannelMemberHistory")] // Many2many // Normal
    public virtual ICollection<ImLivechatExpertise> ImLivechatExpertise { get; set; }
}
