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

[Table("chatbot_script_answer")]
public partial class ChatbotScriptAnswer: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("script_step_id")]
    public Guid? ScriptStepId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("redirect_link")]
    public string? RedirectLink { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    //[InverseProperty("UserScriptAnswer")]
    [NotMapped]
    public virtual ICollection<ChatbotMessage> ChatbotMessages { get; set; } = new List<ChatbotMessage>();

    [ForeignKey("CreatorId")]
    //[InverseProperty("ChatbotScriptAnswerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ScriptStepId")]
    //[InverseProperty("ChatbotScriptAnswers")]
    [NotMapped]
    public virtual ChatbotScriptStep? ScriptStep { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ChatbotScriptAnswerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ChatbotScriptAnswerId")]
    //[InverseProperty("ChatbotScriptAnswersNavigation")]
    [NotMapped]
    public virtual ICollection<ChatbotScriptStep> ChatbotScriptSteps { get; set; } = new List<ChatbotScriptStep>();
}
