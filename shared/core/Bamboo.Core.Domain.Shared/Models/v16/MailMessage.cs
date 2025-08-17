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

[Table("mail_message")]
//[Index("AuthorId", Name = "mail_message_author_id_index")]
//[Index("MailActivityTypeId", Name = "mail_message_mail_activity_type_id_index")]
//[Index("MessageId", Name = "mail_message_message_id_index")]
//[Index("Model", "ResId", "Id", Name = "mail_message_model_res_id_id_idx")]
//[Index("Model", "ResId", Name = "mail_message_model_res_id_idx")]
//[Index("SubtypeId", Name = "mail_message_subtype_id_index")]
public partial class MailMessage: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("subtype_id")]
    public Guid? SubtypeId { get; set; }

    [Column("mail_activity_type_id")]
    public Guid? MailActivityTypeId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("author_guest_id")]
    public Guid? AuthorGuestId { get; set; }

    [Column("mail_server_id")]
    public Guid? MailServerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("record_name")]
    public string? RecordName { get; set; }

    [Column("message_type")]
    public string? MessageType { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("message_id")]
    public string? MessageId { get; set; }

    [Column("reply_to")]
    public string? ReplyTo { get; set; }

    [Column("email_layout_xmlid")]
    public string? EmailLayoutXmlid { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("is_internal")]
    public bool? IsInternal { get; set; }

    [Column("reply_to_force_new")]
    public bool? ReplyToForceNew { get; set; }

    [Column("email_add_signature")]
    public bool? EmailAddSignature { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AuthorId")]
    // [InverseProperty("MailMessage")] //Many2one
    public virtual ResPartner? Author { get; set; }

    // [Many2one]
    [ForeignKey("AuthorGuestId")]
    // [InverseProperty("MailMessage")] //Many2one
    public virtual MailGuest? AuthorGuest { get; set; }

    // [Many2one]
    // [InverseProperty("MailMessage")] //Many2one
    public virtual ChatbotMessage? ChatbotMessage { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailMessageCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<MailMessage> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("MailActivityTypeId")]
    // [InverseProperty("MailMessage")] //Many2one
    public virtual MailActivityType? MailActivityType { get; set; }

    // [One2many]
    [ForeignKey("FetchedMessageId")]
    [InverseProperty("FetchedMessage")]
    public virtual ICollection<MailChannelMember> MailChannelMemberFetchedMessage { get; set; }

    // [One2many]
    [ForeignKey("SeenMessageId")]
    [InverseProperty("SeenMessage")]
    public virtual ICollection<MailChannelMember> MailChannelMemberSeenMessage { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many]
    [ForeignKey("MailMessageId")]
    [InverseProperty("MailMessage")]
    public virtual ICollection<MailGroupMessage> MailGroupMessage { get; set; }

    // [One2many]
    [ForeignKey("MessageId")]
    [InverseProperty("Message")]
    public virtual ICollection<MailLinkPreview> MailLinkPreview { get; set; }

    // [One2many]
    [ForeignKey("MailMessageId")]
    [InverseProperty("MailMessage")]
    public virtual ICollection<MailMail> MailMail { get; set; }

    // [One2many]
    [ForeignKey("MessageId")]
    [InverseProperty("Message")]
    public virtual ICollection<MailMessageReaction> MailMessageReaction { get; set; }

    // [One2many]
    [ForeignKey("MailMessageId")]
    [InverseProperty("MailMessage")]
    public virtual ICollection<MailMessageSchedule> MailMessageSchedule { get; set; }

    // [One2many]
    [ForeignKey("MailMessageId")]
    [InverseProperty("MailMessage")]
    public virtual ICollection<MailNotification> MailNotification { get; set; }

    // [One2many]
    [ForeignKey("MailMessageId")]
    [InverseProperty("MailMessage")]
    public virtual ICollection<MailResendMessage> MailResendMessage { get; set; }

    // [Many2one]
    [ForeignKey("MailServerId")]
    // [InverseProperty("MailMessage")] //Many2one
    public virtual IrMailServer? MailServer { get; set; }

    // [One2many]
    [ForeignKey("MailMessageId")]
    [InverseProperty("MailMessage")]
    public virtual ICollection<MailTrackingValue> MailTrackingValue { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual MailMessage? Parent { get; set; }

    // [One2many]
    [ForeignKey("MessageId")]
    [InverseProperty("Message")]
    public virtual ICollection<RatingRating> RatingRating { get; set; }

    // [One2many]
    [ForeignKey("MailMessageId")]
    [InverseProperty("MailMessage")]
    public virtual ICollection<SmsResend> SmsResend { get; set; }

    // [One2many]
    [ForeignKey("MailMessageId")]
    [InverseProperty("MailMessage")]
    public virtual ICollection<SmsSms> SmsSms { get; set; }

    // [One2many]
    [ForeignKey("MessageId")]
    [InverseProperty("Message")]
    public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many]
    [ForeignKey("MessageId")]
    [InverseProperty("Message")]
    public virtual ICollection<SnailmailLetterFormatError> SnailmailLetterFormatError { get; set; }

    // [Many2one]
    [ForeignKey("SubtypeId")]
    // [InverseProperty("MailMessage")] //Many2one
    public virtual MailMessageSubtype? Subtype { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailMessageWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MessageId")] //Many2many
    // [InverseProperty("Message")] //Many2many
    public virtual ICollection<IrAttachment> Attachment { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailMessageId")] //Many2many
    // [InverseProperty("MailMessageNavigation")] //Many2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailMessageId")] //Many2many
    // [InverseProperty("MailMessage1")] //Many2many
    public virtual ICollection<ResPartner> ResPartnerNavigation { get; set; }
}
