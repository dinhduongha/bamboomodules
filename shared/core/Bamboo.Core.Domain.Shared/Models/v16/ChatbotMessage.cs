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

[Table("chatbot_message")]
//[Index("MailMessageId", Name = "chatbot_message__unique_mail_message_id", IsUnique = true)]
public partial class ChatbotMessage: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("discuss_channel_id")]
    public Guid? DiscussChannelId { get; set; }

    [Column("mail_channel_id")]
    public Guid? MailChannelId { get; set; }

    [Column("script_step_id")]
    public Guid? ScriptStepId { get; set; }

    [Column("user_script_answer_id")]
    public Guid? UserScriptAnswerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("user_raw_answer")]
    public string? UserRawAnswer { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ChatbotMessageCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DiscussChannelId")]
    // [InverseProperty("ChatbotMessage")] //Many2one
    public virtual DiscussChannel? DiscussChannel { get; set; }

    // [Many2one]
    [ForeignKey("MailChannelId")]
    // [InverseProperty("ChatbotMessage")] //Many2one
    public virtual MailChannel? MailChannel { get; set; }

    // [Many2one]
    [ForeignKey("MailMessageId")]
    // [InverseProperty("ChatbotMessage")] //Many2one
    public virtual MailMessage? MailMessage { get; set; }

    // [Many2one]
    [ForeignKey("ScriptStepId")]
    // [InverseProperty("ChatbotMessage")] //Many2one
    public virtual ChatbotScriptStep? ScriptStep { get; set; }

    // [Many2one]
    [ForeignKey("UserScriptAnswerId")]
    // [InverseProperty("ChatbotMessage")] //Many2one
    public virtual ChatbotScriptAnswer? UserScriptAnswer { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ChatbotMessageWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
