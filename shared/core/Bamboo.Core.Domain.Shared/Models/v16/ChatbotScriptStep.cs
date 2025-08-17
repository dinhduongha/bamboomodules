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
public partial class ChatbotScriptStep: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("chatbot_script_id")]
    public Guid? ChatbotScriptId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("step_type")]
    public string? StepType { get; set; }

    [JsonField]
    [Column("message", TypeName = "jsonb")]
    public string? Message { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("crm_team_id")]
    public Guid? CrmTeamId { get; set; }

    // [One2many]
    [ForeignKey("ScriptStepId")]
    [InverseProperty("ScriptStep")]
    public virtual ICollection<ChatbotMessage> ChatbotMessage { get; set; }

    // [Many2one]
    [ForeignKey("ChatbotScriptId")]
    // [InverseProperty("ChatbotScriptStep")] //Many2one
    public virtual ChatbotScript? ChatbotScript { get; set; }

    // [One2many]
    [ForeignKey("ScriptStepId")]
    [InverseProperty("ScriptStep")]
    public virtual ICollection<ChatbotScriptAnswer> ChatbotScriptAnswer { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ChatbotScriptStepCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CrmTeamId")]
    // [InverseProperty("ChatbotScriptStep")] //Many2one
    public virtual CrmTeam? CrmTeam { get; set; }

    // [One2many]
    [ForeignKey("ChatbotCurrentStepId")]
    [InverseProperty("ChatbotCurrentStep")]
    public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ChatbotScriptStepWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ChatbotScriptStepId")] //Many2many
    // [InverseProperty("ChatbotScriptStep")] //Many2many
    public virtual ICollection<ChatbotScriptAnswer> ChatbotScriptAnswerNavigation { get; set; }
}
