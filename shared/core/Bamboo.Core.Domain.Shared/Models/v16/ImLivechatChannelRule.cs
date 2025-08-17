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

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("auto_popup_timer")]
    public long? AutoPopupTimer { get; set; }

    [Column("chatbot_script_id")]
    public Guid? ChatbotScriptId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("regex_url")]
    public string? RegexUrl { get; set; }

    [Column("action")]
    public string? Action { get; set; }

    [Column("chatbot_only_if_no_operator")]
    public bool? ChatbotOnlyIfNoOperator { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ChannelId")]
    // [InverseProperty("ImLivechatChannelRule")] //Many2one
    public virtual ImLivechatChannel? Channel { get; set; }

    // [Many2one]
    [ForeignKey("ChatbotScriptId")]
    // [InverseProperty("ImLivechatChannelRule")] //Many2one
    public virtual ChatbotScript? ChatbotScript { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ImLivechatChannelRuleCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ImLivechatChannelRuleWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ChannelId")] //Many2many
    // [InverseProperty("Channel")] //Many2many
    public virtual ICollection<ResCountry> Country { get; set; }
}
