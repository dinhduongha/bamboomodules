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
//[Index("AuthorId", Name = "mail_message__author_id_index")]
//[Index("MessageId", Name = "mail_message__message_id_index")]
//[Index("SubtypeId", Name = "mail_message__subtype_id_index")]
//[Index("Model", "ResId", "Id", Name = "mail_message_model_res_id_id_idx")]
//[Index("Model", "ResId", Name = "mail_message_model_res_id_idx")]
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

    [Column("record_alias_domain_id")]
    public Guid? RecordAliasDomainId { get; set; }

    [Column("record_company_id")]
    public Guid? RecordCompanyId { get; set; }

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

    [Column("pinned_at", TypeName = "timestamp without time zone")]
    public DateTime? PinnedAt { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AuthorId")]
    public virtual ResPartner? Author { get; set; }

    // [Many2one]
    [ForeignKey("AuthorGuestId")]
    public virtual MailGuest? AuthorGuest { get; set; }

    // [Many2one]
    public virtual ChatbotMessage? ChatbotMessage { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    public virtual DiscussChannel? DiscussChannel { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("FetchedMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FetchedMessage")] // One2many
    public virtual ICollection<DiscussChannelMember> DiscussChannelMemberFetchedMessage { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SeenMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SeenMessage")] // One2many
    public virtual ICollection<DiscussChannelMember> DiscussChannelMemberSeenMessage { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<MailMessage> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("MailActivityTypeId")]
    public virtual MailActivityType? MailActivityType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailMessage")] // One2many
    public virtual ICollection<MailGroupMessage> MailGroupMessage { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Message")] // One2many
    public virtual ICollection<MailLinkPreview> MailLinkPreview { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailMessage")] // One2many
    public virtual ICollection<MailMail> MailMail { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Message")] // One2many
    public virtual ICollection<MailMessageReaction> MailMessageReaction { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailMessage")] // One2many
    public virtual ICollection<MailMessageSchedule> MailMessageSchedule { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Message")] // One2many
    public virtual ICollection<MailMessageTranslation> MailMessageTranslation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailMessage")] // One2many
    public virtual ICollection<MailNotification> MailNotification { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailMessage")] // One2many
    public virtual ICollection<MailResendMessage> MailResendMessage { get; set; }

    // [Many2one]
    [ForeignKey("MailServerId")]
    public virtual IrMailServer? MailServer { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailMessage")] // One2many
    public virtual ICollection<MailTrackingValue> MailTrackingValue { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    public virtual MailMessage? Parent { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Message")] // One2many
    public virtual ICollection<RatingRating> RatingRating { get; set; }

    // [Many2one]
    [ForeignKey("RecordAliasDomainId")]
    public virtual MailAliasDomain? RecordAliasDomain { get; set; }

    // [Many2one]
    [ForeignKey("RecordCompanyId")]
    public virtual ResCompany? RecordCompany { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailMessage")] // One2many
    public virtual ICollection<SmsResend> SmsResend { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailMessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailMessage")] // One2many
    public virtual ICollection<SmsSms> SmsSms { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Message")] // One2many
    public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MessageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Message")] // One2many
    public virtual ICollection<SnailmailLetterFormatError> SnailmailLetterFormatError { get; set; }

    // [Many2one]
    [ForeignKey("SubtypeId")]
    public virtual MailMessageSubtype? Subtype { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (IrAttachment) is commented out
    // [ForeignKey("MessageId")] // Many2many // Normal
    // [InverseProperty("Message")] // Many2many // Normal
    public virtual ICollection<IrAttachment> Attachment { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("MailMessageId")] // Many2many // Normal
    // [InverseProperty("MailMessageNavigation")] // Many2many // Normal
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // [ForeignKey("MailMessageId")] // Many2many // Normal
    // [InverseProperty("MailMessage1")] // Many2many // Normal
    public virtual ICollection<ResPartner> ResPartnerNavigation { get; set; }
}
