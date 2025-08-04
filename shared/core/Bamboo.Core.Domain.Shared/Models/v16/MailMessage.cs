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
public partial class MailMessage: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("AuthorId")]
    //[InverseProperty("MailMessages")]
    [NotMapped]
    public virtual ResPartner? Author { get; set; }

    [ForeignKey("AuthorGuestId")]
    //[InverseProperty("MailMessages")]
    [NotMapped]
    public virtual MailGuest? AuthorGuest { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailMessageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailActivityTypeId")]
    //[InverseProperty("MailMessages")]
    [NotMapped]
    public virtual MailActivityType? MailActivityType { get; set; }

    [ForeignKey("MailServerId")]
    //[InverseProperty("MailMessages")]
    [NotMapped]
    public virtual IrMailServer? MailServer { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual MailMessage? Parent { get; set; }

    [ForeignKey("SubtypeId")]
    //[InverseProperty("MailMessages")]
    [NotMapped]
    public virtual MailMessageSubtype? Subtype { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailMessageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<MailMessage> InverseParent { get; set; } 

    //[InverseProperty("FetchedMessage")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMemberFetchedMessages { get; set; } 

    //[InverseProperty("SeenMessage")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMemberSeenMessages { get; set; } 

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; set; } 

    //[InverseProperty("Message")]
    [NotMapped]
    public virtual ICollection<MailLinkPreview> MailLinkPreviews { get; set; } 

    //[InverseProperty("MailMessage")]
    [NotMapped]
    public virtual ICollection<MailMail> MailMails { get; set; } 

    //[InverseProperty("Message")]
    [NotMapped]
    public virtual ICollection<MailMessageReaction> MailMessageReactions { get; set; } 

    //[InverseProperty("MailMessage")]
    [NotMapped]
    public virtual ICollection<MailMessageSchedule> MailMessageSchedules { get; set; } 

    //[InverseProperty("MailMessage")]
    [NotMapped]
    public virtual ICollection<MailNotification> MailNotifications { get; set; } 

    //[InverseProperty("MailMessage")]
    [NotMapped]
    public virtual ICollection<MailResendMessage> MailResendMessages { get; set; } 

    //[InverseProperty("MailMessage")]
    [NotMapped]
    public virtual ICollection<MailTrackingValue> MailTrackingValues { get; set; } 

    //[InverseProperty("Message")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatings { get; set; } 

    //[InverseProperty("MailMessage")]
    [NotMapped]
    public virtual ICollection<SmsResend> SmsResends { get; set; } 

    //[InverseProperty("MailMessage")]
    [NotMapped]
    public virtual ICollection<SmsSms> SmsSms { get; set; } 

    //[InverseProperty("Message")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterFormatError> SnailmailLetterFormatErrors { get; set; } 

    //[InverseProperty("Message")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; set; } 

    [ForeignKey("MessageId")]
    //[InverseProperty("Messages")]
    [NotMapped]
    public virtual ICollection<IrAttachment> Attachments { get; set; } 

    //[ForeignKey("MailMessageId")]
    //[InverseProperty("MailMessagesNavigation")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } 

    //[ForeignKey("MailMessageId")]
    //[InverseProperty("MailMessages1")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartnersNavigation { get; set; } 
}
