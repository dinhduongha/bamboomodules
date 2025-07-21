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

[Table("chatbot_script_step")]
public partial class ChatbotScriptStep: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("chatbot_script_id")] 
    public Guid? ChatbotScriptId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("step_type")]
    public string? StepType { get; set; }

    [JsonField]
    [Column("message", TypeName = "jsonb")]
    public string? Message { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("crm_team_id")]
    public Guid? CrmTeamId { get; set; }

    //[InverseProperty("ScriptStep")]
    [NotMapped]
    public virtual ICollection<ChatbotMessage> ChatbotMessages { get; set; } = new List<ChatbotMessage>();

    [ForeignKey("ChatbotScriptId")]
    //[InverseProperty("ChatbotScriptSteps")]
    [NotMapped]
    public virtual ChatbotScript? ChatbotScript { get; set; }

    //[InverseProperty("ScriptStep")]
    [NotMapped]
    public virtual ICollection<ChatbotScriptAnswer> ChatbotScriptAnswers { get; set; } = new List<ChatbotScriptAnswer>();

    [ForeignKey("CreatorId")]
    //[InverseProperty("ChatbotScriptStepCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CrmTeamId")]
    //[InverseProperty("ChatbotScriptSteps")]
    [NotMapped]
    public virtual CrmTeam? CrmTeam { get; set; }

    //[InverseProperty("ChatbotCurrentStep")]
    [NotMapped]
    public virtual ICollection<DiscussChannel> DiscussChannels { get; set; } = new List<DiscussChannel>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ChatbotScriptStepWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ChatbotScriptStepId")]
    //[InverseProperty("ChatbotScriptSteps")]
    [NotMapped]
    public virtual ICollection<ChatbotScriptAnswer> ChatbotScriptAnswersNavigation { get; set; } = new List<ChatbotScriptAnswer>();
}
