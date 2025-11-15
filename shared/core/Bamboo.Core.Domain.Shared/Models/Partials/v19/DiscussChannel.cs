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

public partial class DiscussChannel
{
    [Column("livechat_lang_id")]
    public Guid? LivechatLangId { get; set; }

    [Column("livechat_agent_requesting_help_history")]
    public Guid? LivechatAgentRequestingHelpHistory { get; set; }

    [Column("livechat_agent_providing_help_history")]
    public Guid? LivechatAgentProvidingHelpHistory { get; set; }

    [Column("rating_last_text")]
    public string? RatingLastText { get; set; }

    [Column("livechat_status")]
    public string? LivechatStatus { get; set; }

    [Column("livechat_outcome")]
    public string? LivechatOutcome { get; set; }

    [Column("livechat_week_day")]
    public string? LivechatWeekDay { get; set; }

    [Column("livechat_failure")]
    public string? LivechatFailure { get; set; }

    [Column("livechat_note")]
    public string? LivechatNote { get; set; }

    [Column("livechat_is_escalated")]
    public bool? LivechatIsEscalated { get; set; }

    [Column("livechat_end_dt", TypeName = "timestamp without time zone")]
    public DateTime? LivechatEndDt { get; set; }

    [Column("livechat_start_hour")]
    public double? LivechatStartHour { get; set; }

    [Column("has_crm_lead")]
    public bool? HasCrmLead { get; set; }

    [Column("is_pending_chat_request")]
    public bool? IsPendingChatRequest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OriginChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OriginChannel")] // One2many
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<DiscussCallHistory> DiscussCallHistory { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<ImLivechatChannelMemberHistory> ImLivechatChannelMemberHistory { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LivechatAgentProvidingHelpHistory")]
    public virtual ImLivechatChannelMemberHistory? LivechatAgentProvidingHelpHistoryNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LivechatAgentRequestingHelpHistory")]
    public virtual ImLivechatChannelMemberHistory? LivechatAgentRequestingHelpHistoryNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LivechatLangId")]
    public virtual ResLang? LivechatLang { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DiscussChannelId")] // Many2many // Normal
    // [InverseProperty("DiscussChannel")] // Many2many // Normal
    public virtual ICollection<ImLivechatConversationTag> ImLivechatConversationTag { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DiscussChannelId")] // Many2many // Normal
    // [InverseProperty("DiscussChannel")] // Many2many // Normal
    public virtual ICollection<ImLivechatExpertise> ImLivechatExpertise { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("DiscussChannelId")] // Many2many // Normal
    // [InverseProperty("DiscussChannelNavigation")] // Many2many // Normal
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("DiscussChannelId")] // Many2many // Normal
    // [InverseProperty("DiscussChannel2")] // Many2many // Normal
    public virtual ICollection<ResPartner> ResPartner1 { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("DiscussChannelId")] // Many2many // Normal
    // [InverseProperty("DiscussChannel1")] // Many2many // Normal
    public virtual ICollection<ResPartner> ResPartnerNavigation { get; set; }
}