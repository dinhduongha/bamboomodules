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

[Table("im_livechat_channel_rule")]
public partial class ImLivechatChannelRule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("auto_popup_timer")]
    public long? AutoPopupTimer { get; set; }

    [Column("chatbot_script_id")]
    public Guid? ChatbotScriptId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("regex_url")]
    public string? RegexUrl { get; set; }

    [Column("action")]
    public string? Action { get; set; }

    [Column("chatbot_only_if_no_operator")]
    public bool? ChatbotOnlyIfNoOperator { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("ImLivechatChannelRules")]
    [NotMapped]
    public virtual ImLivechatChannel? Channel { get; set; }

    [ForeignKey("ChatbotScriptId")]
    //[InverseProperty("ImLivechatChannelRules")]
    [NotMapped]
    public virtual ChatbotScript? ChatbotScript { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ImLivechatChannelRuleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ImLivechatChannelRuleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("Channels")]
    [NotMapped]
    public virtual ICollection<ResCountry> Countries { get; set; } 
}
