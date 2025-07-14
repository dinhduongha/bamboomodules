using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("discuss_channel_id")]
    public Guid? DiscussChannelId { get; set; }

    [Column("script_step_id")]
    public Guid? ScriptStepId { get; set; }

    [Column("user_script_answer_id")]
    public Guid? UserScriptAnswerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("user_raw_answer")]
    public string? UserRawAnswer { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ChatbotMessageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DiscussChannelId")]
    //[InverseProperty("ChatbotMessages")]
    [NotMapped]
    public virtual DiscussChannel? DiscussChannel { get; set; }

    [ForeignKey("MailMessageId")]
    //[InverseProperty("ChatbotMessage")]
    [NotMapped]
    public virtual MailMessage? MailMessage { get; set; }

    [ForeignKey("ScriptStepId")]
    //[InverseProperty("ChatbotMessages")]
    [NotMapped]
    public virtual ChatbotScriptStep? ScriptStep { get; set; }

    [ForeignKey("UserScriptAnswerId")]
    //[InverseProperty("ChatbotMessages")]
    [NotMapped]
    public virtual ChatbotScriptAnswer? UserScriptAnswer { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ChatbotMessageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
