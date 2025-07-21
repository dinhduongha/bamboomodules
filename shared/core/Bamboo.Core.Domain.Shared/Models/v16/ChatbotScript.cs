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

[Table("chatbot_script")]
public partial class ChatbotScript: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("operator_partner_id")]
    public Guid? OperatorPartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("title", TypeName = "jsonb")]
    public string? Title { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    //[InverseProperty("ChatbotScript")]
    [NotMapped]
    public virtual ICollection<ChatbotScriptStep> ChatbotScriptSteps { get; set; } = new List<ChatbotScriptStep>();

    [ForeignKey("CreatorId")]
    //[InverseProperty("ChatbotScriptCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("ChatbotScript")]
    [NotMapped]
    public virtual ICollection<ImLivechatChannelRule> ImLivechatChannelRules { get; set; } = new List<ImLivechatChannelRule>();

    [ForeignKey("OperatorPartnerId")]
    //[InverseProperty("ChatbotScripts")]
    [NotMapped]
    public virtual ResPartner? OperatorPartner { get; set; }

    [ForeignKey("SourceId")]
    //[InverseProperty("ChatbotScripts")]
    [NotMapped]
    public virtual UtmSource? Source { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ChatbotScriptWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
