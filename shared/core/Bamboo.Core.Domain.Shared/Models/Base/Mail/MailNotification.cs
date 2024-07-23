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

[Table("mail_notification")]
//[Index("IsRead", Name = "mail_notification_is_read_index")]
//[Index("MailMailId", Name = "mail_notification_mail_mail_id_index")]
//[Index("MailMessageId", Name = "mail_notification_mail_message_id_index")]
//[Index("NotificationStatus", Name = "mail_notification_notification_status_index")]
//[Index("NotificationType", Name = "mail_notification_notification_type_index")]
//[Index("ResPartnerId", Name = "mail_notification_res_partner_id_index")]
//[Index("ResPartnerId", "IsRead", "NotificationStatus", "MailMessageId", Name = "mail_notification_res_partner_id_is_read_notification_status_ma")]
public partial class MailNotification: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("mail_mail_id")]
    public Guid? MailMailId { get; set; }

    [Column("res_partner_id")]
    public Guid? ResPartnerId { get; set; }

    [Column("notification_type")]
    public string? NotificationType { get; set; }

    [Column("notification_status")]
    public string? NotificationStatus { get; set; }

    [Column("failure_type")]
    public string? FailureType { get; set; }

    [Column("failure_reason")]
    public string? FailureReason { get; set; }

    [Column("is_read")]
    public bool? IsRead { get; set; }

    [Column("read_date", TypeName = "timestamp without time zone")]
    public DateTime? ReadDate { get; set; }

    [Column("sms_id")]
    public Guid? SmsId { get; set; }

    [Column("sms_number")]
    public string? SmsNumber { get; set; }

    [Column("letter_id")]
    public Guid? LetterId { get; set; }

    [ForeignKey("AuthorId")]
    //[InverseProperty("MailNotificationAuthors")]
    [NotMapped]
    public virtual ResPartner? Author { get; set; }

    [ForeignKey("LetterId")]
    //[InverseProperty("MailNotifications")]
    [NotMapped]
    public virtual SnailmailLetter? Letter { get; set; }

    [ForeignKey("MailMailId")]
    //[InverseProperty("MailNotifications")]
    [NotMapped]
    public virtual MailMail? MailMail { get; set; }

    [ForeignKey("MailMessageId")]
    //[InverseProperty("MailNotifications")]
    [NotMapped]
    public virtual MailMessage? MailMessage { get; set; }

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("MailNotificationResPartners")]
    [NotMapped]
    public virtual ResPartner? ResPartner { get; set; }

    [ForeignKey("SmsId")]
    //[InverseProperty("MailNotifications")]
    [NotMapped]
    public virtual SmsSm? Sms { get; set; }

    //[InverseProperty("Notification")]
    [NotMapped]
    public virtual ICollection<SmsResendRecipient> SmsResendRecipients { get; } = new List<SmsResendRecipient>();

    [ForeignKey("MailNotificationId")]
    //[InverseProperty("MailNotifications")]
    [NotMapped]
    public virtual ICollection<MailResendMessage> MailResendMessages { get; } = new List<MailResendMessage>();
}
